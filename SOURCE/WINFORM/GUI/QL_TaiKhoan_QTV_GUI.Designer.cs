namespace GUI
{
    partial class QL_TaiKhoan_QTV_GUI
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cbLocChucVu = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtMatKhauQTV = new System.Windows.Forms.TextBox();
            this.btnTimKiem = new System.Windows.Forms.Button();
            this.btnThem = new System.Windows.Forms.Button();
            this.btnXoa = new System.Windows.Forms.Button();
            this.btnSua = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dgvQuanTriVien = new System.Windows.Forms.DataGridView();
            this.txtTaiKhoanQTV = new System.Windows.Forms.TextBox();
            this.txtTenQTV = new System.Windows.Forms.TextBox();
            this.btnTaiLai = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.txtChucVu = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvQuanTriVien)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(150, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Tài Khoản";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(20, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(31, 16);
            this.label2.TabIndex = 2;
            this.label2.Text = "Tên";
            // 
            // cbLocChucVu
            // 
            this.cbLocChucVu.FormattingEnabled = true;
            this.cbLocChucVu.Location = new System.Drawing.Point(698, 129);
            this.cbLocChucVu.Name = "cbLocChucVu";
            this.cbLocChucVu.Size = new System.Drawing.Size(121, 24);
            this.cbLocChucVu.TabIndex = 5;
            this.cbLocChucVu.SelectedIndexChanged += new System.EventHandler(this.cbLocChucVu_SelectedIndexChanged_1);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(565, 132);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(110, 16);
            this.label3.TabIndex = 4;
            this.label3.Text = "Lọc theo Chức Vụ";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(284, 16);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(62, 16);
            this.label4.TabIndex = 6;
            this.label4.Text = "Mật Khẩu";
            // 
            // txtMatKhauQTV
            // 
            this.txtMatKhauQTV.Location = new System.Drawing.Point(287, 35);
            this.txtMatKhauQTV.Name = "txtMatKhauQTV";
            this.txtMatKhauQTV.Size = new System.Drawing.Size(100, 22);
            this.txtMatKhauQTV.TabIndex = 7;
            // 
            // btnTimKiem
            // 
            this.btnTimKiem.AutoSize = true;
            this.btnTimKiem.Location = new System.Drawing.Point(12, 75);
            this.btnTimKiem.Name = "btnTimKiem";
            this.btnTimKiem.Size = new System.Drawing.Size(123, 26);
            this.btnTimKiem.TabIndex = 9;
            this.btnTimKiem.Text = "Tìm Kiếm theo tên";
            this.btnTimKiem.UseVisualStyleBackColor = true;
            // 
            // btnThem
            // 
            this.btnThem.AutoSize = true;
            this.btnThem.Location = new System.Drawing.Point(169, 75);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(75, 26);
            this.btnThem.TabIndex = 10;
            this.btnThem.Text = "Thêm";
            this.btnThem.UseVisualStyleBackColor = true;
            // 
            // btnXoa
            // 
            this.btnXoa.AutoSize = true;
            this.btnXoa.Location = new System.Drawing.Point(280, 75);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(75, 26);
            this.btnXoa.TabIndex = 11;
            this.btnXoa.Text = "Xóa";
            this.btnXoa.UseVisualStyleBackColor = true;
            // 
            // btnSua
            // 
            this.btnSua.AutoSize = true;
            this.btnSua.Location = new System.Drawing.Point(388, 75);
            this.btnSua.Name = "btnSua";
            this.btnSua.Size = new System.Drawing.Size(75, 26);
            this.btnSua.TabIndex = 12;
            this.btnSua.Text = "Sửa";
            this.btnSua.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dgvQuanTriVien);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBox1.Location = new System.Drawing.Point(0, 159);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(831, 291);
            this.groupBox1.TabIndex = 13;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Thông Tin Tài Khoản";
            // 
            // dgvQuanTriVien
            // 
            this.dgvQuanTriVien.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvQuanTriVien.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvQuanTriVien.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvQuanTriVien.Location = new System.Drawing.Point(3, 18);
            this.dgvQuanTriVien.Name = "dgvQuanTriVien";
            this.dgvQuanTriVien.ReadOnly = true;
            this.dgvQuanTriVien.RowHeadersWidth = 51;
            this.dgvQuanTriVien.RowTemplate.Height = 24;
            this.dgvQuanTriVien.Size = new System.Drawing.Size(825, 270);
            this.dgvQuanTriVien.TabIndex = 0;
            // 
            // txtTaiKhoanQTV
            // 
            this.txtTaiKhoanQTV.Location = new System.Drawing.Point(153, 35);
            this.txtTaiKhoanQTV.Name = "txtTaiKhoanQTV";
            this.txtTaiKhoanQTV.Size = new System.Drawing.Size(100, 22);
            this.txtTaiKhoanQTV.TabIndex = 14;
            // 
            // txtTenQTV
            // 
            this.txtTenQTV.Location = new System.Drawing.Point(23, 35);
            this.txtTenQTV.Name = "txtTenQTV";
            this.txtTenQTV.Size = new System.Drawing.Size(100, 22);
            this.txtTenQTV.TabIndex = 15;
            // 
            // btnTaiLai
            // 
            this.btnTaiLai.Location = new System.Drawing.Point(12, 130);
            this.btnTaiLai.Name = "btnTaiLai";
            this.btnTaiLai.Size = new System.Drawing.Size(75, 23);
            this.btnTaiLai.TabIndex = 16;
            this.btnTaiLai.Text = "Tải Lại Bảng";
            this.btnTaiLai.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(415, 16);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(56, 16);
            this.label5.TabIndex = 17;
            this.label5.Text = "Chức Vụ";
            // 
            // txtChucVu
            // 
            this.txtChucVu.Location = new System.Drawing.Point(418, 35);
            this.txtChucVu.Name = "txtChucVu";
            this.txtChucVu.Size = new System.Drawing.Size(100, 22);
            this.txtChucVu.TabIndex = 18;
            // 
            // QL_TaiKhoan_QTV_GUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(831, 450);
            this.Controls.Add(this.txtChucVu);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.btnTaiLai);
            this.Controls.Add(this.txtTenQTV);
            this.Controls.Add(this.txtTaiKhoanQTV);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnSua);
            this.Controls.Add(this.btnXoa);
            this.Controls.Add(this.btnThem);
            this.Controls.Add(this.btnTimKiem);
            this.Controls.Add(this.txtMatKhauQTV);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cbLocChucVu);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "QL_TaiKhoan_QTV_GUI";
            this.Text = "QLTaiKhoan_QL_GUI";
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvQuanTriVien)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbLocChucVu;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtMatKhauQTV;
        private System.Windows.Forms.Button btnTimKiem;
        private System.Windows.Forms.Button btnThem;
        private System.Windows.Forms.Button btnXoa;
        private System.Windows.Forms.Button btnSua;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView dgvQuanTriVien;
        private System.Windows.Forms.TextBox txtTaiKhoanQTV;
        private System.Windows.Forms.TextBox txtTenQTV;
        private System.Windows.Forms.Button btnTaiLai;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtChucVu;
    }
}