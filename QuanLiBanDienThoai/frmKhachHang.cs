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
	public partial class frmKhachHang : Form
	{
		DataTable tblKH;
		ConnectData data = new ConnectData();

		public frmKhachHang()
		{
			InitializeComponent();
		}
		private void LoadDataGridView()
		{
			string sql;
			sql = "SELECT * from KhachHang";
			tblKH = data.ReadData(sql); //Lấy dữ liệu từ bảng
			dgvKhachHang.DataSource = tblKH; //Hiển thị vào dataGridView
			dgvKhachHang.Columns[0].HeaderText = "Mã khách";
			dgvKhachHang.Columns[1].HeaderText = "Tên khách";
			dgvKhachHang.Columns[2].HeaderText = "Địa chỉ";
			dgvKhachHang.Columns[3].HeaderText = "Điện thoại";
			dgvKhachHang.Columns[0].Width = 100;
			dgvKhachHang.Columns[1].Width = 150;
			dgvKhachHang.Columns[2].Width = 350;
			dgvKhachHang.Columns[3].Width = 150;
			dgvKhachHang.AllowUserToAddRows = false;
			dgvKhachHang.EditMode = DataGridViewEditMode.EditProgrammatically;
		}
		private void frmKhachHang_Load(object sender, EventArgs e)
		{
			txtMaKhach.Enabled = false;
			btnLuu.Enabled = false;
			btnBoQua.Enabled = false;
			LoadDataGridView();
		}

		private void dgvKhachHang_Click(object sender, EventArgs e)
		{
			if (btnThem.Enabled == false)
			{
				MessageBox.Show("Đang ở chế độ thêm mới!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
				txtMaKhach.Focus();
				return;
			}
			if (tblKH.Rows.Count == 0)
			{
				MessageBox.Show("Không có dữ liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
				return;
			}
			txtMaKhach.Text = dgvKhachHang.CurrentRow.Cells["MaKH"].Value.ToString();
			txtTenKhach.Text = dgvKhachHang.CurrentRow.Cells["TenKH"].Value.ToString();
			txtDiaChi.Text = dgvKhachHang.CurrentRow.Cells["DiaChi"].Value.ToString();
			mtbDienThoai.Text = dgvKhachHang.CurrentRow.Cells["DienThoai"].Value.ToString();
			btnSua.Enabled = true;
			btnXoa.Enabled = true;
			btnBoQua.Enabled = true;
		}


		private void ResetValues()
		{
			txtMaKhach.Text = "";
			txtTenKhach.Text = "";
			txtDiaChi.Text = "";
			mtbDienThoai.Text = "";
		}

		private void btnThem_Click(object sender, EventArgs e)
		{
			btnSua.Enabled = false;
			btnXoa.Enabled = false;
			btnBoQua.Enabled = true;
			btnLuu.Enabled = true;
			btnThem.Enabled = false;
			ResetValues();
			txtMaKhach.Enabled = true;
			txtMaKhach.Focus();
		}

		private void btnXoa_Click(object sender, EventArgs e)
		{
			string sql;
			if (tblKH.Rows.Count == 0)
			{
				MessageBox.Show("Không còn dữ liệu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
				return;
			}
			if (txtMaKhach.Text.Trim() == "")
			{
				MessageBox.Show("Bạn chưa chọn bản ghi nào", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
				return;
			}
			if (MessageBox.Show("Bạn có muốn xoá bản ghi này không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
			{
				sql = "DELETE KhachHang WHERE MaKH=N'" + txtMaKhach.Text + "'";
				data.ChangeData(sql);
				LoadDataGridView();
				ResetValues();
			}

		}

		private void btnSua_Click(object sender, EventArgs e)
		{
			string sql;
			if (tblKH.Rows.Count == 0)
			{
				MessageBox.Show("Không còn dữ liệu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
				return;
			}
			if (txtMaKhach.Text == "")
			{
				MessageBox.Show("Bạn phải chọn bản ghi cần sửa", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
				return;
			}
			if (txtTenKhach.Text.Trim().Length == 0)
			{
				MessageBox.Show("Bạn phải nhập tên khách", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
				txtTenKhach.Focus();
				return;
			}
			if (txtDiaChi.Text.Trim().Length == 0)
			{
				MessageBox.Show("Bạn phải nhập địa chỉ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
				txtDiaChi.Focus();
				return;
			}
			if (mtbDienThoai.Text == "(  )    -")
			{
				MessageBox.Show("Bạn phải nhập điện thoại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
				mtbDienThoai.Focus();
				return;
			}
			sql = "UPDATE KhachHang SET TenKH=N'" + txtTenKhach.Text.Trim().ToString() + "',DiaChi=N'" +
				txtDiaChi.Text.Trim().ToString() + "',DienThoai='" + mtbDienThoai.Text.ToString() +
				"' WHERE MaKH=N'" + txtMaKhach.Text + "'";
			data.ChangeData(sql);
			LoadDataGridView();
			ResetValues();
			btnBoQua.Enabled = false;
		}

		private void btnLuu_Click(object sender, EventArgs e)
		{
			string sql;
			if (txtMaKhach.Text.Trim().Length == 0)
			{
				MessageBox.Show("Bạn phải nhập mã khách", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
				txtMaKhach.Focus();
				return;
			}
			if (txtTenKhach.Text.Trim().Length == 0)
			{
				MessageBox.Show("Bạn phải nhập tên khách", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
				txtTenKhach.Focus();
				return;
			}
			if (txtDiaChi.Text.Trim().Length == 0)
			{
				MessageBox.Show("Bạn phải nhập địa chỉ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
				txtDiaChi.Focus();
				return;
			}
			if (mtbDienThoai.Text == "(  )    -")
			{
				MessageBox.Show("Bạn phải nhập điện thoại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
				mtbDienThoai.Focus();
				return;
			}
			//Kiểm tra đã tồn tại mã khách chưa
			sql = "SELECT MaKH FROM KhachHang WHERE MaKH=N'" + txtMaKhach.Text.Trim() + "'";
			if (data.ReadData(sql).Rows.Count > 0)
			{
				MessageBox.Show("Mã khách này đã tồn tại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
				txtMaKhach.Focus();
				return;
			}
			//Chèn thêm
			sql = "INSERT INTO KhachHang VALUES (N'" + txtMaKhach.Text.Trim() +
				"',N'" + txtTenKhach.Text.Trim() + "',N'" + txtDiaChi.Text.Trim() + "','" + mtbDienThoai.Text + "')";
			data.ChangeData(sql);
			LoadDataGridView();
			ResetValues();

			btnXoa.Enabled = true;
			btnThem.Enabled = true;
			btnSua.Enabled = true;
			btnBoQua.Enabled = false;
			btnLuu.Enabled = false;
			txtMaKhach.Enabled = false;
		}

		private void btnBoQua_Click(object sender, EventArgs e)
		{
			ResetValues();
			btnBoQua.Enabled = false;
			btnThem.Enabled = true;
			btnXoa.Enabled = true;
			btnSua.Enabled = true;
			btnLuu.Enabled = false;
			txtMaKhach.Enabled = false;
		}

		private void btnDong_Click(object sender, EventArgs e)
		{
			this.Close();
		}
	}
}
