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
    public partial class QL_KhachHang_GUI : Form
    {
        KhachHang_BLL khachHangBLL = new KhachHang_BLL();
        public QL_KhachHang_GUI()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormClosing+=QL_KhachHang_GUI_FormClosing;
            this.Load +=QL_KhachHang_GUI_Load;
            btnTimKiem.Click +=BtnTimKiem_Click;
            btnXoa.Click+=BtnXoa_Click;
            btnThem.Click+=BtnThem_Click;
            btnSua.Click+=BtnSua_Click;
            btnTaiLai.Click+=BtnTaiLai_Click;
            dgvKhachHang.CellClick+=DgvKhachHang_CellClick;

        }

        private void DgvKhachHang_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvKhachHang.Rows[e.RowIndex];
                txtTenKhachHang.Text = row.Cells["TenKhachHang"].Value.ToString();
                txtEmail.Text = row.Cells["Email"].Value.ToString();
                txtSoDienThoai.Text = row.Cells["SoDienThoai"].Value.ToString();
                txtDiaChi.Text = row.Cells["DiaChi"].Value.ToString();
                dtpNgaySinh.Value = Convert.ToDateTime(row.Cells["NgaySinh"].Value);
                txtTaiKhoan.Text = row.Cells["TaiKhoan"].Value.ToString();
                txtMatKhau.Text = row.Cells["MatKhau"].Value.ToString();
                txtGioiTinh.Text = row.Cells["GioiTinh"].Value.ToString();
            }
        }

        private void BtnTaiLai_Click(object sender, EventArgs e)
        {
            txtTenKhachHang.Clear();
            txtEmail.Clear();
            txtSoDienThoai.Clear();
            txtDiaChi.Clear();
            dtpNgaySinh.Value = DateTime.Now;
            txtTaiKhoan.Clear();
            txtMatKhau.Clear();
            txtGioiTinh.Clear();
            txtTenKhachHang.Focus();
            LoadKhachHang();
        }

        private void BtnSua_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtTenKhachHang.Text) || string.IsNullOrWhiteSpace(txtEmail.Text) ||
                    string.IsNullOrWhiteSpace(txtSoDienThoai.Text) || string.IsNullOrWhiteSpace(txtDiaChi.Text))
                {
                    MessageBox.Show("Vui lòng điền đầy đủ thông tin!");
                    return;
                }

                var khachHang = new KhachHang
                {
                    TenKhachHang = txtTenKhachHang.Text,
                    Email = txtEmail.Text,
                    SoDienThoai = txtSoDienThoai.Text,
                    DiaChi = txtDiaChi.Text,
                    // Lấy giá trị ngày sinh từ DateTimePicker
                    NgaySinh = dtpNgaySinh.Value,
                    TaiKhoan = txtTaiKhoan.Text,
                    MatKhau = txtMatKhau.Text,
                    GioiTinh = txtGioiTinh.Text
                };

                khachHangBLL.SuaKhachHangTheoTaiKhoan(khachHang);
                LoadKhachHang();
                MessageBox.Show("Sửa khách hàng thành công!");
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
                if (string.IsNullOrWhiteSpace(txtTenKhachHang.Text) || string.IsNullOrWhiteSpace(txtEmail.Text) ||
                    string.IsNullOrWhiteSpace(txtSoDienThoai.Text) || string.IsNullOrWhiteSpace(txtDiaChi.Text))
                {
                    MessageBox.Show("Vui lòng điền đầy đủ thông tin!");
                    return;
                }
                if (khachHangBLL.SoDienThoaiHopLe(txtSoDienThoai.Text))
                {
                    MessageBox.Show("Số điện thoại này đã tồn tại trong hệ thống. Vui lòng nhập số điện thoại khác.");
                    return;
                }
                if (khachHangBLL.EmailHopLe(txtEmail.Text))
                {
                    MessageBox.Show("Email này đã tồn tại trong hệ thống. Vui lòng nhập Email khác.");
                    return;
                }

                var khachHang = new KhachHang
                {
                    TenKhachHang = txtTenKhachHang.Text,
                    Email = txtEmail.Text,
                    SoDienThoai = txtSoDienThoai.Text,
                    DiaChi = txtDiaChi.Text,
                    // Lấy giá trị ngày sinh từ DateTimePicker
                    NgaySinh = dtpNgaySinh.Value,
                    TaiKhoan = txtTaiKhoan.Text,
                    MatKhau = txtMatKhau.Text,
                    GioiTinh = txtGioiTinh.Text
                };

                khachHangBLL.ThemKhachHang(khachHang);
                LoadKhachHang();
                MessageBox.Show("Thêm khách hàng thành công!");
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
                if (string.IsNullOrWhiteSpace(txtTenKhachHang.Text))
                {
                    MessageBox.Show("Vui lòng nhập thông tin khách hàng cần xóa!");
                    return;
                }

                var confirmResult = MessageBox.Show("Bạn có chắc chắn muốn xóa khách hàng này?", "Xóa khách hàng", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (confirmResult == DialogResult.Yes)
                {
                    khachHangBLL.XoaKhachHangTheoTaiKhoan(txtTaiKhoan.Text);
                    LoadKhachHang();
                    MessageBox.Show("Xóa thành công!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }

        private void BtnTimKiem_Click(object sender, EventArgs e)
        {
            // Lấy giá trị từ các ô nhập liệu
            string taiKhoan = txtTaiKhoan.Text.Trim();
            string soDienThoai = txtSoDienThoai.Text.Trim();
            string email = txtEmail.Text.Trim();
            string tenKhachHang = txtTenKhachHang.Text.Trim();

            // Kiểm tra nếu tất cả các ô đều rỗng
            if (string.IsNullOrEmpty(taiKhoan) && string.IsNullOrEmpty(soDienThoai) &&
                string.IsNullOrEmpty(email) && string.IsNullOrEmpty(tenKhachHang))
            {
                MessageBox.Show("Vui lòng nhập ít nhất một thông tin để tìm kiếm!");
                return;
            }

            // Tìm kiếm theo tài khoản nếu có
            if (!string.IsNullOrEmpty(taiKhoan))
            {
                var danhSachKhachHang = khachHangBLL.TimKiemKhachHangTheoTaiKhoan(taiKhoan);
                dgvKhachHang.DataSource = danhSachKhachHang;
                dgvKhachHang.Refresh();
            }
            // Tìm kiếm theo số điện thoại nếu có
            else if (!string.IsNullOrEmpty(soDienThoai))
            {
                var danhSachKhachHang = khachHangBLL.TimKiemKhachHangTheoSoDienThoai(soDienThoai);
                dgvKhachHang.DataSource = danhSachKhachHang;
                dgvKhachHang.Refresh();
            }
            // Tìm kiếm theo email nếu có
            else if (!string.IsNullOrEmpty(email))
            {
                var danhSachKhachHang = khachHangBLL.TimKiemKhachHangTheoEmail(email);
                dgvKhachHang.DataSource = danhSachKhachHang;
                dgvKhachHang.Refresh();
            }
            // Tìm kiếm theo tên khách hàng nếu có
            else if (!string.IsNullOrEmpty(tenKhachHang))
            {
                var danhSachKhachHang = khachHangBLL.TimKiemKhachHangTheoTen(tenKhachHang);
                dgvKhachHang.DataSource = danhSachKhachHang;
                dgvKhachHang.Refresh();
            }
        }

        private void QL_KhachHang_GUI_Load(object sender, EventArgs e)
        {
            txtTenKhachHang.Focus();
            LoadKhachHang();
        }

        private void QL_KhachHang_GUI_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Hide();
            frmMain frmMain = new frmMain();
            frmMain.Show();
        }
        private void LoadKhachHang()
        {
            dgvKhachHang.DataSource = khachHangBLL.LayTatCaKhachHang();
        }
    }
}
