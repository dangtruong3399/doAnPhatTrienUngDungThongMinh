USE [master]
GO
/****** Object:  Database [QlNhanSu2]    Script Date: 8/12/2020 20:08:39 ******/
CREATE DATABASE [QlNhanSu2]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'QlNhanSu2', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL11.SQLEXPRESS\MSSQL\DATA\QlNhanSu2.mdf' , SIZE = 3136KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'QlNhanSu2_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL11.SQLEXPRESS\MSSQL\DATA\QlNhanSu2_log.ldf' , SIZE = 832KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [QlNhanSu2] SET COMPATIBILITY_LEVEL = 110
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [QlNhanSu2].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [QlNhanSu2] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [QlNhanSu2] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [QlNhanSu2] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [QlNhanSu2] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [QlNhanSu2] SET ARITHABORT OFF 
GO
ALTER DATABASE [QlNhanSu2] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [QlNhanSu2] SET AUTO_CREATE_STATISTICS ON 
GO
ALTER DATABASE [QlNhanSu2] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [QlNhanSu2] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [QlNhanSu2] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [QlNhanSu2] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [QlNhanSu2] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [QlNhanSu2] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [QlNhanSu2] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [QlNhanSu2] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [QlNhanSu2] SET  ENABLE_BROKER 
GO
ALTER DATABASE [QlNhanSu2] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [QlNhanSu2] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [QlNhanSu2] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [QlNhanSu2] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [QlNhanSu2] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [QlNhanSu2] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [QlNhanSu2] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [QlNhanSu2] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [QlNhanSu2] SET  MULTI_USER 
GO
ALTER DATABASE [QlNhanSu2] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [QlNhanSu2] SET DB_CHAINING OFF 
GO
ALTER DATABASE [QlNhanSu2] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [QlNhanSu2] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
USE [QlNhanSu2]
GO
/****** Object:  UserDefinedFunction [dbo].[AUTO_ctcv]    Script Date: 8/12/2020 20:08:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create  FUNCTION [dbo].[AUTO_ctcv]()
RETURNS VARCHAR(5)
AS
BEGIN
	DECLARE @ID VARCHAR(5)
	IF (SELECT COUNT(Mactcv) FROM ctChucVu) = 0
		SET @ID = '0'
	ELSE
		SELECT @ID = MAX(RIGHT(Mactcv, 3)) FROM ctChucVu
		SELECT @ID = CASE
			WHEN @ID >= 0 and @ID < 9 THEN 'Ct00' + CONVERT(CHAR, CONVERT(INT, @ID) + 1)
			WHEN @ID >= 9 THEN 'Ct0' + CONVERT(CHAR, CONVERT(INT, @ID) + 1)
		END
	RETURN @ID
END

GO
/****** Object:  UserDefinedFunction [dbo].[AUTO_HD]    Script Date: 8/12/2020 20:08:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create FUNCTION [dbo].[AUTO_HD]()
RETURNS VARCHAR(5)
AS
BEGIN
	DECLARE @ID VARCHAR(5)
	IF (SELECT COUNT(MaHD) FROM HopDong) = 0
		SET @ID = '0'
	ELSE
		SELECT @ID = MAX(RIGHT(MaHD, 3)) FROM HopDong
		SELECT @ID = CASE
			WHEN @ID >= 0 and @ID < 9 THEN 'HD00' + CONVERT(CHAR, CONVERT(INT, @ID) + 1)
			WHEN @ID >= 9 THEN 'HD0' + CONVERT(CHAR, CONVERT(INT, @ID) + 1)
		END
	RETURN @ID
END

GO
/****** Object:  UserDefinedFunction [dbo].[AUTO_mabaohiem]    Script Date: 8/12/2020 20:08:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create  FUNCTION [dbo].[AUTO_mabaohiem]()
RETURNS VARCHAR(5)
AS
BEGIN
	DECLARE @ID VARCHAR(5)
	IF (SELECT COUNT(MaBaoHiem) FROM  BaoHiem) = 0
		SET @ID = '0'
	ELSE
		SELECT @ID = MAX(RIGHT(MaBaoHiem, 3)) FROM BaoHiem
		SELECT @ID = CASE
			WHEN @ID >= 0 and @ID < 9 THEN 'BH00' + CONVERT(CHAR, CONVERT(INT, @ID) + 1)
			WHEN @ID >= 9 THEN 'BH0' + CONVERT(CHAR, CONVERT(INT, @ID) + 1)
		END
	RETURN @ID
END
GO
/****** Object:  Table [dbo].[BaoHiem]    Script Date: 8/12/2020 20:08:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[BaoHiem](
	[MaBaoHiem] [varchar](5) NOT NULL,
	[MaNhanVien] [varchar](5) NOT NULL,
	[LoaiBaoHiem] [nvarchar](50) NOT NULL,
	[SoThe] [varchar](20) NULL,
	[NgayCap] [date] NULL,
	[NgayHetHan] [date] NULL,
	[NoiCap] [nvarchar](100) NULL,
 CONSTRAINT [PK_BaoHiem] PRIMARY KEY CLUSTERED 
(
	[MaBaoHiem] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[ChamCong]    Script Date: 8/12/2020 20:08:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[ChamCong](
	[MaChamCong] [int] IDENTITY(1,1) NOT NULL,
	[Ngay] [date] NOT NULL,
	[MaNhanVien] [varchar](5) NOT NULL,
	[TinhTrang] [nvarchar](20) NULL,
 CONSTRAINT [PK_ChamCong] PRIMARY KEY CLUSTERED 
(
	[MaChamCong] ASC,
	[Ngay] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[ChucVu]    Script Date: 8/12/2020 20:08:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[ChucVu](
	[MaCV] [varchar](5) NOT NULL,
	[TenCv] [nvarchar](20) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[MaCV] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[ctChucVu]    Script Date: 8/12/2020 20:08:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[ctChucVu](
	[Mactcv] [varchar](5) NOT NULL,
	[MaNhanVien] [varchar](5) NOT NULL,
	[MaCV] [varchar](5) NOT NULL,
	[NgayBatDau] [date] NULL,
	[NgayKetThuc] [date] NULL,
 CONSTRAINT [PK_ctChucVu] PRIMARY KEY CLUSTERED 
(
	[Mactcv] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[HopDong]    Script Date: 8/12/2020 20:08:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[HopDong](
	[MaHD] [varchar](5) NOT NULL,
	[NgayVaoLam] [date] NULL,
	[HeSoLuong] [int] NULL,
	[MaCV] [varchar](5) NULL,
	[MaPB] [varchar](5) NULL,
 CONSTRAINT [PK_HopDong] PRIMARY KEY CLUSTERED 
(
	[MaHD] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Luong]    Script Date: 8/12/2020 20:08:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Luong](
	[HeSoLuong] [int] NOT NULL,
	[LuongCB] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[HeSoLuong] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[NGUOIDUNG]    Script Date: 8/12/2020 20:08:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[NGUOIDUNG](
	[USERNAME] [varchar](100) NOT NULL,
	[PASS] [varchar](100) NULL,
	[TENNGUOIDUNG] [nvarchar](50) NULL,
	[EMAIL] [varchar](50) NULL,
	[HOATDONG] [bit] NULL,
 CONSTRAINT [PK_NGUOIDUNG] PRIMARY KEY CLUSTERED 
(
	[USERNAME] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[NhanVien]    Script Date: 8/12/2020 20:08:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[NhanVien](
	[MaNhanVien] [varchar](5) NOT NULL,
	[MaPB] [varchar](5) NOT NULL,
	[MaHD] [varchar](5) NOT NULL,
	[HeSoLuong] [int] NOT NULL,
	[TenNV] [nvarchar](100) NOT NULL,
	[GioiTinh] [nvarchar](5) NOT NULL,
	[NgaySinh] [date] NOT NULL,
	[SoCM] [varchar](20) NOT NULL,
	[DienThoai] [varchar](20) NOT NULL,
	[TrinhDoHV] [nvarchar](30) NOT NULL,
	[DiaChi] [nvarchar](max) NOT NULL,
	[Email] [varchar](20) NULL,
	[Hinh] [nvarchar](100) NOT NULL,
	[TTHonNhan] [nvarchar](10) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[MaNhanVien] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[NHOMQUYEN]    Script Date: 8/12/2020 20:08:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[NHOMQUYEN](
	[MANHOM] [varchar](100) NOT NULL,
	[TENNHOM] [nvarchar](500) NULL,
	[GHICHU] [nvarchar](500) NULL,
 CONSTRAINT [PK_NHOMQUYEN] PRIMARY KEY CLUSTERED 
(
	[MANHOM] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[PHANNGUOIDUNG_VAONHOMQUYEN]    Script Date: 8/12/2020 20:08:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[PHANNGUOIDUNG_VAONHOMQUYEN](
	[USERNAME] [varchar](100) NOT NULL,
	[MANHOM] [varchar](100) NOT NULL,
	[GHICHU] [nvarchar](500) NULL,
 CONSTRAINT [PK_PHANNGUOIDUNG_VAONHOMQUYEN] PRIMARY KEY CLUSTERED 
(
	[USERNAME] ASC,
	[MANHOM] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[PHANQUYEN]    Script Date: 8/12/2020 20:08:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[PHANQUYEN](
	[MANHOM] [varchar](100) NOT NULL,
	[MAQUYEN] [varchar](100) NOT NULL,
	[COQUYEN] [bit] NULL,
 CONSTRAINT [PK_PHANQUYEN] PRIMARY KEY CLUSTERED 
(
	[MANHOM] ASC,
	[MAQUYEN] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[PhongBan]    Script Date: 8/12/2020 20:08:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[PhongBan](
	[MaPB] [varchar](5) NOT NULL,
	[TenPB] [nvarchar](20) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[MaPB] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[QUYEN]    Script Date: 8/12/2020 20:08:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[QUYEN](
	[MAQUYEN] [varchar](100) NOT NULL,
	[TENQUYEN] [nvarchar](500) NULL,
	[GHICHU] [nvarchar](max) NULL,
 CONSTRAINT [PK_QUYEN] PRIMARY KEY CLUSTERED 
(
	[MAQUYEN] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[ThuongPhat]    Script Date: 8/12/2020 20:08:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[ThuongPhat](
	[MaThuongPhat] [int] IDENTITY(1,1) NOT NULL,
	[MaNhanVien] [varchar](5) NOT NULL,
	[Loai] [nvarchar](50) NULL,
	[Tien] [int] NULL,
	[LyDo] [nvarchar](max) NULL,
	[Ngay] [date] NULL,
 CONSTRAINT [PK_ThuongPhat] PRIMARY KEY CLUSTERED 
(
	[MaThuongPhat] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[TinhLuong]    Script Date: 8/12/2020 20:08:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[TinhLuong](
	[MaNhanVien] [varchar](5) NOT NULL,
	[HeSoLuong] [int] NOT NULL,
	[SoNgayCong] [int] NULL,
	[TroCap] [money] NULL,
	[Thuong] [money] NULL,
	[Phat] [money] NULL,
	[ThucLinh] [money] NULL,
 CONSTRAINT [PK_TinhLuong] PRIMARY KEY CLUSTERED 
(
	[MaNhanVien] ASC,
	[HeSoLuong] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
INSERT [dbo].[BaoHiem] ([MaBaoHiem], [MaNhanVien], [LoaiBaoHiem], [SoThe], [NgayCap], [NgayHetHan], [NoiCap]) VALUES (N'BH001', N'NV001', N'Bảo Hiểm Thân Thể', N'12332112', CAST(0x29400B00 AS Date), CAST(0x97410B00 AS Date), N'Hà Nội')
INSERT [dbo].[BaoHiem] ([MaBaoHiem], [MaNhanVien], [LoaiBaoHiem], [SoThe], [NgayCap], [NgayHetHan], [NoiCap]) VALUES (N'BH002', N'NV002', N'Bảo Hiểm Y Tế', N'32132133', CAST(0x02400B00 AS Date), CAST(0x70410B00 AS Date), N'TPHCM')
INSERT [dbo].[BaoHiem] ([MaBaoHiem], [MaNhanVien], [LoaiBaoHiem], [SoThe], [NgayCap], [NgayHetHan], [NoiCap]) VALUES (N'BH003', N'NV003', N'Bảo Hiểm Thân Thể', N'65465434', CAST(0xB13E0B00 AS Date), CAST(0x8C410B00 AS Date), N'Lâm Đồng')
INSERT [dbo].[BaoHiem] ([MaBaoHiem], [MaNhanVien], [LoaiBaoHiem], [SoThe], [NgayCap], [NgayHetHan], [NoiCap]) VALUES (N'BH004', N'NV004', N'Bảo Hiểm Y Tế', N'72727228', CAST(0x3D400B00 AS Date), CAST(0xAB410B00 AS Date), N'TPHCM')
INSERT [dbo].[BaoHiem] ([MaBaoHiem], [MaNhanVien], [LoaiBaoHiem], [SoThe], [NgayCap], [NgayHetHan], [NoiCap]) VALUES (N'BH005', N'NV005', N'Bảo Hiểm Thân Thể', N'98901029', CAST(0x743D0B00 AS Date), CAST(0x18430B00 AS Date), N'TPHCM')
SET IDENTITY_INSERT [dbo].[ChamCong] ON 

INSERT [dbo].[ChamCong] ([MaChamCong], [Ngay], [MaNhanVien], [TinhTrang]) VALUES (1, CAST(0x62410B00 AS Date), N'NV001', N'Đi làm')
INSERT [dbo].[ChamCong] ([MaChamCong], [Ngay], [MaNhanVien], [TinhTrang]) VALUES (2, CAST(0x62410B00 AS Date), N'NV002', N'Đi làm')
INSERT [dbo].[ChamCong] ([MaChamCong], [Ngay], [MaNhanVien], [TinhTrang]) VALUES (3, CAST(0x62410B00 AS Date), N'NV007', N'Đi làm')
INSERT [dbo].[ChamCong] ([MaChamCong], [Ngay], [MaNhanVien], [TinhTrang]) VALUES (4, CAST(0x62410B00 AS Date), N'NV008', N'Đi làm')
INSERT [dbo].[ChamCong] ([MaChamCong], [Ngay], [MaNhanVien], [TinhTrang]) VALUES (5, CAST(0x62410B00 AS Date), N'NV001', N'Đi làm')
INSERT [dbo].[ChamCong] ([MaChamCong], [Ngay], [MaNhanVien], [TinhTrang]) VALUES (6, CAST(0x62410B00 AS Date), N'NV001', N'Đi làm')
INSERT [dbo].[ChamCong] ([MaChamCong], [Ngay], [MaNhanVien], [TinhTrang]) VALUES (7, CAST(0x61410B00 AS Date), N'NV001', N'Đi làm')
INSERT [dbo].[ChamCong] ([MaChamCong], [Ngay], [MaNhanVien], [TinhTrang]) VALUES (8, CAST(0x62410B00 AS Date), N'NV001', N'Đi làm')
INSERT [dbo].[ChamCong] ([MaChamCong], [Ngay], [MaNhanVien], [TinhTrang]) VALUES (9, CAST(0x62410B00 AS Date), N'NV002', N'Đi làm')
INSERT [dbo].[ChamCong] ([MaChamCong], [Ngay], [MaNhanVien], [TinhTrang]) VALUES (10, CAST(0x61410B00 AS Date), N'NV003', N'Đi làm')
INSERT [dbo].[ChamCong] ([MaChamCong], [Ngay], [MaNhanVien], [TinhTrang]) VALUES (11, CAST(0x60410B00 AS Date), N'NV003', N'Đi làm')
INSERT [dbo].[ChamCong] ([MaChamCong], [Ngay], [MaNhanVien], [TinhTrang]) VALUES (12, CAST(0x62410B00 AS Date), N'NV005', N'Đi làm')
INSERT [dbo].[ChamCong] ([MaChamCong], [Ngay], [MaNhanVien], [TinhTrang]) VALUES (13, CAST(0x61410B00 AS Date), N'NV005', N'Đi làm')
INSERT [dbo].[ChamCong] ([MaChamCong], [Ngay], [MaNhanVien], [TinhTrang]) VALUES (14, CAST(0x60410B00 AS Date), N'NV005', N'Đi làm')
INSERT [dbo].[ChamCong] ([MaChamCong], [Ngay], [MaNhanVien], [TinhTrang]) VALUES (15, CAST(0x60410B00 AS Date), N'NV006', N'Đi làm')
INSERT [dbo].[ChamCong] ([MaChamCong], [Ngay], [MaNhanVien], [TinhTrang]) VALUES (16, CAST(0x61410B00 AS Date), N'NV006', N'Đi làm')
INSERT [dbo].[ChamCong] ([MaChamCong], [Ngay], [MaNhanVien], [TinhTrang]) VALUES (17, CAST(0x61410B00 AS Date), N'NV007', N'Đi làm')
INSERT [dbo].[ChamCong] ([MaChamCong], [Ngay], [MaNhanVien], [TinhTrang]) VALUES (18, CAST(0x62410B00 AS Date), N'NV007', N'Đi làm')
INSERT [dbo].[ChamCong] ([MaChamCong], [Ngay], [MaNhanVien], [TinhTrang]) VALUES (19, CAST(0x62410B00 AS Date), N'NV008', N'Đi làm')
INSERT [dbo].[ChamCong] ([MaChamCong], [Ngay], [MaNhanVien], [TinhTrang]) VALUES (20, CAST(0x63410B00 AS Date), N'NV008', N'Đi làm')
INSERT [dbo].[ChamCong] ([MaChamCong], [Ngay], [MaNhanVien], [TinhTrang]) VALUES (21, CAST(0x63410B00 AS Date), N'NV009', N'Đi làm')
INSERT [dbo].[ChamCong] ([MaChamCong], [Ngay], [MaNhanVien], [TinhTrang]) VALUES (22, CAST(0x62410B00 AS Date), N'NV009', N'Đi làm')
INSERT [dbo].[ChamCong] ([MaChamCong], [Ngay], [MaNhanVien], [TinhTrang]) VALUES (23, CAST(0x61410B00 AS Date), N'NV010', N'Đi làm')
INSERT [dbo].[ChamCong] ([MaChamCong], [Ngay], [MaNhanVien], [TinhTrang]) VALUES (24, CAST(0x61410B00 AS Date), N'NV011', N'Đi làm')
INSERT [dbo].[ChamCong] ([MaChamCong], [Ngay], [MaNhanVien], [TinhTrang]) VALUES (25, CAST(0x62410B00 AS Date), N'NV011', N'Đi làm')
INSERT [dbo].[ChamCong] ([MaChamCong], [Ngay], [MaNhanVien], [TinhTrang]) VALUES (26, CAST(0x60410B00 AS Date), N'NV011', N'Đi làm')
INSERT [dbo].[ChamCong] ([MaChamCong], [Ngay], [MaNhanVien], [TinhTrang]) VALUES (27, CAST(0x5F410B00 AS Date), N'NV011', N'Đi làm')
SET IDENTITY_INSERT [dbo].[ChamCong] OFF
INSERT [dbo].[ChucVu] ([MaCV], [TenCv]) VALUES (N'CV001', N'Giám Đốc')
INSERT [dbo].[ChucVu] ([MaCV], [TenCv]) VALUES (N'CV002', N'Phó Giám Đốc')
INSERT [dbo].[ChucVu] ([MaCV], [TenCv]) VALUES (N'CV003', N'Trưởng Phòng')
INSERT [dbo].[ChucVu] ([MaCV], [TenCv]) VALUES (N'CV004', N'Phó Phòng')
INSERT [dbo].[ChucVu] ([MaCV], [TenCv]) VALUES (N'CV005', N'Nhân Viên')
INSERT [dbo].[ctChucVu] ([Mactcv], [MaNhanVien], [MaCV], [NgayBatDau], [NgayKetThuc]) VALUES (N'Ct001', N'NV001', N'CV001', CAST(0x5F410B00 AS Date), NULL)
INSERT [dbo].[ctChucVu] ([Mactcv], [MaNhanVien], [MaCV], [NgayBatDau], [NgayKetThuc]) VALUES (N'CT002', N'NV002', N'CV002', CAST(0x12390B00 AS Date), NULL)
INSERT [dbo].[ctChucVu] ([Mactcv], [MaNhanVien], [MaCV], [NgayBatDau], [NgayKetThuc]) VALUES (N'CT003', N'NV003', N'CV003', CAST(0x12390B00 AS Date), NULL)
INSERT [dbo].[ctChucVu] ([Mactcv], [MaNhanVien], [MaCV], [NgayBatDau], [NgayKetThuc]) VALUES (N'CT004', N'NV004', N'CV003', CAST(0x12390B00 AS Date), NULL)
INSERT [dbo].[ctChucVu] ([Mactcv], [MaNhanVien], [MaCV], [NgayBatDau], [NgayKetThuc]) VALUES (N'CT005', N'NV005', N'CV003', CAST(0x12390B00 AS Date), NULL)
INSERT [dbo].[ctChucVu] ([Mactcv], [MaNhanVien], [MaCV], [NgayBatDau], [NgayKetThuc]) VALUES (N'CT006', N'NV006', N'CV004', CAST(0x12390B00 AS Date), NULL)
INSERT [dbo].[ctChucVu] ([Mactcv], [MaNhanVien], [MaCV], [NgayBatDau], [NgayKetThuc]) VALUES (N'CT007', N'NV007', N'CV004', CAST(0x12390B00 AS Date), NULL)
INSERT [dbo].[ctChucVu] ([Mactcv], [MaNhanVien], [MaCV], [NgayBatDau], [NgayKetThuc]) VALUES (N'CT008', N'NV008', N'CV005', CAST(0x12390B00 AS Date), NULL)
INSERT [dbo].[ctChucVu] ([Mactcv], [MaNhanVien], [MaCV], [NgayBatDau], [NgayKetThuc]) VALUES (N'CT009', N'NV009', N'CV005', CAST(0x12390B00 AS Date), NULL)
INSERT [dbo].[ctChucVu] ([Mactcv], [MaNhanVien], [MaCV], [NgayBatDau], [NgayKetThuc]) VALUES (N'CT010', N'NV010', N'CV005', CAST(0x12390B00 AS Date), NULL)
INSERT [dbo].[ctChucVu] ([Mactcv], [MaNhanVien], [MaCV], [NgayBatDau], [NgayKetThuc]) VALUES (N'CT011', N'NV011', N'CV005', CAST(0x12390B00 AS Date), NULL)
INSERT [dbo].[ctChucVu] ([Mactcv], [MaNhanVien], [MaCV], [NgayBatDau], [NgayKetThuc]) VALUES (N'CT012', N'NV012', N'CV005', CAST(0x12390B00 AS Date), NULL)
INSERT [dbo].[ctChucVu] ([Mactcv], [MaNhanVien], [MaCV], [NgayBatDau], [NgayKetThuc]) VALUES (N'CT013', N'NV013', N'CV005', CAST(0x12390B00 AS Date), NULL)
INSERT [dbo].[ctChucVu] ([Mactcv], [MaNhanVien], [MaCV], [NgayBatDau], [NgayKetThuc]) VALUES (N'CT014', N'NV014', N'CV005', CAST(0x12390B00 AS Date), NULL)
INSERT [dbo].[ctChucVu] ([Mactcv], [MaNhanVien], [MaCV], [NgayBatDau], [NgayKetThuc]) VALUES (N'CT015', N'NV015', N'CV005', CAST(0x12390B00 AS Date), NULL)
INSERT [dbo].[ctChucVu] ([Mactcv], [MaNhanVien], [MaCV], [NgayBatDau], [NgayKetThuc]) VALUES (N'CT016', N'NV016', N'CV005', CAST(0x12390B00 AS Date), NULL)
INSERT [dbo].[ctChucVu] ([Mactcv], [MaNhanVien], [MaCV], [NgayBatDau], [NgayKetThuc]) VALUES (N'Ct017', N'NV017', N'CV002', CAST(0x12390B00 AS Date), NULL)
INSERT [dbo].[ctChucVu] ([Mactcv], [MaNhanVien], [MaCV], [NgayBatDau], [NgayKetThuc]) VALUES (N'Ct018', N'NV018', N'CV001', CAST(0x5F410B00 AS Date), NULL)
INSERT [dbo].[HopDong] ([MaHD], [NgayVaoLam], [HeSoLuong], [MaCV], [MaPB]) VALUES (N'HD001', CAST(0x5F410B00 AS Date), 10, N'CV001', N'PB001')
INSERT [dbo].[HopDong] ([MaHD], [NgayVaoLam], [HeSoLuong], [MaCV], [MaPB]) VALUES (N'HD002', CAST(0x5F410B00 AS Date), 9, N'CV002', N'PB002')
INSERT [dbo].[HopDong] ([MaHD], [NgayVaoLam], [HeSoLuong], [MaCV], [MaPB]) VALUES (N'HD003', CAST(0x19380B00 AS Date), 8, N'CV003', N'PB003')
INSERT [dbo].[HopDong] ([MaHD], [NgayVaoLam], [HeSoLuong], [MaCV], [MaPB]) VALUES (N'HD004', CAST(0x19380B00 AS Date), 8, N'CV003', N'PB004')
INSERT [dbo].[HopDong] ([MaHD], [NgayVaoLam], [HeSoLuong], [MaCV], [MaPB]) VALUES (N'HD005', CAST(0x19380B00 AS Date), 8, N'CV003', N'PB005')
INSERT [dbo].[HopDong] ([MaHD], [NgayVaoLam], [HeSoLuong], [MaCV], [MaPB]) VALUES (N'HD006', CAST(0x19380B00 AS Date), 7, N'CV004', N'PB003')
INSERT [dbo].[HopDong] ([MaHD], [NgayVaoLam], [HeSoLuong], [MaCV], [MaPB]) VALUES (N'HD007', CAST(0x19380B00 AS Date), 7, N'CV004', N'PB004')
INSERT [dbo].[HopDong] ([MaHD], [NgayVaoLam], [HeSoLuong], [MaCV], [MaPB]) VALUES (N'HD008', CAST(0x19380B00 AS Date), 6, N'CV005', N'PB003')
INSERT [dbo].[HopDong] ([MaHD], [NgayVaoLam], [HeSoLuong], [MaCV], [MaPB]) VALUES (N'HD009', CAST(0x19380B00 AS Date), 6, N'CV005', N'PB003')
INSERT [dbo].[HopDong] ([MaHD], [NgayVaoLam], [HeSoLuong], [MaCV], [MaPB]) VALUES (N'HD010', CAST(0x19380B00 AS Date), 6, N'CV003', N'PB003')
INSERT [dbo].[HopDong] ([MaHD], [NgayVaoLam], [HeSoLuong], [MaCV], [MaPB]) VALUES (N'HD011', CAST(0x19380B00 AS Date), 6, N'CV005', N'PB003')
INSERT [dbo].[HopDong] ([MaHD], [NgayVaoLam], [HeSoLuong], [MaCV], [MaPB]) VALUES (N'HD012', CAST(0x19380B00 AS Date), 6, N'CV005', N'PB003')
INSERT [dbo].[HopDong] ([MaHD], [NgayVaoLam], [HeSoLuong], [MaCV], [MaPB]) VALUES (N'HD013', CAST(0x19380B00 AS Date), 6, N'CV005', N'PB003')
INSERT [dbo].[HopDong] ([MaHD], [NgayVaoLam], [HeSoLuong], [MaCV], [MaPB]) VALUES (N'HD014', CAST(0x19380B00 AS Date), 6, N'CV005', N'PB004')
INSERT [dbo].[HopDong] ([MaHD], [NgayVaoLam], [HeSoLuong], [MaCV], [MaPB]) VALUES (N'HD015', CAST(0x19380B00 AS Date), 6, N'CV005', N'PB004')
INSERT [dbo].[HopDong] ([MaHD], [NgayVaoLam], [HeSoLuong], [MaCV], [MaPB]) VALUES (N'HD016', CAST(0x19380B00 AS Date), 6, N'CV005', N'PB005')
INSERT [dbo].[HopDong] ([MaHD], [NgayVaoLam], [HeSoLuong], [MaCV], [MaPB]) VALUES (N'HD017', CAST(0x19380B00 AS Date), 6, N'CV005', N'PB005')
INSERT [dbo].[HopDong] ([MaHD], [NgayVaoLam], [HeSoLuong], [MaCV], [MaPB]) VALUES (N'HD018', CAST(0x19380B00 AS Date), 6, N'CV005', N'PB005')
INSERT [dbo].[HopDong] ([MaHD], [NgayVaoLam], [HeSoLuong], [MaCV], [MaPB]) VALUES (N'HD019', CAST(0x5F410B00 AS Date), 6, N'CV002', N'PB001')
INSERT [dbo].[HopDong] ([MaHD], [NgayVaoLam], [HeSoLuong], [MaCV], [MaPB]) VALUES (N'HD020', CAST(0x5F410B00 AS Date), 10, N'CV001', N'PB001')
INSERT [dbo].[HopDong] ([MaHD], [NgayVaoLam], [HeSoLuong], [MaCV], [MaPB]) VALUES (N'HD021', CAST(0x12390B00 AS Date), 6, N'CV003', N'PB003')
INSERT [dbo].[HopDong] ([MaHD], [NgayVaoLam], [HeSoLuong], [MaCV], [MaPB]) VALUES (N'HD022', CAST(0x5F410B00 AS Date), 10, N'CV001', N'PB001')
INSERT [dbo].[HopDong] ([MaHD], [NgayVaoLam], [HeSoLuong], [MaCV], [MaPB]) VALUES (N'HD023', CAST(0x5F410B00 AS Date), 10, N'CV001', N'PB001')
INSERT [dbo].[HopDong] ([MaHD], [NgayVaoLam], [HeSoLuong], [MaCV], [MaPB]) VALUES (N'HD024', CAST(0x5F410B00 AS Date), 10, N'CV001', N'PB001')
INSERT [dbo].[HopDong] ([MaHD], [NgayVaoLam], [HeSoLuong], [MaCV], [MaPB]) VALUES (N'HD025', CAST(0x5F410B00 AS Date), 10, N'CV001', N'PB001')
INSERT [dbo].[HopDong] ([MaHD], [NgayVaoLam], [HeSoLuong], [MaCV], [MaPB]) VALUES (N'HD026', CAST(0x12390B00 AS Date), 6, N'CV002', N'PB005')
INSERT [dbo].[HopDong] ([MaHD], [NgayVaoLam], [HeSoLuong], [MaCV], [MaPB]) VALUES (N'HD027', CAST(0x5F410B00 AS Date), 10, N'CV004', N'PB005')
INSERT [dbo].[HopDong] ([MaHD], [NgayVaoLam], [HeSoLuong], [MaCV], [MaPB]) VALUES (N'HD028', CAST(0x6F410B00 AS Date), 10, N'CV001', N'PB001')
INSERT [dbo].[HopDong] ([MaHD], [NgayVaoLam], [HeSoLuong], [MaCV], [MaPB]) VALUES (N'HD029', CAST(0x5F410B00 AS Date), 10, N'CV001', N'PB001')
INSERT [dbo].[Luong] ([HeSoLuong], [LuongCB]) VALUES (1, 3500000)
INSERT [dbo].[Luong] ([HeSoLuong], [LuongCB]) VALUES (2, 3700000)
INSERT [dbo].[Luong] ([HeSoLuong], [LuongCB]) VALUES (3, 100000)
INSERT [dbo].[Luong] ([HeSoLuong], [LuongCB]) VALUES (4, 4000000)
INSERT [dbo].[Luong] ([HeSoLuong], [LuongCB]) VALUES (5, 4500000)
INSERT [dbo].[Luong] ([HeSoLuong], [LuongCB]) VALUES (6, 50000)
INSERT [dbo].[Luong] ([HeSoLuong], [LuongCB]) VALUES (7, 70000000)
INSERT [dbo].[Luong] ([HeSoLuong], [LuongCB]) VALUES (8, 10000000)
INSERT [dbo].[Luong] ([HeSoLuong], [LuongCB]) VALUES (9, 12000000)
INSERT [dbo].[Luong] ([HeSoLuong], [LuongCB]) VALUES (10, 16000000)
INSERT [dbo].[NGUOIDUNG] ([USERNAME], [PASS], [TENNGUOIDUNG], [EMAIL], [HOATDONG]) VALUES (N'admin', N'123', N'Quản Trị Viên', N'quantrivien@gmail.com', 1)
INSERT [dbo].[NGUOIDUNG] ([USERNAME], [PASS], [TENNGUOIDUNG], [EMAIL], [HOATDONG]) VALUES (N'user1', N'123', N'Tên User1', N'user1@gmail.com', 1)
INSERT [dbo].[NhanVien] ([MaNhanVien], [MaPB], [MaHD], [HeSoLuong], [TenNV], [GioiTinh], [NgaySinh], [SoCM], [DienThoai], [TrinhDoHV], [DiaChi], [Email], [Hinh], [TTHonNhan]) VALUES (N'NV001', N'PB001', N'HD001', 10, N'Nguyễn Hồng Kỳ', N'Nam', CAST(0xB3220B00 AS Date), N'034099001755', N'0386685086', N'Đại Học', N'Thụy Sơn, Thái Thụy, Thái Bình', N'marinkqh@gmail.com', N'NULL', N'Độc thân')
INSERT [dbo].[NhanVien] ([MaNhanVien], [MaPB], [MaHD], [HeSoLuong], [TenNV], [GioiTinh], [NgaySinh], [SoCM], [DienThoai], [TrinhDoHV], [DiaChi], [Email], [Hinh], [TTHonNhan]) VALUES (N'NV002', N'PB002', N'HD002', 9, N'Nguyễn Quốc Tuấn', N'Nam', CAST(0xA8220B00 AS Date), N'111111', N'1638345699', N'Đại Học', N'An Hiệp, Quỳnh Phụ, Thái Bình', N'tuannguyen@gmail.com', N'NULL', N'Độc thân')
INSERT [dbo].[NhanVien] ([MaNhanVien], [MaPB], [MaHD], [HeSoLuong], [TenNV], [GioiTinh], [NgaySinh], [SoCM], [DienThoai], [TrinhDoHV], [DiaChi], [Email], [Hinh], [TTHonNhan]) VALUES (N'NV003', N'PB003', N'HD003', 8, N'Trương Minh Sang', N'Nam', CAST(0x950F0B00 AS Date), N'88888888', N'1638345699', N'Đại Học', N'Biên Hòa, Đồng nai', N'@gmail.com', N'NULL', N'Đã Kết Hôn')
INSERT [dbo].[NhanVien] ([MaNhanVien], [MaPB], [MaHD], [HeSoLuong], [TenNV], [GioiTinh], [NgaySinh], [SoCM], [DienThoai], [TrinhDoHV], [DiaChi], [Email], [Hinh], [TTHonNhan]) VALUES (N'NV004', N'PB004', N'HD004', 8, N'Nguyễn Thị Lệ Thu', N'Nữ', CAST(0x950F0B00 AS Date), N'88888888', N'1638345699', N'Đại Học', N'Biên Hòa, Đồng nai', N'@gmail.com', N'NULL', N'Đã Kết Hôn')
INSERT [dbo].[NhanVien] ([MaNhanVien], [MaPB], [MaHD], [HeSoLuong], [TenNV], [GioiTinh], [NgaySinh], [SoCM], [DienThoai], [TrinhDoHV], [DiaChi], [Email], [Hinh], [TTHonNhan]) VALUES (N'NV005', N'PB005', N'HD005', 8, N'Trần Minh Siêu', N'Nam', CAST(0x950F0B00 AS Date), N'034099001755', N'0386685086', N'Đại Học', N'Thụy Sơn, Thái Thụy, Thái Bình', N'marinkqh@gmail.com', N'NULL', N'Độc thân')
INSERT [dbo].[NhanVien] ([MaNhanVien], [MaPB], [MaHD], [HeSoLuong], [TenNV], [GioiTinh], [NgaySinh], [SoCM], [DienThoai], [TrinhDoHV], [DiaChi], [Email], [Hinh], [TTHonNhan]) VALUES (N'NV006', N'PB003', N'HD006', 7, N'Trần Ngọc Tuyết', N'Nữ', CAST(0x950F0B00 AS Date), N'111111', N'1638345699', N'Đại Học', N'An Hiệp, Quỳnh Phụ, Thái Bình', N'tuannguyen@gmail.com', N'NULL', N'Độc thân')
INSERT [dbo].[NhanVien] ([MaNhanVien], [MaPB], [MaHD], [HeSoLuong], [TenNV], [GioiTinh], [NgaySinh], [SoCM], [DienThoai], [TrinhDoHV], [DiaChi], [Email], [Hinh], [TTHonNhan]) VALUES (N'NV007', N'PB005', N'HD007', 6, N'Nguyễn Hữu Minh', N'Nam', CAST(0x950F0B00 AS Date), N'88888888', N'1638345699', N'Đại Học', N'Biên Hòa, Đồng nai', N'@gmail.com', N'NULL', N'Đã Kết Hôn')
INSERT [dbo].[NhanVien] ([MaNhanVien], [MaPB], [MaHD], [HeSoLuong], [TenNV], [GioiTinh], [NgaySinh], [SoCM], [DienThoai], [TrinhDoHV], [DiaChi], [Email], [Hinh], [TTHonNhan]) VALUES (N'NV008', N'PB003', N'HD008', 6, N'Huỳnh Thị Yến Lê', N'Nữ', CAST(0x950F0B00 AS Date), N'88888888', N'1638345699', N'Đại Học', N'Biên Hòa, Đồng nai', N'@gmail.com', N'NULL', N'Đã Kết Hôn')
INSERT [dbo].[NhanVien] ([MaNhanVien], [MaPB], [MaHD], [HeSoLuong], [TenNV], [GioiTinh], [NgaySinh], [SoCM], [DienThoai], [TrinhDoHV], [DiaChi], [Email], [Hinh], [TTHonNhan]) VALUES (N'NV009', N'PB003', N'HD009', 6, N'Nguyễn Thị Kim Thoa', N'Nữ', CAST(0x950F0B00 AS Date), N'88888888', N'1638345699', N'Đại Học', N'Biên Hòa, Đồng nai', N'@gmail.com', N'NULL', N'Đã Kết Hôn')
INSERT [dbo].[NhanVien] ([MaNhanVien], [MaPB], [MaHD], [HeSoLuong], [TenNV], [GioiTinh], [NgaySinh], [SoCM], [DienThoai], [TrinhDoHV], [DiaChi], [Email], [Hinh], [TTHonNhan]) VALUES (N'NV010', N'PB003', N'HD010', 6, N'Nguyễn Thị Bích Hằng', N'Nữ', CAST(0x950F0B00 AS Date), N'88888888', N'1638345699', N'Đại Học', N'Biên Hòa, Đồng nai', N'@gmail.com', N'NULL', N'Đã Kết Hôn')
INSERT [dbo].[NhanVien] ([MaNhanVien], [MaPB], [MaHD], [HeSoLuong], [TenNV], [GioiTinh], [NgaySinh], [SoCM], [DienThoai], [TrinhDoHV], [DiaChi], [Email], [Hinh], [TTHonNhan]) VALUES (N'NV011', N'PB003', N'HD011', 6, N'Hồ Mạnh Tiến', N'Nam', CAST(0x950F0B00 AS Date), N'88888888', N'1638345699', N'Đại Học', N'Biên Hòa, Đồng nai', N'@gmail.com', N'NULL', N'Đã Kết Hôn')
INSERT [dbo].[NhanVien] ([MaNhanVien], [MaPB], [MaHD], [HeSoLuong], [TenNV], [GioiTinh], [NgaySinh], [SoCM], [DienThoai], [TrinhDoHV], [DiaChi], [Email], [Hinh], [TTHonNhan]) VALUES (N'NV012', N'PB003', N'HD012', 6, N'Nguyễn Tăng Quốc', N'Nam', CAST(0x950F0B00 AS Date), N'88888888', N'1638345699', N'Đại Học', N'Biên Hòa, Đồng nai', N'@gmail.com', N'NULL', N'Đã Kết Hôn')
INSERT [dbo].[NhanVien] ([MaNhanVien], [MaPB], [MaHD], [HeSoLuong], [TenNV], [GioiTinh], [NgaySinh], [SoCM], [DienThoai], [TrinhDoHV], [DiaChi], [Email], [Hinh], [TTHonNhan]) VALUES (N'NV013', N'PB004', N'HD013', 6, N'Lê Thị Tịnh', N'Nữ', CAST(0x950F0B00 AS Date), N'88888888', N'1638345699', N'Đại Học', N'Biên Hòa, Đồng nai', N'@gmail.com', N'NULL', N'Đã Kết Hôn')
INSERT [dbo].[NhanVien] ([MaNhanVien], [MaPB], [MaHD], [HeSoLuong], [TenNV], [GioiTinh], [NgaySinh], [SoCM], [DienThoai], [TrinhDoHV], [DiaChi], [Email], [Hinh], [TTHonNhan]) VALUES (N'NV014', N'PB004', N'HD014', 6, N'Bùi Thị Sương', N'Nữ', CAST(0x950F0B00 AS Date), N'88888888', N'1638345699', N'Đại Học', N'Biên Hòa, Đồng nai', N'@gmail.com', N'NULL', N'Đã Kết Hôn')
INSERT [dbo].[NhanVien] ([MaNhanVien], [MaPB], [MaHD], [HeSoLuong], [TenNV], [GioiTinh], [NgaySinh], [SoCM], [DienThoai], [TrinhDoHV], [DiaChi], [Email], [Hinh], [TTHonNhan]) VALUES (N'NV015', N'PB005', N'HD015', 6, N'Bùi Văn Long', N'Nam', CAST(0x950F0B00 AS Date), N'88888888', N'1638345699', N'Đại Học', N'Biên Hòa, Đồng nai', N'@gmail.com', N'NULL', N'Đã Kết Hôn')
INSERT [dbo].[NhanVien] ([MaNhanVien], [MaPB], [MaHD], [HeSoLuong], [TenNV], [GioiTinh], [NgaySinh], [SoCM], [DienThoai], [TrinhDoHV], [DiaChi], [Email], [Hinh], [TTHonNhan]) VALUES (N'NV016', N'PB005', N'HD016', 6, N'Đỗ Hữu Tiến', N'Nam', CAST(0x950F0B00 AS Date), N'88888888', N'1638345699', N'Đại Học', N'Biên Hòa, Đồng nai', N'@gmail.com', N'NULL', N'Đã Kết Hôn')
INSERT [dbo].[NhanVien] ([MaNhanVien], [MaPB], [MaHD], [HeSoLuong], [TenNV], [GioiTinh], [NgaySinh], [SoCM], [DienThoai], [TrinhDoHV], [DiaChi], [Email], [Hinh], [TTHonNhan]) VALUES (N'NV017', N'PB005', N'HD026', 6, N'Lê Đăng Trường', N'Nam', CAST(0x1E230B00 AS Date), N'8732763262', N'099787867', N'Tiến Sĩ', N'TPHCM', N'@gmail.com', N'HinhLê Đăng Trường', N'Độc Thân')
INSERT [dbo].[NhanVien] ([MaNhanVien], [MaPB], [MaHD], [HeSoLuong], [TenNV], [GioiTinh], [NgaySinh], [SoCM], [DienThoai], [TrinhDoHV], [DiaChi], [Email], [Hinh], [TTHonNhan]) VALUES (N'NV018', N'PB001', N'HD029', 10, N'Huỳnh Ngọc Khánh', N'Nam', CAST(0xB3220B00 AS Date), N'', N'', N'', N'TPHCM', N'', N'HinhHuỳnh Ngọc Khánh', N'')
INSERT [dbo].[NHOMQUYEN] ([MANHOM], [TENNHOM], [GHICHU]) VALUES (N'NHOM_NGUOI_DUNG_THUONG', N'Nhóm người dùng thường', N'Những ngừoi dùng được tạo sẽ mặt định có những quyền trong nhóm này')
INSERT [dbo].[NHOMQUYEN] ([MANHOM], [TENNHOM], [GHICHU]) VALUES (N'PHONG_QUAN_TRI_QUYEN', N'Phòng Quản Trị Quyền Của Nhóm Và Phân Ngừoi Dùng Vào Nhóm', N'Phòng ban chứa những ngừoi dùng có nhiệm vụ phần quyền cho nhóm vào phân ngừoi dùng vào nhóm')
INSERT [dbo].[PHANNGUOIDUNG_VAONHOMQUYEN] ([USERNAME], [MANHOM], [GHICHU]) VALUES (N'admin', N'NHOM_NGUOI_DUNG_THUONG', N'Giám đốc mặc định có chứa quyền của người dùng thường')
INSERT [dbo].[PHANNGUOIDUNG_VAONHOMQUYEN] ([USERNAME], [MANHOM], [GHICHU]) VALUES (N'admin', N'PHONG_QUAN_TRI_QUYEN', N'Giám đốc ')
INSERT [dbo].[PHANQUYEN] ([MANHOM], [MAQUYEN], [COQUYEN]) VALUES (N'NHOM_NGUOI_DUNG_THUONG', N'MH_DANG_XUAT', 0)
INSERT [dbo].[PHANQUYEN] ([MANHOM], [MAQUYEN], [COQUYEN]) VALUES (N'NHOM_NGUOI_DUNG_THUONG', N'MH_NHAP', 0)
INSERT [dbo].[PHANQUYEN] ([MANHOM], [MAQUYEN], [COQUYEN]) VALUES (N'NHOM_NGUOI_DUNG_THUONG', N'MH_PHAN_QUYEN_CHO_NHOM', 0)
INSERT [dbo].[PHANQUYEN] ([MANHOM], [MAQUYEN], [COQUYEN]) VALUES (N'NHOM_NGUOI_DUNG_THUONG', N'MH_QL_DANH_MUC', 0)
INSERT [dbo].[PHANQUYEN] ([MANHOM], [MAQUYEN], [COQUYEN]) VALUES (N'NHOM_NGUOI_DUNG_THUONG', N'MH_QL_NHAN_VIEN', 0)
INSERT [dbo].[PHANQUYEN] ([MANHOM], [MAQUYEN], [COQUYEN]) VALUES (N'NHOM_NGUOI_DUNG_THUONG', N'MH_QL_NHOM_QUYEN', 0)
INSERT [dbo].[PHANQUYEN] ([MANHOM], [MAQUYEN], [COQUYEN]) VALUES (N'NHOM_NGUOI_DUNG_THUONG', N'MH_QL_QUYEN', 0)
INSERT [dbo].[PHANQUYEN] ([MANHOM], [MAQUYEN], [COQUYEN]) VALUES (N'NHOM_NGUOI_DUNG_THUONG', N'MH_THONG_TIN_UNG_DUNG', 1)
INSERT [dbo].[PHANQUYEN] ([MANHOM], [MAQUYEN], [COQUYEN]) VALUES (N'NHOM_NGUOI_DUNG_THUONG', N'MH_XEM_THONG_TIN_CANHAN', 1)
INSERT [dbo].[PHANQUYEN] ([MANHOM], [MAQUYEN], [COQUYEN]) VALUES (N'NHOM_NGUOI_DUNG_THUONG', N'MH_XUAT', 1)
INSERT [dbo].[PHANQUYEN] ([MANHOM], [MAQUYEN], [COQUYEN]) VALUES (N'PHONG_QUAN_TRI_QUYEN', N'MH_DANG_XUAT', 1)
INSERT [dbo].[PHANQUYEN] ([MANHOM], [MAQUYEN], [COQUYEN]) VALUES (N'PHONG_QUAN_TRI_QUYEN', N'MH_NHAP', 0)
INSERT [dbo].[PHANQUYEN] ([MANHOM], [MAQUYEN], [COQUYEN]) VALUES (N'PHONG_QUAN_TRI_QUYEN', N'MH_PHAN_QUYEN_CHO_NHOM', 1)
INSERT [dbo].[PHANQUYEN] ([MANHOM], [MAQUYEN], [COQUYEN]) VALUES (N'PHONG_QUAN_TRI_QUYEN', N'MH_QL_DANH_MUC', 0)
INSERT [dbo].[PHANQUYEN] ([MANHOM], [MAQUYEN], [COQUYEN]) VALUES (N'PHONG_QUAN_TRI_QUYEN', N'MH_QL_NHAN_VIEN', 0)
INSERT [dbo].[PHANQUYEN] ([MANHOM], [MAQUYEN], [COQUYEN]) VALUES (N'PHONG_QUAN_TRI_QUYEN', N'MH_QL_NHOM_QUYEN', 1)
INSERT [dbo].[PHANQUYEN] ([MANHOM], [MAQUYEN], [COQUYEN]) VALUES (N'PHONG_QUAN_TRI_QUYEN', N'MH_QL_QUYEN', 0)
INSERT [dbo].[PHANQUYEN] ([MANHOM], [MAQUYEN], [COQUYEN]) VALUES (N'PHONG_QUAN_TRI_QUYEN', N'MH_THONG_TIN_UNG_DUNG', 0)
INSERT [dbo].[PHANQUYEN] ([MANHOM], [MAQUYEN], [COQUYEN]) VALUES (N'PHONG_QUAN_TRI_QUYEN', N'MH_XEM_THONG_TIN_CANHAN', 0)
INSERT [dbo].[PHANQUYEN] ([MANHOM], [MAQUYEN], [COQUYEN]) VALUES (N'PHONG_QUAN_TRI_QUYEN', N'MH_XUAT', 0)
INSERT [dbo].[PhongBan] ([MaPB], [TenPB]) VALUES (N'PB001', N'Phòng Giám Đốc')
INSERT [dbo].[PhongBan] ([MaPB], [TenPB]) VALUES (N'PB002', N'Phòng Phó Giám Đốc')
INSERT [dbo].[PhongBan] ([MaPB], [TenPB]) VALUES (N'PB003', N'Phòng Kinh Doanh')
INSERT [dbo].[PhongBan] ([MaPB], [TenPB]) VALUES (N'PB004', N'Phòng Kế Toán')
INSERT [dbo].[PhongBan] ([MaPB], [TenPB]) VALUES (N'PB005', N'Phòng Kỹ Thuật')
INSERT [dbo].[PhongBan] ([MaPB], [TenPB]) VALUES (N'PB006', N'Phong Maketing')
INSERT [dbo].[QUYEN] ([MAQUYEN], [TENQUYEN], [GHICHU]) VALUES (N'MH_DANG_XUAT', N'Chức năng đăng xuất', N'Chức năng đăng xuất, khi nhân viên đăng nhập vào hệ thống')
INSERT [dbo].[QUYEN] ([MAQUYEN], [TENQUYEN], [GHICHU]) VALUES (N'MH_NHAP', N'Màn hình nhập trên ứng dụng', N'Chức năng nhập trên ứng dụng')
INSERT [dbo].[QUYEN] ([MAQUYEN], [TENQUYEN], [GHICHU]) VALUES (N'MH_PHAN_QUYEN_CHO_NHOM', N'Quản lý phân quyền cho nhóm', N'Người có nhiệm vụ phân quyền cho các nhóm, các phòng ban')
INSERT [dbo].[QUYEN] ([MAQUYEN], [TENQUYEN], [GHICHU]) VALUES (N'MH_QL_DANH_MUC', N'Quản lý danh mục', N'Thêm, xóa, sửa trên bảng danh mục')
INSERT [dbo].[QUYEN] ([MAQUYEN], [TENQUYEN], [GHICHU]) VALUES (N'MH_QL_NHAN_VIEN', N'Quản lý nhân viên', N'Thêm, xóa, sửa trên bảng nhân viên')
INSERT [dbo].[QUYEN] ([MAQUYEN], [TENQUYEN], [GHICHU]) VALUES (N'MH_QL_NHOM_QUYEN', N'Quản lý các nhóm quyền trên ứng dụng', N'Thêm, xóa, sửa trên bảng nhóm quyền')
INSERT [dbo].[QUYEN] ([MAQUYEN], [TENQUYEN], [GHICHU]) VALUES (N'MH_QL_QUYEN', N'Quản lý các quyền trên ứng dụng', N'Thêm, xóa, sửa trên bảng quyền')
INSERT [dbo].[QUYEN] ([MAQUYEN], [TENQUYEN], [GHICHU]) VALUES (N'MH_THONG_TIN_UNG_DUNG', N'Màn hình thông tin ứng dụng', N'Chức năng xem thông tin của ứng dụng')
INSERT [dbo].[QUYEN] ([MAQUYEN], [TENQUYEN], [GHICHU]) VALUES (N'MH_XEM_THONG_TIN_CANHAN', N'Màn hình xem thông tin cá nhân', N'Chức năng xem thông tin cá nhân khi nhân viên đăng nhập vào hệ thống')
INSERT [dbo].[QUYEN] ([MAQUYEN], [TENQUYEN], [GHICHU]) VALUES (N'MH_XUAT', N'Màn hình xuất trên ứng dụng', N'Chức năng xuất trên ứng dụng')
SET IDENTITY_INSERT [dbo].[ThuongPhat] ON 

INSERT [dbo].[ThuongPhat] ([MaThuongPhat], [MaNhanVien], [Loai], [Tien], [LyDo], [Ngay]) VALUES (1, N'NV002', N'Thưởng', 600000, N'Ký được hợp đồng', CAST(0x4C410B00 AS Date))
INSERT [dbo].[ThuongPhat] ([MaThuongPhat], [MaNhanVien], [Loai], [Tien], [LyDo], [Ngay]) VALUES (2, N'NV005', N'Thưởng', 600000, N'Điều tiết máy móc xuất sắc', CAST(0x4C410B00 AS Date))
INSERT [dbo].[ThuongPhat] ([MaThuongPhat], [MaNhanVien], [Loai], [Tien], [LyDo], [Ngay]) VALUES (3, N'NV018', N'Thưởng', 600000, N'Điều chỉnh nhân sự tốt', CAST(0x4C410B00 AS Date))
INSERT [dbo].[ThuongPhat] ([MaThuongPhat], [MaNhanVien], [Loai], [Tien], [LyDo], [Ngay]) VALUES (4, N'NV003', N'Thưởng', 600000, N'Mang lợi ích cho công ty', CAST(0x4C410B00 AS Date))
INSERT [dbo].[ThuongPhat] ([MaThuongPhat], [MaNhanVien], [Loai], [Tien], [LyDo], [Ngay]) VALUES (5, N'NV010', N'Thưởng', 600000, N'Mang lại hiệu quả công việc', CAST(0x4C410B00 AS Date))
INSERT [dbo].[ThuongPhat] ([MaThuongPhat], [MaNhanVien], [Loai], [Tien], [LyDo], [Ngay]) VALUES (6, N'NV004', N'Thưởng', 600000, N'CÓ tinh thần chăm chỉ', CAST(0x4C410B00 AS Date))
INSERT [dbo].[ThuongPhat] ([MaThuongPhat], [MaNhanVien], [Loai], [Tien], [LyDo], [Ngay]) VALUES (7, N'NV015', N'Phạt', 600000, N'Hút thuốc trong khu vực làm việc', CAST(0x4C410B00 AS Date))
INSERT [dbo].[ThuongPhat] ([MaThuongPhat], [MaNhanVien], [Loai], [Tien], [LyDo], [Ngay]) VALUES (8, N'NV016', N'Phạt', 600000, N'Hút thuốc trong khu vực làm việc', CAST(0x4C410B00 AS Date))
SET IDENTITY_INSERT [dbo].[ThuongPhat] OFF
INSERT [dbo].[TinhLuong] ([MaNhanVien], [HeSoLuong], [SoNgayCong], [TroCap], [Thuong], [Phat], [ThucLinh]) VALUES (N'NV001', 10, 5, 50000.0000, NULL, NULL, 3126923.0000)
INSERT [dbo].[TinhLuong] ([MaNhanVien], [HeSoLuong], [SoNgayCong], [TroCap], [Thuong], [Phat], [ThucLinh]) VALUES (N'NV002', 9, 2, 60000.0000, NULL, NULL, 983076.0000)
INSERT [dbo].[TinhLuong] ([MaNhanVien], [HeSoLuong], [SoNgayCong], [TroCap], [Thuong], [Phat], [ThucLinh]) VALUES (N'NV003', 8, 2, 60000.0000, NULL, NULL, 829230.0000)
INSERT [dbo].[TinhLuong] ([MaNhanVien], [HeSoLuong], [SoNgayCong], [TroCap], [Thuong], [Phat], [ThucLinh]) VALUES (N'NV005', 8, 5, 500000.0000, NULL, NULL, 2423076.0000)
INSERT [dbo].[TinhLuong] ([MaNhanVien], [HeSoLuong], [SoNgayCong], [TroCap], [Thuong], [Phat], [ThucLinh]) VALUES (N'NV006', 7, 2, 70000.0000, NULL, NULL, 5454615.0000)
INSERT [dbo].[TinhLuong] ([MaNhanVien], [HeSoLuong], [SoNgayCong], [TroCap], [Thuong], [Phat], [ThucLinh]) VALUES (N'NV007', 6, 2, 70000.0000, NULL, NULL, 73846.0000)
INSERT [dbo].[TinhLuong] ([MaNhanVien], [HeSoLuong], [SoNgayCong], [TroCap], [Thuong], [Phat], [ThucLinh]) VALUES (N'NV008', 6, 1, 70000.0000, NULL, NULL, 71923.0000)
ALTER TABLE [dbo].[BaoHiem]  WITH CHECK ADD  CONSTRAINT [FK_BaoHiem_NhanVien1] FOREIGN KEY([MaNhanVien])
REFERENCES [dbo].[NhanVien] ([MaNhanVien])
GO
ALTER TABLE [dbo].[BaoHiem] CHECK CONSTRAINT [FK_BaoHiem_NhanVien1]
GO
ALTER TABLE [dbo].[ChamCong]  WITH CHECK ADD  CONSTRAINT [FK_ChamCong_NhanVien] FOREIGN KEY([MaNhanVien])
REFERENCES [dbo].[NhanVien] ([MaNhanVien])
GO
ALTER TABLE [dbo].[ChamCong] CHECK CONSTRAINT [FK_ChamCong_NhanVien]
GO
ALTER TABLE [dbo].[ctChucVu]  WITH CHECK ADD  CONSTRAINT [FK__ctChucVu__MaCV__267ABA7A] FOREIGN KEY([MaCV])
REFERENCES [dbo].[ChucVu] ([MaCV])
GO
ALTER TABLE [dbo].[ctChucVu] CHECK CONSTRAINT [FK__ctChucVu__MaCV__267ABA7A]
GO
ALTER TABLE [dbo].[ctChucVu]  WITH CHECK ADD  CONSTRAINT [FK_ctChucVu_NhanVien] FOREIGN KEY([MaNhanVien])
REFERENCES [dbo].[NhanVien] ([MaNhanVien])
GO
ALTER TABLE [dbo].[ctChucVu] CHECK CONSTRAINT [FK_ctChucVu_NhanVien]
GO
ALTER TABLE [dbo].[HopDong]  WITH CHECK ADD  CONSTRAINT [FK_HopDong_ChucVu] FOREIGN KEY([MaCV])
REFERENCES [dbo].[ChucVu] ([MaCV])
GO
ALTER TABLE [dbo].[HopDong] CHECK CONSTRAINT [FK_HopDong_ChucVu]
GO
ALTER TABLE [dbo].[HopDong]  WITH CHECK ADD  CONSTRAINT [FK_HopDong_Luong] FOREIGN KEY([HeSoLuong])
REFERENCES [dbo].[Luong] ([HeSoLuong])
GO
ALTER TABLE [dbo].[HopDong] CHECK CONSTRAINT [FK_HopDong_Luong]
GO
ALTER TABLE [dbo].[HopDong]  WITH CHECK ADD  CONSTRAINT [FK_HopDong_PhongBan] FOREIGN KEY([MaPB])
REFERENCES [dbo].[PhongBan] ([MaPB])
GO
ALTER TABLE [dbo].[HopDong] CHECK CONSTRAINT [FK_HopDong_PhongBan]
GO
ALTER TABLE [dbo].[NhanVien]  WITH CHECK ADD FOREIGN KEY([HeSoLuong])
REFERENCES [dbo].[Luong] ([HeSoLuong])
GO
ALTER TABLE [dbo].[NhanVien]  WITH CHECK ADD FOREIGN KEY([MaPB])
REFERENCES [dbo].[PhongBan] ([MaPB])
GO
ALTER TABLE [dbo].[NhanVien]  WITH CHECK ADD  CONSTRAINT [FK_NhanVien_HopDong] FOREIGN KEY([MaHD])
REFERENCES [dbo].[HopDong] ([MaHD])
GO
ALTER TABLE [dbo].[NhanVien] CHECK CONSTRAINT [FK_NhanVien_HopDong]
GO
ALTER TABLE [dbo].[PHANNGUOIDUNG_VAONHOMQUYEN]  WITH CHECK ADD  CONSTRAINT [FK_PHANNGUOIDUNG_VAONHOMQUYEN_NGUOIDUNG] FOREIGN KEY([USERNAME])
REFERENCES [dbo].[NGUOIDUNG] ([USERNAME])
GO
ALTER TABLE [dbo].[PHANNGUOIDUNG_VAONHOMQUYEN] CHECK CONSTRAINT [FK_PHANNGUOIDUNG_VAONHOMQUYEN_NGUOIDUNG]
GO
ALTER TABLE [dbo].[PHANNGUOIDUNG_VAONHOMQUYEN]  WITH CHECK ADD  CONSTRAINT [FK_PHANNGUOIDUNG_VAONHOMQUYEN_NHOMQUYEN] FOREIGN KEY([MANHOM])
REFERENCES [dbo].[NHOMQUYEN] ([MANHOM])
GO
ALTER TABLE [dbo].[PHANNGUOIDUNG_VAONHOMQUYEN] CHECK CONSTRAINT [FK_PHANNGUOIDUNG_VAONHOMQUYEN_NHOMQUYEN]
GO
ALTER TABLE [dbo].[PHANQUYEN]  WITH CHECK ADD  CONSTRAINT [FK_PHANQUYEN_NHOMQUYEN] FOREIGN KEY([MANHOM])
REFERENCES [dbo].[NHOMQUYEN] ([MANHOM])
GO
ALTER TABLE [dbo].[PHANQUYEN] CHECK CONSTRAINT [FK_PHANQUYEN_NHOMQUYEN]
GO
ALTER TABLE [dbo].[PHANQUYEN]  WITH CHECK ADD  CONSTRAINT [FK_PHANQUYEN_QUYEN] FOREIGN KEY([MAQUYEN])
REFERENCES [dbo].[QUYEN] ([MAQUYEN])
GO
ALTER TABLE [dbo].[PHANQUYEN] CHECK CONSTRAINT [FK_PHANQUYEN_QUYEN]
GO
ALTER TABLE [dbo].[ThuongPhat]  WITH CHECK ADD  CONSTRAINT [FK_ThuongPhat_NhanVien] FOREIGN KEY([MaNhanVien])
REFERENCES [dbo].[NhanVien] ([MaNhanVien])
GO
ALTER TABLE [dbo].[ThuongPhat] CHECK CONSTRAINT [FK_ThuongPhat_NhanVien]
GO
ALTER TABLE [dbo].[TinhLuong]  WITH CHECK ADD  CONSTRAINT [FK_TinhLuong_Luong] FOREIGN KEY([HeSoLuong])
REFERENCES [dbo].[Luong] ([HeSoLuong])
GO
ALTER TABLE [dbo].[TinhLuong] CHECK CONSTRAINT [FK_TinhLuong_Luong]
GO
ALTER TABLE [dbo].[TinhLuong]  WITH CHECK ADD  CONSTRAINT [FK_TinhLuong_NhanVien] FOREIGN KEY([MaNhanVien])
REFERENCES [dbo].[NhanVien] ([MaNhanVien])
GO
ALTER TABLE [dbo].[TinhLuong] CHECK CONSTRAINT [FK_TinhLuong_NhanVien]
GO
/****** Object:  Trigger [dbo].[them1baohiem]    Script Date: 8/12/2020 20:08:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create trigger [dbo].[them1baohiem]	on [dbo].[BaoHiem] after insert as
	begin
			declare @mabaohiem varchar(5);
		
			
			select @mabaohiem=dbo.AUTO_mabaohiem();

			update BaoHiem set MaBaoHiem=@mabaohiem where MaBaoHiem=''
		END
GO
/****** Object:  Trigger [dbo].[them1ctcv]    Script Date: 8/12/2020 20:08:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE trigger [dbo].[them1ctcv]	on [dbo].[ctChucVu] after insert as
	begin
			declare @ctcv varchar(5);
		
			
			select @ctcv=dbo.AUTO_ctcv();

			update  ctChucVu set Mactcv=@ctcv where Mactcv=''
		END

GO
/****** Object:  Trigger [dbo].[them1hopdong]    Script Date: 8/12/2020 20:08:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE trigger [dbo].[them1hopdong]	on [dbo].[HopDong] after insert as
	begin
			declare @mahd varchar(5);
		
			
			select @mahd=dbo.AUTO_HD();

			update  HopDong set MaHD=@mahd where MaHD=''
		END

GO
USE [master]
GO
ALTER DATABASE [QlNhanSu2] SET  READ_WRITE 
GO
