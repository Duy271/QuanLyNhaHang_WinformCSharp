CREATE DATABASE QuanLyNhaHang;
USE QuanLyNhaHang;


CREATE TABLE Nguoi (
    MaNguoi NCHAR(10) NOT NULL PRIMARY KEY, 
    Ten NVARCHAR(50) NOT NULL,
    SoDienThoai NVARCHAR(15) NOT NULL,
    Email NVARCHAR(50) NOT NULL,
    DiaChi NVARCHAR(100) NOT NULL,
    NgaySinh DATE NOT NULL
);

CREATE TABLE NhanVien (
    MaNhanVien NCHAR(10) NOT NULL PRIMARY KEY,
    MaNguoi NCHAR(10) NOT NULL,
	AnhNhanVien VARCHAR(MAX) NOT NULL,
    ChucVu NVARCHAR(20) NOT NULL,
	TrangThai NVARCHAR(50) NOT NULL,
	CaLam NVARCHAR(50) NOT NULL,
	SoNgayNghi int NOT NULL,
    Luong DECIMAL(18,3),
    FOREIGN KEY (MaNguoi) REFERENCES Nguoi(MaNguoi)
);


CREATE TABLE KhachHang (
    MaKhachHang NCHAR(10) NOT NULL PRIMARY KEY,
    MaNguoi NCHAR(10) NOT NULL,
	Loai varchar(10),
    FOREIGN KEY (MaNguoi) REFERENCES Nguoi(MaNguoi)
);

CREATE TABLE Ban (
    MaBan NCHAR(10) NOT NULL PRIMARY KEY, 
    TrangThai NVARCHAR(10) NOT NULL,
    ViTri INT NOT NULL
);

CREATE TABLE LoaiMonAn (
    MaLoaiMonAn NCHAR(10) NOT NULL PRIMARY KEY, 
    TenLoaiMonAn NVARCHAR(50) NOT NULL
);

CREATE TABLE ThucDon (
    MaMonAn NCHAR(10) NOT NULL PRIMARY KEY, 
    TenMonAn NVARCHAR(50) NOT NULL,
    MaLoaiMonAn NCHAR(10) NOT NULL,
    DuongDanAnh NVARCHAR(255),
	TrangThai NVARCHAR(50),
    GiaBan DECIMAL(18,3) NOT NULL,
    FOREIGN KEY (MaLoaiMonAn) REFERENCES LoaiMonAn(MaLoaiMonAn)
);


CREATE TABLE DangKiTaiKhoan (
   
    TenDangNhap VARCHAR(50) NOT NULL PRIMARY KEY,
    MatKhau NVARCHAR(100) NOT NULL,
    TenHienThi NVARCHAR(50),
    Email NVARCHAR(50),
    DuongDanAnhDaiDien NVARCHAR(255), 
    ChucVu NVARCHAR(30) NOT NULL
);

insert into DangKiTaiKhoan values('di','6a56190da17334a40561511580c3a995',N'Nhà Hàng','a@gmail.com','Chua Co','admin')

CREATE TABLE DatMon (
    MaDatMon NCHAR(10) NOT NULL PRIMARY KEY, 
    NgayDatMon DATE NOT NULL,
    MaBan NCHAR(10) NOT NULL,
    TenDangNhap VARCHAR(50) NOT NULL,
    FOREIGN KEY (MaBan) REFERENCES Ban(MaBan),
    FOREIGN KEY (TenDangNhap) REFERENCES DangKiTaiKhoan(TenDangNhap)
);

CREATE TABLE ChiTietDatMon (
    MaChiTietDatMon NCHAR(10) NOT NULL PRIMARY KEY,
    MaDatMon NCHAR(10) NOT NULL,
    MaMonAn NCHAR(10) NOT NULL,
    SoLuong INT NOT NULL,
    GhiChu NVARCHAR(200), 
	TrangThai NVARCHAR(50) NOT NULL,
    FOREIGN KEY (MaDatMon) REFERENCES DatMon(MaDatMon),
    FOREIGN KEY (MaMonAn) REFERENCES ThucDon(MaMonAn)
);



CREATE TABLE ThanhToan (
    MaThanhToan NCHAR(10) NOT NULL PRIMARY KEY, 
    NgayThanhToan DATE NOT NULL,
    TongTien DECIMAL(18,3) NOT NULL,
    PhuongThucThanhToan NVARCHAR(10) CHECK (PhuongThucThanhToan IN (N'Tiền mặt', N'Thẻ')), 
    
    MaDatMon NCHAR(10) NOT NULL,
   
    FOREIGN KEY (MaDatMon) REFERENCES DatMon(MaDatMon)
);


select*from ThanhToan

INSERT INTO LoaiMonAn (MaLoaiMonAn, TenLoaiMonAn)
VALUES ('rice', 'Rice'),
       ('noodle', 'Noodle'),
       ('drink', 'Drink'),
	   ('special', 'Special')


INSERT INTO ThucDon (MaMonAn, TenMonAn, MaLoaiMonAn, DuongDanAnh,TrangThai, GiaBan)
VALUES ('M01', N'Cơm Chiên Trái Thơm', 'rice', 'chiengamatong.jpg',N'Con', 125.000),
		('M02', N'Cơm Chiên Ruốc Tôm', 'rice', 'gamatong.jpg',N'Con', 85.000),
       ('M03', N'Cơm Bò Xào Lá Quế', 'rice', 'gagungvang.jpg',N'Con', 130.000),
       ('M04', N'Hủ Tiếu Xào Kiểu Thái', 'noodle', 'trungchienhau.jpg',N'Con', 125.500),
       ('M05', N'Miến Xào Sukiyaki', 'noodle', 'trungchienhau.jpg',N'Con', 185.000),
       ('M06', N'Phở Xào Sốt Nâu', 'noodle', 'goibo.jpg',N'Con', 85.000),
       ('M07', N'Miến Hải Sản Nước Tôm Yum', 'noodle', 'mienapchao.jpg',N'Con', 85.000),
	   ('M08', N'Trà Xoài Chanh Dây', 'drink', 'dauhu.jpg',N'Con', 85.000),
	   ('M09', N'Trà Dưa Hấu Xoài', 'drink', 'banhcrep.jpg',N'Con', 85.000),
	   ('M10', N'Trà Phúc Bồn Tử', 'drink', 'tomyumnam.jpg',N'Con', 85.000),
	   ('M11', N'Bánh Crep Thái', 'special', 'banhcrep.jpg',N'Con', 85.000)

	   -- Thêm dữ liệu vào bảng Nguoi (đảm bảo rằng có dữ liệu trong bảng Nguoi trước)
INSERT INTO Nguoi (MaNguoi, Ten, SoDienThoai, Email, DiaChi, NgaySinh)
VALUES
    ('NV001', 'Nguyen Van A', '123456789', 'nva@example.com', '123 Duong X, Quan Y, TP. Ho Chi Minh', '1990-01-01'),
    ('NV002', 'Tran Thi B', '987654321', 'ttb@example.com', '456 Duong Y, Quan X, TP. Ho Chi Minh', '1995-02-15'),
    ('NV003', 'Le Van C', '456123789', 'lvc@example.com', '789 Duong Z, Quan Z, TP. Ho Chi Minh', '1988-07-10'),
    ('NV004', 'Pham Thi D', '321654987', 'ptd@example.com', '101 Duong K, Quan M, TP. Ho Chi Minh', '1992-11-30');

-- Thêm dữ liệu vào bảng NhanVien
INSERT INTO NhanVien (MaNhanVien, MaNguoi, AnhNhanVien, ChucVu, TrangThai, CaLam, SoNgayNghi, Luong)
VALUES
    ('NV001', 'NV001', 'avt.jpg', 'Quan ly', 'Hoat dong', 'Ca 1', 25, 10000000.000),
    ('NV002', 'NV002', 'avt.jpg', 'Nhan vien', 'Nghi viec', 'Ca 2', 20, 8000000.000),
    ('NV003', 'NV003', 'avt.jpg', 'Nhan vien', 'Hoat dong', 'Ca 3', 22, 8500000.000),
    ('NV004', 'NV004', 'avt.jpg', 'Quan ly', 'Nghi viec', 'Ca 1', 18, 12000000.000);

INSERT INTO Ban (MaBan, TrangThai, ViTri)
VALUES
    ('Ban01', N'Trong', 1),
    ('Ban02', N'Co', 2),
    ('Ban03', N'Co', 3),
    ('Ban04', N'Trong', 4),
    ('Ban05', N'Trong', 5),
    ('Ban06', N'Trong', 6),
    ('Ban07', N'Co', 7),
    ('Ban08', N'Trong', 8),
    ('Ban09', N'Trong', 9),
    ('Ban10', N'Trong', 10);
