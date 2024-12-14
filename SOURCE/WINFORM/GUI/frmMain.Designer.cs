namespace GUI
{
    partial class frmMain
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
            this.components = new System.ComponentModel.Container();
            this.mainMenu1 = new System.Windows.Forms.MainMenu(this.components);
            this.menuItem1 = new System.Windows.Forms.MenuItem();
            this.menuItem5 = new System.Windows.Forms.MenuItem();
            this.menuItem6 = new System.Windows.Forms.MenuItem();
            this.menuItem13 = new System.Windows.Forms.MenuItem();
            this.menuItem20 = new System.Windows.Forms.MenuItem();
            this.menuItem21 = new System.Windows.Forms.MenuItem();
            this.menuItem22 = new System.Windows.Forms.MenuItem();
            this.menuItem3 = new System.Windows.Forms.MenuItem();
            this.menuItem15 = new System.Windows.Forms.MenuItem();
            this.menuItem16 = new System.Windows.Forms.MenuItem();
            this.menuItem17 = new System.Windows.Forms.MenuItem();
            this.menuItem4 = new System.Windows.Forms.MenuItem();
            this.menuItem12 = new System.Windows.Forms.MenuItem();
            this.SuspendLayout();
            // 
            // mainMenu1
            // 
            this.mainMenu1.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuItem1,
            this.menuItem3,
            this.menuItem4,
            this.menuItem12});
            // 
            // menuItem1
            // 
            this.menuItem1.Index = 0;
            this.menuItem1.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuItem5,
            this.menuItem6});
            this.menuItem1.Text = "Quản Lý";
            // 
            // menuItem5
            // 
            this.menuItem5.Index = 0;
            this.menuItem5.Text = "Quản Trị Viên";
            this.menuItem5.Click += new System.EventHandler(this.menuItem5_Click);
            // 
            // menuItem6
            // 
            this.menuItem6.Index = 1;
            this.menuItem6.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuItem13,
            this.menuItem20,
            this.menuItem21,
            this.menuItem22});
            this.menuItem6.Text = "Người Dùng";
            // 
            // menuItem13
            // 
            this.menuItem13.Index = 0;
            this.menuItem13.Text = "Thông Tin Người Dùng";
            this.menuItem13.Click += new System.EventHandler(this.menuItem13_Click);
            // 
            // menuItem20
            // 
            this.menuItem20.Index = 1;
            this.menuItem20.Text = "Đơn Hàng";
            this.menuItem20.Click += new System.EventHandler(this.menuItem20_Click);
            // 
            // menuItem21
            // 
            this.menuItem21.Index = 2;
            this.menuItem21.Text = "Đánh Giá";
            this.menuItem21.Click += new System.EventHandler(this.menuItem21_Click);
            // 
            // menuItem22
            // 
            this.menuItem22.Index = 3;
            this.menuItem22.Text = "Tích Điểm";
            this.menuItem22.Click += new System.EventHandler(this.menuItem22_Click);
            // 
            // menuItem3
            // 
            this.menuItem3.Index = 1;
            this.menuItem3.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuItem15,
            this.menuItem16,
            this.menuItem17});
            this.menuItem3.Text = "Sản Phẩm";
            // 
            // menuItem15
            // 
            this.menuItem15.Index = 0;
            this.menuItem15.Text = "Danh Sách Sản Phẩm";
            this.menuItem15.Click += new System.EventHandler(this.menuItem15_Click);
            // 
            // menuItem16
            // 
            this.menuItem16.Index = 1;
            this.menuItem16.Text = "Danh Sách Loại Sản Phẩm";
            this.menuItem16.Click += new System.EventHandler(this.menuItem16_Click);
            // 
            // menuItem17
            // 
            this.menuItem17.Index = 2;
            this.menuItem17.Text = "Nhà Cung Cấp";
            this.menuItem17.Click += new System.EventHandler(this.menuItem17_Click);
            // 
            // menuItem4
            // 
            this.menuItem4.Index = 2;
            this.menuItem4.Text = "Khuyến Mãi";
            this.menuItem4.Click += new System.EventHandler(this.menuItem4_Click);
            // 
            // menuItem12
            // 
            this.menuItem12.Index = 3;
            this.menuItem12.Text = "Thống Kê";
            this.menuItem12.Click += new System.EventHandler(this.menuItem12_Click);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.IsMdiContainer = true;
            this.Menu = this.mainMenu1;
            this.Name = "frmMain";
            this.Text = "frmMain";
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.MainMenu mainMenu1;
        private System.Windows.Forms.MenuItem menuItem1;
        private System.Windows.Forms.MenuItem menuItem5;
        private System.Windows.Forms.MenuItem menuItem6;
        private System.Windows.Forms.MenuItem menuItem3;
        private System.Windows.Forms.MenuItem menuItem4;
        private System.Windows.Forms.MenuItem menuItem12;
        private System.Windows.Forms.MenuItem menuItem15;
        private System.Windows.Forms.MenuItem menuItem16;
        private System.Windows.Forms.MenuItem menuItem17;
        private System.Windows.Forms.MenuItem menuItem13;
        private System.Windows.Forms.MenuItem menuItem20;
        private System.Windows.Forms.MenuItem menuItem21;
        private System.Windows.Forms.MenuItem menuItem22;
    }
}