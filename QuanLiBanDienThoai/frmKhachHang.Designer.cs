namespace QuanLiBanDienThoai
{
	partial class frmKhachHang
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
			this.panel2 = new System.Windows.Forms.Panel();
			this.txtTenKhach = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.mtbDienThoai = new System.Windows.Forms.MaskedTextBox();
			this.txtDiaChi = new System.Windows.Forms.TextBox();
			this.txtMaKhach = new System.Windows.Forms.TextBox();
			this.label5 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.panel1 = new System.Windows.Forms.Panel();
			this.btnDong = new System.Windows.Forms.Button();
			this.btnLuu = new System.Windows.Forms.Button();
			this.btnBoQua = new System.Windows.Forms.Button();
			this.btnSua = new System.Windows.Forms.Button();
			this.btnXoa = new System.Windows.Forms.Button();
			this.btnThem = new System.Windows.Forms.Button();
			this.dgvKhachHang = new System.Windows.Forms.DataGridView();
			this.panel2.SuspendLayout();
			this.panel1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgvKhachHang)).BeginInit();
			this.SuspendLayout();
			// 
			// panel2
			// 
			this.panel2.Controls.Add(this.txtTenKhach);
			this.panel2.Controls.Add(this.label3);
			this.panel2.Controls.Add(this.mtbDienThoai);
			this.panel2.Controls.Add(this.txtDiaChi);
			this.panel2.Controls.Add(this.txtMaKhach);
			this.panel2.Controls.Add(this.label5);
			this.panel2.Controls.Add(this.label4);
			this.panel2.Controls.Add(this.label2);
			this.panel2.Controls.Add(this.label1);
			this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
			this.panel2.Location = new System.Drawing.Point(0, 0);
			this.panel2.Name = "panel2";
			this.panel2.Size = new System.Drawing.Size(1063, 155);
			this.panel2.TabIndex = 2;
			// 
			// txtTenKhach
			// 
			this.txtTenKhach.Location = new System.Drawing.Point(187, 102);
			this.txtTenKhach.Name = "txtTenKhach";
			this.txtTenKhach.Size = new System.Drawing.Size(205, 22);
			this.txtTenKhach.TabIndex = 12;
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(70, 102);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(103, 16);
			this.label3.TabIndex = 11;
			this.label3.Text = "Tên khách hàng";
			// 
			// mtbDienThoai
			// 
			this.mtbDienThoai.Location = new System.Drawing.Point(608, 106);
			this.mtbDienThoai.Mask = "(999) 000-0000";
			this.mtbDienThoai.Name = "mtbDienThoai";
			this.mtbDienThoai.Size = new System.Drawing.Size(218, 22);
			this.mtbDienThoai.TabIndex = 10;
			// 
			// txtDiaChi
			// 
			this.txtDiaChi.Location = new System.Drawing.Point(608, 64);
			this.txtDiaChi.Name = "txtDiaChi";
			this.txtDiaChi.Size = new System.Drawing.Size(218, 22);
			this.txtDiaChi.TabIndex = 7;
			// 
			// txtMaKhach
			// 
			this.txtMaKhach.Location = new System.Drawing.Point(187, 64);
			this.txtMaKhach.Name = "txtMaKhach";
			this.txtMaKhach.Size = new System.Drawing.Size(205, 22);
			this.txtMaKhach.TabIndex = 6;
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(496, 108);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(66, 16);
			this.label5.TabIndex = 5;
			this.label5.Text = "Điện thoại";
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(496, 67);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(47, 16);
			this.label4.TabIndex = 4;
			this.label4.Text = "Địa chỉ";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(70, 67);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(98, 16);
			this.label2.TabIndex = 2;
			this.label2.Text = "Mã khách hàng";
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.BackColor = System.Drawing.SystemColors.Control;
			this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label1.ForeColor = System.Drawing.SystemColors.Highlight;
			this.label1.Location = new System.Drawing.Point(333, 9);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(321, 29);
			this.label1.TabIndex = 1;
			this.label1.Text = "DANH MỤC KHÁCH HÀNG";
			// 
			// panel1
			// 
			this.panel1.Controls.Add(this.btnDong);
			this.panel1.Controls.Add(this.btnLuu);
			this.panel1.Controls.Add(this.btnBoQua);
			this.panel1.Controls.Add(this.btnSua);
			this.panel1.Controls.Add(this.btnXoa);
			this.panel1.Controls.Add(this.btnThem);
			this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.panel1.Location = new System.Drawing.Point(0, 459);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(1063, 100);
			this.panel1.TabIndex = 3;
			// 
			// btnDong
			// 
			this.btnDong.Location = new System.Drawing.Point(874, 31);
			this.btnDong.Name = "btnDong";
			this.btnDong.Size = new System.Drawing.Size(101, 39);
			this.btnDong.TabIndex = 11;
			this.btnDong.Text = "Đóng";
			this.btnDong.UseVisualStyleBackColor = true;
			this.btnDong.Click += new System.EventHandler(this.btnDong_Click);
			// 
			// btnLuu
			// 
			this.btnLuu.Location = new System.Drawing.Point(550, 31);
			this.btnLuu.Name = "btnLuu";
			this.btnLuu.Size = new System.Drawing.Size(101, 39);
			this.btnLuu.TabIndex = 10;
			this.btnLuu.Text = "Lưu";
			this.btnLuu.UseVisualStyleBackColor = true;
			this.btnLuu.Click += new System.EventHandler(this.btnLuu_Click);
			// 
			// btnBoQua
			// 
			this.btnBoQua.Location = new System.Drawing.Point(712, 31);
			this.btnBoQua.Name = "btnBoQua";
			this.btnBoQua.Size = new System.Drawing.Size(101, 39);
			this.btnBoQua.TabIndex = 9;
			this.btnBoQua.Text = "Bỏ qua";
			this.btnBoQua.UseVisualStyleBackColor = true;
			this.btnBoQua.Click += new System.EventHandler(this.btnBoQua_Click);
			// 
			// btnSua
			// 
			this.btnSua.Location = new System.Drawing.Point(388, 31);
			this.btnSua.Name = "btnSua";
			this.btnSua.Size = new System.Drawing.Size(101, 39);
			this.btnSua.TabIndex = 8;
			this.btnSua.Text = "Sửa";
			this.btnSua.UseVisualStyleBackColor = true;
			this.btnSua.Click += new System.EventHandler(this.btnSua_Click);
			// 
			// btnXoa
			// 
			this.btnXoa.Location = new System.Drawing.Point(226, 31);
			this.btnXoa.Name = "btnXoa";
			this.btnXoa.Size = new System.Drawing.Size(101, 39);
			this.btnXoa.TabIndex = 7;
			this.btnXoa.Text = "Xóa";
			this.btnXoa.UseVisualStyleBackColor = true;
			this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);
			// 
			// btnThem
			// 
			this.btnThem.Location = new System.Drawing.Point(64, 31);
			this.btnThem.Name = "btnThem";
			this.btnThem.Size = new System.Drawing.Size(101, 39);
			this.btnThem.TabIndex = 6;
			this.btnThem.Text = "Thêm";
			this.btnThem.UseVisualStyleBackColor = true;
			this.btnThem.Click += new System.EventHandler(this.btnThem_Click);
			// 
			// dgvKhachHang
			// 
			this.dgvKhachHang.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dgvKhachHang.Dock = System.Windows.Forms.DockStyle.Fill;
			this.dgvKhachHang.Location = new System.Drawing.Point(0, 155);
			this.dgvKhachHang.Name = "dgvKhachHang";
			this.dgvKhachHang.RowHeadersWidth = 51;
			this.dgvKhachHang.RowTemplate.Height = 24;
			this.dgvKhachHang.Size = new System.Drawing.Size(1063, 304);
			this.dgvKhachHang.TabIndex = 4;
			this.dgvKhachHang.Click += new System.EventHandler(this.dgvKhachHang_Click);
			// 
			// frmKhachHang
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1063, 559);
			this.Controls.Add(this.dgvKhachHang);
			this.Controls.Add(this.panel1);
			this.Controls.Add(this.panel2);
			this.Name = "frmKhachHang";
			this.Text = "frmKhachHang";
			this.Load += new System.EventHandler(this.frmKhachHang_Load);
			this.panel2.ResumeLayout(false);
			this.panel2.PerformLayout();
			this.panel1.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.dgvKhachHang)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Panel panel2;
		private System.Windows.Forms.MaskedTextBox mtbDienThoai;
		private System.Windows.Forms.TextBox txtDiaChi;
		private System.Windows.Forms.TextBox txtMaKhach;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Button btnDong;
		private System.Windows.Forms.Button btnLuu;
		private System.Windows.Forms.Button btnBoQua;
		private System.Windows.Forms.Button btnSua;
		private System.Windows.Forms.Button btnXoa;
		private System.Windows.Forms.Button btnThem;
		private System.Windows.Forms.TextBox txtTenKhach;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.DataGridView dgvKhachHang;
	}
}