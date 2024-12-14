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
using CustomControl;
using DTO;

namespace GUI
{
    public partial class DangNhap_GUI : Form
    {
        QuanTriVien_BLL quanTriVienBLL = new QuanTriVien_BLL();
        KhachHang_BLL khachHangBLL = new KhachHang_BLL();
        public DangNhap_GUI()
        {
            InitializeComponent();
            
            this.StartPosition = FormStartPosition.CenterScreen;
            buttonDangNhap.Click+=ButtonDangNhap_Click;
            this.Shown+=DangNhap_GUI_Shown;
            this.FormClosing+=DangNhap_GUI_FormClosing;
            textBoxTaiKhoan.KeyDown+=TextBoxTaiKhoan_KeyDown;
            txtPassMatKhau.KeyDown+=TxtPassMatKhau_KeyDown;
        }

        private void DangNhap_GUI_Shown(object sender, EventArgs e)
        {
            textBoxTaiKhoan.Focus();
        }

        private void TxtPassMatKhau_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                buttonDangNhap.Focus();
            }
        }

        private void TextBoxTaiKhoan_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtPassMatKhau.Focus();
            }
        }

        private void DangNhap_GUI_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult traloi = MessageBox.Show("Bạn có muốn thoát?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (traloi == DialogResult.OK)
            {
                Application.ExitThread();
            }
            else
            {
                e.Cancel = true;
            }
        }

        private void ButtonDangNhap_Click(object sender, EventArgs e)
        {
            string taiKhoan = textBoxTaiKhoan.Text;
            string matKhau = txtPassMatKhau.Text;

            // Kiểm tra đăng nhập cho quản trị viên và khách hàng
            var kiemTraQuantrivien = quanTriVienBLL.DangNhap(taiKhoan, matKhau);

            string ten = string.Empty;

            // Kiểm tra nếu tài khoản quản trị viên hợp lệ
            if (kiemTraQuantrivien != null)
            {
                ten = quanTriVienBLL.LayTenQuanTriVienTheoTaiKhoan(taiKhoan); // Lấy tên quản trị viên
            }

            // Nếu tài khoản hợp lệ (quản trị viên hoặc khách hàng)
            if (!string.IsNullOrEmpty(ten))
            {
                this.Hide();
                // Nếu là quản trị viên hoặc khách hàng, hiển thị form tương ứng
                frmMain frmMain = new frmMain();
                frmMain.Show();
            }
            else
            {
                // Nếu tài khoản hoặc mật khẩu không đúng
                MessageBox.Show("Tài khoản hoặc mật khẩu không đúng", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
