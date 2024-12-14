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
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormClosing+=FrmMain_FormClosing;
        }
        private void FrmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult traloi = MessageBox.Show("Bạn có muốn thoát tài khoản ?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (traloi == DialogResult.OK)
            {
                DangNhap_GUI dangNhap_GUI = new DangNhap_GUI();
                dangNhap_GUI.Show();
                this.Hide();
            }
            else
            {
                e.Cancel = true;
            }
        }

        private void menuItem5_Click(object sender, EventArgs e)
        {
            QL_TaiKhoan_QTV_GUI qL_TaiKhoan_QTV_ = new QL_TaiKhoan_QTV_GUI();
            this.Hide();
            qL_TaiKhoan_QTV_.Show();
        }

        private void menuItem15_Click(object sender, EventArgs e)
        {
            QL_SanPham_GUI qL_SanPham_ = new QL_SanPham_GUI();
            this .Hide();
            qL_SanPham_.Show();
        }

        private void menuItem21_Click(object sender, EventArgs e)
        {
            //Đánh Giá
        }

        private void menuItem13_Click(object sender, EventArgs e)
        {
            QL_KhachHang_GUI qL_KhachHang_ = new QL_KhachHang_GUI();
            this.Hide();
            qL_KhachHang_.Show();
        }

        private void menuItem20_Click(object sender, EventArgs e)
        {
            QL_DonHang_GUI qL_DonHang_ = new QL_DonHang_GUI();
            this.Hide();
            qL_DonHang_.Show();
        }

        private void menuItem4_Click(object sender, EventArgs e)
        {
            //Khuyến Mãi
        }

        private void menuItem12_Click(object sender, EventArgs e)
        {
            //Thống kê
        }

        private void menuItem22_Click(object sender, EventArgs e)
        {
            //Tích Điểm
        }

        private void menuItem16_Click(object sender, EventArgs e)
        {
            //Loại Sản Phẩm
        }

        private void menuItem17_Click(object sender, EventArgs e)
        {
            //Nhà Cung Cấp
        }
    }
}
