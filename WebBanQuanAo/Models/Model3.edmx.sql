
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 12/08/2020 20:00:00
-- Generated from EDMX file: C:\Users\Admin\Desktop\DoAn\ThuongMaiDienTu\WebBanQuanAo\WebBanQuanAo\Models\Model.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [WebQA2];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK__NhanVien__MaCN__1FCDBCEB]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[NhanViens] DROP CONSTRAINT [FK__NhanVien__MaCN__1FCDBCEB];
GO
IF OBJECT_ID(N'[dbo].[FK_ChiTietDonHang_DonHang]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ChiTietDonHangs] DROP CONSTRAINT [FK_ChiTietDonHang_DonHang];
GO
IF OBJECT_ID(N'[dbo].[FK_ChiTietDonHang_SanPham]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ChiTietDonHangs] DROP CONSTRAINT [FK_ChiTietDonHang_SanPham];
GO
IF OBJECT_ID(N'[dbo].[FK__SanPham__MaDM__22AA2996]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[SanPhams] DROP CONSTRAINT [FK__SanPham__MaDM__22AA2996];
GO
IF OBJECT_ID(N'[dbo].[FK__DonHang__MaKH__20C1E124]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[DonHangs] DROP CONSTRAINT [FK__DonHang__MaKH__20C1E124];
GO
IF OBJECT_ID(N'[dbo].[FK__DonHang__MaNV__1ED998B2]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[DonHangs] DROP CONSTRAINT [FK__DonHang__MaNV__1ED998B2];
GO
IF OBJECT_ID(N'[dbo].[FK__SanPham__MaNCC__21B6055D]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[SanPhams] DROP CONSTRAINT [FK__SanPham__MaNCC__21B6055D];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[Admins]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Admins];
GO
IF OBJECT_ID(N'[dbo].[ChiNhanhs]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ChiNhanhs];
GO
IF OBJECT_ID(N'[dbo].[ChiTietDonHangs]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ChiTietDonHangs];
GO
IF OBJECT_ID(N'[dbo].[DanhMucs]', 'U') IS NOT NULL
    DROP TABLE [dbo].[DanhMucs];
GO
IF OBJECT_ID(N'[dbo].[DonHangs]', 'U') IS NOT NULL
    DROP TABLE [dbo].[DonHangs];
GO
IF OBJECT_ID(N'[dbo].[KhachHangs]', 'U') IS NOT NULL
    DROP TABLE [dbo].[KhachHangs];
GO
IF OBJECT_ID(N'[dbo].[NhaCungCaps]', 'U') IS NOT NULL
    DROP TABLE [dbo].[NhaCungCaps];
GO
IF OBJECT_ID(N'[dbo].[NhanViens]', 'U') IS NOT NULL
    DROP TABLE [dbo].[NhanViens];
GO
IF OBJECT_ID(N'[dbo].[SanPhams]', 'U') IS NOT NULL
    DROP TABLE [dbo].[SanPhams];
GO
IF OBJECT_ID(N'[dbo].[sysdiagrams]', 'U') IS NOT NULL
    DROP TABLE [dbo].[sysdiagrams];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Admins'
CREATE TABLE [dbo].[Admins] (
    [MaAdmin] int IDENTITY(1,1) NOT NULL,
    [Username] nvarchar(50)  NOT NULL,
    [Password] nvarchar(50)  NOT NULL
);
GO

-- Creating table 'ChiNhanhs'
CREATE TABLE [dbo].[ChiNhanhs] (
    [MaCN] int IDENTITY(1,1) NOT NULL,
    [TenCN] nvarchar(50)  NOT NULL,
    [DiaChi] nvarchar(max)  NULL,
    [SoDT] nvarchar(50)  NULL
);
GO

-- Creating table 'ChiTietDonHangs'
CREATE TABLE [dbo].[ChiTietDonHangs] (
    [MaSP] int  NOT NULL,
    [MaDonHang] int  NOT NULL,
    [SoLuong] int  NULL,
    [TongTien] int  NULL
);
GO

-- Creating table 'DanhMucs'
CREATE TABLE [dbo].[DanhMucs] (
    [MaDM] int IDENTITY(1,1) NOT NULL,
    [TenDM] nvarchar(50)  NOT NULL
);
GO

-- Creating table 'DonHangs'
CREATE TABLE [dbo].[DonHangs] (
    [MaDH] int IDENTITY(1,1) NOT NULL,
    [MaKH] int  NULL,
    [MaNV] int  NULL,
    [TenNguoiNhan] nvarchar(50)  NULL,
    [SoDT] nvarchar(50)  NULL,
    [DiaChi] nvarchar(max)  NULL,
    [NgayDat] datetime  NOT NULL
);
GO

-- Creating table 'KhachHangs'
CREATE TABLE [dbo].[KhachHangs] (
    [MaKH] int IDENTITY(1,1) NOT NULL,
    [TenKH] nvarchar(50)  NOT NULL,
    [Email] nvarchar(50)  NULL,
    [SoDT] nvarchar(50)  NULL,
    [GioiTinh] nvarchar(50)  NULL,
    [UserName] nvarchar(50)  NULL,
    [MatKhau] nvarchar(50)  NULL,
    [DiaChi] nvarchar(max)  NULL
);
GO

-- Creating table 'NhaCungCaps'
CREATE TABLE [dbo].[NhaCungCaps] (
    [MaNCC] int IDENTITY(1,1) NOT NULL,
    [TenNCC] nvarchar(50)  NOT NULL,
    [DiaChi] nvarchar(max)  NULL,
    [SoDT] nvarchar(50)  NULL,
    [Email] nvarchar(50)  NULL
);
GO

-- Creating table 'NhanViens'
CREATE TABLE [dbo].[NhanViens] (
    [MaNV] int IDENTITY(1,1) NOT NULL,
    [MaCN] int  NOT NULL,
    [TenNV] nvarchar(50)  NOT NULL,
    [SoDT] int  NULL,
    [email] nvarchar(50)  NULL
);
GO

-- Creating table 'SanPhams'
CREATE TABLE [dbo].[SanPhams] (
    [MaSP] int IDENTITY(1,1) NOT NULL,
    [MaNCC] int  NOT NULL,
    [TenSP] nvarchar(50)  NOT NULL,
    [MauSac] nvarchar(50)  NULL,
    [HinhSP] nvarchar(max)  NULL,
    [GiaSP] int  NULL,
    [MoTa] nvarchar(max)  NULL,
    [MaDM] int  NOT NULL
);
GO

-- Creating table 'sysdiagrams'
CREATE TABLE [dbo].[sysdiagrams] (
    [name] nvarchar(128)  NOT NULL,
    [principal_id] int  NOT NULL,
    [diagram_id] int IDENTITY(1,1) NOT NULL,
    [version] int  NULL,
    [definition] varbinary(max)  NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [MaAdmin] in table 'Admins'
ALTER TABLE [dbo].[Admins]
ADD CONSTRAINT [PK_Admins]
    PRIMARY KEY CLUSTERED ([MaAdmin] ASC);
GO

-- Creating primary key on [MaCN] in table 'ChiNhanhs'
ALTER TABLE [dbo].[ChiNhanhs]
ADD CONSTRAINT [PK_ChiNhanhs]
    PRIMARY KEY CLUSTERED ([MaCN] ASC);
GO

-- Creating primary key on [MaSP], [MaDonHang] in table 'ChiTietDonHangs'
ALTER TABLE [dbo].[ChiTietDonHangs]
ADD CONSTRAINT [PK_ChiTietDonHangs]
    PRIMARY KEY CLUSTERED ([MaSP], [MaDonHang] ASC);
GO

-- Creating primary key on [MaDM] in table 'DanhMucs'
ALTER TABLE [dbo].[DanhMucs]
ADD CONSTRAINT [PK_DanhMucs]
    PRIMARY KEY CLUSTERED ([MaDM] ASC);
GO

-- Creating primary key on [MaDH] in table 'DonHangs'
ALTER TABLE [dbo].[DonHangs]
ADD CONSTRAINT [PK_DonHangs]
    PRIMARY KEY CLUSTERED ([MaDH] ASC);
GO

-- Creating primary key on [MaKH] in table 'KhachHangs'
ALTER TABLE [dbo].[KhachHangs]
ADD CONSTRAINT [PK_KhachHangs]
    PRIMARY KEY CLUSTERED ([MaKH] ASC);
GO

-- Creating primary key on [MaNCC] in table 'NhaCungCaps'
ALTER TABLE [dbo].[NhaCungCaps]
ADD CONSTRAINT [PK_NhaCungCaps]
    PRIMARY KEY CLUSTERED ([MaNCC] ASC);
GO

-- Creating primary key on [MaNV] in table 'NhanViens'
ALTER TABLE [dbo].[NhanViens]
ADD CONSTRAINT [PK_NhanViens]
    PRIMARY KEY CLUSTERED ([MaNV] ASC);
GO

-- Creating primary key on [MaSP] in table 'SanPhams'
ALTER TABLE [dbo].[SanPhams]
ADD CONSTRAINT [PK_SanPhams]
    PRIMARY KEY CLUSTERED ([MaSP] ASC);
GO

-- Creating primary key on [diagram_id] in table 'sysdiagrams'
ALTER TABLE [dbo].[sysdiagrams]
ADD CONSTRAINT [PK_sysdiagrams]
    PRIMARY KEY CLUSTERED ([diagram_id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [MaCN] in table 'NhanViens'
ALTER TABLE [dbo].[NhanViens]
ADD CONSTRAINT [FK__NhanVien__MaCN__1FCDBCEB]
    FOREIGN KEY ([MaCN])
    REFERENCES [dbo].[ChiNhanhs]
        ([MaCN])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK__NhanVien__MaCN__1FCDBCEB'
CREATE INDEX [IX_FK__NhanVien__MaCN__1FCDBCEB]
ON [dbo].[NhanViens]
    ([MaCN]);
GO

-- Creating foreign key on [MaDonHang] in table 'ChiTietDonHangs'
ALTER TABLE [dbo].[ChiTietDonHangs]
ADD CONSTRAINT [FK_ChiTietDonHang_DonHang]
    FOREIGN KEY ([MaDonHang])
    REFERENCES [dbo].[DonHangs]
        ([MaDH])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ChiTietDonHang_DonHang'
CREATE INDEX [IX_FK_ChiTietDonHang_DonHang]
ON [dbo].[ChiTietDonHangs]
    ([MaDonHang]);
GO

-- Creating foreign key on [MaSP] in table 'ChiTietDonHangs'
ALTER TABLE [dbo].[ChiTietDonHangs]
ADD CONSTRAINT [FK_ChiTietDonHang_SanPham]
    FOREIGN KEY ([MaSP])
    REFERENCES [dbo].[SanPhams]
        ([MaSP])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [MaDM] in table 'SanPhams'
ALTER TABLE [dbo].[SanPhams]
ADD CONSTRAINT [FK__SanPham__MaDM__22AA2996]
    FOREIGN KEY ([MaDM])
    REFERENCES [dbo].[DanhMucs]
        ([MaDM])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK__SanPham__MaDM__22AA2996'
CREATE INDEX [IX_FK__SanPham__MaDM__22AA2996]
ON [dbo].[SanPhams]
    ([MaDM]);
GO

-- Creating foreign key on [MaKH] in table 'DonHangs'
ALTER TABLE [dbo].[DonHangs]
ADD CONSTRAINT [FK__DonHang__MaKH__20C1E124]
    FOREIGN KEY ([MaKH])
    REFERENCES [dbo].[KhachHangs]
        ([MaKH])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK__DonHang__MaKH__20C1E124'
CREATE INDEX [IX_FK__DonHang__MaKH__20C1E124]
ON [dbo].[DonHangs]
    ([MaKH]);
GO

-- Creating foreign key on [MaNV] in table 'DonHangs'
ALTER TABLE [dbo].[DonHangs]
ADD CONSTRAINT [FK__DonHang__MaNV__1ED998B2]
    FOREIGN KEY ([MaNV])
    REFERENCES [dbo].[NhanViens]
        ([MaNV])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK__DonHang__MaNV__1ED998B2'
CREATE INDEX [IX_FK__DonHang__MaNV__1ED998B2]
ON [dbo].[DonHangs]
    ([MaNV]);
GO

-- Creating foreign key on [MaNCC] in table 'SanPhams'
ALTER TABLE [dbo].[SanPhams]
ADD CONSTRAINT [FK__SanPham__MaNCC__21B6055D]
    FOREIGN KEY ([MaNCC])
    REFERENCES [dbo].[NhaCungCaps]
        ([MaNCC])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK__SanPham__MaNCC__21B6055D'
CREATE INDEX [IX_FK__SanPham__MaNCC__21B6055D]
ON [dbo].[SanPhams]
    ([MaNCC]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------