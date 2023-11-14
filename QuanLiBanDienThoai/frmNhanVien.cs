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
	public partial class frmNhanVien : Form
	{
		ConnectData data = new ConnectData();

		DataTable dtnv; //Chứa dữ liệu bảng Nhân Viên
		public frmNhanVien()
		{
			InitializeComponent();
		}
		public void LoadDataGridView()
		{
			string sql;
			sql = "SELECT MaNV,TenNV,GioiTinh,DienThoai  From NhanVien";
			dtnv = data.ReadData(sql); //lấy dữ liệu
            dgvNhanVien.DataSource = dtnv;
			dgvNhanVien.Columns[0].HeaderText = "Mã nhân viên";
			dgvNhanVien.Columns[1].HeaderText = "Tên nhân viên";
			dgvNhanVien.Columns[2].HeaderText = "Giới tính";
			dgvNhanVien.Columns[3].HeaderText = "Điện thoại";
			dgvNhanVien.Columns[0].Width = 100;
			dgvNhanVien.Columns[1].Width = 250;
			dgvNhanVien.Columns[2].Width = 200;
			dgvNhanVien.Columns[3].Width = 250;
			dgvNhanVien.AllowUserToAddRows = false;
			dgvNhanVien.EditMode = DataGridViewEditMode.EditProgrammatically;
		}

		private void frmNhanVien_Load(object sender, EventArgs e)
		{
			txtMaNhanVien.Enabled = false;
			btnLuu.Enabled = false;
			btnBoQua.Enabled = false;
			LoadDataGridView();
		}

		private void dgvNhanVien_Click(object sender, EventArgs e)
		{
			if (btnThem.Enabled == false)
			{
				MessageBox.Show("Đang ở chế độ thêm mới!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
				txtMaNhanVien.Focus();
				return;
			}
			if (dtnv.Rows.Count == 0)
			{
				MessageBox.Show("Không có dữ liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
				return;
			}
			txtMaNhanVien.Text = dgvNhanVien.CurrentRow.Cells["MaNV"].Value.ToString();
			txtTenNhanVien.Text = dgvNhanVien.CurrentRow.Cells["TenNV"].Value.ToString();
			if (dgvNhanVien.CurrentRow.Cells["GioiTinh"].Value.ToString() == "Nam") chkGioiTinh.Checked = true;
			else chkGioiTinh.Checked = false;
			mtbDienThoai.Text = dgvNhanVien.CurrentRow.Cells["DienThoai"].Value.ToString();
			btnSua.Enabled = true;
			btnXoa.Enabled = true;
			btnXoa.Enabled = true;
		}
		private void ResetValues()
		{
			txtMaNhanVien.Text = "";
			txtTenNhanVien.Text = "";
			chkGioiTinh.Checked = false;
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
			txtMaNhanVien.Enabled = true;
			txtMaNhanVien.Focus();
		}

		private void btnXoa_Click(object sender, EventArgs e)
		{
			string sql;
			if (dtnv.Rows.Count == 0)
			{
				MessageBox.Show("Không còn dữ liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
				return;
			}
			if (txtMaNhanVien.Text == "")
			{
				MessageBox.Show("Bạn chưa chọn bản ghi nào", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
				return;
			}
			if (MessageBox.Show("Bạn có muốn xóa không?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
			{
				sql = "DELETE NhanVien WHERE MaNV=N'" + txtMaNhanVien.Text + "'";
				data.ChangeData(sql);
				LoadDataGridView();
				ResetValues();
			}
		}

		private void btnSua_Click(object sender, EventArgs e)
		{
			string sql, gt;
			if (dtnv.Rows.Count == 0)
			{
				MessageBox.Show("Không còn dữ liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
				return;
			}
			if (txtMaNhanVien.Text == "")
			{
				MessageBox.Show("Bạn chưa chọn bản ghi nào", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
				return;
			}
			if (txtTenNhanVien.Text.Trim().Length == 0)
			{
				MessageBox.Show("Bạn phải nhập tên nhân viên", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				txtTenNhanVien.Focus();
				return;
			}
			if (mtbDienThoai.Text == "(   )     -")
			{
				MessageBox.Show("Bạn phải nhập điện thoại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				mtbDienThoai.Focus();
				return;
			}
			
			if (chkGioiTinh.Checked == true)
				gt = "Nam";
			else
				gt = "Nữ";
			sql = "UPDATE NhanVien SET  TenNV=N'" + txtTenNhanVien.Text.Trim().ToString() +
					"',DienThoai='" + mtbDienThoai.Text.ToString() + "',GioiTinh=N'" + gt +
					"' WHERE MaNV=N'" + txtMaNhanVien.Text + "'";
			data.ChangeData(sql);
			LoadDataGridView();
			ResetValues();
			btnBoQua.Enabled = false;
		}

		private void btnLuu_Click(object sender, EventArgs e)
		{
			string sql, gt;
			if (txtMaNhanVien.Text.Trim().Length == 0)
			{
				MessageBox.Show("Bạn phải nhập mã nhân viên", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				txtMaNhanVien.Focus();
				return;
			}
			if (txtTenNhanVien.Text.Trim().Length == 0)
			{
				MessageBox.Show("Bạn phải nhập tên nhân viên", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				txtTenNhanVien.Focus();
				return;
			}
			if (mtbDienThoai.Text == "(   )     -")
			{
				MessageBox.Show("Bạn phải nhập điện thoại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				mtbDienThoai.Focus();
				return;
			}
			if (chkGioiTinh.Checked == true)
				gt = "Nam";
			else
				gt = "Nữ";
			sql = "SELECT MaNV FROM NhanVien WHERE MaNV=N'" + txtMaNhanVien.Text.Trim() + "'";
			if (data.ReadData(sql).Rows.Count > 0)
			{
				MessageBox.Show("Mã nhân viên này đã có, bạn phải nhập mã khác", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				txtMaNhanVien.Focus();
				txtMaNhanVien.Text = "";
				return;
			}
			sql = "INSERT INTO NhanVien(MaNV,TenNV,GioiTinh,DienThoai) VALUES (N'" + txtMaNhanVien.Text.Trim() + "',N'" + txtTenNhanVien.Text.Trim() + "',N'" + gt + "',N'" + mtbDienThoai.Text + "')";
			data.ChangeData(sql);
			LoadDataGridView();
			ResetValues();
			btnXoa.Enabled = true;
			btnThem.Enabled = true;
			btnSua.Enabled = true;
			btnBoQua.Enabled = false;
			btnLuu.Enabled = false;
			txtMaNhanVien.Enabled = false;
		}

		private void btnBoQua_Click(object sender, EventArgs e)
		{
			ResetValues();
			btnBoQua.Enabled = false;
			btnThem.Enabled = true;
			btnXoa.Enabled = true;
			btnSua.Enabled = true;
			btnLuu.Enabled = false;
			txtMaNhanVien.Enabled = false;
		}

		private void btnDong_Click(object sender, EventArgs e)
		{
			this.Close();
		}
	}
}
