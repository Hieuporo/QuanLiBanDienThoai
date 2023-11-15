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
			frmHang frmH = new frmHang();
			frmH.ShowDialog();
		}

		private void mnuNhanVien_Click(object sender, EventArgs e)
		{
			frmNhanVien frmH = new frmNhanVien();
			frmH.ShowDialog();
			
		}

		private void kháchHàngToolStripMenuItem_Click(object sender, EventArgs e)
		{
			frmKhachHang frmH = new frmKhachHang();
			frmH.ShowDialog();
		}

		private void sảnPhẩmToolStripMenuItem_Click(object sender, EventArgs e)
		{
			frmSanPham frmH = new frmSanPham();
			frmH.ShowDialog();
		}

		private void mnuHoaDon_Click(object sender, EventArgs e)
		{
			frmHoaDonBan frmH = new frmHoaDonBan();
			frmH.ShowDialog();
		}

		private void frmMain_Load(object sender, EventArgs e)
		{
			pictureBox1.Image = Image.FromFile("Images\\AnhNen.gif");
		}
	}
}
