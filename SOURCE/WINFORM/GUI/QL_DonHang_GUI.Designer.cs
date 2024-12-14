namespace GUI
{
    partial class QL_DonHang_GUI
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dgvDonHang = new System.Windows.Forms.DataGridView();
            this.dtpNgayDatHang = new System.Windows.Forms.DateTimePicker();
            this.dtpNgayGiaoHang = new System.Windows.Forms.DateTimePicker();
            this.cbDaThanhToan = new System.Windows.Forms.ComboBox();
            this.chkTinhTrangGiaoHang = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.btnSua = new System.Windows.Forms.Button();
            this.btnXoa = new System.Windows.Forms.Button();
            this.btnThem = new System.Windows.Forms.Button();
            this.btnTimKiem = new System.Windows.Forms.Button();
            this.btnTaiLai = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.txtMaDonHang = new System.Windows.Forms.TextBox();
            this.cbTenKhachHang = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.cbLoc = new System.Windows.Forms.ComboBox();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDonHang)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dgvDonHang);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBox1.Location = new System.Drawing.Point(0, 299);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(996, 206);
            this.groupBox1.TabIndex = 17;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Thông Tin Đơn Hàng";
            // 
            // dgvDonHang
            // 
            this.dgvDonHang.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvDonHang.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDonHang.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvDonHang.Location = new System.Drawing.Point(3, 18);
            this.dgvDonHang.Name = "dgvDonHang";
            this.dgvDonHang.ReadOnly = true;
            this.dgvDonHang.RowHeadersWidth = 51;
            this.dgvDonHang.RowTemplate.Height = 24;
            this.dgvDonHang.Size = new System.Drawing.Size(990, 185);
            this.dgvDonHang.TabIndex = 0;
            // 
            // dtpNgayDatHang
            // 
            this.dtpNgayDatHang.Location = new System.Drawing.Point(255, 95);
            this.dtpNgayDatHang.Name = "dtpNgayDatHang";
            this.dtpNgayDatHang.Size = new System.Drawing.Size(200, 22);
            this.dtpNgayDatHang.TabIndex = 19;
            // 
            // dtpNgayGiaoHang
            // 
            this.dtpNgayGiaoHang.Location = new System.Drawing.Point(255, 149);
            this.dtpNgayGiaoHang.Name = "dtpNgayGiaoHang";
            this.dtpNgayGiaoHang.Size = new System.Drawing.Size(200, 22);
            this.dtpNgayGiaoHang.TabIndex = 20;
            // 
            // cbDaThanhToan
            // 
            this.cbDaThanhToan.FormattingEnabled = true;
            this.cbDaThanhToan.Location = new System.Drawing.Point(25, 97);
            this.cbDaThanhToan.Name = "cbDaThanhToan";
            this.cbDaThanhToan.Size = new System.Drawing.Size(200, 24);
            this.cbDaThanhToan.TabIndex = 21;
            // 
            // chkTinhTrangGiaoHang
            // 
            this.chkTinhTrangGiaoHang.AutoSize = true;
            this.chkTinhTrangGiaoHang.Location = new System.Drawing.Point(25, 149);
            this.chkTinhTrangGiaoHang.Name = "chkTinhTrangGiaoHang";
            this.chkTinhTrangGiaoHang.Size = new System.Drawing.Size(162, 20);
            this.chkTinhTrangGiaoHang.TabIndex = 22;
            this.chkTinhTrangGiaoHang.Text = "Tình Trạng Giao Hàng";
            this.chkTinhTrangGiaoHang.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(22, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 16);
            this.label1.TabIndex = 23;
            this.label1.Text = "Khách Hàng";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(252, 76);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 16);
            this.label2.TabIndex = 24;
            this.label2.Text = "Ngày Đặt";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(252, 130);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(72, 16);
            this.label3.TabIndex = 25;
            this.label3.Text = "Ngày Giao";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(22, 78);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(148, 16);
            this.label4.TabIndex = 26;
            this.label4.Text = "Tình Trạng Thanh Toán";
            // 
            // btnSua
            // 
            this.btnSua.AutoSize = true;
            this.btnSua.Location = new System.Drawing.Point(421, 194);
            this.btnSua.Name = "btnSua";
            this.btnSua.Size = new System.Drawing.Size(75, 26);
            this.btnSua.TabIndex = 30;
            this.btnSua.Text = "Sửa";
            this.btnSua.UseVisualStyleBackColor = true;
            // 
            // btnXoa
            // 
            this.btnXoa.AutoSize = true;
            this.btnXoa.Location = new System.Drawing.Point(313, 194);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(75, 26);
            this.btnXoa.TabIndex = 29;
            this.btnXoa.Text = "Xóa";
            this.btnXoa.UseVisualStyleBackColor = true;
            // 
            // btnThem
            // 
            this.btnThem.AutoSize = true;
            this.btnThem.Location = new System.Drawing.Point(202, 194);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(75, 26);
            this.btnThem.TabIndex = 28;
            this.btnThem.Text = "Thêm";
            this.btnThem.UseVisualStyleBackColor = true;
            // 
            // btnTimKiem
            // 
            this.btnTimKiem.AutoSize = true;
            this.btnTimKiem.Location = new System.Drawing.Point(25, 194);
            this.btnTimKiem.Name = "btnTimKiem";
            this.btnTimKiem.Size = new System.Drawing.Size(135, 26);
            this.btnTimKiem.TabIndex = 27;
            this.btnTimKiem.Text = "Tìm Kiếm Theo Tên";
            this.btnTimKiem.UseVisualStyleBackColor = true;
            // 
            // btnTaiLai
            // 
            this.btnTaiLai.Location = new System.Drawing.Point(12, 270);
            this.btnTaiLai.Name = "btnTaiLai";
            this.btnTaiLai.Size = new System.Drawing.Size(75, 23);
            this.btnTaiLai.TabIndex = 22;
            this.btnTaiLai.Text = "Tải Lại Bảng";
            this.btnTaiLai.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(252, 20);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(67, 16);
            this.label5.TabIndex = 31;
            this.label5.Text = "Đơn Hàng";
            // 
            // txtMaDonHang
            // 
            this.txtMaDonHang.Enabled = false;
            this.txtMaDonHang.Location = new System.Drawing.Point(255, 39);
            this.txtMaDonHang.Name = "txtMaDonHang";
            this.txtMaDonHang.Size = new System.Drawing.Size(100, 22);
            this.txtMaDonHang.TabIndex = 32;
            // 
            // cbTenKhachHang
            // 
            this.cbTenKhachHang.FormattingEnabled = true;
            this.cbTenKhachHang.Location = new System.Drawing.Point(25, 39);
            this.cbTenKhachHang.Name = "cbTenKhachHang";
            this.cbTenKhachHang.Size = new System.Drawing.Size(200, 24);
            this.cbTenKhachHang.TabIndex = 33;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(749, 273);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(29, 16);
            this.label6.TabIndex = 34;
            this.label6.Text = "Lọc";
            // 
            // cbLoc
            // 
            this.cbLoc.FormattingEnabled = true;
            this.cbLoc.Location = new System.Drawing.Point(784, 270);
            this.cbLoc.Name = "cbLoc";
            this.cbLoc.Size = new System.Drawing.Size(200, 24);
            this.cbLoc.TabIndex = 35;
            // 
            // QL_DonHang_GUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(996, 505);
            this.Controls.Add(this.cbLoc);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.cbTenKhachHang);
            this.Controls.Add(this.txtMaDonHang);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.btnTaiLai);
            this.Controls.Add(this.btnSua);
            this.Controls.Add(this.btnXoa);
            this.Controls.Add(this.btnThem);
            this.Controls.Add(this.btnTimKiem);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.chkTinhTrangGiaoHang);
            this.Controls.Add(this.cbDaThanhToan);
            this.Controls.Add(this.dtpNgayGiaoHang);
            this.Controls.Add(this.dtpNgayDatHang);
            this.Controls.Add(this.groupBox1);
            this.Name = "QL_DonHang_GUI";
            this.Text = "QLDonHang_GUI";
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDonHang)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView dgvDonHang;
        private System.Windows.Forms.DateTimePicker dtpNgayDatHang;
        private System.Windows.Forms.DateTimePicker dtpNgayGiaoHang;
        private System.Windows.Forms.ComboBox cbDaThanhToan;
        private System.Windows.Forms.CheckBox chkTinhTrangGiaoHang;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnSua;
        private System.Windows.Forms.Button btnXoa;
        private System.Windows.Forms.Button btnThem;
        private System.Windows.Forms.Button btnTimKiem;
        private System.Windows.Forms.Button btnTaiLai;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtMaDonHang;
        private System.Windows.Forms.ComboBox cbTenKhachHang;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cbLoc;
    }
}