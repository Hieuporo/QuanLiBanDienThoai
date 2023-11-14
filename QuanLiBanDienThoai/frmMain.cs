using QuanLiBanDienThoai.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLiBanDienThoai
{
	public partial class frmMain : Form
	{
		ConnectData data = new ConnectData();

		public frmMain()
		{
			InitializeComponent();
		}

		private void mnuHang_Click(object sender, EventArgs e)
		{
			frmHang frm = new frmHang();
			frm.MdiParent = this;
			frm.Show();
		}

		private void mnuNhanVien_Click(object sender, EventArgs e)
		{
			frmNhanVien frm = new frmNhanVien();
			frm.MdiParent = this;
			frm.Show();
		}

		private void kháchHàngToolStripMenuItem_Click(object sender, EventArgs e)
		{
			frmKhachHang frm = new frmKhachHang();
			frm.MdiParent = this;
			frm.Show();
		}

		private void sảnPhẩmToolStripMenuItem_Click(object sender, EventArgs e)
		{
			frmSanPham frm = new frmSanPham();
			frm.MdiParent = this;
			frm.Show();
		}

		private void mnuHoaDon_Click(object sender, EventArgs e)
		{
			frmHoaDonBan frm = new frmHoaDonBan();
			frm.MdiParent = this;
			frm.Show();
		}
	}
}
