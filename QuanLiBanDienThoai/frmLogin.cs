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
	public partial class frmLogin : Form
	{
		ConnectData data = new ConnectData();
		public frmLogin()
		{
			InitializeComponent();
		}

		private void label1_Click(object sender, EventArgs e)
		{

		}

		private void button1_Click(object sender, EventArgs e)
		{
			var sql = "Select * from TaiKhoan Where TaiKhoan = '" + textBox1.Text + "'" + "and MatKhau = '" + textBox2.Text + "'";
			if (data.ReadData(sql).Rows.Count > 0)
			{
				MessageBox.Show("Chào mừng đăng nhập", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
				frmMain newForm = new frmMain();
				newForm.Show();
				this.Hide();
			}
			else
			{
				MessageBox.Show("Tài khoản hoặc mật khẩu không đúng !!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
				textBox2.Text = "";
				textBox1.Text = "";
				textBox1.Focus();
			}
		}

		private void checkBox1_CheckedChanged(object sender, EventArgs e)
		{
			if (checkBox1.Checked)
			{
				textBox2.PasswordChar = (char)0;
			}
			else
			{
				textBox2.PasswordChar = '*';
			}
		}
	}
}
