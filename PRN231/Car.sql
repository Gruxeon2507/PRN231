USE [master]
GO
/****** Object:  Database [Car]    Script Date: 11/28/2023 10:04:13 PM ******/
CREATE DATABASE [Car]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Car', FILENAME = N'D:\Program Setup\SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\Car.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'Car_log', FILENAME = N'D:\Program Setup\SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\Car_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [Car] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Car].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Car] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Car] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Car] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Car] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Car] SET ARITHABORT OFF 
GO
ALTER DATABASE [Car] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [Car] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Car] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Car] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Car] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Car] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Car] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Car] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Car] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Car] SET  DISABLE_BROKER 
GO
ALTER DATABASE [Car] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Car] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Car] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Car] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Car] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Car] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [Car] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Car] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [Car] SET  MULTI_USER 
GO
ALTER DATABASE [Car] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Car] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Car] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Car] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [Car] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [Car] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [Car] SET QUERY_STORE = OFF
GO
USE [Car]
GO
/****** Object:  Table [dbo].[Branch]    Script Date: 11/28/2023 10:04:13 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Branch](
	[CarBranchID] [nchar](10) NOT NULL,
	[Branch] [nvarchar](100) NULL,
	[Country] [nvarchar](50) NULL,
 CONSTRAINT [PK_Branch] PRIMARY KEY CLUSTERED 
(
	[CarBranchID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Car]    Script Date: 11/28/2023 10:04:13 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Car](
	[CarID] [nchar](10) NOT NULL,
	[CarTypeID] [nchar](10) NOT NULL,
	[CarBranchID] [nchar](10) NOT NULL,
	[CarName] [nvarchar](50) NOT NULL,
	[ReleaseDate] [date] NOT NULL,
	[CarPrice] [money] NOT NULL,
	[CarOnStock] [int] NULL,
	[CarOnOrdert] [int] NULL,
	[Discontinued] [int] NULL,
 CONSTRAINT [PK_Car] PRIMARY KEY CLUSTERED 
(
	[CarID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CarType]    Script Date: 11/28/2023 10:04:13 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CarType](
	[CarTypeID] [nchar](10) NOT NULL,
	[CarTypeName] [nvarchar](100) NULL,
	[CarTypeDescription] [nvarchar](500) NULL,
 CONSTRAINT [PK_CarType] PRIMARY KEY CLUSTERED 
(
	[CarTypeID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[Branch] ([CarBranchID], [Branch], [Country]) VALUES (N'H         ', N'HonDa', N'Japan')
INSERT [dbo].[Branch] ([CarBranchID], [Branch], [Country]) VALUES (N'M         ', N'Mecedec', N'Germany')
GO
INSERT [dbo].[Car] ([CarID], [CarTypeID], [CarBranchID], [CarName], [ReleaseDate], [CarPrice], [CarOnStock], [CarOnOrdert], [Discontinued]) VALUES (N'H1        ', N'S         ', N'H         ', N'Honda Civic', CAST(N'2023-01-03' AS Date), 820.0000, 6, 1, 0)
INSERT [dbo].[Car] ([CarID], [CarTypeID], [CarBranchID], [CarName], [ReleaseDate], [CarPrice], [CarOnStock], [CarOnOrdert], [Discontinued]) VALUES (N'H2        ', N'Su        ', N'H         ', N'Honda CRV', CAST(N'2023-01-04' AS Date), 1120000.0000, 4, 1, 0)
GO
INSERT [dbo].[CarType] ([CarTypeID], [CarTypeName], [CarTypeDescription]) VALUES (N'H         ', N'HatchBack', N'Traditionally, the term "hatchback" has meant a compact or subcompact sedan with a squared-off roof and a rear flip-up hatch door that provides access to the vehicle''s cargo area instead of a conventional trunk')
INSERT [dbo].[CarType] ([CarTypeID], [CarTypeName], [CarTypeDescription]) VALUES (N'S         ', N'Sedan', N'A sedan has four doors and a traditional trunk. Like vehicles in many categories, they''re available in a range of sizes from small ')
INSERT [dbo].[CarType] ([CarTypeID], [CarTypeName], [CarTypeDescription]) VALUES (N'Su        ', N'SUVs', N'a Strong car')
GO
USE [master]
GO
ALTER DATABASE [Car] SET  READ_WRITE 
GO
