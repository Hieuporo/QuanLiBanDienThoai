namespace QuanLiBanDienThoai
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
			this.tệpTinToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.thoátToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.danhMụcToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.hãngToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.nhânViênToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.kháchHàngToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.sảnPhẩmToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.menuStrip1.SuspendLayout();
			this.SuspendLayout();
			// 
			// menuStrip1
			// 
			this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
			this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tệpTinToolStripMenuItem,
            this.danhMụcToolStripMenuItem});
			this.menuStrip1.Location = new System.Drawing.Point(0, 0);
			this.menuStrip1.Name = "menuStrip1";
			this.menuStrip1.Size = new System.Drawing.Size(800, 28);
			this.menuStrip1.TabIndex = 0;
			this.menuStrip1.Text = "menuStrip1";
			// 
			// tệpTinToolStripMenuItem
			// 
			this.tệpTinToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.thoátToolStripMenuItem});
			this.tệpTinToolStripMenuItem.Name = "tệpTinToolStripMenuItem";
			this.tệpTinToolStripMenuItem.Size = new System.Drawing.Size(69, 24);
			this.tệpTinToolStripMenuItem.Text = "Tệp tin";
			// 
			// thoátToolStripMenuItem
			// 
			this.thoátToolStripMenuItem.Name = "thoátToolStripMenuItem";
			this.thoátToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.F4)));
			this.thoátToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
			this.thoátToolStripMenuItem.Text = "Thoát ";
			// 
			// danhMụcToolStripMenuItem
			// 
			this.danhMụcToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.hãngToolStripMenuItem,
            this.nhânViênToolStripMenuItem,
            this.kháchHàngToolStripMenuItem,
            this.sảnPhẩmToolStripMenuItem});
			this.danhMụcToolStripMenuItem.Name = "danhMụcToolStripMenuItem";
			this.danhMụcToolStripMenuItem.Size = new System.Drawing.Size(90, 24);
			this.danhMụcToolStripMenuItem.Text = "Danh mục";
			// 
			// hãngToolStripMenuItem
			// 
			this.hãngToolStripMenuItem.Name = "hãngToolStripMenuItem";
			this.hãngToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
			this.hãngToolStripMenuItem.Text = "Hãng";
			// 
			// nhânViênToolStripMenuItem
			// 
			this.nhânViênToolStripMenuItem.Name = "nhânViênToolStripMenuItem";
			this.nhânViênToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
			this.nhânViênToolStripMenuItem.Text = "Nhân viên";
			// 
			// kháchHàngToolStripMenuItem
			// 
			this.kháchHàngToolStripMenuItem.Name = "kháchHàngToolStripMenuItem";
			this.kháchHàngToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
			this.kháchHàngToolStripMenuItem.Text = "Khách hàng";
			// 
			// sảnPhẩmToolStripMenuItem
			// 
			this.sảnPhẩmToolStripMenuItem.Name = "sảnPhẩmToolStripMenuItem";
			this.sảnPhẩmToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
			this.sảnPhẩmToolStripMenuItem.Text = "Sản phẩm";
			// 
			// frmMain
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(800, 450);
			this.Controls.Add(this.menuStrip1);
			this.IsMdiContainer = true;
			this.MainMenuStrip = this.menuStrip1;
			this.MaximizeBox = false;
			this.Name = "frmMain";
			this.Text = "Chương trình quản lí cửa hàng điện thoại";
			this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
			this.menuStrip1.ResumeLayout(false);
			this.menuStrip1.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.MenuStrip menuStrip1;
		private System.Windows.Forms.ToolStripMenuItem tệpTinToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem thoátToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem danhMụcToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem hãngToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem nhânViênToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem kháchHàngToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem sảnPhẩmToolStripMenuItem;
	}
}

