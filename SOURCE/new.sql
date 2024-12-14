USE master;
GO

IF EXISTS (SELECT name FROM sys.databases WHERE name = 'QUANLYSHOPHOA_NEW')
BEGIN
    DROP DATABASE QUANLYSHOPHOA_NEW;
END
GO
-- Tạo cơ sở dữ liệu và sử dụng cơ sở dữ liệu
CREATE DATABASE QUANLYSHOPHOA_NEW;
GO
USE QUANLYSHOPHOA_NEW;
GO

-- Tạo bảng LoaiSanPham
CREATE TABLE LoaiSanPham (
    MaLoai INT IDENTITY(1,1) PRIMARY KEY,
    TenLoai NVARCHAR(50) COLLATE Vietnamese_CI_AS NOT NULL
);

-- Tạo bảng Hoa
CREATE TABLE Hoa (
    MaSanPham INT IDENTITY(1,1) PRIMARY KEY,
    TenSanPham NVARCHAR(255) COLLATE Vietnamese_CI_AS NOT NULL,
    HinhAnh NVARCHAR(255) NULL,
    MoTa NVARCHAR(255) COLLATE Vietnamese_CI_AS,
    Gia DECIMAL(10, 2) NOT NULL CHECK (Gia > 0),
    DonVi NVARCHAR(10),
    SoLuong INT,
    HanSuDung DATETIME,
    MaLoai INT,
    CONSTRAINT FK_Hoa_LoaiSanPham FOREIGN KEY (MaLoai) REFERENCES LoaiSanPham(MaLoai)
);

CREATE TABLE NhomNguoiDung(
	MaNhomNguoiDung varchar(20) PRIMARY KEY NOT NULL,
	TenNhomNguoiDung nvarchar(50) NOT NULL
);

-- Tạo bảng QuanTriVien
CREATE TABLE QuanTriVien (
    MaQTV INT IDENTITY(1,1) PRIMARY KEY,
    TenQTV NVARCHAR(255) NOT NULL,
    TaiKhoanQTV VARCHAR(50) NOT NULL UNIQUE,
    MatKhauQTV VARCHAR(50) NOT NULL CHECK (LEN(MatKhauQTV) >= 6),
	EmailQTV VARCHAR(100) UNIQUE,
    CONSTRAINT CK_EmailQTV CHECK (EmailQTV LIKE '%@%.%'),
	MaNhomNguoiDung varchar(20) NOT NULL,
	CONSTRAINT FK_NhomNguoiDung_QuanTriVien FOREIGN KEY (MaNhomNguoiDung) REFERENCES NhomNguoiDung(MaNhomNguoiDung)
);

-- Tạo bảng KhachHang
CREATE TABLE KhachHang (
    MaKhachHang INT IDENTITY(1,1) PRIMARY KEY,
    TenKhachHang NVARCHAR(255) NOT NULL,
    DiaChi NVARCHAR(255),
    SoDienThoai VARCHAR(20) UNIQUE,
    Email VARCHAR(100) UNIQUE,
    NgaySinh DATETIME,
    TaiKhoan VARCHAR(50) NOT NULL UNIQUE,
    MatKhau VARCHAR(50) NOT NULL,
    GioiTinh NVARCHAR(10),
    CONSTRAINT CK_SoDienThoai CHECK (LEN(SoDienThoai) >= 10),
    CONSTRAINT CK_Email CHECK (Email LIKE '%@%.%')
);

-- Tạo bảng DonHang
CREATE TABLE DonHang (
    MaDonHang INT IDENTITY(1,1) PRIMARY KEY,
    MaKhachHang INT NOT NULL,
    NgayDatHang DATETIME NOT NULL,
    NgayGiaoHang DATETIME,
    DaThanhToan NVARCHAR(255),
    TinhTrangGiaoHang BIT NOT NULL,
    CONSTRAINT FK_DonHang_KhachHang FOREIGN KEY (MaKhachHang) REFERENCES KhachHang(MaKhachHang)
);

-- Tạo bảng ChiTietDonHang
CREATE TABLE ChiTietDonHang (
    MaChiTiet INT IDENTITY(1,1) PRIMARY KEY,
    MaDonHang INT NOT NULL,
    MaSanPham INT,
    TenSanPham NVARCHAR(255) COLLATE Vietnamese_CI_AS NOT NULL,
    HinhAnh NVARCHAR(255) NULL,
    SoLuong INT NOT NULL,
    GiaBan DECIMAL(10, 2) NOT NULL,
    CONSTRAINT FK_ChiTietDonHang_DonHang FOREIGN KEY (MaDonHang) REFERENCES DonHang(MaDonHang),
    CONSTRAINT FK_ChiTietDonHang_Hoa FOREIGN KEY (MaSanPham) REFERENCES Hoa(MaSanPham)
);

-- Tạo bảng KhoHang
CREATE TABLE KhoHang (
    MaSanPham INT NOT NULL,
    SoLuongTrongKho INT NOT NULL CHECK (SoLuongTrongKho >= 0),
    CONSTRAINT PK_KhoHang PRIMARY KEY (MaSanPham),
    CONSTRAINT FK_KhoHang_Hoa FOREIGN KEY (MaSanPham) REFERENCES Hoa(MaSanPham)
);

-- Tạo bảng NhaCungCap
CREATE TABLE NhaCungCap (
    MaNhaCungCap INT IDENTITY(1, 1) PRIMARY KEY,
    TenNhaCungCap NVARCHAR(255) NOT NULL,
    HinhAnh NVARCHAR(255) NULL,
    DiaChi NVARCHAR(255),
    SoDienThoai VARCHAR(20),
    Email NVARCHAR(100),
    MaSanPham INT, 
    CONSTRAINT CK_SoDienThoai_NCC CHECK (LEN(SoDienThoai) >= 10),
    CONSTRAINT CK_Email_NCC CHECK (Email LIKE '%@%.%'),
    CONSTRAINT FK_NhaCungCap_Hoa FOREIGN KEY (MaSanPham) REFERENCES Hoa(MaSanPham)
);

-- Tạo bảng PhieuNhapHang
CREATE TABLE PhieuNhapHang (
    MaPhieuNhap INT IDENTITY(1,1) PRIMARY KEY,
    MaNhaCungCap INT NOT NULL,
    NgayNhap DATE NOT NULL,
    TongTien DECIMAL(12, 2) NOT NULL,
    GhiChu NVARCHAR(255),
    CONSTRAINT FK_PhieuNhapHang_NhaCungCap FOREIGN KEY (MaNhaCungCap) REFERENCES NhaCungCap(MaNhaCungCap)
);

-- Tạo bảng ChiTietPhieuNhap
CREATE TABLE ChiTietPhieuNhap (
    MaChiTietPhieuNhap INT IDENTITY(1,1) PRIMARY KEY,
    MaPhieuNhap INT NOT NULL,     
    MaSanPham INT NOT NULL,          
    SoLuong INT NOT NULL,            
    GiaNhap DECIMAL(10, 2) NOT NULL,   
    CONSTRAINT FK_ChiTietPhieuNhap_PhieuNhap FOREIGN KEY (MaPhieuNhap) REFERENCES PhieuNhapHang(MaPhieuNhap),
    CONSTRAINT FK_ChiTietPhieuNhap_Hoa FOREIGN KEY (MaSanPham) REFERENCES Hoa(MaSanPham)
);

-- Tạo bảng LichSuGiaoDich
CREATE TABLE LichSuGiaoDich (
    MaLichSu INT IDENTITY(1,1) PRIMARY KEY,
    MaDonHang INT NOT NULL,
    TrangThai NVARCHAR(50) NOT NULL,
    NgayCapNhat DATE NOT NULL,
    CONSTRAINT FK_LichSuGiaoDich_DonHang FOREIGN KEY (MaDonHang) REFERENCES DonHang(MaDonHang)
);

-- Tạo bảng PhanHoi
CREATE TABLE PhanHoi (
    MaPhanHoi INT IDENTITY(1,1) PRIMARY KEY,
    TenKhachHang NVARCHAR(255) NOT NULL,
    SoDienThoai VARCHAR(20),
    Email NVARCHAR(100),
    NoiDung NVARCHAR(MAX) NOT NULL,
    ThoiGian DATETIME NOT NULL,
    GioiTinh NVARCHAR(10),
    MaKhachHang INT,
    CONSTRAINT FK_PhanHoi_KhachHang FOREIGN KEY (MaKhachHang) REFERENCES KhachHang(MaKhachHang)
);

-- Tạo bảng tích điểm khuyến mãi
CREATE TABLE BangTichDiem (
    MaTichDiem INT IDENTITY(1,1) PRIMARY KEY,
    MaKhachHang INT NOT NULL,
    TongDiem INT DEFAULT 0 CHECK (TongDiem >= 0),
	GiaTriGiamGia INT DEFAULT 0 CHECK (GiaTriGiamGia >= 0),
    NgayCapNhat DATE NOT NULL DEFAULT GETDATE(),
    CONSTRAINT FK_BangTichDiem_KhachHang FOREIGN KEY (MaKhachHang) REFERENCES KhachHang(MaKhachHang)
);

-- Tạo bảng TongDoanhThu
CREATE TABLE TongDoanhThu (
    MaDoanhThu INT IDENTITY(1,1) PRIMARY KEY,
    MaDonHang INT NOT NULL, 
    Ngay DATE NOT NULL,
    TongTien DECIMAL(15, 2) NOT NULL CHECK (TongTien >= 0),
    SoLuongHoa INT NOT NULL CHECK (SoLuongHoa >= 0),
    CONSTRAINT FK_TongDoanhThu_DonHang FOREIGN KEY (MaDonHang) REFERENCES DonHang(MaDonHang)
);

CREATE TABLE ManHinh(
	MaManHinh varchar(50) PRIMARY KEY NOT NULL,
	TenManHinh nvarchar(50) NOT NULL
);

CREATE TABLE QL_PhanQuyen(
	MaNhomNguoiDung varchar(20) NOT NULL,
	MaManHinh varchar(50) NOT NULL,
	PRIMARY KEY(MaNhomNguoiDung, MaManHinh),
	CoQuyen bit NOT NULL,
	CONSTRAINT FK_ManHinh_QL_PhanQuyen FOREIGN KEY (MaManHinh) REFERENCES ManHinh(MaManHinh),
	CONSTRAINT FK_NhomNguoiDung_QL_PhanQuyen FOREIGN KEY (MaNhomNguoiDung) REFERENCES NhomNguoiDung(MaNhomNguoiDung)
);

go
-- Trigger cập nhật doanh thu hàng ngày khi có đơn hàng mới hoặc thay đổi
CREATE TRIGGER trg_UpdateDailyRevenue_DonHang ON DonHang
AFTER INSERT, UPDATE
AS
BEGIN
    DECLARE @MaDonHang INT, @TongTien DECIMAL(15,2), @SoLuongHoa INT;
    
    -- Tính toán tổng tiền và số lượng hoa từ chi tiết đơn hàng
    SELECT @MaDonHang = i.MaDonHang, 
           @TongTien = SUM(cd.GiaBan * cd.SoLuong), 
           @SoLuongHoa = SUM(cd.SoLuong)
    FROM inserted i
    INNER JOIN ChiTietDonHang cd ON i.MaDonHang = cd.MaDonHang
    GROUP BY i.MaDonHang;

    -- Kiểm tra nếu MaDonHang là NULL thì không thực hiện insert
    IF @MaDonHang IS NOT NULL
    BEGIN
        -- Cập nhật hoặc thêm mới doanh thu vào bảng TongDoanhThu
        INSERT INTO TongDoanhThu (MaDonHang, Ngay, TongTien, SoLuongHoa)
        VALUES (@MaDonHang, GETDATE(), @TongTien, @SoLuongHoa);
    END
    ELSE
    BEGIN
        -- Nếu MaDonHang là NULL, có thể log lỗi hoặc thực hiện hành động khác
        PRINT 'Error: MaDonHang is NULL. No data inserted into TongDoanhThu.';
    END
END;
GO

INSERT INTO LoaiSanPham (TenLoai)
VALUES
    (N'Hoa cảnh'),
    (N'Hoa quà tặng'),
    (N'Hoa sự kiện'),
    (N'Hoa cưới'),
    (N'Hoa chúc mừng');


INSERT INTO Hoa (TenSanPham, MoTa, Gia, DonVi, SoLuong, HanSuDung, MaLoai, HinhAnh)
VALUES
  (N'Hoa baby màu sắc', N'Hoa baby màu sắc tươi tắn', 55.00, N'Bó', 10, '2023-12-31', 4, '1.png'),
  (N'Hoa cúc trắng', N'Hoa cúc trắng đơn giản', 20.00, N'Bó', 18, '2023-12-31', 3, '2.png'),
  (N'Hoa hồng vàng', N'Hoa hồng vàng nổi bật', 380.00, N'Bó', 28, '2023-12-31', 1, '3.png'),
  (N'Hoa violet', N'Hoa violet tím mềm mại', 65.00, N'Bó', 20, '2023-12-31', 4, '4.png'),
  (N'Hoa cẩm chướng', N'Hoa cẩm chướng tươi tắn', 45.00, N'Bó', 15, '2023-12-31', 5, '5.png'),
  (N'Hoa Hồng Trái Tim', N'Hoa hồng đỏ đẹp', 400.00, N'Bó', 20, '2023-12-31', 1, '6.png'),
  (N'Hoa lan trắng', N'Hoa lan trắng tinh khôi', 30.00, N'Bó', 15, '2023-12-31', 2, '7.png'),
  (N'Hoa tulip vàng', N'Hoa tulip vàng nổi bật', 290.00, N'Bó', 25, '2023-12-31', 3, '8.png'),
  (N'Hoa hồng kết hợp', N'Hoa hồng kết hợp tươi đẹp', 450.00, N'Bó', 30, '2023-12-31', 2, '9.png'),
  (N'Hoa cẩm tú cầu', N'Hoa cẩm tú cầu đa dạng sắc màu', 27.25, N'Bó', 22, '2023-12-31', 5, '10.png'),
  (N'Hoa dại màu tự nhiên', N'Hoa dại màu tự nhiên và thơm ngon', 45.00, N'Bó', 3, '2023-12-31', 3, '11.png'),
  (N'Hoa hồng đỏ', N'Hoa hồng đỏ đẹp và quyến rũ', 65.00, N'Bó', 12, '2023-12-31', 5, '12.png'),
  (N'Hoa cẩm chướng hồng', N'Hoa cẩm chướng hồng đa dạng sắc màu', 127.25, N'Bó', 64, '2023-12-31', 2, '13.png'),
  (N'Hoa bay và 1 bông hồng', N'Hoa bay và 1 bông hồng đỏ ở giữa', 43.5, N'Bó', 54, '2023-12-31', 3, '14.png'),
  (N'Hoa hướng dương điểm hoa baby', N'Hoa hướng dương điểm hoa baby nổi bật', 273.2, N'Bó', 65, '2023-12-31', 4, '15.png'),
  (N'Hoa tone trắng hồng', N'Hoa tone trắng hồng đáng yêu', 34.5, N'Bó', 67, '2023-12-31', 5, '16.png'),
  (N'Hoa tông trắng xanh', N'Hoa tông trắng xanh thân thiện', 54.45, N'Bó', 54, '2023-12-31', 1, '17.png'),
  (N'Hoa tình yêu', N'Hoa tình yêu giản đơn', 77.65, N'Bó', 75, '2023-12-31', 3, '18.png'),
  (N'Hoa giáng sinh', N'Hoa giáng sinh đa dạng sắc màu', 265.87, N'Giỏ', 43, '2023-12-31', 4, '19.png'),
  (N'Giỏ hoa lan', N'Giỏ hoa mẫu đơn được xem là loài hoa của hạnh phúc gia đình', 546.2, N'Giỏ', 76, '2023-12-31', 2, '20.png'),
  (N'Hoa ươm nắng', N'Hoa ươm nắng tinh khôi', 255.98, N'Giỏ', 23, '2023-12-31', 3, '21.png'),
  (N'Hoa mẫu đơn', N'Hoa mẫu đơn đa dạng', 437.15, N'Giỏ', 75, '2023-12-31', 5, '22.png'),
  (N'Giỏ hoa mẫu đơn', N'Giỏ hoa mẫu đơn tự nhiên', 50.84, N'Giỏ', 95, '2023-12-31', 2, '23.png'),
  (N'Giỏ hoa tông màu tím', N'Giỏ hoa tông màu tím quyến rũ', 54.5, N'Giỏ', 25, '2023-12-31', 4, '24.png'),
  (N'Giỏ hoa sinh nhật', N'Giỏ hoa sinh nhật', 432.9, N'Giỏ', 87, '2023-12-31', 5, '25.png'),
  (N'Hoa giáng sinh', N'Hoa giáng sinh We Wish You a Merry Christmas', 267.55, N'Giỏ', 42, '2023-12-31', 4, '26.png');


  

INSERT INTO QuanTriVien (TenQTV, TaiKhoanQTV, MatKhauQTV, EmailQTV, MaNhomNguoiDung) 
VALUES 
		(N'Nguyen Van A', 'admin1', 'matkhau', 'nguyenvana@gmail.com', 'AD'),
		(N'Hoang Van E', 'nhanvien1', 'matkhau', 'hoangvane@gmail.com', 'NV');


INSERT INTO KhachHang (TenKhachHang, DiaChi, SoDienThoai, Email, NgaySinh, TaiKhoan, MatKhau, GioiTinh)
VALUES
    ('Khach Hang 1', 'Dia Chi 1', '0123456789', 'khachhang1@email.com', '2003-09-10', 'taikhoan1', 'matkhau',N'Nam'),
    ('Khach Hang 2', 'Dia Chi 2', '0987654321', 'khachhang2@email.com', '2003-09-11', 'taikhoan2', 'matkhau',N'Nữ'),
    ('Khach Hang 3', 'Dia Chi 3', '0369852147', 'khachhang3@email.com', '2003-09-12', 'taikhoan3', 'matkhau',N'Nam'),
    ('Khach Hang 4', 'Dia Chi 4', '0123456780', 'khachhang4@email.com', '2003-09-13', 'taikhoan4', 'matkhau',N'Nam'),
    ('Khach Hang 5', 'Dia Chi 5', '0987654322', 'khachhang5@email.com', '2003-09-14', 'taikhoan5', 'matkhau',N'Nữ'),
    ('Khach Hang 6', 'Dia Chi 6', '0369852148', 'khachhang6@email.com', '2003-09-15', 'taikhoan6', 'matkhau',N'Nữ'),
    ('Khach Hang 7', 'Dia Chi 7', '0123456781', 'khachhang7@email.com', '2003-09-16', 'taikhoan7', 'matkhau',N'Nam'),
    ('Khach Hang 8', 'Dia Chi 8', '0987654323', 'khachhang8@email.com', '2003-09-17', 'taikhoan8', 'matkhau',N'Nữ'),
    ('Khach Hang 9', 'Dia Chi 9', '0369852149', 'khachhang9@email.com', '2003-09-18', 'taikhoan9', 'matkhau',N'Nam'),
    ('Khach Hang 10', 'Dia Chi 10', '0123456782', 'khachhang10@email.com', '2003-09-19', 'taikhoan10', 'matKhau',N'Nam');



INSERT INTO DonHang (MaKhachHang, NgayDatHang, NgayGiaoHang, DaThanhToan, TinhTrangGiaoHang)
VALUES
    (1, '2023-09-10', '2023-09-15', N'Đã Thanh Toán', 1),
    (2, '2023-09-11', '2023-09-15', N'Đã Thanh Toán', 1),
    (3, '2023-09-12', '2023-09-17', N'Đã Thanh Toán', 1),
    (4, '2023-09-13', '2023-09-19', N'Đã Thanh Toán', 1),
    (5, '2023-09-14', '2023-09-19', N'Đã Thanh Toán', 1),
    (6, '2023-09-15', '2023-09-23', N'Đã Thanh Toán', 1),
    (7, '2023-09-16', '2023-09-21', N'Đã Thanh Toán', 1),
    (8, '2023-09-17', '2023-09-21', N'Đã Thanh Toán', 1),
    (9, '2023-09-18', '2023-09-23', N'Đã Thanh Toán', 1),
    (10, '2023-09-19', '2023-09-23', N'Đã Thanh Toán', 1);



INSERT INTO ChiTietDonHang (MaDonHang, TenSanPham, MaSanPham, HinhAnh, SoLuong, GiaBan)
VALUES
    (10, N'Hoa baby màu sắc', 1, '1.png', 5, 28.75),
    (10, N'Hoa cúc trắng', 2,'2.png', 3, 330.00),
    (2, N'Hoa hồng đỏ', 12,'12.png', 2, 21.50),
    (2, N'Hoa dại màu tự nhiên', 11,'11.png', 4, 243.00),
    (3, N'Hoa tulip vàng', 8,'8.png', 2, 27.25),
    (3, N'Hoa lan trắng', 7,'7.png', 3, 28.75), 
    (4, N'Hoa dại màu tự nhiên', 11,'11.png', 2, 400.00),
    (4, N'Hoa Hồng Trái Tim', 6,'6.png', 3, 30.00),
    (5, N'Hoa hồng đỏ', 12,'12.png', 1, 290.00),
    (5, N'Hoa dại màu tự nhiên', 11,'11.png', 4, 450.00),
    (6, N'Hoa baby màu sắc', 1,'1.png', 2, 27.25),
    (7, N'Hoa Hồng Trái Tim', 6,'6.png', 4, 330.00),  
    (8, N'Hoa dại màu tự nhiên', 11,'11.png', 3, 21.50);   



INSERT INTO KhoHang (MaSanPham, SoLuongTrongKho)
VALUES
    (1, 100),
    (2, 150),
    (3, 200),
    (4, 180),
    (5, 250),
    (6, 220),
    (7, 180),
    (8, 210),
    (9, 150),
    (10, 190);

INSERT INTO NhaCungCap (TenNhaCungCap, HinhAnh, DiaChi, SoDienThoai, Email, MaSanPham)
VALUES
    (N'Nhà Cung Cấp 1', 'NCC001.jpg', N'Địa chỉ 1', '0123456789', 'nhacungcap1@email.com', 1),
    (N'Nhà Cung Cấp 2', 'NCC002.jpg', N'Địa chỉ 2', '0987654321', 'nhacungcap2@email.com', 2),
    (N'Nhà Cung Cấp 3', 'NCC003.jpg', N'Địa chỉ 3', '0369852147', 'nhacungcap3@email.com', 3),
    (N'Nhà Cung Cấp 4', 'NCC004.jpg', N'Địa chỉ 4', '0123456780', 'nhacungcap4@email.com', 4),
    (N'Nhà Cung Cấp 5', 'NCC005.jpg', N'Địa chỉ 5', '0987654322', 'nhacungcap5@email.com', 5);

INSERT INTO PhieuNhapHang (MaNhaCungCap, NgayNhap, TongTien, GhiChu)
VALUES
    (1, '2023-09-10', 750.00, N'Nhập hàng từ nhà cung cấp 1'),
    (2, '2023-09-11', 620.50, N'Nhập hàng từ nhà cung cấp 2');

INSERT INTO LichSuGiaoDich (MaDonHang, TrangThai, NgayCapNhat)
VALUES
    (1, N'Đang xử lý', '2023-09-15'),
    (2, N'Đã thanh toán', '2023-09-12');

INSERT INTO PhanHoi (TenKhachHang, SoDienThoai, Email, NoiDung, ThoiGian, GioiTinh, MaKhachHang)
VALUES 
	(N'Nguyen Van A', '0987654321', 'nguyenvana@gmail.com', N'Rất hài lòng về dịch vụ của bạn', '2021-01-01 10:00:00', N'Nam', 1),
	(N'Tran Thi B', '0909090909', 'tranthib@gmail.com', N'Cần cải thiện chất lượng sản phẩm', '2021-02-15 14:30:00', N'Nữ', 2),
	(N'Le Van C', '0977777777', 'levanc@gmail.com', N'Góp ý về dịch vụ giao hàng', '2021-03-20 09:45:00', N'Nam', 3),
	(N'Pham Thi D', '0912345678', 'phamthid@gmail.com', N'Yêu cầu hỗ trợ kỹ thuật', '2021-04-10 16:20:00', N'Nữ', 4);


INSERT INTO BangTichDiem (MaKhachHang, TongDiem, NgayCapNhat)
VALUES
    (1, 100, '2023-09-10'),
    (2, 150, '2023-09-11'),
    (3, 75, '2023-09-12'),
    (4, 90, '2023-09-13'),
    (5, 200, '2023-09-14'),
    (6, 160, '2023-09-15'),
    (7, 110, '2023-09-16'),
    (8, 130, '2023-09-17'),
	(9, 110, '2023-09-18'),
    (10, 130, '2023-09-19');


INSERT INTO TongDoanhThu (MaDonHang, Ngay, TongTien, SoLuongHoa)
VALUES
    (1, '2023-09-10', 1500000.00, 10),
    (2, '2023-09-11', 1750000.00, 12),
    (3, '2023-09-12', 2000000.00, 15),
    (4, '2023-09-13', 1200000.00, 8),
    (5, '2023-09-14', 1800000.00, 11),
    (6, '2023-09-15', 1600000.00, 9),
    (7, '2023-09-16', 2200000.00, 14),
    (8, '2023-09-17', 1400000.00, 10),
	 (9, '2023-09-18', 2600000.00, 14),
    (10, '2023-09-19', 1920000.00, 15);

INSERT INTO NhomNguoiDung(MaNhomNguoiDung, TenNhomNguoiDung)
VALUES
('AD', 'Admin'),
('NV', 'Nhân Viên');

INSERT INTO ManHinh(MaManHinh, TenManHinh)
VALUES
('MH001', 'Quản lý tài khoản khách hàng'),
('MH002', 'Quản lý tài khoản quản trị viên'),
('MH003', 'Quản lý khách hàng'),
('MH004', 'Quản lý sản phẩm'),
('MH005', 'Quản lý đơn hàng'),
('MH006', 'Quản lý đánh giá của khách hàng'),
('MH007', 'Quản lý tạo khuyến mại'),
('MH008', 'Quản lý thống kê doanh thu');

-- Thêm dữ liệu mẫu vào bảng QL_PhanQuyen với các mã màn hình chức năng
INSERT INTO QL_PhanQuyen (MaNhomNguoiDung, MaManHinh, CoQuyen)
VALUES 
('AD', 'MH001', 1),
('AD', 'MH002', 1),
('AD', 'MH003', 1),
('AD', 'MH004', 1),
('AD', 'MH005', 1),
('AD', 'MH006', 1),
('AD', 'MH007', 1),
('AD', 'MH008', 1),

('KH', 'MH001', 0),
('KH', 'MH002', 0),
('KH', 'MH003', 0),
('KH', 'MH004', 0),
('KH', 'MH005', 1),
('KH', 'MH006', 1),
('KH', 'MH007', 0),
('KH', 'MH008', 0),

('NV', 'MH001', 0),
('NV', 'MH002', 0),
('NV', 'MH003', 1),
('NV', 'MH004', 1),
('NV', 'MH005', 1),
('NV', 'MH006', 0),
('NV', 'MH007', 0),
('NV', 'MH008', 0);
