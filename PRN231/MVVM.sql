USE [master]
GO
/****** Object:  Database [MVVM]    Script Date: 1/9/2024 9:56:45 PM ******/
CREATE DATABASE [MVVM]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'MVVM', FILENAME = N'D:\Program Setup\SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\MVVM.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'MVVM_log', FILENAME = N'D:\Program Setup\SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\MVVM_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [MVVM] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [MVVM].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [MVVM] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [MVVM] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [MVVM] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [MVVM] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [MVVM] SET ARITHABORT OFF 
GO
ALTER DATABASE [MVVM] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [MVVM] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [MVVM] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [MVVM] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [MVVM] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [MVVM] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [MVVM] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [MVVM] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [MVVM] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [MVVM] SET  DISABLE_BROKER 
GO
ALTER DATABASE [MVVM] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [MVVM] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [MVVM] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [MVVM] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [MVVM] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [MVVM] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [MVVM] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [MVVM] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [MVVM] SET  MULTI_USER 
GO
ALTER DATABASE [MVVM] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [MVVM] SET DB_CHAINING OFF 
GO
ALTER DATABASE [MVVM] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [MVVM] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [MVVM] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [MVVM] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [MVVM] SET QUERY_STORE = OFF
GO
USE [MVVM]
GO
/****** Object:  Table [dbo].[Customer]    Script Date: 1/9/2024 9:56:45 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Customer](
	[CustomerID] [nvarchar](50) NOT NULL,
	[CustomerName] [nvarchar](100) NULL,
	[Address] [nvarchar](200) NULL,
	[Phone] [nchar](20) NULL,
	[DiscountRate] [int] NULL,
 CONSTRAINT [PK_Customer] PRIMARY KEY CLUSTERED 
(
	[CustomerID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[EmployeeDetails]    Script Date: 1/9/2024 9:56:45 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[EmployeeDetails](
	[id] [nvarchar](50) NOT NULL,
	[name] [nvarchar](100) NULL,
	[age] [nvarchar](50) NULL,
	[gender] [nvarchar](20) NULL,
	[address] [nvarchar](150) NULL,
 CONSTRAINT [PK_EmployeeDetails] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Order]    Script Date: 1/9/2024 9:56:45 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Order](
	[OrderId] [nchar](10) NOT NULL,
	[Date] [date] NULL,
	[CustomerID] [nvarchar](50) NULL,
	[TotalPayment] [decimal](18, 0) NULL,
 CONSTRAINT [PK_Order] PRIMARY KEY CLUSTERED 
(
	[OrderId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[OrderDetail]    Script Date: 1/9/2024 9:56:45 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OrderDetail](
	[OrderId] [nchar](10) NOT NULL,
	[ProductId] [nchar](10) NOT NULL,
	[Quantity] [int] NULL,
	[UnitPrice] [decimal](18, 0) NULL,
	[Money] [decimal](18, 0) NULL,
 CONSTRAINT [PK_OrderDetail] PRIMARY KEY CLUSTERED 
(
	[OrderId] ASC,
	[ProductId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Product]    Script Date: 1/9/2024 9:56:45 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Product](
	[Id] [nchar](10) NOT NULL,
	[Name] [nvarchar](200) NULL,
	[QuantityPerUnit] [nvarchar](100) NULL,
	[UnitPrice] [decimal](18, 0) NULL,
	[UnitInStock] [int] NULL,
 CONSTRAINT [PK_Product] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[Customer] ([CustomerID], [CustomerName], [Address], [Phone], [DiscountRate]) VALUES (N'1', N'Hùng', N'Hà Nội', N'0981918919          ', 10)
INSERT [dbo].[Customer] ([CustomerID], [CustomerName], [Address], [Phone], [DiscountRate]) VALUES (N'2', N'Hiếu', N'Thanh Hoá', N'0909008006          ', 20)
INSERT [dbo].[Customer] ([CustomerID], [CustomerName], [Address], [Phone], [DiscountRate]) VALUES (N'3', N'Giang', N'Bắc Giang', N'0988344848          ', 30)
INSERT [dbo].[Customer] ([CustomerID], [CustomerName], [Address], [Phone], [DiscountRate]) VALUES (N'4', N'Duc', N'Thái Bình', N'0932383868          ', 40)
GO
INSERT [dbo].[EmployeeDetails] ([id], [name], [age], [gender], [address]) VALUES (N'1', N'Chung', N'40', N'nam', N'Thai Nguyen')
INSERT [dbo].[EmployeeDetails] ([id], [name], [age], [gender], [address]) VALUES (N'10', N'hai', N'22', N'male', N'tn')
INSERT [dbo].[EmployeeDetails] ([id], [name], [age], [gender], [address]) VALUES (N'11', N'hung', N'12', N'male', N'HN')
INSERT [dbo].[EmployeeDetails] ([id], [name], [age], [gender], [address]) VALUES (N'12', N'Hoanf', N'23', N'male', N'HN')
INSERT [dbo].[EmployeeDetails] ([id], [name], [age], [gender], [address]) VALUES (N'13', N'Khoa', N'22', N'male', N'tn')
INSERT [dbo].[EmployeeDetails] ([id], [name], [age], [gender], [address]) VALUES (N'6', N'Sáu', N'60', N'6', N'6')
INSERT [dbo].[EmployeeDetails] ([id], [name], [age], [gender], [address]) VALUES (N'9', N'Chín', N'21', N'female', N'th')
GO
INSERT [dbo].[Order] ([OrderId], [Date], [CustomerID], [TotalPayment]) VALUES (N'1         ', CAST(N'2023-01-10' AS Date), N'1', CAST(7200 AS Decimal(18, 0)))
INSERT [dbo].[Order] ([OrderId], [Date], [CustomerID], [TotalPayment]) VALUES (N'2         ', CAST(N'2023-02-10' AS Date), N'2', CAST(24000 AS Decimal(18, 0)))
GO
INSERT [dbo].[OrderDetail] ([OrderId], [ProductId], [Quantity], [UnitPrice], [Money]) VALUES (N'1         ', N'1         ', 1, CAST(8 AS Decimal(18, 0)), CAST(7200 AS Decimal(18, 0)))
INSERT [dbo].[OrderDetail] ([OrderId], [ProductId], [Quantity], [UnitPrice], [Money]) VALUES (N'2         ', N'3         ', 1, CAST(12000 AS Decimal(18, 0)), CAST(9600 AS Decimal(18, 0)))
INSERT [dbo].[OrderDetail] ([OrderId], [ProductId], [Quantity], [UnitPrice], [Money]) VALUES (N'2         ', N'9         ', 1, CAST(18000 AS Decimal(18, 0)), CAST(14400 AS Decimal(18, 0)))
GO
INSERT [dbo].[Product] ([Id], [Name], [QuantityPerUnit], [UnitPrice], [UnitInStock]) VALUES (N'1         ', N'Del 7300', N'chiếc', CAST(8000 AS Decimal(18, 0)), 8)
INSERT [dbo].[Product] ([Id], [Name], [QuantityPerUnit], [UnitPrice], [UnitInStock]) VALUES (N'10        ', N'MacBook e', N'chiếc', CAST(34000 AS Decimal(18, 0)), 3)
INSERT [dbo].[Product] ([Id], [Name], [QuantityPerUnit], [UnitPrice], [UnitInStock]) VALUES (N'11        ', N'MacBook p', N'chiếc', CAST(48000 AS Decimal(18, 0)), 2)
INSERT [dbo].[Product] ([Id], [Name], [QuantityPerUnit], [UnitPrice], [UnitInStock]) VALUES (N'12        ', N'MacBook M', N'chiếc', CAST(60000 AS Decimal(18, 0)), 2)
INSERT [dbo].[Product] ([Id], [Name], [QuantityPerUnit], [UnitPrice], [UnitInStock]) VALUES (N'13        ', N'MacBook D', N'chiếc', CAST(78000 AS Decimal(18, 0)), 1)
INSERT [dbo].[Product] ([Id], [Name], [QuantityPerUnit], [UnitPrice], [UnitInStock]) VALUES (N'14        ', N'Samsung S2', N'chiếc', CAST(14000 AS Decimal(18, 0)), 2)
INSERT [dbo].[Product] ([Id], [Name], [QuantityPerUnit], [UnitPrice], [UnitInStock]) VALUES (N'15        ', N'Samsung S8', N'chiếc', CAST(27000 AS Decimal(18, 0)), 2)
INSERT [dbo].[Product] ([Id], [Name], [QuantityPerUnit], [UnitPrice], [UnitInStock]) VALUES (N'2         ', N'Del 7400', N'chiếc', CAST(9000 AS Decimal(18, 0)), 8)
INSERT [dbo].[Product] ([Id], [Name], [QuantityPerUnit], [UnitPrice], [UnitInStock]) VALUES (N'3         ', N'Del 7600', N'chiếc', CAST(12000 AS Decimal(18, 0)), 6)
INSERT [dbo].[Product] ([Id], [Name], [QuantityPerUnit], [UnitPrice], [UnitInStock]) VALUES (N'4         ', N'Del 8800', N'chiếc', CAST(22000 AS Decimal(18, 0)), 3)
INSERT [dbo].[Product] ([Id], [Name], [QuantityPerUnit], [UnitPrice], [UnitInStock]) VALUES (N'5         ', N'HP 1650', N'chiếc', CAST(12000 AS Decimal(18, 0)), 1)
INSERT [dbo].[Product] ([Id], [Name], [QuantityPerUnit], [UnitPrice], [UnitInStock]) VALUES (N'6         ', N'HP 1860', N'chiếc ', CAST(15000 AS Decimal(18, 0)), 2)
INSERT [dbo].[Product] ([Id], [Name], [QuantityPerUnit], [UnitPrice], [UnitInStock]) VALUES (N'7         ', N'HP 2600', N'chiếc', CAST(25000 AS Decimal(18, 0)), 1)
INSERT [dbo].[Product] ([Id], [Name], [QuantityPerUnit], [UnitPrice], [UnitInStock]) VALUES (N'8         ', N'Asus A50', N'chiếc', CAST(7000 AS Decimal(18, 0)), 8)
INSERT [dbo].[Product] ([Id], [Name], [QuantityPerUnit], [UnitPrice], [UnitInStock]) VALUES (N'9         ', N'Asus AP8', N'chiếc', CAST(18000 AS Decimal(18, 0)), 2)
GO
ALTER TABLE [dbo].[Order]  WITH CHECK ADD  CONSTRAINT [FK_Order_Customer] FOREIGN KEY([CustomerID])
REFERENCES [dbo].[Customer] ([CustomerID])
GO
ALTER TABLE [dbo].[Order] CHECK CONSTRAINT [FK_Order_Customer]
GO
ALTER TABLE [dbo].[OrderDetail]  WITH CHECK ADD  CONSTRAINT [FK_OrderDetail_Order] FOREIGN KEY([OrderId])
REFERENCES [dbo].[Order] ([OrderId])
GO
ALTER TABLE [dbo].[OrderDetail] CHECK CONSTRAINT [FK_OrderDetail_Order]
GO
ALTER TABLE [dbo].[OrderDetail]  WITH CHECK ADD  CONSTRAINT [FK_OrderDetail_Product] FOREIGN KEY([ProductId])
REFERENCES [dbo].[Product] ([Id])
GO
ALTER TABLE [dbo].[OrderDetail] CHECK CONSTRAINT [FK_OrderDetail_Product]
GO
USE [master]
GO
ALTER DATABASE [MVVM] SET  READ_WRITE 
GO
