using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BLL;
using DTO;

namespace GUI
{
    public partial class QL_TaiKhoan_QTV_GUI : Form
    {
        QuanTriVien_BLL quanTriVien_BLL = new QuanTriVien_BLL();
        public QL_TaiKhoan_QTV_GUI()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormClosing+=QL_TaiKhoan_QTV_GUI_FormClosing;
            this.Load+=QL_TaiKhoan_QTV_GUI_Load;
            btnTimKiem.Click+=BtnTimKiem_Click;
            btnThem.Click+=BtnThem_Click;
            btnXoa.Click+=BtnXoa_Click;
            btnSua.Click+=BtnSua_Click;
            btnTaiLai.Click+=BtnTaiLai_Click;
            dgvQuanTriVien.CellClick+=DgvQuanTriVien_CellClick;
            cbLocChucVu.SelectedIndexChanged+=CbLocChucVu_SelectedIndexChanged;
        }

        private void CbLocChucVu_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedChucVu = cbLocChucVu.SelectedItem?.ToString();

            if (!string.IsNullOrEmpty(selectedChucVu))
            {
                var result = quanTriVien_BLL.LayQuanTriVienTheoChucVu(selectedChucVu);
                dgvQuanTriVien.DataSource = result;
                dgvQuanTriVien.Refresh();
            }
            else
            {
                LoadQTV();
            }
        }

        private void BtnTaiLai_Click(object sender, EventArgs e)
        {
            txtChucVu.Clear();
            txtMatKhauQTV.Clear();
            txtTaiKhoanQTV.Clear();
            txtTenQTV.Clear();
            txtTenQTV.Focus();
            cbLocChucVu.SelectedItem = null;
            LoadQTV();
        }

        private void DgvQuanTriVien_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvQuanTriVien.Rows[e.RowIndex];
                txtTenQTV.Text = row.Cells["TenQTV"].Value.ToString();
                txtTaiKhoanQTV.Text = row.Cells["TaiKhoanQTV"].Value.ToString();
                txtMatKhauQTV.Text = row.Cells["MatKhauQTV"].Value.ToString();
                txtChucVu.Text = row.Cells["MaNhomNguoiDung"].Value.ToString();
            }
        }

        private void BtnSua_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtTenQTV.Text) || string.IsNullOrWhiteSpace(txtTaiKhoanQTV.Text) ||
                    string.IsNullOrWhiteSpace(txtMatKhauQTV.Text) || string.IsNullOrWhiteSpace(txtChucVu.Text))
                {
                    MessageBox.Show("Vui lòng điền đầy đủ thông tin!");
                    return;
                }

                var quanTriVien = new QuanTriVien
                {
                    TaiKhoanQTV = txtTaiKhoanQTV.Text,
                    MatKhauQTV = txtMatKhauQTV.Text,
                    MaNhomNguoiDung = txtChucVu.Text,
                };

                quanTriVien_BLL.SuaQuanTriVien(quanTriVien);
                LoadQTV();
                MessageBox.Show("Cập nhật thông tin thành công!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }

        private void BtnXoa_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtTaiKhoanQTV.Text))
                {
                    MessageBox.Show("Vui lòng chọn tài khoản cần xóa!");
                    return;
                }

                var confirmResult = MessageBox.Show("Bạn có chắc chắn muốn xóa tài khoản này?",
                                                     "Xóa tài khoản",
                                                     MessageBoxButtons.YesNo,
                                                     MessageBoxIcon.Warning);

                if (confirmResult == DialogResult.Yes)
                {
                    quanTriVien_BLL.XoaQuanTriVienTheoTaiKhoan(txtTaiKhoanQTV.Text);
                    LoadQTV();
                    MessageBox.Show("Xóa thành công!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }

        private void BtnThem_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtTenQTV.Text) || string.IsNullOrWhiteSpace(txtTaiKhoanQTV.Text) ||
                    string.IsNullOrWhiteSpace(txtMatKhauQTV.Text) || string.IsNullOrWhiteSpace(txtChucVu.Text))
                {
                    MessageBox.Show("Vui lòng điền đầy đủ thông tin!");
                    return;
                }

                if (quanTriVien_BLL.TaiKhoanQuanTriVienTonTai(txtTaiKhoanQTV.Text))
                {
                    MessageBox.Show("Tài Khoản đã tồn tại!");
                    return;
                }

                var quanTriVien = new QuanTriVien
                {
                    TenQTV = txtTenQTV.Text,
                    TaiKhoanQTV = txtTaiKhoanQTV.Text,
                    MatKhauQTV = txtMatKhauQTV.Text,
                    MaNhomNguoiDung = txtChucVu.Text
                };

                quanTriVien_BLL.ThemQuanTriVien(quanTriVien);
                LoadQTV();
                MessageBox.Show("Thêm tài khoản thành công!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }


        private void BtnTimKiem_Click(object sender, EventArgs e)
        {
            dgvQuanTriVien.DataSource = quanTriVien_BLL.LayQuanTriVienTheoTen(txtTenQTV.Text);
            dgvQuanTriVien.Refresh();
        }

        private void QL_TaiKhoan_QTV_GUI_Load(object sender, EventArgs e)
        {
            // Đặt tiêu điểm vào ô txtTaiKhoanQTV khi form được tải
            txtTaiKhoanQTV.Focus();

            var maNhomNguoiDung = quanTriVien_BLL.LayMaNhomNguoiDungKhongLap();
            if (maNhomNguoiDung != null && maNhomNguoiDung.Count > 0)
            {
                cbLocChucVu.DataSource = maNhomNguoiDung;
                cbLocChucVu.SelectedItem = null;
            }
            else
            {
                MessageBox.Show("Không có dữ liệu chức vụ.");
            }

            LoadQTV();
        }
        private void LoadQTV()
        {
            dgvQuanTriVien.DataSource = quanTriVien_BLL.LayTatCaQuanTriVien();
        }

        private void QL_TaiKhoan_QTV_GUI_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Hide();
            frmMain frmMain = new frmMain();
            frmMain.Show();
        }

        private void cbLocChucVu_SelectedIndexChanged_1(object sender, EventArgs e)
        {

        }
    }
}
