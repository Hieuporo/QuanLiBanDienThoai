create database QLDienThoai
go 

use QLDienThoai
go

create table ThuongHieu(
	MaThuongHieu nvarchar(50) primary key ,
	TenThuongHieu nvarchar(50) not null
)
go

create table TaiKhoan(
	TaiKhoan  nvarchar(50) primary key ,
	MatKhau nvarchar(50) not null,
)
go

insert into TaiKhoan( TaiKhoan, MatKhau ) Values('admin' , 'admin')

create table NhanVien(
	MaNV  nvarchar(50) primary key ,
	TenNV nvarchar(50) not null,
	GioiTinh nvarchar(50) not null,
	DienThoai nvarchar(50) not null,	
)
go

create table KhachHang(
	MaKH  nvarchar(50) primary key ,
	TenKH nvarchar(50) not null,
	DiaChi nvarchar(50) not null,
	DienThoai nvarchar(50) not null,	
)
go


create table SanPham(
	MaSP  nvarchar(50) primary key ,
	TenSP nvarchar(50) not null,
	MaThuongHieu nvarchar(50) not null FOREIGN KEY REFERENCES ThuongHieu(MaThuongHieu),
	SoLuong int not null,
	GiaBan float not null ,
	Anh nvarchar(200) not null,
)
go


create table HoaDonBan(
	MaHD  nvarchar(50) primary key ,
	MaNV nvarchar(50) not null FOREIGN KEY REFERENCES NhanVien(MaNV),
	NgayBan datetime not null ,
	MaKH nvarchar(50) not null FOREIGN KEY REFERENCES KhachHang(MaKH),
	TongTien float not null ,
)
go


create table ChiTietHD(
	MaHD nvarchar(50) FOREIGN KEY REFERENCES HoaDonBan(MaHD) ,
	MaSP nvarchar(50) FOREIGN KEY REFERENCES SanPham(MaSP),
	PRIMARY KEY (MaHD, MaSP),
	SoLuong int not null,
	TongTien float not null
)
go