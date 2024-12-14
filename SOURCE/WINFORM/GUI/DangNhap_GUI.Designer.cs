namespace GUI
{
    partial class DangNhap_GUI
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
            this.txtPassMatKhau = new CustomControl.txtPass();
            this.textBoxTaiKhoan = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.buttonDangNhap = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtPassMatKhau
            // 
            this.txtPassMatKhau.Location = new System.Drawing.Point(53, 113);
            this.txtPassMatKhau.Name = "txtPassMatKhau";
            this.txtPassMatKhau.Size = new System.Drawing.Size(150, 22);
            this.txtPassMatKhau.TabIndex = 0;
            this.txtPassMatKhau.UseSystemPasswordChar = true;
            // 
            // textBoxTaiKhoan
            // 
            this.textBoxTaiKhoan.Location = new System.Drawing.Point(53, 60);
            this.textBoxTaiKhoan.Name = "textBoxTaiKhoan";
            this.textBoxTaiKhoan.Size = new System.Drawing.Size(150, 22);
            this.textBoxTaiKhoan.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(50, 41);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 16);
            this.label1.TabIndex = 2;
            this.label1.Text = "Tài Khoản";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(50, 94);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(62, 16);
            this.label2.TabIndex = 3;
            this.label2.Text = "Mật Khẩu";
            // 
            // buttonDangNhap
            // 
            this.buttonDangNhap.AutoSize = true;
            this.buttonDangNhap.Location = new System.Drawing.Point(157, 170);
            this.buttonDangNhap.Name = "buttonDangNhap";
            this.buttonDangNhap.Size = new System.Drawing.Size(85, 26);
            this.buttonDangNhap.TabIndex = 4;
            this.buttonDangNhap.Text = "Đăng Nhập";
            this.buttonDangNhap.UseVisualStyleBackColor = true;
            // 
            // DangNhap_GUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(400, 225);
            this.Controls.Add(this.buttonDangNhap);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBoxTaiKhoan);
            this.Controls.Add(this.txtPassMatKhau);
            this.Name = "DangNhap_GUI";
            this.Text = "DangNhap_GUI";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private CustomControl.txtPass txtPassMatKhau;
        private System.Windows.Forms.TextBox textBoxTaiKhoan;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button buttonDangNhap;
    }
}