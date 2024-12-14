using BLL;
using CustomControl;
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
    public partial class QL_DonHang_GUI : Form
    {
        DonHang_BLL donHang_BLL = new DonHang_BLL();
        public QL_DonHang_GUI()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormClosing+=QL_DonHang_GUI_FormClosing;
            this.Load+=QL_DonHang_GUI_Load;
            btnThem.Click+=BtnThem_Click;
            btnSua.Click+=BtnSua_Click;
            btnXoa.Click+=BtnXoa_Click;
            btnTimKiem.Click+=BtnTimKiem_Click;
            btnTaiLai.Click+=BtnTaiLai_Click;
            cbLoc.SelectedIndexChanged+=CbLoc_SelectedIndexChanged;
            dgvDonHang.CellClick+=DgvDonHang_CellClick;
        }

        private void CbLoc_SelectedIndexChanged(object sender, EventArgs e)
        {
            int selectedIndex = cbLoc.SelectedIndex;
            if (selectedIndex == -1) return;

            switch (selectedIndex)
            {
                case 0: // Lọc Đã Thanh Toán
                    dgvDonHang.DataSource = donHang_BLL.LayDonHangTheoLoc("Đã Thanh Toán");
                    break;
                case 1: // Lọc Chưa Thanh Toán
                    dgvDonHang.DataSource = donHang_BLL.LayDonHangTheoLoc("Chưa Thanh Toán");
                    break;
                case 2: // Lọc Đã giao hàng
                    dgvDonHang.DataSource = donHang_BLL.LayDonHangTheoLoc(tinhTrangGiaoHang: true);
                    break;
                case 3: // Lọc Chưa giao hàng
                    dgvDonHang.DataSource = donHang_BLL.LayDonHangTheoLoc(tinhTrangGiaoHang: false);
                    break;
                case 4: // Lọc theo ngày đặt hàng hôm nay
                    dgvDonHang.DataSource = donHang_BLL.LayDonHangTheoLoc(Ngay: DateTime.Now.Date);
                    break;
                default:
                    break;
            }
        }

        private void BtnTaiLai_Click(object sender, EventArgs e)
        {
            cbTenKhachHang.SelectedIndex = -1;
            txtMaDonHang.Clear();
            dtpNgayDatHang.Value = DateTime.Now;
            dtpNgayGiaoHang.Value = DateTime.Now;
            chkTinhTrangGiaoHang.Checked = false;
            cbDaThanhToan.SelectedIndex = -1;

            loadDonHang();
        }

        private void DgvDonHang_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvDonHang.Rows[e.RowIndex];

                txtMaDonHang.Text = row.Cells["MaDonHang"].Value.ToString();
                cbTenKhachHang.SelectedValue = row.Cells["MaKhachHang"].Value;
                dtpNgayDatHang.Value = Convert.ToDateTime(row.Cells["NgayDatHang"].Value);
                dtpNgayGiaoHang.Value = Convert.ToDateTime(row.Cells["NgayGiaoHang"].Value);
                chkTinhTrangGiaoHang.Checked = Convert.ToBoolean(row.Cells["TinhTrangGiaoHang"].Value);
                cbDaThanhToan.SelectedItem = row.Cells["DaThanhToan"].Value.ToString();
            }
        }

        private void BtnTimKiem_Click(object sender, EventArgs e)
        {
            string customerName = cbTenKhachHang.Text.Trim();
            if (!string.IsNullOrEmpty(customerName))
            {
                dgvDonHang.DataSource = donHang_BLL.TimKiemDonHangTheoTenKhachHang(customerName);
            }
            else
            {
                MessageBox.Show("Vui lòng nhập tên khách hàng để tìm kiếm.");
            }
        }

        private void BtnXoa_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txtMaDonHang.Text))
                {
                    MessageBox.Show("Vui lòng chọn một đơn hàng để xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var maDonHang = int.Parse(txtMaDonHang.Text);
                donHang_BLL.XoaDonHang(maDonHang);
                BtnTaiLai_Click(sender, e);
                MessageBox.Show("Xóa đơn hàng thành công!");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi xóa đơn hàng: {ex.Message}");
            }
        }

        private void BtnSua_Click(object sender, EventArgs e)
        {
            try
            {
                // Kiểm tra nếu chưa chọn khách hàng
                if (cbTenKhachHang.SelectedValue == null)
                {
                    MessageBox.Show("Vui lòng chọn khách hàng để sửa đơn hàng!");
                    return;
                }

                var donHang = new DonHang
                {
                    MaDonHang = Convert.ToInt32(txtMaDonHang.Text),
                    MaKhachHang = (int)cbTenKhachHang.SelectedValue,
                    NgayDatHang = dtpNgayDatHang.Value,
                    NgayGiaoHang = dtpNgayGiaoHang.Value,
                    DaThanhToan = cbDaThanhToan.SelectedItem.ToString(),
                    TinhTrangGiaoHang = chkTinhTrangGiaoHang.Checked
                };

                donHang_BLL.SuaDonHang(donHang);
                BtnTaiLai_Click(sender, e);
                MessageBox.Show("Sửa đơn hàng thành công!");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi sửa đơn hàng: {ex.Message}");
            }
        }

        private void BtnThem_Click(object sender, EventArgs e)
        {
            try
            {
                if (cbTenKhachHang.SelectedValue == null)
                {
                    MessageBox.Show("Vui lòng chọn khách hàng để thêm đơn hàng!");
                    return;
                }

                var donHang = new DonHang
                {
                    MaKhachHang = (int)cbTenKhachHang.SelectedValue,
                    NgayDatHang = dtpNgayDatHang.Value,
                    NgayGiaoHang = dtpNgayGiaoHang.Value,
                    DaThanhToan = cbDaThanhToan.SelectedItem.ToString(),
                    TinhTrangGiaoHang = chkTinhTrangGiaoHang.Checked
                };

                donHang_BLL.ThemDonHang(donHang);
                BtnTaiLai_Click(sender, e);
                MessageBox.Show("Thêm đơn hàng thành công!");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi thêm đơn hàng: {ex.Message}");
            }
        }

        private void QL_DonHang_GUI_Load(object sender, EventArgs e)
        {
            loadDonHang();

            cbDaThanhToan.Items.AddRange(new[] { "Đã Thanh Toán", "Chưa Thanh Toán" });
            cbDaThanhToan.SelectedIndex = -1;

            cbLoc.Items.AddRange(new[]
            {
                "Đã thanh toán",
                "Chưa thanh toán",
                "Đã giao hàng",
                "Chưa giao hàng",
                "Theo ngày đặt hàng hôm nay"
            });
            cbLoc.SelectedIndex = -1;
        }

        private void QL_DonHang_GUI_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Hide();
            frmMain frmMain = new frmMain();
            frmMain.Show();
        }
        private void loadDonHang()
        {
            dgvDonHang.DataSource = donHang_BLL.LayTatCaDonHang();

            cbTenKhachHang.DataSource = donHang_BLL.LayTatCaKhachHang();
            cbTenKhachHang.DisplayMember = "TenKhachHang";
            cbTenKhachHang.ValueMember = "MaKhachHang";
        }
    }
}
