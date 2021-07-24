CREATE DATABASE QLNTTDA
USE QLNTTDA
GO

CREATE TABLE NHOMNHANVIEN(
	MANHOMNV varchar(10) NOT NULL PRIMARY KEY,
	TENNHOM nvarchar(500) NULL,
)


CREATE TABLE DANHMUCMANHINH(
	MADMMH varchar(10) NOT NULL PRIMARY KEY,
	TENMANHINH nvarchar(500) NOT NULL,
)

CREATE TABLE PHANQUYEN(
	MANHOMNV varchar(10) NOT NULL,
	MADMMH varchar(10) NOT NULL,
	COQUYEN bit,					 -- 0	nhân viên, 1 quản lý
	PRIMARY KEY(MANHOMNV, MADMMH)
)

CREATE TABLE NHANVIEN
(
	MANV varchar(10) NOT NULL PRIMARY KEY,
	MANHOMNV VARCHAR(10) NOT NULL,
	TENDANGNHAP NVARCHAR(500) NOT NULL,
	MATKHAU NVARCHAR(500) NOT NULL,
	HOTENNV NVARCHAR(500) NOT NULL,
	GIOITINHNV NVARCHAR(50) NULL,
	NGAYSINHNV DATETIME NULL,
	DIACHINV NVARCHAR(500) NULL,
	SODIENTHOAINV VARCHAR(15) NULL,
	CHUNGMINHTHU VARCHAR(10) NULL,
	NGAYBATDAULAMVIEC datetime NOT NULL,
	NGAYKETTHUCLAMVIEC datetime NULL,
	TRINHDOHOCVAN NVARCHAR(500) NOT NULL,
	MUCLUONGCOBAN DECIMAL(18, 0) NOT NULL,
)


CREATE TABLE BANGLUONG(
	MABANGLUONG varchar(10) NOT NULL,
	MANV varchar(10) NOT NULL,
	LUONGTHUCTE decimal(18, 0) NOT NULL,
	NGAYAPDUNG date NOT NULL,
	GHICHUBL nvarchar(500) NULL,
	PRIMARY KEY(MABANGLUONG, MANV)
)
---ngayapdung = ngaybatdaulam (nhanvien)
-- GHICHUBANGLUONG 13 tháng lương cho nhanvien tốt, hoa hồng cho ql


CREATE TABLE CHAMCONG(
	MANV varchar(10) NOT NULL ,
	MACHAMCONG varchar(10) NOT NULL,
	THANG INT NOT NULL,
	NAM INT NOT NULL,
	SONGAYLAMVIEC int NOT NULL,
	PRIMARY KEY(MACHAMCONG, MANV)
)

CREATE TABLE BACLUONG(
	MABAC varchar(10) NOT NULL PRIMARY KEY,
	TENBAC nvarchar(500) NOT NULL,
	HESO FLOAT NOT NULL,
)

CREATE TABLE CHITIETBACLUONG(
	MABAC varchar(10) NOT NULL,
	MANV varchar(10) NOT NULL,
	TUNGAY date NOT NULL,
	DENNGAY date NOT NULL,
	PRIMARY KEY(MABAC, MANV)
)

CREATE TABLE KHACHHANG(
	MAKH varchar(10) NOT NULL PRIMARY KEY,
	MAQUANHUYEN VARCHAR(10),
	HOTENKH nvarchar(500) NULL,
	LOAIKHACHHANG nvarchar(500) NOT NULL,
	NGAYSINHKH date NULL,
	GIOITINHKH nvarchar(10) NULL,
	DIACHIKH nvarchar(500) NULL,
	SODIENTHOAIKH varchar(15) NULL,
)


CREATE TABLE TINHTHANH(
	MATINHTHANH VARCHAR(10) NOT NULL PRIMARY KEY,
	TENTINHTHANH NVARCHAR(500)
)

CREATE TABLE QUANHUYEN(
	MAQUANHUYEN VARCHAR(10) NOT NULL PRIMARY KEY,
	MATINHTHANH VARCHAR(10),
	TENQUANHUYEN NVARCHAR(500),
)

CREATE TABLE NHACUNGCAP(
	MANCC VARCHAR(10) NOT NULL PRIMARY KEY,
	MAQUANHUYEN VARCHAR(10),
	TENNHACUNGCAP NVARCHAR(500),
	DIACHI NVARCHAR(500),
	SDT VARCHAR(15),
)


CREATE TABLE HOADONBAN(
	MAHDB varchar(10) NOT NULL PRIMARY KEY,
	MAKH varchar(10) NOT NULL,
	MANV varchar(10) NOT NULL,
	NGAYLAPBAN date NOT NULL,
	VAT float NOT NULL,
	TONGTIENBAN decimal(18, 0) NOT NULL,
)

CREATE TABLE CHITIETHOADONBAN(
	MAHDB varchar(10) NOT NULL,
	MATHUOC varchar(10) NOT NULL,
	SOLUONGBAN int NOT NULL,
	THANHTIENBAN decimal(18, 0) NOT NULL,
	PRIMARY KEY(MAHDB, MATHUOC)
)


CREATE TABLE HANGSANXUAT(
	MAHSX VARCHAR(10) NOT NULL PRIMARY KEY,
	TENHSX NVARCHAR(500),
)


CREATE TABLE XUATXU(
	MAXUATXU VARCHAR(10) NOT NULL PRIMARY KEY,
	TENXUATXU NVARCHAR(500),
	LOAIXUATXU NVARCHAR(500),
)

CREATE TABLE LOAITHUOC(
	MALOAITHUOC varchar(10) NOT NULL PRIMARY KEY,
	MAKE varchar(10) NOT NULL,
	TENLOAITHUOC nvarchar(500) NOT NULL,
)

CREATE TABLE THUOC(
	MATHUOC varchar(10) NOT NULL PRIMARY KEY,
	MALOAITHUOC varchar(10) NOT NULL,
	MAHSX VARCHAR(10) NOT NULL,
	MAXUATXU VARCHAR(10) NOT NULL,
	TENTHUOC nvarchar(500) NOT NULL,
	HINHTHUOC nvarchar(500),
	THANHPHAN nvarchar(500) NULL,
	CONGDUNG nvarchar(500) NULL,
	BAOQUAN nvarchar(500) NULL,
	GHICHUTHUOC nvarchar(500) NULL,
	DVT nvarchar(500) NOT NULL,
	SOLOTHUOC int NOT NULL,
	NGAYSANXUAT date NOT NULL,
	HANSUDUNG date NOT NULL,
	DONGIATHUOC decimal(18, 0) NULL,
	SOLUONGTON int NOT NULL,
)

CREATE TABLE KETHUOC(
	MAKE varchar(10) NOT NULL PRIMARY KEY,
	TENKE nvarchar(500) NOT NULL,
)


CREATE TABLE PHIEUNHAPTHUOC(
	MAPNT varchar(10) NOT NULL PRIMARY KEY,
	MANCC VARCHAR(10) NOT NULL,
	NGAYNHAPTHUOC date NOT NULL,
	GHICHUNT nvarchar(500) NULL,
	TRANGTHAI bit NULL,
	TONGTIEN decimal(18, 0) NULL,
)

CREATE TABLE CHITIETPHIEUNHAPTHUOC(
	MAPNT varchar(10) NOT NULL,
	MATHUOC varchar(10) NOT NULL,
	SOLUONGNHAPTHUOC int NOT NULL,
	DVT nvarchar(500) NOT NULL,
	THANHTIENNT decimal(18, 0) NOT NULL,
	DONGIABAN decimal(18, 0) NULL,
	PRIMARY KEY(MAPNT, MATHUOC)
)


-----------------------------------KHÓA NGOẠI-------------------------------------------
--PHÂN QUYỀN
ALTER TABLE PHANQUYEN
ADD CONSTRAINT FK_PQ_NNV FOREIGN KEY(MANHOMNV) REFERENCES NHOMNHANVIEN(MANHOMNV)

ALTER TABLE PHANQUYEN
ADD CONSTRAINT FK_QL_DMMH FOREIGN KEY(MADMMH) REFERENCES DANHMUCMANHINH(MADMMH)

--CHẤM CÔNG
ALTER TABLE CHAMCONG
ADD CONSTRAINT FK_CC_NV FOREIGN KEY(MANV) REFERENCES NHANVIEN(MANV)

--BANGLUONG
ALTER TABLE BANGLUONG
ADD CONSTRAINT FK_BL_NV FOREIGN KEY(MANV) REFERENCES NHANVIEN(MANV)

--CHI TIẾT BẬC LƯƠNG
ALTER TABLE CHITIETBACLUONG
ADD CONSTRAINT FK_CTBL_BL FOREIGN KEY(MABAC) REFERENCES BACLUONG(MABAC)

ALTER TABLE CHITIETBACLUONG
ADD CONSTRAINT FK_CTBL_NV FOREIGN KEY(MANV) REFERENCES NHANVIEN(MANV)


--HÓA ĐƠN BÁN
ALTER TABLE HOADONBAN
ADD CONSTRAINT FK_HDB_NV FOREIGN KEY(MANV) REFERENCES NHANVIEN(MANV)

ALTER TABLE HOADONBAN
ADD CONSTRAINT FK_HDB_KH FOREIGN KEY(MAKH) REFERENCES KHACHHANG(MAKH)

--CHI TIẾT HÓA ĐƠN BÁN
ALTER TABLE CHITIETHOADONBAN
ADD CONSTRAINT FK_CTHDB_HDB FOREIGN KEY(MAHDB) REFERENCES HOADONBAN(MAHDB)

ALTER TABLE CHITIETHOADONBAN
ADD CONSTRAINT FK_CTHDB_T FOREIGN KEY(MATHUOC) REFERENCES THUOC(MATHUOC)

--THUỐC
ALTER TABLE THUOC
ADD CONSTRAINT FK_T_LT FOREIGN KEY(MALOAITHUOC) REFERENCES LOAITHUOC(MALOAITHUOC)

ALTER TABLE THUOC
ADD CONSTRAINT FK_T_HSX FOREIGN KEY(MAHSX) REFERENCES HANGSANXUAT(MAHSX)

ALTER TABLE THUOC
ADD CONSTRAINT FK_T_XX FOREIGN KEY(MAXUATXU) REFERENCES XUATXU(MAXUATXU)

--LOẠI THUỐC
ALTER TABLE LOAITHUOC
ADD CONSTRAINT FK_LT_KT FOREIGN KEY(MAKE) REFERENCES KETHUOC(MAKE)

--CHI TIẾT PHIẾU NHẬP THUỐC

ALTER TABLE CHITIETPHIEUNHAPTHUOC
ADD CONSTRAINT FK_CTPNT_T FOREIGN KEY(MATHUOC) REFERENCES THUOC(MATHUOC)

ALTER TABLE CHITIETPHIEUNHAPTHUOC
ADD CONSTRAINT FK_CTPNT_PNT FOREIGN KEY(MAPNT) REFERENCES PHIEUNHAPTHUOC(MAPNT)

--KHÁCH HÀNG
ALTER TABLE KHACHHANG
ADD CONSTRAINT FK_KH_QH FOREIGN KEY(MAQUANHUYEN) REFERENCES QUANHUYEN(MAQUANHUYEN)

--TỈNH THÀNH
ALTER TABLE QUANHUYEN
ADD CONSTRAINT FK_QH_TT FOREIGN KEY(MATINHTHANH) REFERENCES TINHTHANH(MATINHTHANH)

--NHÀ CUNG CẤP
ALTER TABLE NHACUNGCAP
ADD CONSTRAINT FK_NCC_QH FOREIGN KEY(MAQUANHUYEN) REFERENCES QUANHUYEN(MAQUANHUYEN)

--------------------------------------CHECK, DEFAULT,UNIQUE------------------------------------

ALTER TABLE NHOMNHANVIEN
ADD CONSTRAINT NNV_TENNHOM UNIQUE(TENNHOM)

ALTER TABLE PHANQUYEN
ADD CONSTRAINT PHANQUYEN_COQUYEN CHECK(COQUYEN='0' OR COQUYEN='1')

ALTER TABLE NHANVIEN
ADD CONSTRAINT NV_TENDANGNHAP UNIQUE(TENDANGNHAP)

ALTER TABLE NHANVIEN
ADD CONSTRAINT NV_NGAYKETTHUCLAMVIEC DEFAULT GETDATE() FOR NGAYKETTHUCLAMVIEC

ALTER TABLE NHANVIEN
ADD CONSTRAINT NV_NGAYBATDAULAMVIEC DEFAULT GETDATE() FOR NGAYBATDAULAMVIEC

ALTER TABLE NHANVIEN
ADD CONSTRAINT NV_CHUNGMINHTHU UNIQUE(CHUNGMINHTHU)

ALTER TABLE NHANVIEN
ADD CONSTRAINT NV_GIOITINHNV CHECK(GIOITINHNV = N'Nữ' OR GIOITINHNV= N'Nam' OR GIOITINHNV=N'Khác')

ALTER TABLE NHANVIEN
ADD CONSTRAINT NV_TRINHDOHOCVAN CHECK(TRINHDOHOCVAN = N'Trung cấp' OR TRINHDOHOCVAN= N'Cao đẳng' OR TRINHDOHOCVAN=N'Đại học' OR TRINHDOHOCVAN=N'Thạc sĩ')

ALTER TABLE NHANVIEN
ADD CONSTRAINT NV_MUCLUONGCOBAN CHECK(MUCLUONGCOBAN >= 2000000 )


ALTER TABLE BANGLUONG
ADD CONSTRAINT BL_LUONGTHUCTE CHECK(LUONGTHUCTE >= 2000000 )

ALTER TABLE BANGLUONG
ADD CONSTRAINT BL_NGAYAPDUNG DEFAULT GETDATE() FOR NGAYAPDUNG

ALTER TABLE CHITIETBACLUONG
ADD CONSTRAINT CTBL_TUNGAY DEFAULT GETDATE() FOR TUNGAY

ALTER TABLE CHITIETBACLUONG
ADD CONSTRAINT CTBL_DENNGAY DEFAULT GETDATE() FOR DENNGAY

ALTER TABLE QUANHUYEN
ADD CONSTRAINT QH_TENQUANHUYEN UNIQUE(TENQUANHUYEN)

ALTER TABLE NHACUNGCAP
ADD CONSTRAINT NCC_TENNCC UNIQUE(TENNHACUNGCAP)

ALTER TABLE THUOC
ADD CONSTRAINT THUOC_TENTHUOC UNIQUE(TENTHUOC)

ALTER TABLE KHACHHANG
ADD CONSTRAINT KH_GIOITINHKH CHECK(GIOITINHKH = N'Nữ' OR GIOITINHKH= N'Nam' OR GIOITINHKH=N'Khác')

ALTER TABLE THUOC
ADD CONSTRAINT THUOC_DONGIA CHECK(DONGIATHUOC > 0 )

ALTER TABLE PHIEUNHAPTHUOC
ADD CONSTRAINT NGAYNHAPTHUOC_CTPN DEFAULT GETDATE() FOR NGAYNHAPTHUOC

--- kiểm tra tuổi trước khi thêm vào

CREATE TRIGGER KTTUOI ON NHANVIEN
   AFTER INSERT
AS
 BEGIN
 DECLARE @TUOINV_MOI INT
 SET @TUOINV_MOI = ( SELECT YEAR(GETDATE())-YEAR(NGAYSINHNV) from inserted)
 IF (@TUOINV_MOI < 18)
     BEGIN 
            RAISERROR (N'NHÂN VIÊN PHẢI LỚN HƠN 18 TUỔI',16,1)
     END
END
GO

-------------------------------------------DỮ LIỆU---------------------------------------------

--========================================NHÓM NHÂN VIÊN============================================

insert into NHOMNHANVIEN(MANHOMNV, TENNHOM)
values ('ADMIN',N'ADMIN')

insert into NHOMNHANVIEN(MANHOMNV, TENNHOM)
values ('NV',N'Nhân viên')

--======================================DANH MỤC MÀN HÌNH===========================================

insert into DANHMUCMANHINH(MADMMH, TENMANHINH)
values ('MHNV',N'Màn hình nhân viên')

insert into DANHMUCMANHINH(MADMMH, TENMANHINH)
values ('MHL',N'Màn hình lương')

insert into DANHMUCMANHINH(MADMMH, TENMANHINH)
values ('MHBL',N'Màn hình bậc lương')

insert into DANHMUCMANHINH(MADMMH, TENMANHINH)
values ('MHCC',N'Màn hình chấm công')

insert into DANHMUCMANHINH(MADMMH, TENMANHINH)
values ('MHT',N'Màn hình thuốc')

insert into DANHMUCMANHINH(MADMMH, TENMANHINH)
values ('MHNCC',N'Màn hình nhà cung cấp')

insert into DANHMUCMANHINH(MADMMH, TENMANHINH)
values ('MHXX',N'Màn hình xuất xứ')

insert into DANHMUCMANHINH(MADMMH, TENMANHINH)
values ('MHTT',N'Màn hình tỉnh thành')

insert into DANHMUCMANHINH(MADMMH, TENMANHINH)
values ('MHHSX',N'Màn hình hãng sản xuất')

insert into DANHMUCMANHINH(MADMMH, TENMANHINH)
values ('MHKT',N'Màn hình kệ thuốc')

insert into DANHMUCMANHINH(MADMMH, TENMANHINH)
values ('MHKH',N'Màn hình khách hàng')

insert into DANHMUCMANHINH(MADMMH, TENMANHINH)
values ('MHLT',N'Màn hình loại thuốc')

insert into DANHMUCMANHINH(MADMMH, TENMANHINH)
values ('MHHDB',N'Màn hình hóa đơn bán')

insert into DANHMUCMANHINH(MADMMH, TENMANHINH)
values ('MHPNT',N'Màn hình phiếu nhập thuốc')

insert into DANHMUCMANHINH(MADMMH, TENMANHINH)
values ('MHST',N'Màn hình tìm kiếm thuốc')

insert into DANHMUCMANHINH(MADMMH, TENMANHINH)
values ('MHSNV',N'Màn hình tìm kiếm nhân viên')

insert into DANHMUCMANHINH(MADMMH, TENMANHINH)
values ('MHTTK',N'Màn hình thuốc tồn kho')

insert into DANHMUCMANHINH(MADMMH, TENMANHINH)
values ('MHTKHD',N'Màn hình thống kê hóa đơn')

insert into DANHMUCMANHINH(MADMMH, TENMANHINH)
values ('MHTKT',N'Màn hình thống kê thuốc')

insert into DANHMUCMANHINH(MADMMH, TENMANHINH)
values ('MHPQ',N'Màn hình phân quyền')



--==========================================PHÂN QUYỀN==============================================

insert into PHANQUYEN(MANHOMNV,MADMMH,COQUYEN)
values('NV','MHNV',0)

insert into PHANQUYEN(MANHOMNV,MADMMH,COQUYEN)
values('NV','MHL',0)

insert into PHANQUYEN(MANHOMNV,MADMMH,COQUYEN)
values('NV','MHBL',0)

insert into PHANQUYEN(MANHOMNV,MADMMH,COQUYEN)
values('NV','MHCC',1)

insert into PHANQUYEN(MANHOMNV,MADMMH,COQUYEN)
values('NV','MHT',1)

insert into PHANQUYEN(MANHOMNV,MADMMH,COQUYEN)
values('NV','MHNCC',1)

insert into PHANQUYEN(MANHOMNV,MADMMH,COQUYEN)
values('NV','MHXX',1)

insert into PHANQUYEN(MANHOMNV,MADMMH,COQUYEN)
values('NV','MHTT',1)

insert into PHANQUYEN(MANHOMNV,MADMMH,COQUYEN)
values('NV','MHHSX',1)

insert into PHANQUYEN(MANHOMNV,MADMMH,COQUYEN)
values('NV','MHKT',1)

insert into PHANQUYEN(MANHOMNV,MADMMH,COQUYEN)
values('NV','MHKH',1)

insert into PHANQUYEN(MANHOMNV,MADMMH,COQUYEN)
values('NV','MHLT',1)

insert into PHANQUYEN(MANHOMNV,MADMMH,COQUYEN)
values('NV','MHHDB',1)

insert into PHANQUYEN(MANHOMNV,MADMMH,COQUYEN)
values('NV','MHPNT',0)

insert into PHANQUYEN(MANHOMNV,MADMMH,COQUYEN)
values('NV','MHTTK',1)

insert into PHANQUYEN(MANHOMNV,MADMMH,COQUYEN)
values('NV','MHSNV',1)

insert into PHANQUYEN(MANHOMNV,MADMMH,COQUYEN)
values('NV','MHST',1)

insert into PHANQUYEN(MANHOMNV,MADMMH,COQUYEN)
values('NV','MHTKT',0)

insert into PHANQUYEN(MANHOMNV,MADMMH,COQUYEN)
values('NV','MHTKHD',0)

insert into PHANQUYEN(MANHOMNV,MADMMH,COQUYEN)
values('NV','MHPQ',0)
--==========================================NHÂN VIÊN===============================================

set dateformat dmy;
insert into NHANVIEN(MANV, MANHOMNV, TENDANGNHAP, MATKHAU, HOTENNV, GIOITINHNV, NGAYSINHNV, DIACHINV, SODIENTHOAINV, CHUNGMINHTHU, NGAYBATDAULAMVIEC, NGAYKETTHUCLAMVIEC, TRINHDOHOCVAN, MUCLUONGCOBAN)
values ('NV01','ADMIN','giangtt','123',N'Tạ Trường Giang',N'Nam','03-05-2000',N'Bình Dương','0946788406','340692492','11-01-2019','04-09-2020',N'Thạc sĩ',11000000)

insert into NHANVIEN(MANV, MANHOMNV, TENDANGNHAP, MATKHAU, HOTENNV, GIOITINHNV, NGAYSINHNV, DIACHINV, SODIENTHOAINV, CHUNGMINHTHU, NGAYBATDAULAMVIEC, NGAYKETTHUCLAMVIEC, TRINHDOHOCVAN, MUCLUONGCOBAN)
values ('NV02','ADMIN','baont','123',N'Nguyễn Thái Bảo',N'Nam','08-05-2000',N'Đồng Tháp','0868487136','342305311','18-03-2019','22-05-2020',N'Thạc sĩ',11000000)

insert into NHANVIEN(MANV, MANHOMNV, TENDANGNHAP, MATKHAU, HOTENNV, GIOITINHNV, NGAYSINHNV, DIACHINV, SODIENTHOAINV, CHUNGMINHTHU, NGAYBATDAULAMVIEC, NGAYKETTHUCLAMVIEC, TRINHDOHOCVAN, MUCLUONGCOBAN)
values ('NV03','ADMIN','khangnh','123',N'Nguyễn Hoài Khang',N'Nam','22-05-2000',N'TPHCM','0835456270','340773775','14-08-2018','09-12-2020',N'Đại học',6000000)

insert into NHANVIEN(MANV, MANHOMNV, TENDANGNHAP, MATKHAU, HOTENNV, GIOITINHNV, NGAYSINHNV, DIACHINV, SODIENTHOAINV, CHUNGMINHTHU, NGAYBATDAULAMVIEC, NGAYKETTHUCLAMVIEC, TRINHDOHOCVAN, MUCLUONGCOBAN)
values ('NV04','NV','thachhn','123',N'Huỳnh Ngọc Thạch',N'Nam','18-09-2000',N'TPHCM','0918353686','341252221','02-11-2018','27-07-2021',N'Đại học',6000000)

insert into NHANVIEN(MANV, MANHOMNV, TENDANGNHAP, MATKHAU, HOTENNV, GIOITINHNV, NGAYSINHNV, DIACHINV, SODIENTHOAINV, CHUNGMINHTHU, NGAYBATDAULAMVIEC, NGAYKETTHUCLAMVIEC, TRINHDOHOCVAN, MUCLUONGCOBAN)
values ('NV05','NV','myntn','123',N'Nguyễn Thị Ngọc Mỹ',N'Nữ','06-10-2000',N'Đồng Tháp','0889131006','34203831','22-04-2017','20-11-2018',N'Đại học',6000000)

insert into NHANVIEN(MANV, MANHOMNV, TENDANGNHAP, MATKHAU, HOTENNV, GIOITINHNV, NGAYSINHNV, DIACHINV, SODIENTHOAINV, CHUNGMINHTHU, NGAYBATDAULAMVIEC, NGAYKETTHUCLAMVIEC, TRINHDOHOCVAN, MUCLUONGCOBAN)
values ('NV06','NV','thuna','123',N'Nguyễn Anh Thư',N'Nữ','29-04-2000',N'Kiên Giang','0961327210','342032091','01-06-2018','15-03-2020',N'Đại học',6000000)

insert into NHANVIEN(MANV, MANHOMNV, TENDANGNHAP, MATKHAU, HOTENNV, GIOITINHNV, NGAYSINHNV, DIACHINV, SODIENTHOAINV, CHUNGMINHTHU, NGAYBATDAULAMVIEC, NGAYKETTHUCLAMVIEC, TRINHDOHOCVAN, MUCLUONGCOBAN)
values ('NV07','NV','quanlh','123',N'Lê Hoàng Quân',N'Nam','12-12-2000',N'Vĩnh Long','0932789201','341339553','23-02-2018','16-03-2020',N'Cao đẳng',4000000)

insert into NHANVIEN(MANV, MANHOMNV, TENDANGNHAP, MATKHAU, HOTENNV, GIOITINHNV, NGAYSINHNV, DIACHINV, SODIENTHOAINV, CHUNGMINHTHU, NGAYBATDAULAMVIEC, NGAYKETTHUCLAMVIEC, TRINHDOHOCVAN, MUCLUONGCOBAN)
values ('NV08','NV','tantq','123',N'Trần Quốc Tấn',N'Nam','07-08-2000',N'Tây Ninh','0939098248','341995778','06-07-2018','12-10-2020',N'Cao đẳng',4000000)

--==========================================BẢNG LƯƠNG===============================================


set dateformat dmy;
insert into BANGLUONG (MABANGLUONG, MANV, LUONGTHUCTE, NGAYAPDUNG, GHICHUBL) 
values ('BL01','NV01',11000000,'11-01-2019',N'Hoa hồng')

insert into BANGLUONG (MABANGLUONG, MANV, LUONGTHUCTE, NGAYAPDUNG, GHICHUBL) 
values ('BL01','NV03',5500000,'14-08-2018',N'13 tháng')

insert into BANGLUONG (MABANGLUONG, MANV, LUONGTHUCTE, NGAYAPDUNG, GHICHUBL) 
values ('BL02','NV05',5500000,'22-04-2017',N'13 tháng')

insert into BANGLUONG (MABANGLUONG, MANV, LUONGTHUCTE, NGAYAPDUNG) 
values ('BL02','NV07',3500000,'23-02-2018')

insert into BANGLUONG (MABANGLUONG, MANV, LUONGTHUCTE, NGAYAPDUNG) 
values ('BL03','NV08',3500000,'06-07-2018')

--========================================CHẤM CÔNG================================================

insert into CHAMCONG (MANV, MACHAMCONG, THANG, NAM, SONGAYLAMVIEC)
values ('NV01','CC01',6,2020,27)

insert into CHAMCONG (MANV, MACHAMCONG, THANG, NAM, SONGAYLAMVIEC)
values ('NV01','CC02',7,2020,15)

insert into CHAMCONG (MANV, MACHAMCONG, THANG, NAM, SONGAYLAMVIEC)
values ('NV01','CC03',8,2020,20)

insert into CHAMCONG (MANV, MACHAMCONG, THANG, NAM, SONGAYLAMVIEC)
values ('NV02','CC01',9,2020,22)

insert into CHAMCONG (MANV, MACHAMCONG, THANG, NAM, SONGAYLAMVIEC)
values ('NV02','CC02',10,2020,20)

insert into CHAMCONG (MANV, MACHAMCONG, THANG, NAM, SONGAYLAMVIEC)
values ('NV03','CC01',9,2020,22)

insert into CHAMCONG (MANV, MACHAMCONG, THANG, NAM, SONGAYLAMVIEC)
values ('NV03','CC02',10,2020,22)

insert into CHAMCONG (MANV, MACHAMCONG, THANG, NAM, SONGAYLAMVIEC)
values ('NV04','CC01',6,2020,27)

insert into CHAMCONG (MANV, MACHAMCONG, THANG, NAM, SONGAYLAMVIEC)
values ('NV04','CC02',7,2020,15)

insert into CHAMCONG (MANV, MACHAMCONG, THANG, NAM, SONGAYLAMVIEC)
values ('NV04','CC03',8,2020,20)

insert into CHAMCONG (MANV, MACHAMCONG, THANG, NAM, SONGAYLAMVIEC)
values ('NV05','CC01',6,2020,27)

insert into CHAMCONG (MANV, MACHAMCONG, THANG, NAM, SONGAYLAMVIEC)
values ('NV05','CC02',7,2020,28)

insert into CHAMCONG (MANV, MACHAMCONG, THANG, NAM, SONGAYLAMVIEC)
values ('NV05','CC03',8,2020,28)

insert into CHAMCONG (MANV, MACHAMCONG, THANG, NAM, SONGAYLAMVIEC)
values ('NV06','CC01',8,2020,28)

insert into CHAMCONG (MANV, MACHAMCONG, THANG, NAM, SONGAYLAMVIEC)
values ('NV07','CC01',8,2020,28)

insert into CHAMCONG (MANV, MACHAMCONG, THANG, NAM, SONGAYLAMVIEC)
values ('NV08','CC01',8,2020,28)

--=======================================BẬC LƯƠNG===================================================

insert into BACLUONG (MABAC, TENBAC, HESO)
values ('B04',N'Bậc 4',6.92)

insert into BACLUONG (MABAC, TENBAC, HESO)
values ('B03',N'Bậc 3',6.44)

insert into BACLUONG (MABAC, TENBAC, HESO)
values ('B02',N'Bậc 2',4.98)

insert into BACLUONG (MABAC, TENBAC, HESO)
values ('B01',N'Bậc 1',2.32)


--========================================CHI TIẾT BẬC LƯƠNG========================================================

set dateformat dmy;
insert into CHITIETBACLUONG (MABAC, MANV, TUNGAY, DENNGAY)
values ('B04','NV01','11-01-2019','11-04-2019')

insert into CHITIETBACLUONG (MABAC, MANV, TUNGAY, DENNGAY)
values ('B03','NV03','14-08-2018','14-11-2018')

insert into CHITIETBACLUONG (MABAC, MANV, TUNGAY, DENNGAY)
values ('B03','NV05','22-04-2017','22-07-2017')

insert into CHITIETBACLUONG (MABAC, MANV, TUNGAY, DENNGAY)
values ('B02','NV07','23-02-2018','23-05-2018')

insert into CHITIETBACLUONG (MABAC, MANV, TUNGAY, DENNGAY)
values ('B02','NV08','06-07-2018','06-10-2018')

--================================HÃNG SẢN XUẤT=============================================

insert into HANGSANXUAT (MAHSX, TENHSX)
values ('HSX01',N'Công ty Cổ phần HSX03')

insert into HANGSANXUAT (MAHSX, TENHSX)
values ('HSX02',N'Công ty Cổ phần Dược Hậu Giang')

insert into HANGSANXUAT (MAHSX, TENHSX)
values ('HSX03',N'Công ty Cổ phần dược phẩm Nam Hà')

--=================================XUẤT XỨ===============================================
--loaixuatxu là nội địa hay ngoại địa

insert into XUATXU (MAXUATXU, TENXUATXU, LOAIXUATXU)
values ('XX01',N'Nhật Bản',N'Ngoại địa')

insert into XUATXU (MAXUATXU, TENXUATXU, LOAIXUATXU)
values ('XX02',N'Đức',N'Ngoại địa')

insert into XUATXU (MAXUATXU, TENXUATXU, LOAIXUATXU)
values ('XX03',N'Pháp',N'Ngoại địa')

insert into XUATXU (MAXUATXU, TENXUATXU, LOAIXUATXU)
values ('XX04',N'Đà Nẵng',N'Nội địa')

insert into XUATXU (MAXUATXU, TENXUATXU, LOAIXUATXU)
values ('XX05',N'TPHCM',N'Nội địa')
--===================================KỆ THUỐC===========================================

insert into KETHUOC (MAKE, TENKE)
values ('K1',N'Kệ số 1')

insert into KETHUOC (MAKE, TENKE)
values ('K2',N'Kệ số 2')

insert into KETHUOC (MAKE, TENKE)
values ('K3',N'Kệ số 3')

insert into KETHUOC (MAKE, TENKE)
values ('K4',N'Kệ số 4')

insert into KETHUOC (MAKE, TENKE)
values ('K5',N'Kệ số 5')

--===================================LOẠI THUỐC=============================================

insert into LOAITHUOC(MALOAITHUOC, MAKE, TENLOAITHUOC)
values ('L001','K1',N'Thuốc kháng sinh')

insert into LOAITHUOC(MALOAITHUOC, MAKE, TENLOAITHUOC)
values ('L002','K1',N'Thuốc kháng viêm')

insert into LOAITHUOC(MALOAITHUOC, MAKE, TENLOAITHUOC)
values ('L003','K2',N'Giảm đau hạ sốt')

insert into LOAITHUOC(MALOAITHUOC, MAKE, TENLOAITHUOC)
values ('L004','K3',N'Thuốc ho và long đờm')

insert into LOAITHUOC(MALOAITHUOC, MAKE, TENLOAITHUOC)
values ('L005','K4',N'Nhóm dạ dày')

insert into LOAITHUOC(MALOAITHUOC, MAKE, TENLOAITHUOC)
values ('L006','K5',N'Nhóm huyết áp tim mạch')


--====================================THUỐC======================================

set dateformat dmy;
insert into THUOC (MATHUOC, MALOAITHUOC, MAHSX, MAXUATXU, TENTHUOC, HINHTHUOC, THANHPHAN, CONGDUNG, BAOQUAN, GHICHUTHUOC, DVT, SOLOTHUOC, NGAYSANXUAT, HANSUDUNG, DONGIATHUOC, SOLUONGTON)
values ('TH01','L001','HSX01','XX01',N'Oxytetracycline',N'oxytetracycline.png',N'Oxytetracyclin 30 mg, hydrocortison 15 mg, polymyxin B 10.000 đvqt trong 1 gam',N'Sử dụng trong điều trị bệnh tả và bệnh dịch hạch',N'Bảo quản các chế phẩm oxytetracyclin và oxytetracyclin hydroclorid ở nhiệt độ dưới 40oC',N'Hẹp thực quản và/hoặc tắc nghẽn ở đường tiêu hóa. Trẻ em dưới 8 tuổi (nếu dùng uống)',N'Vỉ',32,'18-10-2020','03-03-2022',110000,20)

insert into THUOC (MATHUOC, MALOAITHUOC, MAHSX, MAXUATXU, TENTHUOC, HINHTHUOC, THANHPHAN, CONGDUNG, BAOQUAN, GHICHUTHUOC, DVT, SOLOTHUOC, NGAYSANXUAT, HANSUDUNG, DONGIATHUOC, SOLUONGTON)
values ('TH02','L001','HSX02','XX02',N'Tetracyclin',N'tetracyclin.png',N'Viên nén, hàm lượng 250mg hoặc 500mg',N'Sử dụng để điều trị nhiều loại nhiễm trùng khác nhau',N'Bảo quản ở nhiệt độ phòng, tránh ẩm, tránh ánh sáng',N'Tetracyclin có hiệu quả tốt nhất khi dùng lúc bụng đói, khoảng 1 giờ trước hoặc 2 giờ sau khi ăn',N'Hộp',12,'12-02-2020','12-02-2022',120000,25)

insert into THUOC (MATHUOC, MALOAITHUOC, MAHSX, MAXUATXU, TENTHUOC, HINHTHUOC, THANHPHAN, CONGDUNG, BAOQUAN, GHICHUTHUOC, DVT, SOLOTHUOC, NGAYSANXUAT, HANSUDUNG, DONGIATHUOC, SOLUONGTON)
values ('TH03','L001','HSX03','XX02',N'Amikacin',N'amikacin.jpg',N' Lọ 250 mg hoặc 500 mg bột kèm theo tương ứng 2 ml hoặc 4 ml dung môi',N'Thuốc diệt khuẩn nhanh do gắn hẳn vào tiểu đơn vị 30S của ribosom vi khuẩn và ngăn chặn sự tổng hợp protein của vi khuẩn',N'Giữ ở nhiệt độ phòng, bảo quản được ít nhất 2 năm kể từ ngày sản xuất. Bảo quản tránh ánh sáng',N'Quá mẫn với các aminoglycosid, bệnh nhược cơ',N'Lọ',15,'16-04-2021','16-07-2023',150000,40)

--
insert into THUOC (MATHUOC, MALOAITHUOC, MAHSX, MAXUATXU, TENTHUOC, HINHTHUOC, THANHPHAN, CONGDUNG, BAOQUAN, GHICHUTHUOC, DVT, SOLOTHUOC, NGAYSANXUAT, HANSUDUNG, DONGIATHUOC, SOLUONGTON)
values ('TH04','L002','HSX01','XX02',N'Dexamethason',N'dexamethason.png',N'Kem dexamethason natri phosphat 1mg/1g',N'Dexamethason được dùng để điều trị các bệnh như sốc do chảy máu, do chấn thương, do phẫu thuật, hoặc do nhiễm khuẩn',N'Bảo quản dưới 250C, tránh ánh sáng, không để đông lạnh',N'Quá mẫn với dexamethason hoặc các hợp phần khác của chế phẩm; nhiễm nấm toàn thân, nhiễm virus tại chỗ hoặc nhiễm khuẩn lao',N'Tuýp',27,'25-09-2020','25-09-2021',230000,30)

insert into THUOC (MATHUOC, MALOAITHUOC, MAHSX, MAXUATXU, TENTHUOC, HINHTHUOC, THANHPHAN, CONGDUNG, BAOQUAN, GHICHUTHUOC, DVT, SOLOTHUOC, NGAYSANXUAT, HANSUDUNG, DONGIATHUOC, SOLUONGTON)
values ('TH05','L002','HSX03','XX02',N'Diclofenac',N'diclofenac.png',N'Diclofenac 50mg, sắt III oxid, PVP vd 1 viên',N'Sử dụng để giảm đau, sưng tấy hoặc viêm do các thương tích và các triệu chứng như viêm khớp, viêm thấp khớp, kinh nguyệt',N'bảo quản ở nhiệt độ phòng, tránh ẩm và tránh ánh sáng. Không bảo quản trong phòng tắm hoặc trong ngăn đá',N'Quá mẫn đã biết với hoạt chất hay tá dược của thuốc. Loét dạ dày tá tràng',N'Hộp',14,'12-12-2019','12-12-2021',200000,25)


--
insert into THUOC (MATHUOC, MALOAITHUOC, MAHSX, MAXUATXU, TENTHUOC, HINHTHUOC, THANHPHAN, CONGDUNG, BAOQUAN, GHICHUTHUOC, DVT, SOLOTHUOC, NGAYSANXUAT, HANSUDUNG, DONGIATHUOC, SOLUONGTON)
values ('TH06','L003','HSX01','XX01',N'Acid acetylsalicylic',N'acetylsalicylic.jpg',N'Aspirin 81mg, tá dược vừa đủ 1 viên',N'Có tác dụng giảm đau, hạ nhiệt và chống viêm',N'Để nơi khô ráo và mát. Không dùng nếu thấy mùi dấm',N'Mẫn cảm với acid acetylsalicylic hoặc các thuốc chống viêm không steroid khác',N'Hộp',19,'26-11-2020','26-11-2021',300000,20)

insert into THUOC (MATHUOC, MALOAITHUOC, MAHSX, MAXUATXU, TENTHUOC, HINHTHUOC, THANHPHAN, CONGDUNG, BAOQUAN, GHICHUTHUOC, DVT, SOLOTHUOC, NGAYSANXUAT, HANSUDUNG, DONGIATHUOC, SOLUONGTON)
values ('TH07','L003','HSX03','XX02',N'Diflunisal',N'diflunisal.jpg',N'Diflunisal 500mg, tá dược vừa đủ',N'Ðiều trị triệu chứng (giảm đau) và viêm trong bệnh viêm khớp dạng thấp hoặc viêm xương khớp cấp và mạn',N'Bảo quản thuốc ở nhiệt độ dưới 250C trong bao gói thật kín và tránh ánh sáng',N'Không dùng diflunisal làm thuốc hạ sốt. Quá mẫn với diflunisal',N'Vỉ',22,'05-04-2020','05-04-2022',265000,30)

--
insert into THUOC (MATHUOC, MALOAITHUOC, MAHSX, MAXUATXU, TENTHUOC, HINHTHUOC, THANHPHAN, CONGDUNG, BAOQUAN, GHICHUTHUOC, DVT, SOLOTHUOC, NGAYSANXUAT, HANSUDUNG, DONGIATHUOC, SOLUONGTON)
values ('TH08','L004','HSX02','XX03',N'Acetylcystein',N'acetylcystein.png',N'Acetylcystein 100mg, tá dược vừa đủ',N'Acetylcystein là thuốc thuộc nhóm thuốc long đờm, có tác dụng làm loãng chất nhầy để chúng dễ dàng lưu thông qua phổi',N'Được bảo quản ở nhiệt độ phòng, tránh ẩm, tránh ánh sáng',N'Acetylcysteine chống chỉ định cho bệnh nhân hen suyễn hoặc có tiền sử hen',N'Vỉ',25,'08-05-2019','08-05-2022',220000,25)

insert into THUOC (MATHUOC, MALOAITHUOC, MAHSX, MAXUATXU, TENTHUOC, HINHTHUOC, THANHPHAN, CONGDUNG, BAOQUAN, GHICHUTHUOC, DVT, SOLOTHUOC, NGAYSANXUAT, HANSUDUNG, DONGIATHUOC, SOLUONGTON)
values ('TH09','L004','HSX03','XX03',N'Kali iodid',N'kaliiodid.jpg',N'Potassium iodide',N'Làm giảm nhanh các triệu chứng bằng cách ức chế giải phóng hormon giáp vào tuần hoàn',N'Bảo quản thuốc dưới 400C, tốt nhất là trong khoảng 15 đến 300C, trong lọ hoặc hộp kín, tránh ánh sáng',N'Có tiền sử mẫn cảm với kali iodid; người đang bị viêm phế quản cấp',N'Lọ',28,'06-06-2020','06-06-2022',160000,30)

insert into THUOC (MATHUOC, MALOAITHUOC, MAHSX, MAXUATXU, TENTHUOC, HINHTHUOC, THANHPHAN, CONGDUNG, BAOQUAN, GHICHUTHUOC, DVT, SOLOTHUOC, NGAYSANXUAT, HANSUDUNG, DONGIATHUOC, SOLUONGTON)
values ('TH10','L004','HSX01','XX03',N'Mesna',N'mesna.jpg',N'Mesna 200mg, tá dược vừa đủ',N'Mesna có tác dụng ngăn ngừa hoặc giảm thiểu những tác dụng độc hại của hóa trị đối với bàng quang',N'Bảo quản ở nơi khô ráo, tránh ánh sáng, không được để trong ngăn đá hay phòng tắm',N'Quá mẫn với mesna hoặc các phức hợp khác có thiol',N'Hộp',26,'01-10-2020','01-10-2021',180000,35)

--
insert into THUOC (MATHUOC, MALOAITHUOC, MAHSX, MAXUATXU, TENTHUOC, HINHTHUOC, THANHPHAN, CONGDUNG, BAOQUAN, GHICHUTHUOC, DVT, SOLOTHUOC, NGAYSANXUAT, HANSUDUNG, DONGIATHUOC, SOLUONGTON)
values ('TH11','L005','HSX01','XX01',N'Omeprazol',N'omeprazol.jpg',N'Omeprazol 20mg, tá dược vừa đủ',N'Thuốc thường được dùng để điều trị bệnh viêm thực quản, trào ngược dạ dày – thực quản, viêm loét dạ dày – tá tràng',N'Bảo quản ở nhiệt độ phòng, tránh ẩm ướt và ánh sáng trực tiếp',N'Dị ứng hoặc mẫn cảm với bất cứ thành phần nào của thuốc',N'Hộp',24,'15-11-2019','15-11-2021',90000,30)

insert into THUOC (MATHUOC, MALOAITHUOC, MAHSX, MAXUATXU, TENTHUOC, HINHTHUOC, THANHPHAN, CONGDUNG, BAOQUAN, GHICHUTHUOC, DVT, SOLOTHUOC, NGAYSANXUAT, HANSUDUNG, DONGIATHUOC, SOLUONGTON)
values ('TH12','L005','HSX02','XX03',N'Lansoprazol',N'lansoprazol.jpg',N'Lansoprazol 30mg, tá dược đủ',N'Lansoprazol được dùng điều trị ngắn ngày chứng loét dạ dày - tá tràng và điều trị dài ngày các chứng tăng tiết dịch tiêu hóa bệnh lý',N'Bảo quản ở nhiệt độ phòng',N'Quá mẫn với lansoprazol hoặc các thành phần khác của thuốc. Có thai trong 3 tháng đầu',N'Vỉ',23,'21-09-2019','21-09-2021',90000,25)
   
--
insert into THUOC (MATHUOC, MALOAITHUOC, MAHSX, MAXUATXU, TENTHUOC, HINHTHUOC, THANHPHAN, CONGDUNG, BAOQUAN, GHICHUTHUOC, DVT, SOLOTHUOC, NGAYSANXUAT, HANSUDUNG, DONGIATHUOC, SOLUONGTON)
values ('TH13','L006','HSX02','XX04',N'Indometacin',N'indomecatin.png',N'Indometacin 25mg',N'Indomethacin có tác dụng giảm đau, hạ sốt, chống viêm và ức chế kết tập tiểu cầu',N'Bảo quản nang indomethacin trong lọ kín ở nhiệt độ 15 - 30oC',N'Người có tiền sử mẫn cảm với indomethacin và các chất tương tự, kể cả với aspirin',N'Lọ',27,'24-05-2021','24-01-2023',130000,30)

insert into THUOC (MATHUOC, MALOAITHUOC, MAHSX, MAXUATXU, TENTHUOC, HINHTHUOC, THANHPHAN, CONGDUNG, BAOQUAN, GHICHUTHUOC, DVT, SOLOTHUOC, NGAYSANXUAT, HANSUDUNG, DONGIATHUOC, SOLUONGTON)
values ('TH14','L006','HSX03','XX03',N'Adenosin',N'adenosin.png',N'Adenosin 30mg',N'Adenosine là thuốc chống loạn nhịp và là một nucleoside',N'Ðể thuốc nơi mát 15 - 300C. Tránh ánh sáng. Không để đông lạnh',N'Người đã có từ trước hội chứng suy nút xoang hay blốc nhĩ thất độ hai hoặc ba mà không cấy máy tạo nhịp',N'Hộp',29,'09-05-2020','09-05-2021',150000,30)

--==================================TỈNH THÀNH===============================================

insert into TINHTHANH (MATINHTHANH, TENTINHTHANH)
values ('01',N'An Giang')

insert into TINHTHANH (MATINHTHANH, TENTINHTHANH)
values ('02',N'Bà Rịa - Vũng Tàu')

insert into TINHTHANH (MATINHTHANH, TENTINHTHANH)
values ('03',N'Bạc Liêu')

insert into TINHTHANH (MATINHTHANH, TENTINHTHANH)
values ('04',N'Bắc Giang')

insert into TINHTHANH (MATINHTHANH, TENTINHTHANH)
values ('05',N'Bắc Cạn')

insert into TINHTHANH (MATINHTHANH, TENTINHTHANH)
values ('06',N'Bắc Ninh')

insert into TINHTHANH (MATINHTHANH, TENTINHTHANH)
values ('07',N'Bến Tre')

insert into TINHTHANH (MATINHTHANH, TENTINHTHANH)
values ('08',N'Bình Dương')

insert into TINHTHANH (MATINHTHANH, TENTINHTHANH)
values ('09',N'Bình Định')

insert into TINHTHANH (MATINHTHANH, TENTINHTHANH)
values ('10',N'Bình Phước')

insert into TINHTHANH (MATINHTHANH, TENTINHTHANH)
values ('11',N'Bình Thuận')

insert into TINHTHANH (MATINHTHANH, TENTINHTHANH)
values ('12',N'Cà Mau')

insert into TINHTHANH (MATINHTHANH, TENTINHTHANH)
values ('13',N'Cao Bằng')

insert into TINHTHANH (MATINHTHANH, TENTINHTHANH)
values ('14',N'Cần Thơ')

insert into TINHTHANH (MATINHTHANH, TENTINHTHANH)
values ('15',N'Đà Nẵng')

insert into TINHTHANH (MATINHTHANH, TENTINHTHANH)
values ('16',N'Đắk Lắk')

insert into TINHTHANH (MATINHTHANH, TENTINHTHANH)
values ('17',N'Đắk Nông')

insert into TINHTHANH (MATINHTHANH, TENTINHTHANH)
values ('18',N'Điện Biên')

insert into TINHTHANH (MATINHTHANH, TENTINHTHANH)
values ('19',N'Đồng Nai')

insert into TINHTHANH (MATINHTHANH, TENTINHTHANH)
values ('20',N'Đồng Tháp')

insert into TINHTHANH (MATINHTHANH, TENTINHTHANH)
values ('21',N'Gia Lai')

insert into TINHTHANH (MATINHTHANH, TENTINHTHANH)
values ('22',N'Hà Giang')

insert into TINHTHANH (MATINHTHANH, TENTINHTHANH)
values ('23',N'Hà Nam')

insert into TINHTHANH (MATINHTHANH, TENTINHTHANH)
values ('24',N'Hà Nội')

insert into TINHTHANH (MATINHTHANH, TENTINHTHANH)
values ('25',N'Hà Tĩnh')

insert into TINHTHANH (MATINHTHANH, TENTINHTHANH)
values ('26',N'Hải Dương')

insert into TINHTHANH (MATINHTHANH, TENTINHTHANH)
values ('27',N'Hải Phòng')

insert into TINHTHANH (MATINHTHANH, TENTINHTHANH)
values ('28',N'Hậu Giang')

insert into TINHTHANH (MATINHTHANH, TENTINHTHANH)
values ('29',N'Hòa Bình')

insert into TINHTHANH (MATINHTHANH, TENTINHTHANH)
values ('30',N'TP. Hồ Chí Minh')

insert into TINHTHANH (MATINHTHANH, TENTINHTHANH)
values ('31',N'Hưng Yên')

insert into TINHTHANH (MATINHTHANH, TENTINHTHANH)
values ('32',N'Khánh Hòa')

insert into TINHTHANH (MATINHTHANH, TENTINHTHANH)
values ('33',N'Kiên Giang')

insert into TINHTHANH (MATINHTHANH, TENTINHTHANH)
values ('34',N'Kon Tum')

insert into TINHTHANH (MATINHTHANH, TENTINHTHANH)
values ('35',N'Lai Châu')

insert into TINHTHANH (MATINHTHANH, TENTINHTHANH)
values ('36',N'Lạng Sơn')

insert into TINHTHANH (MATINHTHANH, TENTINHTHANH)
values ('37',N'Lào Cai')

insert into TINHTHANH (MATINHTHANH, TENTINHTHANH)
values ('38',N'Lâm Đồng')

insert into TINHTHANH (MATINHTHANH, TENTINHTHANH)
values ('39',N'Long An')

insert into TINHTHANH (MATINHTHANH, TENTINHTHANH)
values ('40',N'Nam Định')

insert into TINHTHANH (MATINHTHANH, TENTINHTHANH)
values ('41',N'Nghệ An')

insert into TINHTHANH (MATINHTHANH, TENTINHTHANH)
values ('42',N'Ninh Bình')

insert into TINHTHANH (MATINHTHANH, TENTINHTHANH)
values ('43',N'Ninh Thuận')

insert into TINHTHANH (MATINHTHANH, TENTINHTHANH)
values ('44',N'Phú Thọ')

insert into TINHTHANH (MATINHTHANH, TENTINHTHANH)
values ('45',N'Phú Yên')

insert into TINHTHANH (MATINHTHANH, TENTINHTHANH)
values ('46',N'Quảng Bình')

insert into TINHTHANH (MATINHTHANH, TENTINHTHANH)
values ('47',N'Quảng Nam')

insert into TINHTHANH (MATINHTHANH, TENTINHTHANH)
values ('48',N'Quảng Ngãi')

insert into TINHTHANH (MATINHTHANH, TENTINHTHANH)
values ('49',N'Quảng Ninh')

insert into TINHTHANH (MATINHTHANH, TENTINHTHANH)
values ('50',N'Quảng Trị')

insert into TINHTHANH (MATINHTHANH, TENTINHTHANH)
values ('51',N'Sóc Trăng')

insert into TINHTHANH (MATINHTHANH, TENTINHTHANH)
values ('52',N'Sơn La')

insert into TINHTHANH (MATINHTHANH, TENTINHTHANH)
values ('53',N'Tây Ninh')

insert into TINHTHANH (MATINHTHANH, TENTINHTHANH)
values ('54',N'Thái Bình')

insert into TINHTHANH (MATINHTHANH, TENTINHTHANH)
values ('55',N'Thái Nguyên')

insert into TINHTHANH (MATINHTHANH, TENTINHTHANH)
values ('56',N'Thanh Hóa')

insert into TINHTHANH (MATINHTHANH, TENTINHTHANH)
values ('57',N'Thừa Thiên Huế')

insert into TINHTHANH (MATINHTHANH, TENTINHTHANH)
values ('58',N'Tiền Giang')

insert into TINHTHANH (MATINHTHANH, TENTINHTHANH)
values ('59',N'Trà Vinh')

insert into TINHTHANH (MATINHTHANH, TENTINHTHANH)
values ('60',N'Tuyên Quang')

insert into TINHTHANH (MATINHTHANH, TENTINHTHANH)
values ('61',N'Vĩnh Long')

insert into TINHTHANH (MATINHTHANH, TENTINHTHANH)
values ('62',N'Vĩnh Phúc')

insert into TINHTHANH (MATINHTHANH, TENTINHTHANH)
values ('63',N'Yên Bái')

--====================================QUẬN HUYỆNH============================================

insert into QUANHUYEN (MAQUANHUYEN, MATINHTHANH,TENQUANHUYEN)
values 
('01', '01', N'Huyện An Phú'),
('02', '01', N'Huyện Phú Tân'),
('03', '01', N'Huyện Tịnh Biên'),
('04', '01', N'Huyện Tri Tôn'),
('05', '01', N'Huyện Châu Phú'),
('06', '01', N'Huyện Chợ Mới'),
('07', '01', N'Huyện Châu Thành'),
('08', '01', N'Huyện Thoại Sơn')

--

insert into QUANHUYEN (MAQUANHUYEN, MATINHTHANH,TENQUANHUYEN)
values 
('09', '02', N'Huyện Xuyên Mộc'),
('10', '02', N'Huyện Long Điền'),
('11', '02', N'Huyện Côn Đảo'),
('12', '02', N'Huyện Châu Đức'),
('13', '02', N'Huyện Đất Đỏ')

--

insert into QUANHUYEN (MAQUANHUYEN, MATINHTHANH,TENQUANHUYEN)
values 
('14', '03', N'Huyện Vĩnh Lợi'),
('15', '03', N'Huyện Hồng Dân'),
('16', '03', N'Huyện Phước Long'),
('17', '03', N'Huyện Đông Hải'),
('18', '03', N'Huyện Hòa Bình')

--

insert into QUANHUYEN (MAQUANHUYEN, MATINHTHANH,TENQUANHUYEN)
values 
('19', '04', N'Huyện Yên Thế'),
('20', '04', N'Huyện Lục Ngạn'),
('21', '04', N'Huyện Sơn Động'),
('22', '04', N'Huyện Lục Nam'),
('23', '04', N'Huyện Tân Yên'),
('24', '04', N'Huyện Hiệp Hòa'),
('25', '04', N'Huyện Lạng Giang'),
('26', '04', N'Huyện Việt Yên'),
('27', '04', N'Huyện Yên Dũng')

--

insert into QUANHUYEN (MAQUANHUYEN, MATINHTHANH,TENQUANHUYEN)
values 
('28', '05', N'Huyện Chợ Đồn'),
('29', '05', N'Huyện Bạch Thông'),
('30', '05', N'Huyện Na Rì'),
('31', '05', N'Huyện Ngân Sơn'),
('32', '05', N'Huyện Ba Bể'),
('34', '05', N'Huyện Pác Nặm')

--

insert into QUANHUYEN (MAQUANHUYEN, MATINHTHANH,TENQUANHUYEN)
values 
('35', '06', N'Huyện Yên Phong'),
('36', '06', N'Huyện Quế Võ'),
('37', '06', N'Huyện Tiên Du'),
('38', '06', N'Huyện Thuận Thành'),
('39', '06', N'Huyện Gia Bình'),
('40', '06', N'Huyện Lương Tài')

--

insert into QUANHUYEN (MAQUANHUYEN, MATINHTHANH,TENQUANHUYEN)
values 
('42', '07', N'Huyện Chợ Lách'),
('43', '07', N'Huyện Mỏ Cày Bắc'),
('44', '07', N'Huyện Giồng Trôm'),
('45', '07', N'Huyện Bình Đại'),
('46', '07', N'Huyện Ba Tri'),
('47', '07', N'Huyện Thạnh Phú'),
('48', '07', N'Huyện Mỏ Cày Nam')

--

insert into QUANHUYEN (MAQUANHUYEN, MATINHTHANH,TENQUANHUYEN)
values 
('49', '08', N'Huyện Phú Giáo'),
('50', '08', N'Huyện Dầu Tiếng'),
('51', '08', N'Huyện Bắc Tân Uyên'),
('52', '08', N'Huyện Bàu Bàng')

--

insert into QUANHUYEN (MAQUANHUYEN, MATINHTHANH,TENQUANHUYEN)
values 
('53', '09', N'Huyện An Lão'),
('54', '09', N'Huyện Hoài Ân'),
('55', '09', N'Huyện Hoài Nhơn'),
('56', '09', N'Huyện Phù Mỹ'),
('57', '09', N'Huyện Phù Cát'),
('58', '09', N'Huyện Vĩnh Thạnh'),
('59', '09', N'Huyện Tây Sơn'),
('60', '09', N'Huyện Vân Canh'),
('61', '09', N'Huyện Tuy Phước')

--

insert into QUANHUYEN (MAQUANHUYEN, MATINHTHANH,TENQUANHUYEN)
values 
('62', '10', N'Huyện Đồng Phú'),
('63', '10', N'Huyện Chơn Thành'),
('64', '10', N'Huyện Lộc Ninh'),
('65', '10', N'Huyện Bù Đốp'),
('66', '10', N'Huyện Bù Đăng'),
('67', '10', N'Huyện Hớn Quản'),
('68', '10', N'Huyện Bù Gia Mập'),
('69', '10', N'Huyện Phú Riềng')

--

insert into QUANHUYEN (MAQUANHUYEN, MATINHTHANH,TENQUANHUYEN)
values 
('70', '11', N'Huyện Tuy Phong'),
('71', '11', N'Huyện Bắc Bình'),
('72', '11', N'Huyện Hàm Thuận Bắc'),
('73', '11', N'Huyện Hàm Thuận Nam'),
('74', '11', N'Huyện Hàm Tân'),
('75', '11', N'Huyện Đức Linh'),
('76', '11', N'Huyện Tánh Linh'),
('77', '11', N'Huyện Đảo Phú Quý')

--

insert into QUANHUYEN (MAQUANHUYEN, MATINHTHANH,TENQUANHUYEN)
values 
('78', '12', N'Huyện Thới Bình'),
('79', '12', N'Huyện U Minh'),
('80', '12', N'Huyện Trần Văn Thời'),
('81', '12', N'Huyện Cái Nước'),
('82', '12', N'Huyện Đầm Dơi'),
('83', '12', N'Huyện Ngọc Hiển'),
('84', '12', N'Huyện Năm Căn')

--

insert into QUANHUYEN (MAQUANHUYEN, MATINHTHANH,TENQUANHUYEN)
values 
('86', '13', N'Huyện Bảo Lạc'),
('87', '13', N'Huyện Thông Nông'),
('88', '13', N'Huyện Hà Quảng'),
('89', '13', N'Huyện Trà Lĩnh'),
('90', '13', N'Huyện Trùng Khánh'),
('91', '13', N'Huyện Nguyên Bình'),
('92', '13', N'Huyện Hoà An'),
('93', '13', N'Huyện Quảng Uyên'),
('94', '13', N'Huyện Thạch An'),
('95', '13', N'Huyện Hạ Lang'),
('96', '13', N'Huyện Bảo Lâm'),
('97', '13', N'Huyện Phục Hoà')

--

insert into QUANHUYEN (MAQUANHUYEN, MATINHTHANH,TENQUANHUYEN)
values 
('98', '14', N'Quận Ninh Kiều'),
('99', '14', N'Quận Bình Thủy'),
('100', '14', N'Quận Cái Răng'),
('101', '14', N'Quận Ô Môn'),
('102', '14', N'Huyện Phong Điền'),
('103', '14', N'Huyện Cờ Đỏ'),
('105', '14', N'Quận Thốt Nốt'),
('106', '14', N'Quận Thới Lai')

--

insert into QUANHUYEN (MAQUANHUYEN, MATINHTHANH,TENQUANHUYEN)
values 
('107', '15', N'Quận Hải Châu'),
('108', '15', N'Quận Thanh Khê'),
('109', '15', N'Quận Sơn Trà'),
('110', '15', N'Quận Ngũ Hành Sơn'),
('111', '15', N'Quận Liên Chiểu'),
('112', '15', N'Huyện Hòa Vang'),
('113', '15', N'Quận Cẩm Lệ')

--

insert into QUANHUYEN (MAQUANHUYEN, MATINHTHANH,TENQUANHUYEN)
values 
('114', '16', N'Huyện Ea HLeo'),
('115', '16', N'Huyện Krông Buk'),
('116', '16', N'Huyện Krông Năng'),
('117', '16', N'Huyện Ea Súp'),
('118', '16', N'Huyện Cư Mgar'),
('119', '16', N'Huyện Krông Pắk'),
('120', '16', N'Huyện Ea Kar'),
('121', '16', N'Huyện MDrăk'),
('122', '16', N'Huyện Krông Ana'),
('123', '16', N'Huyện Krông Bông'),
('124', '16', N'Huyện Lắk'),
('125', '16', N'Huyện Buôn Đôn'),
('126', '16', N'Huyện Cư Kuin'),
('127', '16', N'Huyện Thị xã Buôn Hồ')

--

insert into QUANHUYEN (MAQUANHUYEN, MATINHTHANH,TENQUANHUYEN)
values 
('128', '17', N'Huyện Đăk RLấp'),
('129', '17', N'Huyện Đăk Mil'),
('130', '17', N'Huyện Cư Jút'),
('131', '17', N'Huyện Đăk Song'),
('132', '17', N'Huyện Krông Nô'),
('133', '17', N'Huyện Đăk Glong'),
('134', '17', N'Huyện Tuy Đức')

--

insert into QUANHUYEN (MAQUANHUYEN, MATINHTHANH,TENQUANHUYEN)
values 
('135', '18', N'Huyện Điện Biên'),
('136', '18', N'Huyện Tuần Giáo'),
('137', '18', N'Huyện Mường Chà'),
('138', '18', N'Huyện Tủa Chùa'),
('139', '18', N'Huyện Điện Biên Đông'),
('140', '18', N'Huyện Mường Nhé'),
('141', '18', N'Huyện Mường Ảng'),
('142', '18', N'Huyện Nậm Pồ')

--

insert into QUANHUYEN (MAQUANHUYEN, MATINHTHANH,TENQUANHUYEN)
values 
('143', '19', N'Huyện Vĩnh Cửu'),
('144', '19', N'Huyện Tân Phú'),
('145', '19', N'Huyện Định Quán'),
('146', '19', N'Huyện Thống Nhất'),
('147', '19', N'Huyện Xuân Lộc'),
('148', '19', N'Huyện Long Thành'),
('149', '19', N'Huyện Nhơn Trạch'),
('150', '19', N'Huyện Trảng Bom'),
('151', '19', N'Huyện Cẩm Mỹ')

--

insert into QUANHUYEN (MAQUANHUYEN, MATINHTHANH,TENQUANHUYEN)
values 
('153', '20', N'Huyện Lai Vung'),
('154', '20', N'Huyện Lấp Vò'),
('155', '20', N'Huyện Cao Lãnh'),
('156', '20', N'Huyện Tháp Mười'),
('157', '20', N'Huyện Tam Nông'),
('158', '20', N'Huyện Thanh Bình'),
('159', '20', N'Huyện Hồng Ngự'),
('160', '20', N'Huyện Tân Hồng')

--

insert into QUANHUYEN (MAQUANHUYEN, MATINHTHANH,TENQUANHUYEN)
values 
('161', '21', N'Huyện Chư Păh'),
('162', '21', N'Huyện Mang Yang'),
('163', '21', N'Huyện KBang'),
('164', '21', N'Huyện Kông Chro'),
('165', '21', N'Huyện Đức Cơ'),
('166', '21', N'Huyện Chư Prông'),
('167', '21', N'Huyện Chư Sê'),
('168', '21', N'Huyện Krông Pa'),
('169', '21', N'Huyện Ia Grai'),
('170', '21', N'Huyện Đak Đoa'),
('171', '21', N'Huyện Ia Pa'),
('172', '21', N'Huyện Đak Pơ'),
('173', '21', N'Huyện Phú Thiện'),
('174', '21', N'Huyện Chư Pưh')

--

insert into QUANHUYEN (MAQUANHUYEN, MATINHTHANH,TENQUANHUYEN)
values 
('175', '22', N'Huyện Đồng Văn'),
('176', '22', N'Huyện Mèo Vạc'),
('177', '22', N'Huyện Yên Minh'),
('178', '22', N'Huyện Quản Bạ'),
('179', '22', N'Huyện Vị Xuyên'),
('180', '22', N'Huyện Bắc Mê'),
('181', '22', N'Huyện Hoàng Su Phì'),
('182', '22', N'Huyện Xín Mần'),
('183', '22', N'Huyện Bắc Quang'),
('184', '22', N'Huyện Quang Bình')

--

insert into QUANHUYEN (MAQUANHUYEN, MATINHTHANH,TENQUANHUYEN)
values 
('185', '23', N'Huyện Duy Tiên'),
('186', '23', N'Huyện Kim Bảng'),
('187', '23', N'Huyện Lý Nhân'),
('188', '23', N'Huyện Thanh Liêm'),
('189', '23', N'Huyện Bình Lục')

--

insert into QUANHUYEN (MAQUANHUYEN, MATINHTHANH,TENQUANHUYEN)
values 
('190', '24', N'Quận Ba Đình'),
('191', '24', N'Quận Hoàn Kiếm'),
('192', '24', N'Quận Hai Bà Trưng'),
('193', '24', N'Quận Đống Đa'),
('194', '24', N'Quận Tây Hồ'),
('195', '24', N'Quận Cầu Giấy'),
('196', '24', N'Quận Thanh Xuân'),
('197', '24', N'Quận Hoàng Mai'),
('198', '24', N'Quận Long Biên'),
('199', '24', N'Quận Bắc Từ Liêm'),
('200', '24', N'Huyện Thanh Trì'),
('201', '24', N'Huyện Gia Lâm'),
('202', '24', N'Huyện Đông Anh'),
('203', '24', N'Huyện Sóc Sơn'),
('204', '24', N'Quận Hà Đông'),
('205', '24', N'Huyện Ba Vì'),
('206', '24', N'Huyện Phúc Thọ'),
('207', '24', N'Huyện Thạch Thất'),
('208', '24', N'Huyện Quốc Oai'),
('209', '24', N'Huyện Chương Mỹ'),
('210', '24', N'Huyện Đan Phượng'),
('211', '24', N'Huyện Hoài Đức'),
('212', '24', N'Huyện Thanh Oai'),
('213', '24', N'Huyện Mỹ Đức'),
('214', '24', N'Huyện Ứng Hòa'),
('215', '24', N'Huyện Thường Tín'),
('216', '24', N'Huyện Phú Xuyên'),
('217', '24', N'Huyện Mê Linh'),
('218', '24', N'Quận Nam Từ Liêm'),
('219', '24', N'Huyện Từ Liêm')

 --

insert into QUANHUYEN (MAQUANHUYEN, MATINHTHANH,TENQUANHUYEN)
values 
('220', '25', N'Huyện Hương Sơn'),
('221', '25', N'Huyện Đức Thọ'),
('222', '25', N'Huyện Nghi Xuân'),
('223', '25', N'Huyện Can Lộc'),
('224', '25', N'Huyện Hương Khê'),
('225', '25', N'Huyện Thạch Hà'),
('226', '25', N'Huyện Cẩm Xuyên'),
('227', '25', N'Huyện Kỳ Anh'),
('228', '25', N'Huyện Vũ Quang'),
('229', '25', N'Huyện Lộc Hà')

--

insert into QUANHUYEN (MAQUANHUYEN, MATINHTHANH,TENQUANHUYEN)
values 
('230', '26', N'Huyện Nam Sách'),
('231', '26', N'Huyện Kinh Môn'),
('232', '26', N'Huyện Gia Lộc'),
('233', '26', N'Huyện Tứ Kỳ:'),
('234', '26', N'Huyện Thanh Miện'),
('235', '26', N'Huyện Ninh Giang'),
('236', '26', N'Huyện Cẩm Giàng'),
('237', '26', N'Huyện Thanh Hà'),
('238', '26', N'Huyện Kim Thành'),
('239', '26', N'Huyện Bình Giang')

--

insert into QUANHUYEN (MAQUANHUYEN, MATINHTHANH,TENQUANHUYEN)
values 
('240', '27', N'Quận Hồng Bàng'),
('241', '27', N'Quận Lê Chân'),
('242', '27', N'Quận Ngô Quyền'),
('243', '27', N'Quận Kiến An'),
('244', '27', N'Quận Hải An'),
('245', '27', N'Quận Đồ Sơn'),
('247', '27', N'Huyện Kiến Thụy'),
('248', '27', N'Huyện Thủy Nguyên'),
('249', '27', N'Huyện An Dương'),
('250', '27', N'Huyện Tiên Lãng'),
('251', '27', N'Huyện Vĩnh Bảo'),
('252', '27', N'Huyện Cát Hải'),
('253', '27', N'Quận Dương Kinh')

--

insert into QUANHUYEN (MAQUANHUYEN, MATINHTHANH,TENQUANHUYEN)
values 
('254', '28', N'Huyện Vị Thủy'),
('255', '28', N'Huyện Long Mỹ'),
('256', '28', N'Huyện Phụng Hiệp'),
('258', '28', N'Huyện Châu Thành A')

--

insert into QUANHUYEN (MAQUANHUYEN, MATINHTHANH,TENQUANHUYEN)
values 
('259', '29', N'Huyện Đà Bắc'),
('260', '29', N'Huyện Mai Châu'),
('261', '29', N'Huyện Tân Lạc'),
('262', '29', N'Huyện Lạc Sơn'),
('263', '29', N'Huyện Kỳ Sơn'),
('264', '29', N'Huyện Lương Sơn'),
('265', '29', N'Huyện Kim Bôi'),
('266', '29', N'Huyện Lạc Thuỷ'),
('267', '29', N'Huyện Yên Thuỷ'),
('268', '29', N'Huyện Cao Phong')

--

insert into QUANHUYEN (MAQUANHUYEN, MATINHTHANH,TENQUANHUYEN)
values 
('269', '30', N'Quận 1'),
('270', '30', N'Quận 2'),
('271', '30', N'Quận 3'),
('272', '30', N'Quận 4'),
('273', '30', N'Quận 5'),
('274', '30', N'Quận 6'),
('275', '30', N'Quận 7'),
('276', '30', N'Quận 8'),
('277', '30', N'Quận 9'),
('278', '30', N'Quận 10'),
('279', '30', N'Quận 11'),
('280', '30', N'Quận 12'),
('281', '30', N'Quận Gò Vấp'),
('282', '30', N'Quận Tân Bình'),
('283', '30', N'Quận Tân Phú'),
('284', '30', N'Quận Bình Thạnh'),
('285', '30', N'Quận Phú Nhuận'),
('286', '30', N'Quận Thủ Đức'),
('287', '30', N'Quận Bình Tân'),
('288', '30', N'Huyện Bình Chánh'),
('289', '30', N'Huyện Củ Chi'),
('290', '30', N'Huyện Hóc Môn'),
('291', '30', N'Huyện Nhà Bè'),
('292', '30', N'Huyện Cần Giờ')

--

insert into QUANHUYEN (MAQUANHUYEN, MATINHTHANH,TENQUANHUYEN)
values 
('293', '31', N'Huyện Kim Động'),
('294', '31', N'Huyện Ân Thi'),
('295', '31', N'Huyện Khoái Châu'),
('296', '31', N'Huyện Yên Mỹ'),
('297', '31', N'Huyện Tiên Lữ'),
('298', '31', N'Huyện Phù Cừ'),
('299', '31', N'Huyện Mỹ Hào'),
('300', '31', N'Huyện Văn Lâm'),
('301', '31', N'Huyện Văn Giang')

--

insert into QUANHUYEN (MAQUANHUYEN, MATINHTHANH,TENQUANHUYEN)
values 
('302', '32', N'Huyện Vạn Ninh'),
('304', '32', N'Huyện Diên Khánh'),
('305', '32', N'Huyện Khánh Vĩnh'),
('306', '32', N'Huyện Khánh Sơn'),
('307', '32', N'Huyện Cam Lâm')

--

insert into QUANHUYEN (MAQUANHUYEN, MATINHTHANH,TENQUANHUYEN)
values 
('308', '33', N'Huyện Kiên Lương'),
('309', '33', N'Huyện Hòn Đất'),
('310', '33', N'Huyện Tân Hiệp'),
('312', '33', N'Huyện Giồng Riềng'),
('313', '33', N'Huyện Gò Quao'),
('314', '33', N'Huyện An Biên'),
('315', '33', N'Huyện An Minh'),
('316', '33', N'Huyện Vĩnh Thuận'),
('317', '33', N'Huyện Phú Quốc'),
('318', '33', N'Huyện Kiên Hải'),
('319', '33', N'Huyện U Minh Thượng'),
('320', '33', N'Huyện Giang Thành')

--

insert into QUANHUYEN (MAQUANHUYEN, MATINHTHANH,TENQUANHUYEN)
values 
('321', '34', N'Huyện Đăk Glei'),
('322', '34', N'Huyện Ngọc Hồi'),
('323', '34', N'Huyện Đăk Tô'),
('324', '34', N'Huyện Sa Thầy'),
('325', '34', N'Huyện Kon Plông'),
('326', '34', N'Huyện Đăk Hà'),
('327', '34', N'Huyện Kon Rẫy'),
('328', '34', N'Huyện Tu Mơ Rông')

--

insert into QUANHUYEN (MAQUANHUYEN, MATINHTHANH,TENQUANHUYEN)
values 
('329', '35', N'Huyện Tam Đường'),
('330', '35', N'Huyện Phong Thổ'),
('331', '35', N'Huyện Sìn Hồ'),
('332', '35', N'Huyện Mường Tè'),
('333', '35', N'Huyện Than Uyên'),
('334', '35', N'Huyện Tân Uyên'),
('335', '35', N'Huyện Nậm Nhùn')

--

insert into QUANHUYEN (MAQUANHUYEN, MATINHTHANH,TENQUANHUYEN)
values 
('336', '36', N'Huyện Tràng Định'),
('337', '36', N'Huyện Bình Gia'),
('338', '36', N'Huyện Văn Lãng'),
('339', '36', N'Huyện Bắc Sơn'),
('340', '36', N'Huyện Văn Quan'),
('341', '36', N'Huyện Cao Lộc'),
('342', '36', N'Huyện Lộc Bình'),
('343', '36', N'Huyện Chi Lăng'),
('344', '36', N'Huyện Đình Lập'),
('345', '36', N'Huyện Hữu Lũng')

--

insert into QUANHUYEN (MAQUANHUYEN, MATINHTHANH,TENQUANHUYEN)
values 
('346', '37', N'Huyện Bảo Thắng'),
('347', '37', N'Huyện Bảo Yên'),
('348', '37', N'Huyện Bát Xát'),
('349', '37', N'Huyện Bắc Hà'),
('350', '37', N'Huyện Mường Khương'),
('351', '37', N'Huyện Sa Pa'),
('352', '37', N'Huyện Si Ma Cai'),
('353', '37', N'Huyện Văn Bàn')

--

insert into QUANHUYEN (MAQUANHUYEN, MATINHTHANH,TENQUANHUYEN)
values 
('354', '38', N'Huyện Đức Trọng'),
('355', '38', N'Huyện Di Linh'),
('356', '38', N'Huyện Đơn Dương'),
('357', '38', N'Huyện Lạc Dương'),
('358', '38', N'Huyện Đạ Huoai'),
('359', '38', N'Huyện Đạ Tẻh'),
('361', '38', N'Huyện Cát Tiên'),
('362', '38', N'Huyện Lâm Hà'),
('364', '38', N'Huyện Đam Rông')

--

insert into QUANHUYEN (MAQUANHUYEN, MATINHTHANH,TENQUANHUYEN)
values 
('365', '39', N'Huyện Vĩnh Hưng'),
('366', '39', N'Huyện Mộc Hóa'),
('367', '39', N'Huyện Tân Thạnh'),
('368', '39', N'Huyện Thạnh Hoá'),
('369', '39', N'Huyện Đức Huệ'),
('370', '39', N'Huyện Đức Hoà'),
('371', '39', N'Huyện Bến Lức'),
('372', '39', N'Huyện Thủ Thừa'),
('374', '39', N'Huyện Tân Trụ'),
('375', '39', N'Huyện Cần Đước'),
('376', '39', N'Huyện Cần Giuộc'),
('377', '39', N'Huyện Tân Hưng')

--

insert into QUANHUYEN (MAQUANHUYEN, MATINHTHANH,TENQUANHUYEN)
values 
('378', '40', N'Huyện Mỹ Lộc'),
('379', '40', N'Huyện Xuân Trường'),
('380', '40', N'Huyện Giao Thuỷ'),
('381', '40', N'Huyện Ý Yên'),
('382', '40', N'Huyện Vụ Bản'),
('383', '40', N'Huyện Nam Trực'),
('384', '40', N'Huyện Trực Ninh'),
('385', '40', N'Huyện Nghĩa Hưng'),
('386', '40', N'Huyện Hải Hậu')

--

insert into QUANHUYEN (MAQUANHUYEN, MATINHTHANH,TENQUANHUYEN)
values 
('387', '41', N'Huyện Quỳ Châu'),
('388', '41', N'Huyện Quỳ Hợp'),
('389', '41', N'Huyện Nghĩa Đàn'),
('390', '41', N'Huyện Quỳnh Lưu'),
('392', '41', N'Huyện Tương Dương'),
('393', '41', N'Huyện Con Cuông'),
('394', '41', N'Huyện Tân Kỳ'),
('395', '41', N'Huyện Yên Thành'),
('396', '41', N'Huyện Diễn Châu'),
('397', '41', N'Huyện Anh Sơn'),
('398', '41', N'Huyện Đô Lương'),
('399', '41', N'Huyện Thanh Chương'),
('400', '41', N'Huyện Nghi Lộc'),
('401', '41', N'Huyện Nam Đàn'),
('402', '41', N'Huyện Hưng Nguyên'),
('403', '41', N'Huyện Quế Phong')

--

insert into QUANHUYEN (MAQUANHUYEN, MATINHTHANH,TENQUANHUYEN)
values 
('404', '42', N'Huyện Nho Quan'),
('405', '42', N'Huyện Gia Viễn'),
('406', '42', N'Huyện Hoa Lư'),
('407', '42', N'Huyện Yên Mô'),
('408', '42', N'Huyện Kim Sơn'),
('409', '42', N'Huyện Yên Khánh')

--

insert into QUANHUYEN (MAQUANHUYEN, MATINHTHANH,TENQUANHUYEN)
values 
('410', '43', N'Huyện Ninh Sơn'),
('411', '43', N'Huyện Ninh Hải'),
('412', '43', N'Huyện Ninh Phước'),
('413', '43', N'Huyện Bác Ái'),
('414', '43', N'Huyện Thuận Bắc'),
('415', '43', N'Huyện Thuận Nam')

--

insert into QUANHUYEN (MAQUANHUYEN, MATINHTHANH,TENQUANHUYEN)
values 
('416', '44', N'Huyện Đoan Hùng'),
('417', '44', N'Huyện Thanh Ba'),
('418', '44', N'Huyện Hạ Hoà'),
('419', '44', N'Huyện Cẩm Khê'),
('420', '44', N'Huyện Yên Lập'),
('421', '44', N'Huyện Thanh Sơn'),
('422', '44', N'Huyện Phù Ninh'),
('423', '44', N'Huyện Lâm Thao'),
('425', '44', N'Huyện Thanh Thuỷ'),
('426', '44', N'Huyện Tân Sơn')

--

insert into QUANHUYEN (MAQUANHUYEN, MATINHTHANH,TENQUANHUYEN)
values 
('427', '45', N'Huyện Đồng Xuân'),
('428', '45', N'Huyện Tuy An'),
('429', '45', N'Huyện Sơn Hòa'),
('430', '45', N'Huyện Sông Hinh'),
('431', '45', N'Huyện Đông Hòa'),
('432', '45', N'Huyện Phú Hòa'),
('433', '45', N'Huyện Tây Hòa')

--

insert into QUANHUYEN (MAQUANHUYEN, MATINHTHANH,TENQUANHUYEN)
values 
('434', '46', N'Huyện Tuyên Hoá'),
('435', '46', N'Huyện Minh Hoá'),
('436', '46', N'Huyện Quảng Trạch'),
('437', '46', N'Huyện Bố Trạch'),
('438', '46', N'Huyện Quảng Ninh'),
('439', '46', N'Huyện Lệ Thuỷ')

--

insert into QUANHUYEN (MAQUANHUYEN, MATINHTHANH,TENQUANHUYEN)
values 
('440', '47', N'Huyện Duy Xuyên'),
('441', '47', N'Huyện Đại Lộc'),
('442', '47', N'Huyện Quế Sơn'),
('443', '47', N'Huyện Hiệp Đức'),
('444', '47', N'Huyện Thăng Bình'),
('445', '47', N'Huyện Núi Thành'),
('446', '47', N'Huyện Tiên Phước'),
('447', '47', N'Huyện Bắc Trà My'),
('448', '47', N'Huyện Đông Giang'),
('449', '47', N'Huyện Nam Giang'),
('450', '47', N'Huyện Phước Sơn'),
('451', '47', N'Huyện Nam Trà My'),
('452', '47', N'Huyện Tây Giang'),
('453', '47', N'Huyện Phú Ninh'),
('454', '47', N'Huyện Nông Sơn')

--

insert into QUANHUYEN (MAQUANHUYEN, MATINHTHANH,TENQUANHUYEN)
values 
('455', '48', N'Huyện Bình Sơn'),
('456', '48', N'Huyện Sơn Tịnh'),
('457', '48', N'Huyện Tư Nghĩa'),
('458', '48', N'Huyện Nghĩa Hành'),
('459', '48', N'Huyện Mộ Đức'),
('460', '48', N'Huyện Đức Phổ'),
('461', '48', N'Huyện Ba Tơ'),
('462', '48', N'Huyện Minh Long'),
('463', '48', N'Huyện Sơn Hà'),
('464', '48', N'Huyện Sơn Tây'),
('465', '48', N'Huyện Trà Bồng'),
('466', '48', N'Huyện Tây Trà'),
('467', '48', N'Huyện Lý Sơn')

--

insert into QUANHUYEN (MAQUANHUYEN, MATINHTHANH,TENQUANHUYEN)
values 
('468', '49', N'Huyện Bình Liêu'),
('469', '49', N'Huyện Đầm Hà'),
('470', '49', N'Huyện Hải Hà'),
('471', '49', N'Huyện Tiên Yên'),
('472', '49', N'Huyện Ba Chẽ'),
('473', '49', N'Huyện Hoành Bồ'),
('474', '49', N'Huyện Vân Đồn'),
('475', '49', N'Huyện Cô Tô')

--

insert into QUANHUYEN (MAQUANHUYEN, MATINHTHANH,TENQUANHUYEN)
values 
('476', '50', N'Huyện Vĩnh Linh'),
('477', '50', N'Huyện Gio Linh'),
('478', '50', N'Huyện Cam Lộ'),
('479', '50', N'Huyện Triệu Phong'),
('480', '50', N'Huyện Hải Lăng'),
('481', '50', N'Huyện Hướng Hoá'),
('482', '50', N'Huyện Đakrông'),
('483', '50', N'Huyện đảo Cồn Cỏ')

--

insert into QUANHUYEN (MAQUANHUYEN, MATINHTHANH,TENQUANHUYEN)
values 
('484', '51', N'Huyện Kế Sách'),
('485', '51', N'Huyện Mỹ Tú'),
('486', '51', N'Huyện Mỹ Xuyên'),
('487', '51', N'Huyện Thạnh Trị'),
('488', '51', N'Huyện Long Phú'),
('489', '51', N'Huyện Cù Lao Dung'),
('491', '51', N'Huyện Trần Đề')

--

insert into QUANHUYEN (MAQUANHUYEN, MATINHTHANH,TENQUANHUYEN)
values 
('492', '52', N'Huyện Quỳnh Nhai'),
('493', '52', N'Huyện Mường La'),
('494', '52', N'Huyện Thuận Châu'),
('495', '52', N'Huyện Bắc Yên'),
('496', '52', N'Huyện Phù Yên'),
('497', '52', N'Huyện Mai Sơn'),
('498', '52', N'Huyện Yên Châu'),
('499', '52', N'Huyện Sông Mã'),
('500', '52', N'Huyện Mộc Châu'),
('501', '52', N'Huyện Sốp Cộp'),
('502', '52', N'Huyện Vân Hồ')

--

insert into QUANHUYEN (MAQUANHUYEN, MATINHTHANH,TENQUANHUYEN)
values 
('503', '53', N'Huyện Tân Biên'),
('504', '53', N'Huyện Tân Châu'),
('505', '53', N'Huyện Dương Minh Châu'),
('507', '53', N'Huyện Hoà Thành'),
('508', '53', N'Huyện Bến Cầu'),
('509', '53', N'Huyện Gò Dầu'),
('510', '53', N'Huyện Trảng Bàng')

--

insert into QUANHUYEN (MAQUANHUYEN, MATINHTHANH,TENQUANHUYEN)
values 
('511', '54', N'Huyện Quỳnh Phụ'),
('512', '54', N'Huyện Hưng Hà'),
('513', '54', N'Huyện Đông Hưng'),
('514', '54', N'Huyện Vũ Thư'),
('515', '54', N'Huyện Kiến Xương'),
('516', '54', N'Huyện Tiền Hải'),
('517', '54', N'Huyện Thái Thụy')

--

insert into QUANHUYEN (MAQUANHUYEN, MATINHTHANH,TENQUANHUYEN)
values 
('518', '55', N'Huyện Định Hoá'),
('519', '55', N'Huyện Phú Lương'),
('520', '55', N'Huyện Võ Nhai'),
('521', '55', N'Huyện Đại Từ'),
('522', '55', N'Huyện Đồng Hỷ'),
('523', '55', N'Huyện Phú Bình')

--

insert into QUANHUYEN (MAQUANHUYEN, MATINHTHANH,TENQUANHUYEN)
values 
('524', '56', N'Huyện Sầm Sơn'),
('525', '56', N'Huyện Quan Hóa'),
('526', '56', N'Huyện Quan Sơn'),
('527', '56', N'Huyện Mường Lát'),
('528', '56', N'Huyện Bá Thước'),
('529', '56', N'Huyện Thường Xuân'),
('530', '56', N'Huyện Như Xuân'),
('531', '56', N'Huyện Như Thanh'),
('532', '56', N'Huyện Lang Chánh'),
('533', '56', N'Huyện Ngọc Lặc'),
('534', '56', N'Huyện Thạch Thành'),
('535', '56', N'Huyện Cẩm Thuỷ'),
('536', '56', N'Huyện Thọ Xuân'),
('537', '56', N'Huyện Vĩnh Lộc'),
('538', '56', N'Huyện Thiệu Hoá'),
('539', '56', N'Huyện Triệu Sơn'),
('540', '56', N'Huyện Nông Cống'),
('541', '56', N'Huyện Đông Sơn'),
('542', '56', N'Huyện Hà Trung'),
('543', '56', N'Huyện Hoằng Hoá'),
('544', '56', N'Huyện Nga Sơn'),
('545', '56', N'Huyện Hậu Lộc'),
('546', '56', N'Huyện Quảng Xương'),
('547', '56', N'Huyện Tĩnh Gia'),
('548', '56', N'Huyện Yên Định')

--

insert into QUANHUYEN (MAQUANHUYEN, MATINHTHANH,TENQUANHUYEN)
values 
('550', '57', N'Huyện Quảng Điền'),
('551', '57', N'Huyện Phú Vang'),
('552', '57', N'Huyện Phú Lộc'),
('553', '57', N'Huyện Nam Đông'),
('554', '57', N'Huyện A Lưới')

--

insert into QUANHUYEN (MAQUANHUYEN, MATINHTHANH,TENQUANHUYEN)
values 
('555', '58', N'Huyện Cái Bè'),
('556', '58', N'Huyện Cai Lậy'),
('558', '58', N'Huyện Chợ Gạo'),
('559', '58', N'Huyện Gò Công Tây'),
('560', '58', N'Huyện Gò Công Đông'),
('561', '58', N'Huyện Tân Phước'),
('562', '58', N'Huyện Tân Phú Đông')

--

insert into QUANHUYEN (MAQUANHUYEN, MATINHTHANH,TENQUANHUYEN)
values 
('563', '59', N'Huyện Càng Long'),
('564', '59', N'Huyện Cầu Kè'),
('565', '59', N'Huyện Tiểu Cần'),
('567', '59', N'Huyện Trà Cú'),
('568', '59', N'Huyện Cầu Ngang'),
('569', '59', N'Huyện Duyên Hải')

--

insert into QUANHUYEN (MAQUANHUYEN, MATINHTHANH,TENQUANHUYEN)
values 
('570', '60', N'Huyện Lâm Bình'),
('571', '60', N'Huyện Na Hang'),
('572', '60', N'Huyện Chiêm Hóa'),
('573', '60', N'Huyện Hàm Yên'),
('574', '60', N'Huyện Yên Sơn'),
('575', '60', N'Huyện Sơn Dương')

--

insert into QUANHUYEN (MAQUANHUYEN, MATINHTHANH,TENQUANHUYEN)
values 
('576', '61', N'Huyện Long Hồ'),
('577', '61', N'Huyện Mang Thít'),
('578', '61', N'Huyện Tam Bình'),
('579', '61', N'Huyện Trà Ôn'),
('580', '61', N'Huyện Vũng Liêm'),
('581', '61', N'Huyện Bình Tân')

--

insert into QUANHUYEN (MAQUANHUYEN, MATINHTHANH,TENQUANHUYEN)
values 
('582', '62', N'Huyện Tam Dương'),
('583', '62', N'Huyện Lập Thạch'),
('584', '62', N'Huyện Vĩnh Tường'),
('585', '62', N'Huyện Yên Lạc'),
('586', '62', N'Huyện Bình Xuyên'),
('587', '62', N'Huyện Sông Lô'),
('588', '62', N'Huyện Tam Đảo')

--

insert into QUANHUYEN (MAQUANHUYEN, MATINHTHANH,TENQUANHUYEN)
values 
('589', '63', N'Huyện Văn Yên'),
('590', '63', N'Huyện Yên Bình'),
('591', '63', N'Huyện Mù Cang Chải'),
('592', '63', N'Huyện Văn Chấn'),
('593', '63', N'Huyện Trấn Yên'),
('594', '63', N'Huyện Trạm Tấu'),
('595', '63', N'Huyện Lục Yên')

--===================================KHÁCH HÀNG============================================

set dateformat dmy;
insert into KHACHHANG (MAKH, MAQUANHUYEN, HOTENKH, LOAIKHACHHANG, NGAYSINHKH, GIOITINHKH, DIACHIKH, SODIENTHOAIKH)
values ('KH01','02',N'Hoàng Minh Tú',N'Sinh viên','12-12-2015',N'Nam',N'TPHCM','0943359354')

insert into KHACHHANG (MAKH, MAQUANHUYEN, HOTENKH, LOAIKHACHHANG, NGAYSINHKH, GIOITINHKH, DIACHIKH, SODIENTHOAIKH)
values ('KH02','01',N'Mai Hồng Ngọc',N'Học sinh','13-04-2003',N'Nữ',N'Đà Nẵng','0901286445')

insert into KHACHHANG (MAKH, MAQUANHUYEN, HOTENKH, LOAIKHACHHANG, NGAYSINHKH, GIOITINHKH, DIACHIKH, SODIENTHOAIKH)
values ('KH03','03',N'Trần Quốc Khánh',N'Nội trợ','27-08-1990',N'Nam',N'Tây Ninh','0866222445')

insert into KHACHHANG (MAKH, MAQUANHUYEN, HOTENKH, LOAIKHACHHANG, NGAYSINHKH, GIOITINHKH, DIACHIKH, SODIENTHOAIKH)
values ('KH04','08',N'Cao Tuấn Vũ',N'Đi làm','02-10-1986',N'Nam',N'Đồng Tháp','0969679695')

insert into KHACHHANG (MAKH, MAQUANHUYEN, HOTENKH, LOAIKHACHHANG, NGAYSINHKH, GIOITINHKH, DIACHIKH, SODIENTHOAIKH)
values ('KH05','15',N'Trịnh Văn Sơn',N'Lớn tuổi','09-06-1976',N'Nam',N'Vĩnh Long','0335470986')

insert into KHACHHANG (MAKH, MAQUANHUYEN, HOTENKH, LOAIKHACHHANG, NGAYSINHKH, GIOITINHKH, DIACHIKH, SODIENTHOAIKH)
values ('KH00','01',N'Null','','',N'Nam','','')
--==================================NHÀ CUNG CẤP========================================
insert into NHACUNGCAP (MANCC, MAQUANHUYEN, TENNHACUNGCAP, DIACHI, SDT)
values ('NCC01','15',N'CÔNG TY CỔ PHẦN HSX01LAND',N'2/21 Quách Văn Tuấn, P.12, Q.Tân Phú, TPHCM','62621452')

insert into NHACUNGCAP (MANCC, MAQUANHUYEN, TENNHACUNGCAP, DIACHI, SDT)
values ('NCC02','08',N'Công Ty Cổ Phần Difoco',N'289 Đinh Bộ Lĩnh, P.26, Q.Bình Tân, TPHCM','66857787')


--====================================HÓA ĐƠN BÁN=============================================

set dateformat dmy;
insert into HOADONBAN (MAHDB, MAKH, MANV, NGAYLAPBAN, VAT, TONGTIENBAN)
values ('HDB001','KH02','NV03','08-10-2020',10,16280000)

insert into HOADONBAN (MAHDB, MAKH, MANV, NGAYLAPBAN, VAT, TONGTIENBAN)
values ('HDB002','KH01','NV08','09-05-2021',0,565000)

insert into HOADONBAN (MAHDB, MAKH, MANV, NGAYLAPBAN, VAT, TONGTIENBAN)
values ('HDB003','KH04','NV05','13-04-2021',0,360000)

insert into HOADONBAN (MAHDB, MAKH, MANV, NGAYLAPBAN, VAT, TONGTIENBAN)
values ('HDB004','KH03','NV02','26-12-2020',10,2750000)

--=================================CHI TIẾT HÓA ĐƠN==========================================

insert into CHITIETHOADONBAN (MAHDB, MATHUOC, SOLUONGBAN, THANHTIENBAN)
values ('HDB001','TH01',3,690000)

insert into CHITIETHOADONBAN (MAHDB, MATHUOC, SOLUONGBAN, THANHTIENBAN)
values ('HDB001','TH02',3,270000)

insert into CHITIETHOADONBAN (MAHDB, MATHUOC, SOLUONGBAN, THANHTIENBAN)
values ('HDB001','TH03',4,520000)

insert into CHITIETHOADONBAN (MAHDB, MATHUOC, SOLUONGBAN, THANHTIENBAN)
values ('HDB002','TH04',2,300000)

insert into CHITIETHOADONBAN (MAHDB, MATHUOC, SOLUONGBAN, THANHTIENBAN)
values ('HDB002','TH05',1,265000)

insert into CHITIETHOADONBAN (MAHDB, MATHUOC, SOLUONGBAN, THANHTIENBAN)
values ('HDB003','TH06',2,360000)

insert into CHITIETHOADONBAN (MAHDB, MATHUOC, SOLUONGBAN, THANHTIENBAN)
values ('HDB004','TH07',1,250000)


--=============================================PHIẾU NHẬP THUỐC================================================

insert into PHIEUNHAPTHUOC(MAPNT, MANCC, NGAYNHAPTHUOC, GHICHUNT, TRANGTHAI, TONGTIEN)
values ('PNT001','HSX01CY','20-10-2020','',1,495000)

insert into PHIEUNHAPTHUOC(MAPNT, MANCC, NGAYNHAPTHUOC, GHICHUNT, TRANGTHAI, TONGTIEN)
values ('PNT002','HSX01CY','18-5-2021','',0,250000)

insert into PHIEUNHAPTHUOC(MAPNT, MANCC, NGAYNHAPTHUOC, GHICHUNT, TRANGTHAI, TONGTIEN)
values ('PNT003','DIFOCO','15-3-2021','',1,270000)

--=========================================CHI TIẾT PHIẾU NHẬP THUỐC===========================================

insert into CHITIETPHIEUNHAPTHUOC (MAPNT, MATHUOC, SOLUONGNHAPTHUOC, DVT, THANHTIENNT, DONGIABAN)
values ('PNT001','TH01',3,N'Tuýp',690000,230000)

insert into CHITIETPHIEUNHAPTHUOC (MAPNT, MATHUOC, SOLUONGNHAPTHUOC, DVT, THANHTIENNT, DONGIABAN)
values ('PNT001','TH02',3,N'Vỉ',795000,265000)

insert into CHITIETPHIEUNHAPTHUOC (MAPNT, MATHUOC, SOLUONGNHAPTHUOC, DVT, THANHTIENNT, DONGIABAN)
values ('PNT002','TH03',1,N'Lọ',160000,160000)

insert into CHITIETPHIEUNHAPTHUOC (MAPNT, MATHUOC, SOLUONGNHAPTHUOC, DVT, THANHTIENNT, DONGIABAN)
values ('PNT002','TH04',4,N'Hộp',360000,90000)

insert into CHITIETPHIEUNHAPTHUOC (MAPNT, MATHUOC, SOLUONGNHAPTHUOC, DVT, THANHTIENNT, DONGIABAN)
values ('PNT003','TH05',2,N'Hộp',300000,150000)

insert into CHITIETPHIEUNHAPTHUOC (MAPNT, MATHUOC, SOLUONGNHAPTHUOC, DVT, THANHTIENNT, DONGIABAN)
values ('PNT003','TH06',4,N'Hộp',480000,120000)


-------------------------------------	TRIGGER	----------------------------------------------
--trigger So luong ton kho
--NHAP THUOC
--Them Chi tiet phieu nhap hang thi so luong ton cua thuoc tang
CREATE TRIGGER trg_ThemDonHang ON CHITIETPHIEUNHAPTHUOC AFTER INSERT AS
BEGIN
	UPDATE THUOC
	SET SOLUONGTON = SOLUONGTON + (
		SELECT SOLUONGNHAPTHUOC
		FROM inserted
		WHERE MATHUOC = THUOC.MATHUOC
	)
	FROM THUOC
	JOIN inserted ON THUOC.MATHUOC = inserted.MATHUOC
END

--Xoa Chi tiet phieu dat hang thi so luong ton giam
CREATE TRIGGER trg_HuyDonDatHang ON CHITIETPHIEUNHAPTHUOC FOR DELETE AS
BEGIN
	UPDATE THUOC
	SET SOLUONGTON = SOLUONGTON - (
		SELECT SOLUONGNHAPTHUOC
		FROM deleted
		WHERE MATHUOC = THUOC.MATHUOC
	)
	FROM THUOC
	JOIN deleted ON THUOC.MATHUOC = deleted.MATHUOC
END

--Sua chi tiet phieu dat hang thi so luong ton update
CREATE TRIGGER trg_CapNhatCTDH ON CHITIETPHIEUNHAPTHUOC AFTER UPDATE AS
BEGIN
	UPDATE THUOC
	SET SOLUONGTON = SOLUONGTON -
		(SELECT SOLUONGNHAPTHUOC FROM deleted WHERE MATHUOC = THUOC.MATHUOC) +
		(SELECT SOLUONGNHAPTHUOC FROM inserted WHERE MATHUOC = THUOC.MATHUOC)
	FROM THUOC
	JOIN deleted ON THUOC.MATHUOC = deleted.MATHUOC
END


--BAN THUOC
--Them Chi tiet phieu nhap hang thi so luong ton cua thuoc tang
CREATE TRIGGER trg_ThemDonBanHang ON CHITIETHOADONBAN AFTER INSERT AS
BEGIN
	UPDATE THUOC
	SET SOLUONGTON = SOLUONGTON - (
		SELECT SOLUONGBAN
		FROM inserted
		WHERE MATHUOC = THUOC.MATHUOC
	)
	FROM THUOC
	JOIN inserted ON THUOC.MATHUOC = inserted.MATHUOC
END

--Xoa Chi tiet phieu dat hang thi so luong ton giam
CREATE TRIGGER trg_HuyDonBanHang ON CHITIETHOADONBAN FOR DELETE AS
BEGIN
	UPDATE THUOC
	SET SOLUONGTON = SOLUONGTON + (
		SELECT SOLUONGBAN
		FROM deleted
		WHERE MATHUOC = THUOC.MATHUOC
	)
	FROM THUOC
	JOIN deleted ON THUOC.MATHUOC = deleted.MATHUOC
END

--Sua chi tiet phieu dat hang thi so luong ton update
CREATE TRIGGER trg_CapNhatCTBH ON CHITIETHOADONBAN AFTER UPDATE AS
BEGIN
	UPDATE THUOC
	SET SOLUONGTON = SOLUONGTON +
		(SELECT SOLUONGBAN FROM deleted WHERE MATHUOC = THUOC.MATHUOC) -
		(SELECT SOLUONGBAN FROM inserted WHERE MATHUOC = THUOC.MATHUOC)
	FROM THUOC
	JOIN deleted ON THUOC.MATHUOC = deleted.MATHUOC
END

--Trigger Xoa Don Ban Hang
CREATE TRIGGER trg_XoaDonBanHang ON HOADONBAN
instead of delete
AS
begin
    DELETE FROM CHITIETHOADONBAN
    WHERE exists (SELECT MAHDB FROM deleted where deleted.MAHDB = CHITIETHOADONBAN.MAHDB)
	DELETE FROM HOADONBAN
    WHERE exists (SELECT MAHDB FROM deleted where deleted.MAHDB = HOADONBAN.MAHDB)
end
GO

--Trigger Xoa Don Dat Hang
CREATE TRIGGER trg_XoaDonDatHang ON PHIEUNHAPTHUOC
instead of delete
AS
begin
    DELETE FROM CHITIETPHIEUNHAPTHUOC
    WHERE exists (SELECT MAPNT FROM deleted where deleted.MAPNT = CHITIETPHIEUNHAPTHUOC.MAPNT)
	DELETE FROM PHIEUNHAPTHUOC
    WHERE exists (SELECT MAPNT FROM deleted where deleted.MAPNT = PHIEUNHAPTHUOC.MAPNT)
end
GO


--Trigger Xoa Thuoc
CREATE TRIGGER trg_XoaThuoc ON THUOC
instead of delete
AS
begin
    DELETE FROM CHITIETHOADONBAN
    WHERE exists (SELECT MATHUOC FROM deleted where deleted.MATHUOC = CHITIETHOADONBAN.MATHUOC)
	DELETE FROM CHITIETPHIEUNHAPTHUOC
    WHERE exists (SELECT MATHUOC FROM deleted where deleted.MATHUOC = CHITIETPHIEUNHAPTHUOC.MATHUOC)
	DELETE FROM THUOC
	WHERE EXISTS (SELECT MATHUOC FROM deleted WHERE deleted.MATHUOC = THUOC.MATHUOC)
end
GO

--Trigger Xoa KhachHang
CREATE TRIGGER trg_XoaKH ON KHACHHANG
instead of delete
AS
begin
    DELETE FROM HOADONBAN
    WHERE exists (SELECT MAKH FROM deleted where deleted.MAKH = HOADONBAN.MAKH)
	DELETE FROM KHACHHANG
	WHERE EXISTS (SELECT MAKH FROM deleted WHERE deleted.MAKH = KHACHHANG.MAKH)
end
GO

--Trigger XoaNV
CREATE TRIGGER trg_XoaNV ON NHANVIEN
instead of delete
AS
begin
    DELETE FROM CHAMCONG
    WHERE exists (SELECT MANV FROM deleted where deleted.MANV = CHAMCONG.MANV)
	DELETE FROM BANGLUONG
	WHERE EXISTS (SELECT MANV FROM deleted WHERE deleted.MANV = BANGLUONG.MANV)
	DELETE FROM NHANVIEN
	WHERE EXISTS (SELECT MANV FROM deleted WHERE deleted.MANV = NHANVIEN.MANV)
end
GO

--Trigger XoaKeThuoc
CREATE TRIGGER trg_XoaKe ON KeThuoc
instead of delete
AS
begin
    DELETE FROM LOAITHUOC
    WHERE exists (SELECT MAKE FROM deleted where deleted.MAKE = LOAITHUOC.MAKE)
	DELETE FROM KETHUOC
	WHERE EXISTS (SELECT MAKE FROM deleted WHERE deleted.MAKE = KETHUOC.MAKE)
end
GO

--Trigger XoaLoaiThuoc
CREATE TRIGGER trg_XoaLoaiThuoc ON LOAITHUOC
instead of delete
AS
begin
    DELETE FROM THUOC
    WHERE exists (SELECT MALOAITHUOC FROM deleted where deleted.MALOAITHUOC = THUOC.MALOAITHUOC)
	DELETE FROM LOAITHUOC
	WHERE EXISTS (SELECT MALOAITHUOC FROM deleted WHERE deleted.MALOAITHUOC = LOAITHUOC.MALOAITHUOC)
end
GO

-- trigger kiểm tra số lượng sản phẩm tồn > số lượng bán không 

CREATE TRIGGER KTRASLUONGTON ON CHITIETHOADONBAN FOR INSERT
AS
BEGIN
	DECLARE @SOLUONGTON INT;
	DECLARE @SOLUONGBAN INT;
	SELECT @SOLUONGBAN= inserted.SOLUONGBAN FROM inserted;
	SELECT @SOLUONGTON= THUOC.SOLUONGTON FROM inserted,THUOC WHERE inserted.MATHUOC= THUOC.MATHUOC;
	IF (@SOLUONGBAN > @SOLUONGTON)
		BEGIN
			RAISERROR (N'SỐ LƯỢNG SẢN PHẨM KHÔNG ĐỦ ĐỂ ĐÁP ỨNG',16,1)
			ROLLBACK TRANSACTION;
		END
END


----- KIỂM TRA SỐ LƯỢNG TỒN CÓ BẰNG KHÔNG

--CREATE TRIGGER KT_SLTonBANG0 on THUOC 
--INSTEAD OF INSERT
--AS
--DECLARE @mathuoc NCHAR(30);
--DECLARE @maloaithuoc NCHAR(30);
--DECLARE @mahsx NCHAR(30);
--DECLARE @tenthuoc INT;
--DECLARE @slTon INT;

--SELECT @mathuoc=MATHUOC FROM inserted;
--SELECT @slTon=SOLUONGTON FROM inserted;
--BEGIN 
--	SELECT @slTon=Count(*) FROM THUOC T 
--	INNER JOIN CHITIETHOADONBAN HD on HD.MATHUOC=T.MATHUOC
--	WHERE T.SOLUONGTON -(T.SOLUONGTON*@slTon) <0
--IF(@slTon=0)
--	BEGIN
--		RAISERROR (N'SỐ LƯỢNG SẢN PHẨM KHÔNG ĐỦ ĐỂ ĐÁP ỨNG CẦN NHẬP THÊM',16,1)
--		ROLLBACK TRANSACTION;
--	END;
--END;

---- TỔNG DOANH THU TIỆM THUỐC THEO THÁNG
--CREATE PROC THONGKE_DOANHTHU
--	@ThangDauVao DATETIME,
--	@ThangCuoi DATETIME,
--	@@TongDoanhThu FLOAT OUTPUT
--	AS
--	BEGIN
--	IF (@ThangDauVao<=@ThangCuoi)
--	BEGIN
--		SELECT SUM (HOADONBAN.TONGTIENBAN) AS N'TỔNG DOANH THU HỆ THỐNG'
--		FROM HOADONBAN 
--		WHERE NGAYLAPBAN>=@ThangDauVao AND NGAYLAPBAN<=@ThangCuoi
--		SELECT @@TongDoanhThu=(SELECT SUM (HOADONBAN.TONGTIENBAN)
--		FROM HOADONBAN 
--		WHERE NGAYLAPBAN>=@ThangDauVao AND NGAYLAPBAN<=@ThangCuoi);
--	END; 
--	ELSE
--		PRINT N'THỜI GIAN BẮT ĐẦU SAU LỚN HƠN THỜI GIAN KẾT THÚC THẾ !!';
--	END;

--DECLARE @@TongDoanhThuShop FLOAT
--EXEC THONGKE_DOANHTHU '04/11/2019','04/20/2021',@@TongDoanhThuShop
--OUTPUT 
--	IF(@@TongDoanhThuShop>100000)
--		PRINT N'TỔNG DOANH THU TIỆM LÀ: '+Cast (@@TongDoanhThuShop AS NVARCHAR(100))
--	ELSE
--		PRINT N'TỔNG DOANH THU ÍT THẾ TA!' 
