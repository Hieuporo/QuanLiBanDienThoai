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
	public partial class frmHoaDonBan : Form
	{
		Functions func = new Functions();
		ConnectData data = new ConnectData();
		DataTable tblCTHDB; 
		public frmHoaDonBan()
		{
			InitializeComponent();
		}

		private void frmHoaDonBan_Load(object sender, EventArgs e)
		{
			btnThem.Enabled = true;
			btnLuu.Enabled = false;
			btnXoa.Enabled = false;
			btnInHoaDon.Enabled = false;
			txtMaHDBan.ReadOnly = true;
			txtTenNhanVien.ReadOnly = true;
			txtTenKhach.ReadOnly = true;
			txtDiaChi.ReadOnly = true;
			txtDienThoai.ReadOnly = true;
			txtTenHang.ReadOnly = true;
			txtDonGiaBan.ReadOnly = true;
			txtTongTien.ReadOnly = true;
			txtTongTien.Text = "0";
			func.FillComboBox( cboMaKhach, data.ReadData("SELECT MaKH, TenKH FROM KhachHang") , "TenKH", "MaKH");
			cboMaKhach.SelectedIndex = -1;
			func.FillComboBox(cboMaNhanVien, data.ReadData("SELECT MaNV, TenNV FROM NhanVien"), "TenNV", "MaNV");
			cboMaNhanVien.SelectedIndex = -1;
			func.FillComboBox(cboMaHang, data.ReadData("SELECT MaSP, TenSP FROM SanPham"), "TenSP", "MaSP");
			cboMaHang.SelectedIndex = -1;
			//Hiển thị thông tin của một hóa đơn được gọi từ form tìm kiếm
			if (txtMaHDBan.Text != "")
			{
				LoadInfoHoaDon();
				btnXoa.Enabled = true;
				btnInHoaDon.Enabled = true;
			}
			LoadDataGridView();
		}

		private void LoadDataGridView()
		{
			string sql;
			sql = "SELECT a.MaSP, b.TenSP, a.SoLuong, b.GiaBan FROM ChiTietHD AS a, SanPham AS b WHERE a.MaHDBan = N'" + txtMaHDBan.Text + "' AND a.MaSP=b.MaSP";
			tblCTHDB = data.ReadData(sql);
			dgvHDBanHang.DataSource = tblCTHDB;
			dgvHDBanHang.Columns[0].HeaderText = "Mã sản phẩm";
			dgvHDBanHang.Columns[1].HeaderText = "Tên sản phẩm";
			dgvHDBanHang.Columns[2].HeaderText = "Số lượng";
			dgvHDBanHang.Columns[3].HeaderText = "Đơn giá";
			dgvHDBanHang.Columns[0].Width = 80;
			dgvHDBanHang.Columns[1].Width = 130;
			dgvHDBanHang.Columns[2].Width = 80;
			dgvHDBanHang.Columns[3].Width = 90;
			dgvHDBanHang.AllowUserToAddRows = false;
			dgvHDBanHang.EditMode = DataGridViewEditMode.EditProgrammatically;
		}

		private void LoadInfoHoaDon()
		{
			string str;
			str = "SELECT NgayBan FROM HoaDonBan WHERE MaHDBan = N'" + txtMaHDBan.Text + "'";
			txtNgayBan.Text = Functions.ConvertDateTime(data.GetFieldValues(str));
			str = "SELECT MaNV FROM HoaDonBan WHERE MaHDBan = N'" + txtMaHDBan.Text + "'";
			cboMaNhanVien.Text = data.GetFieldValues(str);
			str = "SELECT MaKhach FROM HoaDonBan WHERE MaHDBan = N'" + txtMaHDBan.Text + "'";
			cboMaKhach.Text = data.GetFieldValues(str);
			str = "SELECT TongTien FROM HoaDonBan WHERE MaHDBan = N'" + txtMaHDBan.Text + "'";
			txtTongTien.Text = data.GetFieldValues(str);
		}

		private void ResetValues()
		{
			txtMaHDBan.Text = "";
			txtNgayBan.Text = DateTime.Now.ToShortDateString();
			cboMaNhanVien.Text = "";
			cboMaKhach.Text = "";
			txtTongTien.Text = "0";
			cboMaHang.Text = "";
			txtSoLuong.Text = "";
		}
		private void btnThem_Click(object sender, EventArgs e)
		{
			btnXoa.Enabled = false;
			btnLuu.Enabled = true;
			btnInHoaDon.Enabled = false;
			btnThem.Enabled = false;
			ResetValues();
			txtMaHDBan.Text = Functions.CreateKey("HDB");
			LoadDataGridView();
		}

		private void ResetValuesHang()
		{
			cboMaHang.Text = "";
			txtSoLuong.Text = "";
		}


		private void btnLuu_Click(object sender, EventArgs e)
		{
			string sql;
			double sl, SLcon, tong, Tongmoi;
			sql = "SELECT MaHDBan FROM HoaDonBan WHERE MaHDBan=N'" + txtMaHDBan.Text + "'";
			if (data.ReadData(sql).Rows.Count > 0)
			{
				// Mã hóa đơn chưa có, tiến hành lưu các thông tin chung
				// Mã HDBan được sinh tự động do đó không có trường hợp trùng khóa
				if (txtNgayBan.Text.Length == 0)
				{
					MessageBox.Show("Bạn phải nhập ngày bán", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
					txtNgayBan.Focus();
					return;
				}
				if (cboMaNhanVien.Text.Length == 0)
				{
					MessageBox.Show("Bạn phải nhập nhân viên", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
					cboMaNhanVien.Focus();
					return;
				}
				if (cboMaKhach.Text.Length == 0)
				{
					MessageBox.Show("Bạn phải nhập khách hàng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
					cboMaKhach.Focus();
					return;
				}
				sql = "INSERT INTO HoaDonBan(MaHDBan, NgayBan, MaNV, MaKH, TongTien) VALUES (N'" + txtMaHDBan.Text.Trim() + "','" +
						Functions.ConvertDateTime(txtNgayBan.Text.Trim()) + "',N'" + cboMaNhanVien.SelectedValue + "',N'" +
						cboMaKhach.SelectedValue + "'," + txtTongTien.Text + ")";
				data.ChangeData(sql);
			}
			// Lưu thông tin của các mặt hàng
			if (cboMaHang.Text.Trim().Length == 0)
			{
				MessageBox.Show("Bạn phải nhập mã hàng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
				cboMaHang.Focus();
				return;
			}
			if ((txtSoLuong.Text.Trim().Length == 0) || (txtSoLuong.Text == "0"))
			{
				MessageBox.Show("Bạn phải nhập số lượng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
				txtSoLuong.Text = "";
				txtSoLuong.Focus();
				return;
			}
			
			sql = "SELECT MaHang FROM ChiTietHD WHERE MaSP=N'" + cboMaHang.SelectedValue + "' AND MaHDBan = N'" + txtMaHDBan.Text.Trim() + "'";
			if (data.ReadData(sql).Rows.Count > 0)
			{
				MessageBox.Show("Mã hàng này đã có, bạn phải nhập mã khác", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
				ResetValuesHang();
				cboMaHang.Focus();
				return;
			}
			// Kiểm tra xem số lượng hàng trong kho còn đủ để cung cấp không?
			sl = Convert.ToDouble(data.GetFieldValues("SELECT SoLuong FROM SanPham WHERE MaSP = N'" + cboMaHang.SelectedValue + "'"));
			if (Convert.ToDouble(txtSoLuong.Text) > sl)
			{
				MessageBox.Show("Số lượng mặt hàng này chỉ còn " + sl, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
				txtSoLuong.Text = "";
				txtSoLuong.Focus();
				return;
			}
			sql = "INSERT INTO ChiTietHD(MaHDBan,MaSP,SoLuong,ThanhTien) VALUES(N'" + txtMaHDBan.Text.Trim() + "',N'" + cboMaHang.SelectedValue + "'," + txtSoLuong.Text + "," + txtDonGiaBan.Text +  ")";
			data.ChangeData(sql);
			LoadDataGridView();
			// Cập nhật lại số lượng của mặt hàng vào bảng SanPham
			SLcon = sl - Convert.ToDouble(txtSoLuong.Text);
			sql = "UPDATE SanPham SET SoLuong =" + SLcon + " WHERE MaHang= N'" + cboMaHang.SelectedValue + "'";
			data.ChangeData(sql);
			// Cập nhật lại tổng tiền cho hóa đơn bán
			tong = Convert.ToDouble(data.GetFieldValues("SELECT TongTien FROM ChiTietHD WHERE MaHDBan = N'" + txtMaHDBan.Text + "'"));
			Tongmoi = tong + Convert.ToDouble(txtThanhTien.Text);
			sql = "UPDATE HoaDonBan SET TongTien =" + Tongmoi + " WHERE MaHDBan = N'" + txtMaHDBan.Text + "'";
			data.ChangeData(sql);
			txtTongTien.Text = Tongmoi.ToString();
			ResetValuesHang();
			btnXoa.Enabled = true;
			btnThem.Enabled = true;
			btnInHoaDon.Enabled = true;
		}

		private void btnXoa_Click(object sender, EventArgs e)
		{
			double sl, slcon, slxoa;
			if (MessageBox.Show("Bạn có chắc chắn muốn xóa không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
			{
				string sql = "SELECT MaSP, SoLuong FROM ChiTietHD WHERE MaHDBan = N'" + txtMaHDBan.Text + "'";
				DataTable tblHang = data.ReadData(sql);
				for (int hang = 0; hang <= tblHang.Rows.Count - 1; hang++)
				{
					// Cập nhật lại số lượng cho các mặt hàng
					sl = Convert.ToDouble(data.GetFieldValues("SELECT SoLuong FROM SanPham WHERE MaSP = N'" + tblHang.Rows[hang][0].ToString() + "'"));
					slxoa = Convert.ToDouble(tblHang.Rows[hang][1].ToString());
					slcon = sl + slxoa;
					sql = "UPDATE SanPham SET SoLuong =" + slcon + " WHERE MaSP= N'" + tblHang.Rows[hang][0].ToString() + "'";
					data.ChangeData(sql);
				}

				//Xóa chi tiết hóa đơn
				sql = "DELETE ChiTietHD WHERE MaHDBan=N'" + txtMaHDBan.Text + "'";
				data.ChangeData(sql);


				//Xóa hóa đơn
				sql = "DELETE HoaDonBan WHERE MaHDBan=N'" + txtMaHDBan.Text + "'";
				data.ChangeData(sql);

				ResetValues();
				LoadDataGridView();
				btnXoa.Enabled = false;
				btnInHoaDon.Enabled = false;
			}
		}

		private void btnInHoaDon_Click(object sender, EventArgs e)
		{

		}

		private void btnDong_Click(object sender, EventArgs e)
		{
			if (cboMaHDBan.Text == "")
			{
				MessageBox.Show("Bạn phải chọn một mã hóa đơn để tìm", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
				cboMaHDBan.Focus();
				return;
			}
			txtMaHDBan.Text = cboMaHDBan.Text;
			LoadInfoHoadon();
			LoadDataGridView();
			btnXoa.Enabled = true;
			btnLuu.Enabled = true;
			btnInHoaDon.Enabled = true;
			cboMaHDBan.SelectedIndex = -1;
		}

		
		private void btnTimKiem_Click(object sender, EventArgs e)
		{

		}

		private void dgvHDBanHang_DoubleClick(object sender, EventArgs e)
		{
			string MaHangxoa, sql;
			Double ThanhTienxoa, SoLuongxoa, sl, slcon, tong, tongmoi;
			if (tblCTHDB.Rows.Count == 0)
			{
				MessageBox.Show("Không có dữ liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
				return;
			}
			if ((MessageBox.Show("Bạn có chắc chắn muốn xóa không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes))
			{
				//Xóa hàng và cập nhật lại số lượng hàng 
				MaHangxoa = dgvHDBanHang.CurrentRow.Cells["MaSP"].Value.ToString();
				SoLuongxoa = Convert.ToDouble(dgvHDBanHang.CurrentRow.Cells["SoLuong"].Value.ToString());
				ThanhTienxoa = Convert.ToDouble(dgvHDBanHang.CurrentRow.Cells["TongTien"].Value.ToString());
				sql = "DELETE ChiTietHD WHERE MaHDBan=N'" + txtMaHDBan.Text + "' AND MaSP = N'" + MaHangxoa + "'";
				data.ChangeData(sql);
				// Cập nhật lại số lượng cho các mặt hàng
				sl = Convert.ToDouble(data.GetFieldValues("SELECT SoLuong FROM SanPham WHERE MaSP = N'" + MaHangxoa + "'"));
				slcon = sl + SoLuongxoa;
				sql = "UPDATE tblHang SET SoLuong =" + slcon + " WHERE MaHang= N'" + MaHangxoa + "'";
				data.ChangeData(sql);
				// Cập nhật lại tổng tiền cho hóa đơn bán
				tong = Convert.ToDouble(data.GetFieldValues("SELECT TongTien FROM HoaDonBan WHERE MaHDBan = N'" + txtMaHDBan.Text + "'"));
				tongmoi = tong - ThanhTienxoa;
				sql = "UPDATE HoaDonBan SET TongTien =" + tongmoi + " WHERE MaHDBan = N'" + txtMaHDBan.Text + "'";
				data.ChangeData(sql);
				txtTongTien.Text = tongmoi.ToString();
				LoadDataGridView();
			}
		}

		private void t(object sender, EventArgs e)
		{

		}

		private void cboMaKhach_TextChanged(object sender, EventArgs e)
		{
			string str;
			if (cboMaKhach.Text == "")
			{
				txtTenKhach.Text = "";
				txtDiaChi.Text = "";
				txtDienThoai.Text = "";
			}
			//Khi chọn Mã khách hàng thì các thông tin của khách hàng sẽ hiện ra
			str = "Select TenKhach from tblKhach where MaKH = N'" + cboMaKhach.SelectedValue + "'";
			txtTenKhach.Text = data.GetFieldValues(str);
			str = "Select DiaChi from tblKhach where MaKH = N'" + cboMaKhach.SelectedValue + "'";
			txtDiaChi.Text = data.GetFieldValues(str);
			str = "Select DienThoai from tblKhach where MaKH= N'" + cboMaKhach.SelectedValue + "'";
			txtDienThoai.Text = data.GetFieldValues(str);
		}

		private void cboMaNhanVien_SelectedIndexChanged(object sender, EventArgs e)
		{
			string str;
			if (cboMaNhanVien.Text == "")
				txtTenNhanVien.Text = "";
			// Khi chọn Mã nhân viên thì tên nhân viên tự động hiện ra
			str = "Select TenNV from NhanVien where MaNV =N'" + cboMaNhanVien.SelectedValue + "'";
			txtTenNhanVien.Text = data.GetFieldValues(str);
		}

		private void cboMaHang_TextChanged(object sender, EventArgs e)
		{
			string str;
			if (cboMaHang.Text == "")
			{
				txtTenHang.Text = "";
				txtDonGiaBan.Text = "";
			}
			// Khi chọn mã sản phẩm thì các thông tin về sp hiện ra
			str = "SELECT TenSP FROM SanPham WHERE MaSP =N'" + cboMaHang.SelectedValue + "'";
			txtTenHang.Text = data.GetFieldValues(str);
			str = "SELECT DonGiaBan FROM SanPham WHERE MaSP =N'" + cboMaHang.SelectedValue + "'";
			txtDonGiaBan.Text = data.GetFieldValues(str);
		}

		private void txtSoLuong_TextChanged(object sender, EventArgs e)
		{
			//Khi thay đổi số lượng thì thực hiện tính lại thành tiền
			double tt, sl, dg;
			if (txtSoLuong.Text == "")
				sl = 0;
			else
				sl = Convert.ToDouble(txtSoLuong.Text);
			if (txtDonGiaBan.Text == "")
				dg = 0;
			else
				dg = Convert.ToDouble(txtDonGiaBan.Text);
			tt = sl * dg ;
			txtThanhTien.Text = tt.ToString();
		}
	}
}
