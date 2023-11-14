using QuanLiBanDienThoai.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLiBanDienThoai
{
	public partial class frmSanPham : Form
	{
		Functions func = new Functions();
		ConnectData data = new ConnectData();
		DataTable tbSP;
		public frmSanPham()
		{
			InitializeComponent();
		}

		private void LoadDataGridView()
		{
			string sql;
			sql = "SELECT * from SanPham";
			tbSP = data.ReadData(sql);
			dgvSanPham.DataSource = tbSP;
			dgvSanPham.Columns[0].HeaderText = "Mã hàng";
			dgvSanPham.Columns[1].HeaderText = "Tên hàng";
			dgvSanPham.Columns[2].HeaderText = "Hãng";
			dgvSanPham.Columns[3].HeaderText = "Số lượng";
			dgvSanPham.Columns[4].HeaderText = "Đơn giá nhập";
			dgvSanPham.Columns[5].HeaderText = "Ảnh";
			dgvSanPham.Columns[0].Width = 80;
			dgvSanPham.Columns[1].Width = 140;
			dgvSanPham.Columns[2].Width = 100;
			dgvSanPham.Columns[3].Width = 100;
			dgvSanPham.Columns[4].Width = 200;
			dgvSanPham.Columns[5].Width = 300;
			dgvSanPham.AllowUserToAddRows = false;
			dgvSanPham.EditMode = DataGridViewEditMode.EditProgrammatically;
		}

		private void frmSanPham_Load(object sender, EventArgs e)
		{
			string sql;
			sql = "SELECT * from ThuongHieu";
			txtMaSanPham.Enabled = false;
			btnLuu.Enabled = false;
			btnBoQua.Enabled = false;
			LoadDataGridView();
			func.FillComboBox(cboMaNhanHieu, data.ReadData(sql) , "TenThuongHieu", "MaThuongHieu");
			cboMaNhanHieu.SelectedIndex = -1;
			ResetValues();
		}

		private void ResetValues()
		{
			txtMaSanPham.Text = "";
			txtTenSanPham.Text = "";
			cboMaNhanHieu.Text = "";
			txtSoLuong.Text = "0";
			txtDonGiaBan.Text = "0";
			txtSoLuong.Enabled = true;
			txtDonGiaBan.Enabled = false;
			txtAnh.Text = "";
			picAnh.Image = null;
		}

		private void dgvSanPham_Click(object sender, EventArgs e)
		{
			string MaThuongHieu;
			string sql;
			if (btnThem.Enabled == false)
			{
				MessageBox.Show("Đang ở chế độ thêm mới!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
				txtMaSanPham.Focus();
				return;
			}
			if (tbSP.Rows.Count == 0)
			{
				MessageBox.Show("Không có dữ liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
				return;
			}
			txtMaSanPham.Text = dgvSanPham.CurrentRow.Cells["MaSP"].Value.ToString();
			txtTenSanPham.Text = dgvSanPham.CurrentRow.Cells["TenSP"].Value.ToString();
			MaThuongHieu = dgvSanPham.CurrentRow.Cells["MaThuongHieu"].Value.ToString();
			sql = "SELECT TenThuongHieu FROM ThuongHieu WHERE MaThuongHieu=N'" + MaThuongHieu + "'";
			cboMaNhanHieu.Text = data.GetFieldValues(sql);
			txtSoLuong.Text = dgvSanPham.CurrentRow.Cells["SoLuong"].Value.ToString();
			txtDonGiaBan.Text = dgvSanPham.CurrentRow.Cells["GiaBan"].Value.ToString();
			sql = "SELECT Anh FROM SanPham WHERE MaSP=N'" + txtMaSanPham.Text + "'";
			txtAnh.Text = data.GetFieldValues(sql);
			picAnh.Image = Image.FromFile(txtAnh.Text);
			btnSua.Enabled = true;
			btnXoa.Enabled = true;
			btnBoQua.Enabled = true;
		}

		private void btnThem_Click(object sender, EventArgs e)
		{
			btnSua.Enabled = false;
			btnXoa.Enabled = false;
			btnBoQua.Enabled = true;
			btnLuu.Enabled = true;
			btnThem.Enabled = false;
			ResetValues();
			txtMaSanPham.Enabled = true;
			txtMaSanPham.Focus();
			txtSoLuong.Enabled = true;
			txtDonGiaBan.Enabled = true;
		}

		private void btnXoa_Click(object sender, EventArgs e)
		{
			string sql;
			if (tbSP.Rows.Count == 0)
			{
				MessageBox.Show("Không còn dữ liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
				return;
			}
			if (txtMaSanPham.Text == "")
			{
				MessageBox.Show("Bạn chưa chọn bản ghi nào", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
				return;
			}
			if (MessageBox.Show("Bạn có muốn xoá bản ghi này không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
			{
				sql = "DELETE SanPham WHERE MaSP=N'" + txtMaSanPham.Text + "'";
				data.ChangeData(sql);
				LoadDataGridView();
				ResetValues();
			}
		}

		private void btnSua_Click(object sender, EventArgs e)
		{
			string sql;
			if (tbSP.Rows.Count == 0)
			{
				MessageBox.Show("Không còn dữ liệu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
				return;
			}
			if (txtMaSanPham.Text == "")
			{
				MessageBox.Show("Bạn chưa chọn bản ghi nào", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
				txtMaSanPham.Focus();
				return;
			}
			if (txtTenSanPham.Text.Trim().Length == 0)
			{
				MessageBox.Show("Bạn phải nhập tên nhãn hiệu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
				txtTenSanPham.Focus();
				return;
			}
			if (cboMaNhanHieu.Text.Trim().Length == 0)
			{
				MessageBox.Show("Bạn phải nhập nhãn hiệu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
				cboMaNhanHieu.Focus();
				return;
			}
			if (txtAnh.Text.Trim().Length == 0)
			{
				MessageBox.Show("Bạn phải ảnh minh hoạ cho hàng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
				txtAnh.Focus();
				return;
			}
			sql = "UPDATE SanPham SET TenSP=N'" + txtTenSanPham.Text.Trim().ToString() +
				"',MaThuongHieu=N'" + cboMaNhanHieu.SelectedValue.ToString() +
				"',SoLuong=" + txtSoLuong.Text +
				",Anh='" + txtAnh.Text +  "' WHERE MaSP=N'" + txtMaSanPham.Text + "'";
			data.ChangeData(sql);
			LoadDataGridView();
			ResetValues();
			btnBoQua.Enabled = false;
		}

		private void btnLuu_Click(object sender, EventArgs e)
		{
			string sql;
			if (txtMaSanPham.Text.Trim().Length == 0)
			{
				MessageBox.Show("Bạn phải nhập mã sản phẩm", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
				txtMaSanPham.Focus();
				return;
			}
			if (txtTenSanPham.Text.Trim().Length == 0)
			{
				MessageBox.Show("Bạn phải nhập tên sản phẩm", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
				txtTenSanPham.Focus();
				return;
			}
			if (cboMaNhanHieu.Text.Trim().Length == 0)
			{
				MessageBox.Show("Bạn phải nhập nhãn hiệu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
				cboMaNhanHieu.Focus();
				return;
			}
			if (txtAnh.Text.Trim().Length == 0)
			{
				MessageBox.Show("Bạn phải chọn ảnh minh hoạ cho hàng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
				btnOpen.Focus();
				return;
			}
			sql = "SELECT MaThuongHieu FROM SanPham WHERE MaSP=N'" + txtMaSanPham.Text.Trim() + "'";
			if (data.ReadData(sql).Rows.Count > 0)
			{
				MessageBox.Show("Mã hàng này đã tồn tại, bạn phải chọn mã hàng khác", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
				txtMaSanPham.Focus();
				return;
			}
			sql = "INSERT INTO SanPham(MaSP,TenSP,MaThuongHieu,SoLuong,GiaBan,Anh) VALUES(N'"
				+ txtMaSanPham.Text.Trim() + "',N'" + txtTenSanPham.Text.Trim() +
				"',N'" + cboMaNhanHieu.SelectedValue.ToString() +
				"'," + txtSoLuong.Text.Trim() + "," + txtDonGiaBan.Text +
				",'" + txtAnh.Text +  "')";

			data.ReadData(sql);
			LoadDataGridView();
			//ResetValues();
			btnXoa.Enabled = true;
			btnThem.Enabled = true;
			btnSua.Enabled = true;
			btnBoQua.Enabled = false;
			btnLuu.Enabled = false;
			txtMaSanPham.Enabled = false;
		}

		private void btnBoQua_Click(object sender, EventArgs e)
		{
			ResetValues();
			btnXoa.Enabled = true;
			btnSua.Enabled = true;
			btnThem.Enabled = true;
			btnBoQua.Enabled = false;
			btnLuu.Enabled = false;
			txtMaSanPham.Enabled = false;
		}

		private void button1_Click(object sender, EventArgs e)
		{
			string sql;
			sql = "SELECT * FROM SanPham";
			tbSP = data.ReadData(sql);
			dgvSanPham.DataSource = tbSP;
		}

		private void btnDong_Click(object sender, EventArgs e)
		{
			this.Close();
		}

		private void btnOpen_Click(object sender, EventArgs e)
		{
			OpenFileDialog dlgOpen = new OpenFileDialog();
			dlgOpen.Filter = "Bitmap(*.bmp)|*.bmp|JPEG(*.jpg)|*.jpg|GIF(*.gif)|*.gif|All files(*.*)|*.*";
			dlgOpen.FilterIndex = 2;
			dlgOpen.Title = "Chọn ảnh minh hoạ cho sản phẩm";
			if (dlgOpen.ShowDialog() == DialogResult.OK)
			{
				picAnh.Image = Image.FromFile(dlgOpen.FileName);
				txtAnh.Text = dlgOpen.FileName;
			}
		}
	}
}
