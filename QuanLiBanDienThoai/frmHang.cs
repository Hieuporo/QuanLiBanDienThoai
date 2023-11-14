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
	public partial class frmHang : Form
	{
		ConnectData data = new ConnectData();

		DataTable dtth; //Chứa dữ liệu bảng Thương hiệu

		public frmHang()
		{
			InitializeComponent();
		}

		private void label1_Click(object sender, EventArgs e)
		{

		}

		private void LoadDataGridView()
		{
			string sql;
			sql = "SELECT MaThuongHieu, TenThuongHieu  FROM ThuongHieu";
			dtth = data.ReadData(sql); //Đọc dữ liệu từ bảng
			dgvHang.DataSource = dtth; //Nguồn dữ liệu            
			dgvHang.Columns[0].HeaderText = "Mã thương hiệu";
			dgvHang.Columns[1].HeaderText = "Tên thương hiệu";
			dgvHang.Columns[0].Width = 300;
			dgvHang.Columns[1].Width = 400;
			dgvHang.AllowUserToAddRows = false; //Không cho người dùng thêm dữ liệu trực tiếp
			dgvHang.EditMode = DataGridViewEditMode.EditProgrammatically; //Không cho sửa dữ liệu trực tiếp
		}

		private void frmHang_Load(object sender, EventArgs e)
		{
			txtMaThuongHieu.Enabled = false;
			btnLuu.Enabled = false;
			btnBoQua.Enabled = false;
			LoadDataGridView();
		}

		private void dgvHang_Click(object sender, EventArgs e)
		{
			if (btnThem.Enabled == false)
			{
				MessageBox.Show("Đang ở chế độ thêm mới!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
				txtMaThuongHieu.Focus();
				return;
			}
			if (dtth.Rows.Count == 0) //Nếu không có dữ liệu 
			{
				MessageBox.Show("Không có dữ liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
				return;
			}
			txtMaThuongHieu.Text = dgvHang.CurrentRow.Cells["MaThuongHieu"].Value.ToString();
			txtTenThuongHieu.Text = dgvHang.CurrentRow.Cells["TenThuongHieu"].Value.ToString();
			btnSua.Enabled = true;
			btnXoa.Enabled = true;
			btnBoQua.Enabled = true;
		}

		private void ResetValue()
		{
			txtMaThuongHieu.Text = "";
			txtTenThuongHieu.Text = "";
		}

		private void btnThem_Click(object sender, EventArgs e)
		{
			btnSua.Enabled = false;
			btnXoa.Enabled = false;
			btnBoQua.Enabled = true;
			btnLuu.Enabled = true;
			btnThem.Enabled = false;
			ResetValue(); //Xoá trắng các textbox
			txtMaThuongHieu.Enabled = true; //cho phép nhập mới
			txtMaThuongHieu.Focus();
		}

		private void btnLuu_Click(object sender, EventArgs e)
		{
			string sql; //Lưu lệnh sql
			if (txtMaThuongHieu.Text.Trim().Length == 0) //Nếu chưa nhập mã 
			{
				MessageBox.Show("Bạn phải nhập mã thương hiệu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
				txtMaThuongHieu.Focus();
				return;
			}
			if (txtTenThuongHieu.Text.Trim().Length == 0) //Nếu chưa nhập tên
			{
				MessageBox.Show("Bạn phải nhập tên thương hiệu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
				txtTenThuongHieu.Focus();
				return;
			}
			sql = "Select MaThuongHieu From ThuongHieu where MaThuongHieu=N'" + txtMaThuongHieu.Text.Trim() + "'";
			if (data.ReadData(sql).Rows.Count > 0)
			{
				MessageBox.Show("Mã thương hiệu này đã tồn tại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				txtMaThuongHieu.Focus();
				return;
			}

			sql = "INSERT INTO ThuongHieu VALUES(N'" +
				txtMaThuongHieu.Text + "',N'" + txtTenThuongHieu.Text + "')";
			data.ChangeData(sql); //Thực hiện câu lệnh sql
			LoadDataGridView(); //Nạp lại DataGridView
			ResetValue();
			btnXoa.Enabled = true;
			btnThem.Enabled = true;
			btnSua.Enabled = true;
			btnBoQua.Enabled = false;
			btnLuu.Enabled = false;
			txtTenThuongHieu.Enabled = false;
		}

		private void btnSua_Click(object sender, EventArgs e)
		{
			string sql; //Lưu câu lệnh sql
			if (dtth.Rows.Count == 0)
			{
				MessageBox.Show("Không còn dữ liệu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
				return;
			}
			if (txtMaThuongHieu.Text == "") //nếu chưa chọn bản ghi nào
			{
				MessageBox.Show("Bạn chưa chọn bản ghi nào", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
				return;
			}
			if (txtTenThuongHieu.Text.Trim().Length == 0) //nếu chưa nhập tên nhãn hiệu
			{
				MessageBox.Show("Bạn chưa nhập tên thương hiệu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
				return;
			}
			sql = "UPDATE ThuongHieu SET TenThuongHieu=N'" +
				txtTenThuongHieu.Text.ToString() +
				"' WHERE MaThuongHieu=N'" + txtMaThuongHieu.Text + "'";
			data.ChangeData(sql);
			LoadDataGridView();
			ResetValue();

			btnBoQua.Enabled = false;
		}

		private void btnXoa_Click(object sender, EventArgs e)
		{
			string sql;
			if (dtth.Rows.Count == 0)
			{
				MessageBox.Show("Không còn dữ liệu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
				return;
			}
			if (txtMaThuongHieu.Text == "") //nếu chưa chọn bản ghi nào
			{
				MessageBox.Show("Bạn chưa chọn bản ghi nào", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
				return;
			}
			if (MessageBox.Show("Bạn có muốn xoá không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
			{
				sql = "DELETE ThuongHieu WHERE MaThuongHieu=N'" + txtMaThuongHieu.Text + "'";
				data.ChangeData(sql);
				LoadDataGridView();
				ResetValue();
			}
		}

		private void btnBoQua_Click(object sender, EventArgs e)
		{
			ResetValue();
			btnBoQua.Enabled = false;
			btnThem.Enabled = true;
			btnXoa.Enabled = true;
			btnSua.Enabled = true;
			btnLuu.Enabled = false;
			txtMaThuongHieu.Enabled = false;
		}

		private void btnDong_Click(object sender, EventArgs e)
		{
			this.Close();
		}
	}
}
