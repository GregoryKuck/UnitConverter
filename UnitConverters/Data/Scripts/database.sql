USE [master]
GO

CREATE DATABASE [UnitConversion]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'UnitConversion', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\UnitConversion.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'UnitConversion_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\UnitConversion_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [UnitConversion] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [UnitConversion].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [UnitConversion] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [UnitConversion] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [UnitConversion] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [UnitConversion] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [UnitConversion] SET ARITHABORT OFF 
GO
ALTER DATABASE [UnitConversion] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [UnitConversion] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [UnitConversion] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [UnitConversion] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [UnitConversion] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [UnitConversion] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [UnitConversion] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [UnitConversion] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [UnitConversion] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [UnitConversion] SET  ENABLE_BROKER 
GO
ALTER DATABASE [UnitConversion] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [UnitConversion] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [UnitConversion] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [UnitConversion] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [UnitConversion] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [UnitConversion] SET READ_COMMITTED_SNAPSHOT ON 
GO
ALTER DATABASE [UnitConversion] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [UnitConversion] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [UnitConversion] SET  MULTI_USER 
GO
ALTER DATABASE [UnitConversion] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [UnitConversion] SET DB_CHAINING OFF 
GO
ALTER DATABASE [UnitConversion] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [UnitConversion] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [UnitConversion] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [UnitConversion] SET QUERY_STORE = OFF
GO
USE [UnitConversion]
GO
/****** Object:  Table [dbo].[UnitConversionFormulae]    Script Date: 2021/12/04 14:45:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UnitConversionFormulae](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ConversionKey] [nvarchar](max) NOT NULL,
	[ConversionFormula] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_UnitConversionFormulae] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
USE [master]
GO
ALTER DATABASE [UnitConversion] SET  READ_WRITE 
GO
