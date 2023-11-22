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
using COMExcel = Microsoft.Office.Interop.Excel;

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

		private void LoadInfoHoaDon()
		{
			string str;
			str = "SELECT NgayBan FROM HoaDonBan WHERE MaHD = N'" + txtMaHDBan.Text + "'";
			txtNgayBan.Text = Functions.ConvertDateTime(data.GetFieldValues(str));
			str = "SELECT MaNV FROM HoaDonBan WHERE MaHD = N'" + txtMaHDBan.Text + "'";
			cboMaNhanVien.Text = data.GetFieldValues(str);
			str = "SELECT MaKH FROM HoaDonBan WHERE MaHD = N'" + txtMaHDBan.Text + "'";
			cboMaKhach.Text = data.GetFieldValues(str);
			str = "SELECT TongTien FROM HoaDonBan WHERE MaHD = N'" + txtMaHDBan.Text + "'";
			txtTongTien.Text = data.GetFieldValues(str);
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
			func.FillComboBox( cboMaKhach, data.ReadData("SELECT MaKH, TenKH FROM KhachHang") , "MaKH", "MaKH");
			cboMaKhach.SelectedIndex = -1;
			func.FillComboBox(cboMaNhanVien, data.ReadData("SELECT MaNV, TenNV FROM NhanVien"), "MaNV", "MaNV");
			cboMaNhanVien.SelectedIndex = -1;
			func.FillComboBox(cboMaHang, data.ReadData("SELECT MaSP, TenSP FROM SanPham"), "MaSP", "MaSP");
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
			sql = "SELECT a.MaSP, b.TenSP, a.SoLuong, b.GiaBan FROM ChiTietHD AS a, SanPham AS b WHERE a.MaHD = N'" + txtMaHDBan.Text + "' AND a.MaSP=b.MaSP";
			tblCTHDB = data.ReadData(sql);
			dgvHDBanHang.DataSource = tblCTHDB;
			dgvHDBanHang.Columns[0].HeaderText = "Mã sản phẩm";
			dgvHDBanHang.Columns[1].HeaderText = "Tên sản phẩm";
			dgvHDBanHang.Columns[2].HeaderText = "Số lượng";
			dgvHDBanHang.Columns[3].HeaderText = "Đơn giá";
			dgvHDBanHang.Columns[0].Width = 180;
			dgvHDBanHang.Columns[1].Width = 230;
			dgvHDBanHang.Columns[2].Width = 180;
			dgvHDBanHang.Columns[3].Width = 190;
			dgvHDBanHang.AllowUserToAddRows = false;
			dgvHDBanHang.EditMode = DataGridViewEditMode.EditProgrammatically;
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
			sql = "SELECT MaHD FROM HoaDonBan WHERE MaHD=N'" + txtMaHDBan.Text + "'";
			if (data.ReadData(sql).Rows.Count == 0)
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
				sql = "INSERT INTO HoaDonBan(MaHD, NgayBan, MaNV, MaKH, TongTien) VALUES (N'" + txtMaHDBan.Text.Trim() + "','" +
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
			
			sql = "SELECT MaSP FROM ChiTietHD WHERE MaSP=N'" + cboMaHang.SelectedValue + "' AND MaHD = N'" + txtMaHDBan.Text.Trim() + "'";
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
			sql = "INSERT INTO ChiTietHD(MaHD,MaSP,SoLuong,TongTien) VALUES(N'" + txtMaHDBan.Text.Trim() + "',N'" + cboMaHang.SelectedValue + "'," + txtSoLuong.Text + "," + txtDonGiaBan.Text +  ")";
			data.ChangeData(sql);
			LoadDataGridView();
			// Cập nhật lại số lượng của mặt hàng vào bảng SanPham
			SLcon = sl - Convert.ToDouble(txtSoLuong.Text);
			sql = "UPDATE SanPham SET SoLuong =" + SLcon + " WHERE MaSP= N'" + cboMaHang.SelectedValue + "'";
			data.ChangeData(sql);
			// Cập nhật lại tổng tiền cho hóa đơn bán
			tong = Convert.ToDouble(data.GetFieldValues("SELECT TongTien FROM ChiTietHD WHERE MaHD = N'" + txtMaHDBan.Text + "'"));
			Tongmoi = tong + Convert.ToDouble(txtTongTien.Text);
			sql = "UPDATE HoaDonBan SET TongTien =" + Tongmoi + " WHERE MaHD = N'" + txtMaHDBan.Text + "'";
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
				string sql = "SELECT MaSP, SoLuong FROM ChiTietHD WHERE MaHD = N'" + txtMaHDBan.Text + "'";
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
				sql = "DELETE ChiTietHD WHERE MaHD=N'" + txtMaHDBan.Text + "'";
				data.ChangeData(sql);


				//Xóa hóa đơn
				sql = "DELETE HoaDonBan WHERE MaHD=N'" + txtMaHDBan.Text + "'";
				data.ChangeData(sql);

				ResetValues();
				LoadDataGridView();
				btnXoa.Enabled = false;
				btnInHoaDon.Enabled = false;
			}
		}

		private void btnInHoaDon_Click(object sender, EventArgs e)
		{
			COMExcel.Application exApp = new COMExcel.Application();
			COMExcel.Workbook exBook; //Trong 1 chương trình Excel có nhiều Workbook
			COMExcel.Worksheet exSheet; //Trong 1 Workbook có nhiều Worksheet
			COMExcel.Range exRange;
			string sql;
			int hang = 0, cot = 0;
			DataTable tblThongtinHD, tblThongtinHang;
			exBook = exApp.Workbooks.Add(COMExcel.XlWBATemplate.xlWBATWorksheet);
			exSheet = exBook.Worksheets[1];
			// Định dạng chung
			exRange = exSheet.Cells[1, 1];
			exRange.Range["A1:Z300"].Font.Name = "Times new roman"; //Font chữ
			exRange.Range["A1:B3"].Font.Size = 10;
			exRange.Range["A1:B3"].Font.Bold = true;
			exRange.Range["A1:B3"].Font.ColorIndex = 5; //Màu xanh da trời
			exRange.Range["A1:A1"].ColumnWidth = 7;
			exRange.Range["B1:B1"].ColumnWidth = 15;
			exRange.Range["A1:B1"].MergeCells = true;
			exRange.Range["A1:B1"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
			exRange.Range["A1:B1"].Value = "Trung Hieu Shop";
			exRange.Range["A2:B2"].MergeCells = true;
			exRange.Range["A2:B2"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
			exRange.Range["A2:B2"].Value = "UTC - Hà Nội";
			exRange.Range["A3:B3"].MergeCells = true;
			exRange.Range["A3:B3"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
			exRange.Range["A3:B3"].Value = "Điện thoại: (04)1232323";
			exRange.Range["C2:E2"].Font.Size = 16;
			exRange.Range["C2:E2"].Font.Bold = true;
			exRange.Range["C2:E2"].Font.ColorIndex = 3; //Màu đỏ
			exRange.Range["C2:E2"].MergeCells = true;
			exRange.Range["C2:E2"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
			exRange.Range["C2:E2"].Value = "HÓA ĐƠN BÁN";
			// Biểu diễn thông tin chung của hóa đơn bán
			sql = "SELECT a.MaHD, a.NgayBan, a.TongTien, b.TenKH, b.DiaChi, b.DienThoai, c.TenNV FROM HoaDonBan AS a, KhachHang AS b, NhanVien AS c WHERE a.MaHD = N'" + txtMaHDBan.Text + "' AND a.MaKH = b.MaKH AND a.MaNV = c.MaNV";
			tblThongtinHD = data.ReadData(sql);
			exRange.Range["B6:C9"].Font.Size = 12;
			exRange.Range["B6:B6"].Value = "Mã hóa đơn:";
			exRange.Range["C6:E6"].MergeCells = true;
			exRange.Range["C6:E6"].Value = tblThongtinHD.Rows[0][0].ToString();
			exRange.Range["B7:B7"].Value = "Khách hàng:";
			exRange.Range["C7:E7"].MergeCells = true;
			exRange.Range["C7:E7"].Value = tblThongtinHD.Rows[0][3].ToString();
			exRange.Range["B8:B8"].Value = "Địa chỉ:";
			exRange.Range["C8:E8"].MergeCells = true;
			exRange.Range["C8:E8"].Value = tblThongtinHD.Rows[0][4].ToString();
			exRange.Range["B9:B9"].Value = "Điện thoại:";
			exRange.Range["C9:E9"].MergeCells = true;
			exRange.Range["C9:E9"].Value = tblThongtinHD.Rows[0][5].ToString();
			//Lấy thông tin các mặt hàng
			sql = "SELECT b.TenSP, a.SoLuong, b.GiaBan, a.TongTien " +
				  "FROM ChiTietHD AS a ,SanPham AS b WHERE a.MaHD = N'" +
				  txtMaHDBan.Text + "' AND a.MaSP = b.MaSP";
			tblThongtinHang = data.ReadData(sql);
			//Tạo dòng tiêu đề bảng
			exRange.Range["A11:F11"].Font.Bold = true;
			exRange.Range["A11:F11"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
			exRange.Range["C11:F11"].ColumnWidth = 12;
			exRange.Range["A11:A11"].Value = "STT";
			exRange.Range["B11:B11"].Value = "Tên hàng";
			exRange.Range["C11:C11"].Value = "Số lượng";
			exRange.Range["D11:D11"].Value = "Đơn giá";
			exRange.Range["E11:E11"].Value = "Thành tiền";
			for (hang = 0; hang < tblThongtinHang.Rows.Count; hang++)
			{
				//Điền số thứ tự vào cột 1 từ dòng 12
				exSheet.Cells[1][hang + 12] = hang + 1;
				for (cot = 0; cot < tblThongtinHang.Columns.Count; cot++)
				//Điền thông tin hàng từ cột thứ 2, dòng 12
				{
					exSheet.Cells[cot + 2][hang + 12] = tblThongtinHang.Rows[hang][cot].ToString();
					if (cot == 3) exSheet.Cells[cot + 2][hang + 12] = tblThongtinHang.Rows[hang][cot].ToString() ;
				}
			}
			exRange = exSheet.Cells[cot][hang + 14];
			exRange.Font.Bold = true;
			exRange.Value2 = "Tổng tiền:";
			exRange = exSheet.Cells[cot + 1][hang + 14];
			exRange.Font.Bold = true;
			exRange.Value2 = tblThongtinHD.Rows[0][2].ToString();
			exRange = exSheet.Cells[1][hang + 15]; //Ô A1 
			exRange.Range["A1:F1"].MergeCells = true;
			exRange.Range["A1:F1"].Font.Bold = true;
			exRange.Range["A1:F1"].Font.Italic = true;
			exRange.Range["A1:F1"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignRight;
			exRange = exSheet.Cells[4][hang + 17]; //Ô A1 
			exRange.Range["A1:C1"].MergeCells = true;
			exRange.Range["A1:C1"].Font.Italic = true;
			exRange.Range["A1:C1"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
			DateTime d = Convert.ToDateTime(tblThongtinHD.Rows[0][1]);
			exRange.Range["A1:C1"].Value = "Hà Nội, ngày " + d.Day + " tháng " + d.Month + " năm " + d.Year;
			exRange.Range["A2:C2"].MergeCells = true;
			exRange.Range["A2:C2"].Font.Italic = true;
			exRange.Range["A2:C2"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
			exRange.Range["A2:C2"].Value = "Nhân viên bán hàng";
			exRange.Range["A6:C6"].MergeCells = true;
			exRange.Range["A6:C6"].Font.Italic = true;
			exRange.Range["A6:C6"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
			exRange.Range["A6:C6"].Value = tblThongtinHD.Rows[0][6];
			exSheet.Name = "Hóa đơn nhập";
			exApp.Visible = true;
		}

		private void btnDong_Click(object sender, EventArgs e)
		{
			this.Close();
		}

		
		private void btnTimKiem_Click(object sender, EventArgs e)
		{

			if (cboMaHDBan.Text == "")
			{
				MessageBox.Show("Bạn phải chọn một mã hóa đơn để tìm", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
				cboMaHDBan.Focus();
				return;
			}
			txtMaHDBan.Text = cboMaHDBan.Text;
			LoadInfoHoaDon();
			LoadDataGridView();
			btnXoa.Enabled = true;
			btnLuu.Enabled = true;
			btnInHoaDon.Enabled = true;
			cboMaHDBan.SelectedIndex = -1;
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
				sql = "DELETE ChiTietHD WHERE MaHD=N'" + txtMaHDBan.Text + "' AND MaSP = N'" + MaHangxoa + "'";
				data.ChangeData(sql);
				// Cập nhật lại số lượng cho các mặt hàng
				sl = Convert.ToDouble(data.GetFieldValues("SELECT SoLuong FROM SanPham WHERE MaSP = N'" + MaHangxoa + "'"));
				slcon = sl + SoLuongxoa;
				sql = "UPDATE tblHang SET SoLuong =" + slcon + " WHERE MaHang= N'" + MaHangxoa + "'";
				data.ChangeData(sql);
				// Cập nhật lại tổng tiền cho hóa đơn bán
				tong = Convert.ToDouble(data.GetFieldValues("SELECT TongTien FROM HoaDonBan WHERE MaHD = N'" + txtMaHDBan.Text + "'"));
				tongmoi = tong - ThanhTienxoa;
				sql = "UPDATE HoaDonBan SET TongTien =" + tongmoi + " WHERE MaHD = N'" + txtMaHDBan.Text + "'";
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
			str = "Select TenKH from KhachHang where MaKH = N'" + cboMaKhach.SelectedValue + "'";
			txtTenKhach.Text = data.GetFieldValues(str);
			str = "Select DiaChi from KhachHang where MaKH = N'" + cboMaKhach.SelectedValue + "'";
			txtDiaChi.Text = data.GetFieldValues(str);
			str = "Select DienThoai from KhachHang where MaKH= N'" + cboMaKhach.SelectedValue + "'";
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
			str = "SELECT GiaBan FROM SanPham WHERE MaSP =N'" + cboMaHang.SelectedValue + "'";
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

		private void txtSoLuong_KeyPress(object sender, KeyPressEventArgs e)
		{
			if (((e.KeyChar >= '0') && (e.KeyChar <= '9')) || (Convert.ToInt32(e.KeyChar) == 8))
				e.Handled = false;
			else e.Handled = true;
		}

		private void cboMaHDBan_DropDown(object sender, EventArgs e)
		{
			func.FillComboBox(cboMaHDBan, data.ReadData("SELECT MaHD FROM HoaDonBan"), "MaHD", "MaHD");
			cboMaHDBan.SelectedIndex = -1;
		}

		private void frmHoaDonBan_FormClosing(object sender, FormClosingEventArgs e)
		{
			//Xóa dữ liệu trong các điều khiển trước khi đóng Form
			ResetValues();
		}



		private void cboMaHang_SelectedIndexChanged(object sender, EventArgs e)
		{

		}

		private void cboMaKhach_SelectedIndexChanged(object sender, EventArgs e)
		{

		}

		private void dgvHDBanHang_CellContentClick(object sender, DataGridViewCellEventArgs e)
		{

		}
	}
}
