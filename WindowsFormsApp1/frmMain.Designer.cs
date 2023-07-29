namespace WindowsFormsApp1
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.buônBánToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmOder = new System.Windows.Forms.ToolStripMenuItem();
            this.dữLiệuBuônBánToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.Thoat = new System.Windows.Forms.ToolStripMenuItem();
            this.Logout = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmOrderlist = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.buônBánToolStripMenuItem,
            this.dữLiệuBuônBánToolStripMenuItem,
            this.Logout,
            this.Thoat});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(800, 28);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // buônBánToolStripMenuItem
            // 
            this.buônBánToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmOder,
            this.tsmOrderlist});
            this.buônBánToolStripMenuItem.Name = "buônBánToolStripMenuItem";
            this.buônBánToolStripMenuItem.Size = new System.Drawing.Size(86, 24);
            this.buônBánToolStripMenuItem.Text = "Buôn bán";
            // 
            // tsmOder
            // 
            this.tsmOder.Name = "tsmOder";
            this.tsmOder.Size = new System.Drawing.Size(224, 26);
            this.tsmOder.Text = "Gọi món";
            this.tsmOder.Click += new System.EventHandler(this.tsmOrder_Click);
            // 
            // dữLiệuBuônBánToolStripMenuItem
            // 
            this.dữLiệuBuônBánToolStripMenuItem.Name = "dữLiệuBuônBánToolStripMenuItem";
            this.dữLiệuBuônBánToolStripMenuItem.Size = new System.Drawing.Size(138, 24);
            this.dữLiệuBuônBánToolStripMenuItem.Text = "Dữ liệu buôn bán";
            // 
            // Thoat
            // 
            this.Thoat.Name = "Thoat";
            this.Thoat.Size = new System.Drawing.Size(61, 24);
            this.Thoat.Text = "Thoát";
            this.Thoat.Click += new System.EventHandler(this.Thoat_click);
            // 
            // Logout
            // 
            this.Logout.Name = "Logout";
            this.Logout.Size = new System.Drawing.Size(91, 24);
            this.Logout.Text = "Đăng xuất";
            this.Logout.Click += new System.EventHandler(this.Logout_click);
            // 
            // tsmOrderlist
            // 
            this.tsmOrderlist.Name = "tsmOrderlist";
            this.tsmOrderlist.Size = new System.Drawing.Size(224, 26);
            this.tsmOrderlist.Text = "Danh sách gọi món";
            this.tsmOrderlist.Click += new System.EventHandler(this.tsmOrderlist_click);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmMain";
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem buônBánToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem dữLiệuBuônBánToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tsmOder;
        private System.Windows.Forms.ToolStripMenuItem Thoat;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem Logout;
        private System.Windows.Forms.ToolStripMenuItem tsmOrderlist;
    }
}