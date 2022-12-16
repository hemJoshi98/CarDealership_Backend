USE [master]
GO
/****** Object:  Database [UsedCarDashboard]    Script Date: 2022-12-15 6:48:55 PM ******/
CREATE DATABASE [UsedCarDashboard]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'UsedCarDashboard', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\UsedCarDashboard.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'UsedCarDashboard_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\UsedCarDashboard_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [UsedCarDashboard] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [UsedCarDashboard].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [UsedCarDashboard] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [UsedCarDashboard] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [UsedCarDashboard] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [UsedCarDashboard] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [UsedCarDashboard] SET ARITHABORT OFF 
GO
ALTER DATABASE [UsedCarDashboard] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [UsedCarDashboard] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [UsedCarDashboard] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [UsedCarDashboard] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [UsedCarDashboard] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [UsedCarDashboard] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [UsedCarDashboard] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [UsedCarDashboard] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [UsedCarDashboard] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [UsedCarDashboard] SET  DISABLE_BROKER 
GO
ALTER DATABASE [UsedCarDashboard] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [UsedCarDashboard] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [UsedCarDashboard] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [UsedCarDashboard] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [UsedCarDashboard] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [UsedCarDashboard] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [UsedCarDashboard] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [UsedCarDashboard] SET RECOVERY FULL 
GO
ALTER DATABASE [UsedCarDashboard] SET  MULTI_USER 
GO
ALTER DATABASE [UsedCarDashboard] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [UsedCarDashboard] SET DB_CHAINING OFF 
GO
ALTER DATABASE [UsedCarDashboard] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [UsedCarDashboard] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [UsedCarDashboard] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [UsedCarDashboard] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'UsedCarDashboard', N'ON'
GO
ALTER DATABASE [UsedCarDashboard] SET QUERY_STORE = OFF
GO
USE [UsedCarDashboard]
GO
/****** Object:  Table [dbo].[Buyer]    Script Date: 2022-12-15 6:48:55 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Buyer](
	[BuyerID] [int] IDENTITY(1,1) NOT NULL,
	[FirstName] [nvarchar](40) NOT NULL,
	[LastName] [nvarchar](40) NULL,
	[Age] [int] NOT NULL,
 CONSTRAINT [PK_Buyer_BuyerID] PRIMARY KEY CLUSTERED 
(
	[BuyerID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Car]    Script Date: 2022-12-15 6:48:55 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Car](
	[CarID] [int] IDENTITY(1,1) NOT NULL,
	[Color] [nvarchar](40) NULL,
	[Make] [nvarchar](40) NOT NULL,
	[Model] [nvarchar](40) NOT NULL,
	[Year] [int] NOT NULL,
	[Mileage] [decimal](3, 1) NOT NULL,
	[Price] [decimal](15, 4) NOT NULL,
	[PreviousOwners] [int] NOT NULL,
 CONSTRAINT [PK_Car_CarID] PRIMARY KEY CLUSTERED 
(
	[CarID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Preferences]    Script Date: 2022-12-15 6:48:55 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Preferences](
	[PrefID] [int] IDENTITY(1,1) NOT NULL,
	[BuyerID] [int] NOT NULL,
	[CarID] [int] NOT NULL,
 CONSTRAINT [PK_Preferences_PrefID] PRIMARY KEY CLUSTERED 
(
	[PrefID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Users]    Script Date: 2022-12-15 6:48:56 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[UserID] [int] IDENTITY(1,1) NOT NULL,
	[LoginName] [nvarchar](40) NOT NULL,
	[PasswordHash] [binary](64) NOT NULL,
	[FirstName] [nvarchar](40) NOT NULL,
	[LastName] [nvarchar](40) NULL,
	[EmpType] [nvarchar](40) NOT NULL,
	[Salt] [uniqueidentifier] NULL,
 CONSTRAINT [PK_User_UserID] PRIMARY KEY CLUSTERED 
(
	[UserID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Preferences]  WITH CHECK ADD  CONSTRAINT [FK_Preferences_BuyerID] FOREIGN KEY([BuyerID])
REFERENCES [dbo].[Buyer] ([BuyerID])
GO
ALTER TABLE [dbo].[Preferences] CHECK CONSTRAINT [FK_Preferences_BuyerID]
GO
ALTER TABLE [dbo].[Preferences]  WITH CHECK ADD  CONSTRAINT [FK_Preferences_CarID] FOREIGN KEY([CarID])
REFERENCES [dbo].[Car] ([CarID])
GO
ALTER TABLE [dbo].[Preferences] CHECK CONSTRAINT [FK_Preferences_CarID]
GO
/****** Object:  StoredProcedure [dbo].[AddUser]    Script Date: 2022-12-15 6:48:56 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[AddUser]
	@pLogin NVARCHAR(50), 
    @pPassword NVARCHAR(50), 
    @pFirstName NVARCHAR(40),
    @pLastName NVARCHAR(40) = NULL,
	@pEmpType NVARCHAR(40),
    @responseMessage NVARCHAR(250) OUTPUT
AS
BEGIN
    SET NOCOUNT ON
	DECLARE @salt UNIQUEIDENTIFIER=NEWID()
    BEGIN TRY

        INSERT INTO [dbo].[Users] (LoginName, PasswordHash, Salt, FirstName, LastName, EmpType)
        VALUES(@pLogin, HASHBYTES('SHA2_512', @pPassword+CAST(@salt AS NVARCHAR(36))), @salt, @pFirstName, @pLastName, @pEmpType)

        SET @responseMessage='New User Created'

    END TRY
    BEGIN CATCH
        SET @responseMessage=ERROR_MESSAGE() 
    END CATCH

END
GO
/****** Object:  StoredProcedure [dbo].[VerifyLogin]    Script Date: 2022-12-15 6:48:56 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[VerifyLogin]
    @pLoginName NVARCHAR(254),
    @pPassword NVARCHAR(50),
    @responseMessage NVARCHAR(250)='' OUTPUT
AS
BEGIN

    SET NOCOUNT ON

    DECLARE @userID INT

    IF EXISTS (SELECT TOP 1 UserID FROM [dbo].[Users] WHERE LoginName=@pLoginName)
    BEGIN
        SET @userID=(SELECT UserID FROM [dbo].[Users] WHERE LoginName=@pLoginName AND PasswordHash=HASHBYTES('SHA2_512', @pPassword+CAST(Salt AS NVARCHAR(36))))

       IF(@userID IS NULL)
           SET @responseMessage='Incorrect password'
       ELSE 
           SET @responseMessage='User successfully logged in'
    END
    ELSE
       SET @responseMessage='Invalid login'

END
GO
USE [master]
GO
ALTER DATABASE [UsedCarDashboard] SET  READ_WRITE 
GO
