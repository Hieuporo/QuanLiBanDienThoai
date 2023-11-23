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
			if (!IsPasswordValid(textBox2.Text))
			{
				 MessageBox.Show("Vui lòng sử dụng ít nhất một chữ hoa và một số.");
			} else
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

			
		}

		// Hàm kiểm tra mật khẩu có ít nhất một chữ hoa và một số
		private bool IsPasswordValid(string password)
		{
			bool hasUpperCase = false;
			bool hasDigit = false;

			foreach (char c in password)
			{
				if (char.IsUpper(c))
				{
					hasUpperCase = true;
				}
				else if (char.IsDigit(c))
				{
					hasDigit = true;
				}

				// Nếu đã tìm thấy cả chữ hoa và số, thoát khỏi vòng lặp
				if (hasUpperCase && hasDigit)
				{
					break;
				}
			}

			// Mật khẩu hợp lệ nếu có ít nhất một chữ hoa và một số
			return hasUpperCase && hasDigit;
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
