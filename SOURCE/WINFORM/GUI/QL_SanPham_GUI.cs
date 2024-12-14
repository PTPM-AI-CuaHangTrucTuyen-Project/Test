using BLL;
using DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI
{
    public partial class QL_SanPham_GUI : Form
    {
        Hoa_BLL hoa_BLL = new Hoa_BLL();
        public QL_SanPham_GUI()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormClosing+=QL_SanPham_GUI_FormClosing;
            this.Load+=QL_SanPham_GUI_Load;
            btnThem.Click+=BtnThem_Click;
            btnTaiLai.Click+=BtnTaiLai_Click;
            btnXoa.Click+=BtnXoa_Click;
            btnSua.Click+=BtnSua_Click;
            btnTimKiem.Click+=BtnTimKiem_Click;
            cmbSortOptions.SelectedIndexChanged+=CmbSortOptions_SelectedIndexChanged;
            cbLocTheoLoai.SelectedIndexChanged+=CbLocTheoLoai_SelectedIndexChanged;
            dgvSanPham.CellClick+=DgvSanPham_CellClick;
        }

        private void DgvSanPham_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0) // Kiểm tra nếu chỉ số dòng hợp lệ
            {
                try
                {
                    // Lấy dòng đã chọn
                    DataGridViewRow selectedRow = dgvSanPham.Rows[e.RowIndex];

                    // Cập nhật các giá trị từ DataGridView vào các điều khiển khác, ví dụ như TextBox và DateTimePicker
                    txtTenSanPham.Text = selectedRow.Cells["TenSanPham"].Value?.ToString() ?? string.Empty;
                    txtHinhAnh.Text = selectedRow.Cells["HinhAnh"].Value?.ToString() ?? string.Empty;
                    txtMoTa.Text = selectedRow.Cells["MoTa"].Value?.ToString() ?? string.Empty;
                    txtGia.Text = selectedRow.Cells["Gia"].Value?.ToString() ?? string.Empty;
                    txtDonVi.Text = selectedRow.Cells["DonVi"].Value?.ToString() ?? string.Empty;
                    txtSoLuong.Text = selectedRow.Cells["SoLuong"].Value?.ToString() ?? string.Empty;
                    txtMaLoai.Text = selectedRow.Cells["MaLoai"].Value?.ToString() ?? string.Empty;

                    // Cập nhật DateTimePicker với giá trị từ DataGridView
                    if (selectedRow.Cells["HanSuDung"].Value != DBNull.Value)
                    {
                        DateTime hanSuDung;
                        if (DateTime.TryParse(selectedRow.Cells["HanSuDung"].Value.ToString(), out hanSuDung))
                        {
                            dtpHanSuDung.Value = hanSuDung; // Gán giá trị vào DateTimePicker
                        }
                        else
                        {
                            dtpHanSuDung.Value = DateTime.Now; // Nếu không thể chuyển đổi, đặt giá trị mặc định là ngày hiện tại
                        }
                    }
                    else
                    {
                        dtpHanSuDung.Value = DateTime.Now; // Nếu không có giá trị, đặt giá trị mặc định là ngày hiện tại
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi lấy dữ liệu: " + ex.Message);
                }
            }
        }

        private void CbLocTheoLoai_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbLocTheoLoai.SelectedValue != null)
            {
                try
                {
                    // Lọc sản phẩm theo mã loại
                    if (int.TryParse(cbLocTheoLoai.SelectedValue?.ToString(), out int maLoai))
                    {
                        var danhSachSanPham = hoa_BLL.LocHoaTheoLoai(maLoai);
                        dgvSanPham.DataSource = danhSachSanPham;
                        dgvSanPham.Refresh();
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi lọc sản phẩm: " + ex.Message);
                }
            }
            else
            {
                // Nếu chưa chọn loại, hiển thị tất cả sản phẩm
                try
                {
                    var danhSachSanPham = hoa_BLL.LayTatCaHoa();
                    dgvSanPham.DataSource = danhSachSanPham;
                    dgvSanPham.Refresh();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi tải tất cả sản phẩm: " + ex.Message);
                }
            }
        }

        private void BtnTimKiem_Click(object sender, EventArgs e)
        {
            dgvSanPham.DataSource = hoa_BLL.TimKiemHoa(txtTenSanPham.Text);
            dgvSanPham.Refresh();
        }

        private void BtnSua_Click(object sender, EventArgs e)
        {
            try
            {
                var hoa = new Hoa
                {
                    TenSanPham = txtTenSanPham.Text,
                    HinhAnh = txtHinhAnh.Text,
                    MoTa = txtMoTa.Text,
                    Gia = decimal.Parse(txtGia.Text),
                    DonVi = txtDonVi.Text,
                    SoLuong = int.Parse(txtSoLuong.Text),
                    HanSuDung = dtpHanSuDung.Value,
                    MaLoai = int.Parse(txtMaLoai.Text)
                };
                hoa_BLL.SuaHoa(hoa);
                MessageBox.Show("Sửa sản phẩm thành công!");
                BtnTaiLai_Click(sender, e);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi sửa sản phẩm: " + ex.Message);
            }
        }

        private void CmbSortOptions_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                switch (cmbSortOptions.SelectedIndex)
                {
                    case 0: // "Sắp xếp theo tên (A-Z)"
                        dgvSanPham.DataSource = hoa_BLL.SapXepTheoTenTangDan();
                        break;
                    case 1: // "Sắp xếp theo tên (Z-A)"
                        dgvSanPham.DataSource = hoa_BLL.SapXepTheoTenGiamDan();
                        break;
                    case 2: // "Sắp xếp theo giá (Tăng dần)"
                        dgvSanPham.DataSource = hoa_BLL.SapXepTheoGiaTangDan();
                        break;
                    case 3: // "Sắp xếp theo giá (Giảm dần)"
                        dgvSanPham.DataSource = hoa_BLL.SapXepTheoGiaGiamDan();
                        break;
                }
                dgvSanPham.Refresh();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi sắp xếp sản phẩm: " + ex.Message);
            }
        }

        private void BtnXoa_Click(object sender, EventArgs e)
        {
            try
            {
                string tenHoa = txtTenSanPham.Text;
                hoa_BLL.XoaHoa(tenHoa);
                MessageBox.Show("Xóa sản phẩm thành công!");
                BtnTaiLai_Click(sender, e);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi xóa sản phẩm: " + ex.Message);
            }
        }

        private void BtnTaiLai_Click(object sender, EventArgs e)
        {
            try
            {
                dgvSanPham.DataSource = hoa_BLL.LayTatCaHoa();
                cbLocTheoLoai.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải lại dữ liệu: " + ex.Message);
            }
        }

        private void BtnThem_Click(object sender, EventArgs e)
        {
            try
            {
                var hoa = new Hoa
                {
                    TenSanPham = txtTenSanPham.Text,
                    HinhAnh = txtHinhAnh.Text,
                    MoTa = txtMoTa.Text,
                    Gia = decimal.Parse(txtGia.Text),
                    DonVi = txtDonVi.Text,
                    SoLuong = int.Parse(txtSoLuong.Text),
                    HanSuDung = dtpHanSuDung.Value,
                    MaLoai = int.Parse(txtMaLoai.Text)
                };
                hoa_BLL.ThemHoa(hoa);
                MessageBox.Show("Thêm sản phẩm thành công!");
                BtnTaiLai_Click(sender, e);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi thêm sản phẩm: " + ex.Message);
            }
        }

        private void QL_SanPham_GUI_Load(object sender, EventArgs e)
        {
            try
            {
                var loaiSanPhamList = hoa_BLL.LocLoaiSanPham();
                cbLocTheoLoai.DataSource = loaiSanPhamList;
                cbLocTheoLoai.DisplayMember = "TenLoai";
                cbLocTheoLoai.ValueMember = "MaLoai";
                cbLocTheoLoai.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi nạp loại sản phẩm: " + ex.Message);
            }

            cmbSortOptions.Items.Add("Sắp xếp theo tên (A-Z)");
            cmbSortOptions.Items.Add("Sắp xếp theo tên (Z-A)");
            cmbSortOptions.Items.Add("Sắp xếp theo giá (Tăng dần)");
            cmbSortOptions.Items.Add("Sắp xếp theo giá (Giảm dần)");
            cmbSortOptions.SelectedIndex = 0;
        }

        private void QL_SanPham_GUI_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Hide();
            frmMain frmMain = new frmMain();
            frmMain.Show();
        }

    }
}
