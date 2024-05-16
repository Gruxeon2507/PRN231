USE [master]
GO
/****** Object:  Database [MyStore]    Script Date: 1/6/2024 5:32:24 PM ******/
CREATE DATABASE [MyStore]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'MyStore', FILENAME = N'D:\Program Setup\SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\MyStore.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'MyStore_log', FILENAME = N'D:\Program Setup\SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\MyStore_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [MyStore] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [MyStore].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [MyStore] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [MyStore] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [MyStore] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [MyStore] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [MyStore] SET ARITHABORT OFF 
GO
ALTER DATABASE [MyStore] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [MyStore] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [MyStore] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [MyStore] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [MyStore] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [MyStore] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [MyStore] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [MyStore] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [MyStore] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [MyStore] SET  DISABLE_BROKER 
GO
ALTER DATABASE [MyStore] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [MyStore] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [MyStore] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [MyStore] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [MyStore] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [MyStore] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [MyStore] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [MyStore] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [MyStore] SET  MULTI_USER 
GO
ALTER DATABASE [MyStore] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [MyStore] SET DB_CHAINING OFF 
GO
ALTER DATABASE [MyStore] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [MyStore] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [MyStore] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [MyStore] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [MyStore] SET QUERY_STORE = OFF
GO
USE [MyStore]
GO
/****** Object:  Table [dbo].[Category]    Script Date: 1/6/2024 5:32:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Category](
	[CategoryId] [nvarchar](10) NOT NULL,
	[CategoryName] [nvarchar](100) NULL,
	[HotTrend] [bit] NULL,
 CONSTRAINT [PK_Category] PRIMARY KEY CLUSTERED 
(
	[CategoryId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Product]    Script Date: 1/6/2024 5:32:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Product](
	[ProductId] [nvarchar](10) NOT NULL,
	[ProductName] [nvarchar](100) NOT NULL,
	[CategoryId] [nvarchar](10) NULL,
	[UnitsInStock] [int] NULL,
	[UnitPrice] [money] NULL,
	[bestseller] [int] NULL,
 CONSTRAINT [PK_Product] PRIMARY KEY CLUSTERED 
(
	[ProductId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[Category] ([CategoryId], [CategoryName], [HotTrend]) VALUES (N'1', N'Beverages', 0)
INSERT [dbo].[Category] ([CategoryId], [CategoryName], [HotTrend]) VALUES (N'2', N'Condiments', 0)
INSERT [dbo].[Category] ([CategoryId], [CategoryName], [HotTrend]) VALUES (N'3', N'Confections', 0)
INSERT [dbo].[Category] ([CategoryId], [CategoryName], [HotTrend]) VALUES (N'4', N'Dairy Products', 1)
INSERT [dbo].[Category] ([CategoryId], [CategoryName], [HotTrend]) VALUES (N'5', N'Grains/Cereals', 1)
INSERT [dbo].[Category] ([CategoryId], [CategoryName], [HotTrend]) VALUES (N'6', N'Meat/Poultry', 0)
INSERT [dbo].[Category] ([CategoryId], [CategoryName], [HotTrend]) VALUES (N'7', N'Childrent', 0)
INSERT [dbo].[Category] ([CategoryId], [CategoryName], [HotTrend]) VALUES (N'8', N'Seafood', 0)
GO
INSERT [dbo].[Product] ([ProductId], [ProductName], [CategoryId], [UnitsInStock], [UnitPrice], [bestseller]) VALUES (N'1', N'Sua lai', N'1', 39, 18.0000, 0)
INSERT [dbo].[Product] ([ProductId], [ProductName], [CategoryId], [UnitsInStock], [UnitPrice], [bestseller]) VALUES (N'10', N'Ikura', N'8', 31, 31.0000, 0)
INSERT [dbo].[Product] ([ProductId], [ProductName], [CategoryId], [UnitsInStock], [UnitPrice], [bestseller]) VALUES (N'1092', N'Sua SignalR', N'1', 0, 0.0000, 0)
INSERT [dbo].[Product] ([ProductId], [ProductName], [CategoryId], [UnitsInStock], [UnitPrice], [bestseller]) VALUES (N'1094', N'ssai', N'1', 0, 0.0000, 0)
INSERT [dbo].[Product] ([ProductId], [ProductName], [CategoryId], [UnitsInStock], [UnitPrice], [bestseller]) VALUES (N'1095', N'Sua lai moi', N'1', 39, 18.0000, 0)
INSERT [dbo].[Product] ([ProductId], [ProductName], [CategoryId], [UnitsInStock], [UnitPrice], [bestseller]) VALUES (N'11', N'Sua moi', N'4', 22, 21.0000, 0)
INSERT [dbo].[Product] ([ProductId], [ProductName], [CategoryId], [UnitsInStock], [UnitPrice], [bestseller]) VALUES (N'12', N'Queso Manchego La Pastora', N'4', 86, 38.0000, 0)
INSERT [dbo].[Product] ([ProductId], [ProductName], [CategoryId], [UnitsInStock], [UnitPrice], [bestseller]) VALUES (N'13', N'Konbu', N'8', 24, 6.0000, 0)
INSERT [dbo].[Product] ([ProductId], [ProductName], [CategoryId], [UnitsInStock], [UnitPrice], [bestseller]) VALUES (N'14', N'Tofu', N'7', 35, 23.2500, 0)
INSERT [dbo].[Product] ([ProductId], [ProductName], [CategoryId], [UnitsInStock], [UnitPrice], [bestseller]) VALUES (N'15', N'Genen Shouyu', N'2', 39, 15.5000, 0)
INSERT [dbo].[Product] ([ProductId], [ProductName], [CategoryId], [UnitsInStock], [UnitPrice], [bestseller]) VALUES (N'16', N'Pavlova', N'3', 29, 17.4500, 0)
INSERT [dbo].[Product] ([ProductId], [ProductName], [CategoryId], [UnitsInStock], [UnitPrice], [bestseller]) VALUES (N'17', N'Alice Mutton', N'6', 0, 39.0000, 1)
INSERT [dbo].[Product] ([ProductId], [ProductName], [CategoryId], [UnitsInStock], [UnitPrice], [bestseller]) VALUES (N'18', N'Carnarvon Tigers', N'8', 42, 62.5000, 0)
INSERT [dbo].[Product] ([ProductId], [ProductName], [CategoryId], [UnitsInStock], [UnitPrice], [bestseller]) VALUES (N'19', N'Teatime Chocolate Biscuits', N'3', 25, 9.2000, 0)
INSERT [dbo].[Product] ([ProductId], [ProductName], [CategoryId], [UnitsInStock], [UnitPrice], [bestseller]) VALUES (N'2', N'quan ao', N'2', 17, 130000.0000, 0)
INSERT [dbo].[Product] ([ProductId], [ProductName], [CategoryId], [UnitsInStock], [UnitPrice], [bestseller]) VALUES (N'20', N'Sir Rodney''s Marmalade', N'3', 40, 81.0000, 0)
INSERT [dbo].[Product] ([ProductId], [ProductName], [CategoryId], [UnitsInStock], [UnitPrice], [bestseller]) VALUES (N'21', N'Sir Rodney''s Scones', N'3', 3, 10.0000, 0)
INSERT [dbo].[Product] ([ProductId], [ProductName], [CategoryId], [UnitsInStock], [UnitPrice], [bestseller]) VALUES (N'22', N'Gustaf''s Knäckebröd', N'5', 104, 21.0000, 0)
INSERT [dbo].[Product] ([ProductId], [ProductName], [CategoryId], [UnitsInStock], [UnitPrice], [bestseller]) VALUES (N'23', N'Tunnbröd', N'5', 61, 9.0000, 0)
INSERT [dbo].[Product] ([ProductId], [ProductName], [CategoryId], [UnitsInStock], [UnitPrice], [bestseller]) VALUES (N'24', N'Guaraná Fantástica', N'1', 20, 4.5000, 1)
INSERT [dbo].[Product] ([ProductId], [ProductName], [CategoryId], [UnitsInStock], [UnitPrice], [bestseller]) VALUES (N'25', N'NuNuCa Nuß-Nougat-Creme', N'3', 76, 14.0000, 0)
INSERT [dbo].[Product] ([ProductId], [ProductName], [CategoryId], [UnitsInStock], [UnitPrice], [bestseller]) VALUES (N'26', N'Gumbär Gummibärchen', N'3', 15, 31.2300, 0)
INSERT [dbo].[Product] ([ProductId], [ProductName], [CategoryId], [UnitsInStock], [UnitPrice], [bestseller]) VALUES (N'27', N'Schoggi Schokolade', N'3', 49, 43.9000, 0)
INSERT [dbo].[Product] ([ProductId], [ProductName], [CategoryId], [UnitsInStock], [UnitPrice], [bestseller]) VALUES (N'28', N'Rössle Sauerkraut', N'7', 26, 45.6000, 1)
INSERT [dbo].[Product] ([ProductId], [ProductName], [CategoryId], [UnitsInStock], [UnitPrice], [bestseller]) VALUES (N'29', N'Thüringer Rostbratwurst', N'6', 0, 123.7900, 1)
INSERT [dbo].[Product] ([ProductId], [ProductName], [CategoryId], [UnitsInStock], [UnitPrice], [bestseller]) VALUES (N'3', N'Aniseed Syrup', N'2', 13, 10.0000, 0)
INSERT [dbo].[Product] ([ProductId], [ProductName], [CategoryId], [UnitsInStock], [UnitPrice], [bestseller]) VALUES (N'30', N'Nord-Ost Matjeshering', N'8', 10, 25.8900, 0)
INSERT [dbo].[Product] ([ProductId], [ProductName], [CategoryId], [UnitsInStock], [UnitPrice], [bestseller]) VALUES (N'31', N'Gorgonzola Telino', N'4', 0, 12.5000, 0)
INSERT [dbo].[Product] ([ProductId], [ProductName], [CategoryId], [UnitsInStock], [UnitPrice], [bestseller]) VALUES (N'32', N'Mascarpone Fabioli', N'4', 9, 32.0000, 0)
INSERT [dbo].[Product] ([ProductId], [ProductName], [CategoryId], [UnitsInStock], [UnitPrice], [bestseller]) VALUES (N'33', N'Geitost', N'4', 112, 2.5000, 0)
INSERT [dbo].[Product] ([ProductId], [ProductName], [CategoryId], [UnitsInStock], [UnitPrice], [bestseller]) VALUES (N'34', N'Sasquatch Ale', N'1', 111, 14.0000, 0)
INSERT [dbo].[Product] ([ProductId], [ProductName], [CategoryId], [UnitsInStock], [UnitPrice], [bestseller]) VALUES (N'35', N'Steeleye Stout', N'1', 20, 18.0000, 0)
INSERT [dbo].[Product] ([ProductId], [ProductName], [CategoryId], [UnitsInStock], [UnitPrice], [bestseller]) VALUES (N'36', N'Inlagd Sill', N'8', 112, 19.0000, 0)
INSERT [dbo].[Product] ([ProductId], [ProductName], [CategoryId], [UnitsInStock], [UnitPrice], [bestseller]) VALUES (N'37', N'Gravad lax', N'8', 11, 26.0000, 0)
INSERT [dbo].[Product] ([ProductId], [ProductName], [CategoryId], [UnitsInStock], [UnitPrice], [bestseller]) VALUES (N'38', N'Côte de Blaye', N'1', 17, 263.5000, 0)
INSERT [dbo].[Product] ([ProductId], [ProductName], [CategoryId], [UnitsInStock], [UnitPrice], [bestseller]) VALUES (N'39', N'Chartreuse verte', N'1', 69, 18.0000, 0)
INSERT [dbo].[Product] ([ProductId], [ProductName], [CategoryId], [UnitsInStock], [UnitPrice], [bestseller]) VALUES (N'4', N'Chef Anton''s Cajun Seasoning', N'2', 53, 22.0000, 0)
INSERT [dbo].[Product] ([ProductId], [ProductName], [CategoryId], [UnitsInStock], [UnitPrice], [bestseller]) VALUES (N'40', N'Boston Crab Meat', N'8', 123, 18.4000, 0)
INSERT [dbo].[Product] ([ProductId], [ProductName], [CategoryId], [UnitsInStock], [UnitPrice], [bestseller]) VALUES (N'41', N'Jack''s New England Clam Chowder', N'8', 85, 9.6500, 0)
INSERT [dbo].[Product] ([ProductId], [ProductName], [CategoryId], [UnitsInStock], [UnitPrice], [bestseller]) VALUES (N'42', N'Singaporean Hokkien Fried Mee', N'5', 26, 14.0000, 1)
INSERT [dbo].[Product] ([ProductId], [ProductName], [CategoryId], [UnitsInStock], [UnitPrice], [bestseller]) VALUES (N'43', N'Ipoh Coffee', N'1', 17, 46.0000, 0)
INSERT [dbo].[Product] ([ProductId], [ProductName], [CategoryId], [UnitsInStock], [UnitPrice], [bestseller]) VALUES (N'44', N'Gula Malacca', N'2', 27, 19.4500, 0)
INSERT [dbo].[Product] ([ProductId], [ProductName], [CategoryId], [UnitsInStock], [UnitPrice], [bestseller]) VALUES (N'45', N'Rogede sild', N'8', 5, 9.5000, 0)
INSERT [dbo].[Product] ([ProductId], [ProductName], [CategoryId], [UnitsInStock], [UnitPrice], [bestseller]) VALUES (N'46', N'Spegesild', N'8', 95, 12.0000, 0)
INSERT [dbo].[Product] ([ProductId], [ProductName], [CategoryId], [UnitsInStock], [UnitPrice], [bestseller]) VALUES (N'47', N'Zaanse koeken', N'3', 36, 9.5000, 0)
INSERT [dbo].[Product] ([ProductId], [ProductName], [CategoryId], [UnitsInStock], [UnitPrice], [bestseller]) VALUES (N'48', N'Chocolade', N'3', 15, 12.7500, 0)
INSERT [dbo].[Product] ([ProductId], [ProductName], [CategoryId], [UnitsInStock], [UnitPrice], [bestseller]) VALUES (N'49', N'Maxilaku', N'3', 10, 20.0000, 0)
INSERT [dbo].[Product] ([ProductId], [ProductName], [CategoryId], [UnitsInStock], [UnitPrice], [bestseller]) VALUES (N'5', N'Chef Anton''s Gumbo Mix', N'2', 0, 21.3500, 1)
INSERT [dbo].[Product] ([ProductId], [ProductName], [CategoryId], [UnitsInStock], [UnitPrice], [bestseller]) VALUES (N'50', N'Valkoinen suklaa', N'3', 65, 16.2500, 0)
INSERT [dbo].[Product] ([ProductId], [ProductName], [CategoryId], [UnitsInStock], [UnitPrice], [bestseller]) VALUES (N'51', N'Manjimup Dried Apples', N'7', 20, 53.0000, 0)
INSERT [dbo].[Product] ([ProductId], [ProductName], [CategoryId], [UnitsInStock], [UnitPrice], [bestseller]) VALUES (N'52', N'Filo Mix', N'5', 38, 7.0000, 0)
INSERT [dbo].[Product] ([ProductId], [ProductName], [CategoryId], [UnitsInStock], [UnitPrice], [bestseller]) VALUES (N'53', N'Perth Pasties', N'6', 0, 32.8000, 1)
INSERT [dbo].[Product] ([ProductId], [ProductName], [CategoryId], [UnitsInStock], [UnitPrice], [bestseller]) VALUES (N'54', N'Tourtière', N'6', 21, 7.4500, 0)
INSERT [dbo].[Product] ([ProductId], [ProductName], [CategoryId], [UnitsInStock], [UnitPrice], [bestseller]) VALUES (N'55', N'Pâté chinois', N'6', 115, 24.0000, 0)
INSERT [dbo].[Product] ([ProductId], [ProductName], [CategoryId], [UnitsInStock], [UnitPrice], [bestseller]) VALUES (N'56', N'Gnocchi di nonna Alice', N'5', 21, 38.0000, 0)
INSERT [dbo].[Product] ([ProductId], [ProductName], [CategoryId], [UnitsInStock], [UnitPrice], [bestseller]) VALUES (N'57', N'Ravioli Angelo', N'5', 36, 19.5000, 0)
INSERT [dbo].[Product] ([ProductId], [ProductName], [CategoryId], [UnitsInStock], [UnitPrice], [bestseller]) VALUES (N'58', N'Escargots de Bourgogne', N'8', 62, 13.2500, 0)
INSERT [dbo].[Product] ([ProductId], [ProductName], [CategoryId], [UnitsInStock], [UnitPrice], [bestseller]) VALUES (N'59', N'Raclette Courdavault', N'4', 79, 55.0000, 0)
INSERT [dbo].[Product] ([ProductId], [ProductName], [CategoryId], [UnitsInStock], [UnitPrice], [bestseller]) VALUES (N'6', N'moi sua', N'4', 2222, 2.0000, 0)
INSERT [dbo].[Product] ([ProductId], [ProductName], [CategoryId], [UnitsInStock], [UnitPrice], [bestseller]) VALUES (N'60', N'Camembert Pierrot', N'4', 19, 34.0000, 0)
INSERT [dbo].[Product] ([ProductId], [ProductName], [CategoryId], [UnitsInStock], [UnitPrice], [bestseller]) VALUES (N'61', N'Sirop d''érable', N'2', 113, 28.5000, 0)
INSERT [dbo].[Product] ([ProductId], [ProductName], [CategoryId], [UnitsInStock], [UnitPrice], [bestseller]) VALUES (N'62', N'Tarte au sucre', N'3', 17, 49.3000, 0)
INSERT [dbo].[Product] ([ProductId], [ProductName], [CategoryId], [UnitsInStock], [UnitPrice], [bestseller]) VALUES (N'63', N'Vegie-spread', N'2', 24, 43.9000, 0)
INSERT [dbo].[Product] ([ProductId], [ProductName], [CategoryId], [UnitsInStock], [UnitPrice], [bestseller]) VALUES (N'64', N'Wimmers gute Semmelknödel', N'5', 22, 33.2500, 0)
INSERT [dbo].[Product] ([ProductId], [ProductName], [CategoryId], [UnitsInStock], [UnitPrice], [bestseller]) VALUES (N'65', N'Louisiana Fiery Hot Pepper Sauce', N'2', 76, 21.0500, 0)
INSERT [dbo].[Product] ([ProductId], [ProductName], [CategoryId], [UnitsInStock], [UnitPrice], [bestseller]) VALUES (N'66', N'Louisiana Hot Spiced Okra', N'2', 4, 17.0000, 0)
INSERT [dbo].[Product] ([ProductId], [ProductName], [CategoryId], [UnitsInStock], [UnitPrice], [bestseller]) VALUES (N'67', N'Laughing Lumberjack Lager', N'1', 52, 14.0000, 0)
INSERT [dbo].[Product] ([ProductId], [ProductName], [CategoryId], [UnitsInStock], [UnitPrice], [bestseller]) VALUES (N'68', N'Scottish Longbreads', N'3', 6, 12.5000, 0)
INSERT [dbo].[Product] ([ProductId], [ProductName], [CategoryId], [UnitsInStock], [UnitPrice], [bestseller]) VALUES (N'69', N'Gudbrandsdalsost', N'4', 26, 36.0000, 0)
INSERT [dbo].[Product] ([ProductId], [ProductName], [CategoryId], [UnitsInStock], [UnitPrice], [bestseller]) VALUES (N'7', N'sua 2', N'4', 3, 3.0000, 0)
INSERT [dbo].[Product] ([ProductId], [ProductName], [CategoryId], [UnitsInStock], [UnitPrice], [bestseller]) VALUES (N'70', N'Outback Lager', N'1', 15, 15.0000, 0)
INSERT [dbo].[Product] ([ProductId], [ProductName], [CategoryId], [UnitsInStock], [UnitPrice], [bestseller]) VALUES (N'71', N'Flotemysost', N'4', 26, 21.5000, 0)
INSERT [dbo].[Product] ([ProductId], [ProductName], [CategoryId], [UnitsInStock], [UnitPrice], [bestseller]) VALUES (N'72', N'Mozzarella di Giovanni', N'4', 14, 34.8000, 0)
INSERT [dbo].[Product] ([ProductId], [ProductName], [CategoryId], [UnitsInStock], [UnitPrice], [bestseller]) VALUES (N'73', N'Röd Kaviar', N'8', 101, 15.0000, 0)
INSERT [dbo].[Product] ([ProductId], [ProductName], [CategoryId], [UnitsInStock], [UnitPrice], [bestseller]) VALUES (N'74', N'Longlife Tofu', N'7', 4, 10.0000, 0)
INSERT [dbo].[Product] ([ProductId], [ProductName], [CategoryId], [UnitsInStock], [UnitPrice], [bestseller]) VALUES (N'75', N'Rhönbräu Klosterbier', N'1', 125, 7.7500, 0)
INSERT [dbo].[Product] ([ProductId], [ProductName], [CategoryId], [UnitsInStock], [UnitPrice], [bestseller]) VALUES (N'76', N'Lakkalikööri', N'1', 57, 18.0000, 0)
INSERT [dbo].[Product] ([ProductId], [ProductName], [CategoryId], [UnitsInStock], [UnitPrice], [bestseller]) VALUES (N'77', N'Original Frankfurter grüne Soße', N'2', 32, 13.0000, 0)
INSERT [dbo].[Product] ([ProductId], [ProductName], [CategoryId], [UnitsInStock], [UnitPrice], [bestseller]) VALUES (N'8', N'Keo Mut', N'6', 5, 4.0000, 0)
INSERT [dbo].[Product] ([ProductId], [ProductName], [CategoryId], [UnitsInStock], [UnitPrice], [bestseller]) VALUES (N'83', N'Keo dong', N'3', 1000, 100.0000, 0)
INSERT [dbo].[Product] ([ProductId], [ProductName], [CategoryId], [UnitsInStock], [UnitPrice], [bestseller]) VALUES (N'87', N'Keo bong', N'6', 2, 2.0000, 1)
INSERT [dbo].[Product] ([ProductId], [ProductName], [CategoryId], [UnitsInStock], [UnitPrice], [bestseller]) VALUES (N'88', N'Keo Mut', N'5', 5, 4.0000, 1)
INSERT [dbo].[Product] ([ProductId], [ProductName], [CategoryId], [UnitsInStock], [UnitPrice], [bestseller]) VALUES (N'89', N'324', N'3', 43, 43.0000, 1)
INSERT [dbo].[Product] ([ProductId], [ProductName], [CategoryId], [UnitsInStock], [UnitPrice], [bestseller]) VALUES (N'9', N'Mishi Kobe Niku', N'6', 29, 97.0000, 1)
INSERT [dbo].[Product] ([ProductId], [ProductName], [CategoryId], [UnitsInStock], [UnitPrice], [bestseller]) VALUES (N'90', N'2423', N'7', 234, 423.0000, 1)
INSERT [dbo].[Product] ([ProductId], [ProductName], [CategoryId], [UnitsInStock], [UnitPrice], [bestseller]) VALUES (N'91', N'moi', N'4', 2, 2.0000, 1)
INSERT [dbo].[Product] ([ProductId], [ProductName], [CategoryId], [UnitsInStock], [UnitPrice], [bestseller]) VALUES (N'92', N'Sua', N'4', 22, 21.0000, 0)
INSERT [dbo].[Product] ([ProductId], [ProductName], [CategoryId], [UnitsInStock], [UnitPrice], [bestseller]) VALUES (N'93', N'sua1', N'7', 15, 30.0000, 0)
INSERT [dbo].[Product] ([ProductId], [ProductName], [CategoryId], [UnitsInStock], [UnitPrice], [bestseller]) VALUES (N'94', N'sua 2', N'4', 3, 3.0000, 1)
INSERT [dbo].[Product] ([ProductId], [ProductName], [CategoryId], [UnitsInStock], [UnitPrice], [bestseller]) VALUES (N'95', N'Sua 3', N'1', 39, 18.0000, 0)
INSERT [dbo].[Product] ([ProductId], [ProductName], [CategoryId], [UnitsInStock], [UnitPrice], [bestseller]) VALUES (N'96', N'Sua 4', N'1', 17, 19.0000, 0)
INSERT [dbo].[Product] ([ProductId], [ProductName], [CategoryId], [UnitsInStock], [UnitPrice], [bestseller]) VALUES (N'97', N'Sua 6', N'2', 13, 10.0000, 0)
GO
ALTER TABLE [dbo].[Product]  WITH CHECK ADD  CONSTRAINT [FK_Product_Category] FOREIGN KEY([CategoryId])
REFERENCES [dbo].[Category] ([CategoryId])
GO
ALTER TABLE [dbo].[Product] CHECK CONSTRAINT [FK_Product_Category]
GO
USE [master]
GO
ALTER DATABASE [MyStore] SET  READ_WRITE 
GO
