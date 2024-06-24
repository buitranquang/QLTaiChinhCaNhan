CREATE DATABASE QLTaiChinh

USE [QLTaiChinh]
GO
/****** Object:  Table [dbo].[ChiTieu]    Script Date: 24/05/2024 11:39:43 SA ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ChiTieu](
	[MaChiTieu] [int] IDENTITY(1,1) NOT NULL,
	[SoTienChitieu] [int] NULL,
	[NgayChiTieu] [date] NULL,
	[MaLoaiCT] [nvarchar](50) NULL,
	[MaVi] [nvarchar](50) NULL,
	[MaTK] [nvarchar](50) NULL,
 CONSTRAINT [PK__ChiTieu___CDF0A117B8CF50C3] PRIMARY KEY CLUSTERED 
(
	[MaChiTieu] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[KhoanVay]    Script Date: 24/05/2024 11:39:43 SA ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[KhoanVay](
	[MaKV] [nvarchar](50) NOT NULL,
	[SoTienTra] [bigint] NULL,
	[NgayHan] [date] NULL,
	[TrangThai] [nvarchar](max) NULL,
	[MaTK] [nvarchar](50) NULL,
	[TenKV] [nvarchar](50) NULL,
 CONSTRAINT [PK__KhoanVay__2725CF6C94A12D73] PRIMARY KEY CLUSTERED 
(
	[MaKV] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[LoaiCT]    Script Date: 24/05/2024 11:39:43 SA ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LoaiCT](
	[MaLoaiCT] [nvarchar](50) NOT NULL,
	[TenLoaiCT] [nvarchar](50) NULL,
	[MaTK] [nvarchar](50) NULL,
 CONSTRAINT [PK__LoaiCT__12274044CD7D81CE] PRIMARY KEY CLUSTERED 
(
	[MaLoaiCT] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TaiKhoan]    Script Date: 24/05/2024 11:39:43 SA ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TaiKhoan](
	[MaTK] [nvarchar](50) NOT NULL,
	[TenTK] [nvarchar](30) NOT NULL,
	[MatKhau] [nvarchar](20) NOT NULL,
	[ThanhPho] [nchar](50) NOT NULL,
	[SDT] [bigint] NULL,
	[DateTK] [date] NOT NULL,
	[SLVi] [int] NULL,
	[TenUser] [nvarchar](30) NULL,
 CONSTRAINT [PK__TaiKhoan__2725007015D96BFF] PRIMARY KEY CLUSTERED 
(
	[MaTK] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Vi]    Script Date: 24/05/2024 11:39:43 SA ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Vi](
	[MaVi] [nvarchar](50) NOT NULL,
	[TenVi] [nvarchar](50) NULL,
	[MaTK] [nvarchar](50) NULL,
 CONSTRAINT [PK__Vi__27251013E4AC0A45] PRIMARY KEY CLUSTERED 
(
	[MaVi] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[ChiTieu]  WITH CHECK ADD  CONSTRAINT [FK_ChiTieu_ChiTieu] FOREIGN KEY([MaChiTieu])
REFERENCES [dbo].[ChiTieu] ([MaChiTieu])
GO
ALTER TABLE [dbo].[ChiTieu] CHECK CONSTRAINT [FK_ChiTieu_ChiTieu]
GO
ALTER TABLE [dbo].[ChiTieu]  WITH CHECK ADD  CONSTRAINT [FK_ChiTieu_LoaiCT] FOREIGN KEY([MaLoaiCT])
REFERENCES [dbo].[LoaiCT] ([MaLoaiCT])
GO
ALTER TABLE [dbo].[ChiTieu] CHECK CONSTRAINT [FK_ChiTieu_LoaiCT]
GO
ALTER TABLE [dbo].[ChiTieu]  WITH CHECK ADD  CONSTRAINT [FK_ChiTieu_TaiKhoan] FOREIGN KEY([MaTK])
REFERENCES [dbo].[TaiKhoan] ([MaTK])
GO
ALTER TABLE [dbo].[ChiTieu] CHECK CONSTRAINT [FK_ChiTieu_TaiKhoan]
GO
ALTER TABLE [dbo].[ChiTieu]  WITH CHECK ADD  CONSTRAINT [FK_ChiTieu_Vi] FOREIGN KEY([MaVi])
REFERENCES [dbo].[Vi] ([MaVi])
GO
ALTER TABLE [dbo].[ChiTieu] CHECK CONSTRAINT [FK_ChiTieu_Vi]
GO
ALTER TABLE [dbo].[KhoanVay]  WITH CHECK ADD  CONSTRAINT [FK__KhoanVay__MaTK__4222D4EF] FOREIGN KEY([MaTK])
REFERENCES [dbo].[TaiKhoan] ([MaTK])
GO
ALTER TABLE [dbo].[KhoanVay] CHECK CONSTRAINT [FK__KhoanVay__MaTK__4222D4EF]
GO
ALTER TABLE [dbo].[LoaiCT]  WITH CHECK ADD  CONSTRAINT [FK_LoaiCT_LoaiCT] FOREIGN KEY([MaLoaiCT])
REFERENCES [dbo].[LoaiCT] ([MaLoaiCT])
GO
ALTER TABLE [dbo].[LoaiCT] CHECK CONSTRAINT [FK_LoaiCT_LoaiCT]
GO
ALTER TABLE [dbo].[LoaiCT]  WITH CHECK ADD  CONSTRAINT [LoaiCT_TaiKhoan] FOREIGN KEY([MaTK])
REFERENCES [dbo].[TaiKhoan] ([MaTK])
GO
ALTER TABLE [dbo].[LoaiCT] CHECK CONSTRAINT [LoaiCT_TaiKhoan]
GO
ALTER TABLE [dbo].[Vi]  WITH CHECK ADD  CONSTRAINT [FK__Vi__MaTK__398D8EEE] FOREIGN KEY([MaTK])
REFERENCES [dbo].[TaiKhoan] ([MaTK])
GO
ALTER TABLE [dbo].[Vi] CHECK CONSTRAINT [FK__Vi__MaTK__398D8EEE]
GO
/****** Object:  StoredProcedure [dbo].[proc_logic]    Script Date: 24/05/2024 11:39:43 SA ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[proc_logic]
@user nvarchar(50),
@pass nvarchar(20)
as
BEGIN
	SELECT * FROM TaiKhoan WHERE TenTK = @user AND MatKhau = @pass
END
GO

INSERT INTO [dbo].[LoaiCT]
           ([MaLoaiCT]
           ,[TenLoaiCT]
           ,[MaTK])
     VALUES
           (N'Thu01',N'Lương',null),
		   (N'Thu02',N'Việc vặt',null),
		   (N'Thu03',N'Tiết kiệm',null),
		   (N'Thu04',N'Đầu tư',null),
		   (N'Thu05',N'Thu nhập phụ',null),
		   (N'Thu06',N'Thưởng',null),
		   (N'Thu07',N'Thu nhập tạm',null),
		   (N'Chi01',N'Ăn uống',null),
		   (N'Chi02',N'Mua sắm',null),
		   (N'Chi03',N'Phí giao lưu',null),
		   (N'Chi04',N'Sách báo',null),
		   (N'Chi05',N'Hóa đơn',null),
		   (N'Chi06',N'Sức khỏe',null),
		   (N'Chi07',N'Đi lại',null),
		   (N'Chi08',N'Xăng dầu',null),
		   (N'Chi09',N'Thú nuôi',null)
GO

