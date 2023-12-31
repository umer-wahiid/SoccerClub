USE [master]
GO
/****** Object:  Database [SoccerClub]    Script Date: 9/20/2023 5:33:11 AM ******/
CREATE DATABASE [SoccerClub]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'SoccerClub', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER\MSSQL\DATA\SoccerClub.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'SoccerClub_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER\MSSQL\DATA\SoccerClub_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT, LEDGER = OFF
GO
ALTER DATABASE [SoccerClub] SET COMPATIBILITY_LEVEL = 160
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [SoccerClub].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [SoccerClub] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [SoccerClub] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [SoccerClub] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [SoccerClub] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [SoccerClub] SET ARITHABORT OFF 
GO
ALTER DATABASE [SoccerClub] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [SoccerClub] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [SoccerClub] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [SoccerClub] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [SoccerClub] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [SoccerClub] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [SoccerClub] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [SoccerClub] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [SoccerClub] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [SoccerClub] SET  ENABLE_BROKER 
GO
ALTER DATABASE [SoccerClub] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [SoccerClub] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [SoccerClub] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [SoccerClub] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [SoccerClub] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [SoccerClub] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [SoccerClub] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [SoccerClub] SET RECOVERY FULL 
GO
ALTER DATABASE [SoccerClub] SET  MULTI_USER 
GO
ALTER DATABASE [SoccerClub] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [SoccerClub] SET DB_CHAINING OFF 
GO
ALTER DATABASE [SoccerClub] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [SoccerClub] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [SoccerClub] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [SoccerClub] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'SoccerClub', N'ON'
GO
ALTER DATABASE [SoccerClub] SET QUERY_STORE = ON
GO
ALTER DATABASE [SoccerClub] SET QUERY_STORE (OPERATION_MODE = READ_WRITE, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 30), DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_STORAGE_SIZE_MB = 1000, QUERY_CAPTURE_MODE = AUTO, SIZE_BASED_CLEANUP_MODE = AUTO, MAX_PLANS_PER_QUERY = 200, WAIT_STATS_CAPTURE_MODE = ON)
GO
USE [SoccerClub]
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 9/20/2023 5:33:11 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[__EFMigrationsHistory](
	[MigrationId] [nvarchar](150) NOT NULL,
	[ProductVersion] [nvarchar](32) NOT NULL,
 CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY CLUSTERED 
(
	[MigrationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Carts]    Script Date: 9/20/2023 5:33:11 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Carts](
	[CartId] [int] IDENTITY(1,1) NOT NULL,
	[Price] [int] NOT NULL,
	[Quantity] [int] NOT NULL,
	[Status] [bit] NOT NULL,
	[ProductId] [int] NOT NULL,
	[UserId] [int] NOT NULL,
 CONSTRAINT [PK_Carts] PRIMARY KEY CLUSTERED 
(
	[CartId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Category]    Script Date: 9/20/2023 5:33:11 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Category](
	[CategoryId] [int] IDENTITY(1,1) NOT NULL,
	[CategoryName] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_Category] PRIMARY KEY CLUSTERED 
(
	[CategoryId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[contactUs]    Script Date: 9/20/2023 5:33:11 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[contactUs](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[FirstName] [nvarchar](20) NOT NULL,
	[LastName] [nvarchar](20) NOT NULL,
	[PhoneNumber] [nvarchar](11) NOT NULL,
	[Email] [nvarchar](50) NOT NULL,
	[Comment] [nvarchar](250) NOT NULL,
 CONSTRAINT [PK_contactUs] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Feedbacks]    Script Date: 9/20/2023 5:33:11 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Feedbacks](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [int] NOT NULL,
	[Feedbacks] [nvarchar](100) NOT NULL,
 CONSTRAINT [PK_Feedbacks] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Matches]    Script Date: 9/20/2023 5:33:11 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Matches](
	[MatchId] [int] IDENTITY(1,1) NOT NULL,
	[Date] [datetime2](7) NOT NULL,
	[Time] [datetime2](7) NOT NULL,
	[HomeTeamId] [int] NOT NULL,
	[AwayTeamId] [int] NOT NULL,
	[Venue] [nvarchar](40) NOT NULL,
	[Season] [nvarchar](10) NOT NULL,
	[League] [nvarchar](40) NOT NULL,
 CONSTRAINT [PK_Matches] PRIMARY KEY CLUSTERED 
(
	[MatchId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Orders]    Script Date: 9/20/2023 5:33:11 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Orders](
	[OrderId] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [int] NOT NULL,
	[TotalPrice] [int] NOT NULL,
	[OrderDate] [datetime2](7) NOT NULL,
 CONSTRAINT [PK_Orders] PRIMARY KEY CLUSTERED 
(
	[OrderId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Players]    Script Date: 9/20/2023 5:33:11 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Players](
	[PlayerID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[Nationality] [nvarchar](20) NOT NULL,
	[Position] [nvarchar](20) NOT NULL,
	[PlayerImage] [nvarchar](max) NOT NULL,
	[Age] [int] NOT NULL,
	[TeamId] [int] NOT NULL,
	[DOB] [datetime2](7) NOT NULL,
 CONSTRAINT [PK_Players] PRIMARY KEY CLUSTERED 
(
	[PlayerID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Products]    Script Date: 9/20/2023 5:33:11 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Products](
	[ProductId] [int] IDENTITY(1,1) NOT NULL,
	[ProductName] [nvarchar](50) NOT NULL,
	[Description] [nvarchar](150) NOT NULL,
	[Quantity] [nvarchar](max) NOT NULL,
	[Price] [int] NOT NULL,
	[ImageUrl] [nvarchar](30) NOT NULL,
	[CategoryId] [int] NOT NULL,
 CONSTRAINT [PK_Products] PRIMARY KEY CLUSTERED 
(
	[ProductId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Reminder]    Script Date: 9/20/2023 5:33:11 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Reminder](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [int] NOT NULL,
	[MatchId] [int] NOT NULL,
 CONSTRAINT [PK_Reminder] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Teams]    Script Date: 9/20/2023 5:33:11 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Teams](
	[TeamId] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[Country] [nvarchar](15) NOT NULL,
	[LogoUrl] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_Teams] PRIMARY KEY CLUSTERED 
(
	[TeamId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[User]    Script Date: 9/20/2023 5:33:11 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[User](
	[UserId] [int] IDENTITY(1,1) NOT NULL,
	[Username] [nvarchar](20) NOT NULL,
	[FullName] [nvarchar](50) NOT NULL,
	[Email] [nvarchar](40) NOT NULL,
	[PhoneNo] [nvarchar](11) NOT NULL,
	[Password] [nvarchar](30) NOT NULL,
	[ConfirmPassword] [nvarchar](max) NOT NULL,
	[IsAdmin] [bit] NOT NULL,
	[Address] [nvarchar](500) NOT NULL,
 CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20230813083735_Initial', N'7.0.10')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20230915151948_AddAddress', N'7.0.10')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20230919190431_AddReminder', N'7.0.10')
GO
SET IDENTITY_INSERT [dbo].[Carts] ON 

INSERT [dbo].[Carts] ([CartId], [Price], [Quantity], [Status], [ProductId], [UserId]) VALUES (1, 6400, 32, 0, 1, 1)
INSERT [dbo].[Carts] ([CartId], [Price], [Quantity], [Status], [ProductId], [UserId]) VALUES (2, 4000, 8, 0, 2, 1)
INSERT [dbo].[Carts] ([CartId], [Price], [Quantity], [Status], [ProductId], [UserId]) VALUES (3, 2000, 4, 0, 2, 1)
INSERT [dbo].[Carts] ([CartId], [Price], [Quantity], [Status], [ProductId], [UserId]) VALUES (4, 400, 2, 0, 1, 1)
INSERT [dbo].[Carts] ([CartId], [Price], [Quantity], [Status], [ProductId], [UserId]) VALUES (6, 2000, 4, 1, 2, 2)
INSERT [dbo].[Carts] ([CartId], [Price], [Quantity], [Status], [ProductId], [UserId]) VALUES (7, 500, 1, 0, 2, 3)
INSERT [dbo].[Carts] ([CartId], [Price], [Quantity], [Status], [ProductId], [UserId]) VALUES (8, 600, 1, 0, 3, 3)
INSERT [dbo].[Carts] ([CartId], [Price], [Quantity], [Status], [ProductId], [UserId]) VALUES (9, 1200, 2, 1, 3, 3)
INSERT [dbo].[Carts] ([CartId], [Price], [Quantity], [Status], [ProductId], [UserId]) VALUES (10, 1600, 2, 1, 6, 3)
SET IDENTITY_INSERT [dbo].[Carts] OFF
GO
SET IDENTITY_INSERT [dbo].[Category] ON 

INSERT [dbo].[Category] ([CategoryId], [CategoryName]) VALUES (1, N'Hand Accessories')
INSERT [dbo].[Category] ([CategoryId], [CategoryName]) VALUES (2, N'Game Accessories')
INSERT [dbo].[Category] ([CategoryId], [CategoryName]) VALUES (3, N'Footwear')
INSERT [dbo].[Category] ([CategoryId], [CategoryName]) VALUES (4, N'T-Shirt')
INSERT [dbo].[Category] ([CategoryId], [CategoryName]) VALUES (5, N'T-shirts')
SET IDENTITY_INSERT [dbo].[Category] OFF
GO
SET IDENTITY_INSERT [dbo].[contactUs] ON 

INSERT [dbo].[contactUs] ([Id], [FirstName], [LastName], [PhoneNumber], [Email], [Comment]) VALUES (1, N'hashir', N'khan', N'023156435', N'hashir@gmail.com', N'some message')
INSERT [dbo].[contactUs] ([Id], [FirstName], [LastName], [PhoneNumber], [Email], [Comment]) VALUES (2, N'Indian', N'Tigers', N'03188687787', N'umer@gmail.com', N'Lorem Ipsum Lorem Ipsum Lorem Ipsum')
SET IDENTITY_INSERT [dbo].[contactUs] OFF
GO
SET IDENTITY_INSERT [dbo].[Feedbacks] ON 

INSERT [dbo].[Feedbacks] ([Id], [UserId], [Feedbacks]) VALUES (1, 1, N'Lorem Ipsum ')
INSERT [dbo].[Feedbacks] ([Id], [UserId], [Feedbacks]) VALUES (2, 1, N'Lorem Ipsum hasr btghn')
INSERT [dbo].[Feedbacks] ([Id], [UserId], [Feedbacks]) VALUES (3, 1, N'Lorem Ipsum hasr btghn')
INSERT [dbo].[Feedbacks] ([Id], [UserId], [Feedbacks]) VALUES (4, 3, N'What a UI')
SET IDENTITY_INSERT [dbo].[Feedbacks] OFF
GO
SET IDENTITY_INSERT [dbo].[Matches] ON 

INSERT [dbo].[Matches] ([MatchId], [Date], [Time], [HomeTeamId], [AwayTeamId], [Venue], [Season], [League]) VALUES (1, CAST(N'2023-08-23T14:15:00.0000000' AS DateTime2), CAST(N'2023-08-23T14:15:00.0000000' AS DateTime2), 1, 2, N'Turkey', N'2023', N'National Olympics')
INSERT [dbo].[Matches] ([MatchId], [Date], [Time], [HomeTeamId], [AwayTeamId], [Venue], [Season], [League]) VALUES (2, CAST(N'2023-09-25T14:16:00.0000000' AS DateTime2), CAST(N'2023-09-25T14:16:00.0000000' AS DateTime2), 3, 4, N'Argentina', N'2024', N'National Olympics')
INSERT [dbo].[Matches] ([MatchId], [Date], [Time], [HomeTeamId], [AwayTeamId], [Venue], [Season], [League]) VALUES (3, CAST(N'2023-09-28T14:17:00.0000000' AS DateTime2), CAST(N'2023-09-28T14:17:00.0000000' AS DateTime2), 4, 2, N'Barcelona', N'2023', N'National Olympics')
INSERT [dbo].[Matches] ([MatchId], [Date], [Time], [HomeTeamId], [AwayTeamId], [Venue], [Season], [League]) VALUES (4, CAST(N'2023-09-29T14:18:00.0000000' AS DateTime2), CAST(N'2023-09-29T14:18:00.0000000' AS DateTime2), 6, 4, N'Brazil', N'2023', N'National Olympics')
INSERT [dbo].[Matches] ([MatchId], [Date], [Time], [HomeTeamId], [AwayTeamId], [Venue], [Season], [League]) VALUES (5, CAST(N'2023-08-10T16:19:00.0000000' AS DateTime2), CAST(N'2023-08-10T16:19:00.0000000' AS DateTime2), 7, 3, N'Argentina', N'2023', N'World Cup')
INSERT [dbo].[Matches] ([MatchId], [Date], [Time], [HomeTeamId], [AwayTeamId], [Venue], [Season], [League]) VALUES (6, CAST(N'2023-09-27T17:41:00.0000000' AS DateTime2), CAST(N'2023-09-27T17:41:00.0000000' AS DateTime2), 1, 3, N'Turkey', N'2023', N'Laliga')
SET IDENTITY_INSERT [dbo].[Matches] OFF
GO
SET IDENTITY_INSERT [dbo].[Orders] ON 

INSERT [dbo].[Orders] ([OrderId], [UserId], [TotalPrice], [OrderDate]) VALUES (1, 1, 10400, CAST(N'2023-08-13T15:53:47.1209522' AS DateTime2))
INSERT [dbo].[Orders] ([OrderId], [UserId], [TotalPrice], [OrderDate]) VALUES (2, 1, 0, CAST(N'2023-08-13T15:53:56.0192227' AS DateTime2))
INSERT [dbo].[Orders] ([OrderId], [UserId], [TotalPrice], [OrderDate]) VALUES (3, 1, 2400, CAST(N'2023-09-19T19:25:15.4693042' AS DateTime2))
INSERT [dbo].[Orders] ([OrderId], [UserId], [TotalPrice], [OrderDate]) VALUES (4, 3, 1100, CAST(N'2023-09-19T20:30:07.7842363' AS DateTime2))
SET IDENTITY_INSERT [dbo].[Orders] OFF
GO
SET IDENTITY_INSERT [dbo].[Players] ON 

INSERT [dbo].[Players] ([PlayerID], [Name], [Nationality], [Position], [PlayerImage], [Age], [TeamId], [DOB]) VALUES (1, N'Leonal Messi', N'Argentina', N'Attacker', N'/Images/player4.png', 22, 3, CAST(N'2023-08-23T14:09:00.0000000' AS DateTime2))
INSERT [dbo].[Players] ([PlayerID], [Name], [Nationality], [Position], [PlayerImage], [Age], [TeamId], [DOB]) VALUES (2, N'Andres Aniesta', N'Spain', N'Attacker', N'/Images/player3.png', 34, 4, CAST(N'2023-08-01T14:10:00.0000000' AS DateTime2))
INSERT [dbo].[Players] ([PlayerID], [Name], [Nationality], [Position], [PlayerImage], [Age], [TeamId], [DOB]) VALUES (3, N'Radamel Falcao', N'Spain', N'FORWARD', N'/Images/player1.png', 22, 4, CAST(N'2023-08-22T14:12:00.0000000' AS DateTime2))
INSERT [dbo].[Players] ([PlayerID], [Name], [Nationality], [Position], [PlayerImage], [Age], [TeamId], [DOB]) VALUES (4, N'Andrea Pirlo', N'Italy', N'DEFENDER', N'/Images/player2.png', 21, 4, CAST(N'2023-08-16T14:14:00.0000000' AS DateTime2))
INSERT [dbo].[Players] ([PlayerID], [Name], [Nationality], [Position], [PlayerImage], [Age], [TeamId], [DOB]) VALUES (5, N'Edinson Kavani', N'Spain', N'DEFENDER', N'/Images/player6.png', 34, 2, CAST(N'2023-06-28T14:15:00.0000000' AS DateTime2))
INSERT [dbo].[Players] ([PlayerID], [Name], [Nationality], [Position], [PlayerImage], [Age], [TeamId], [DOB]) VALUES (6, N'Umer', N'Spain', N'Keeper', N'/Images/player2.png', 21, 7, CAST(N'2022-01-07T19:05:00.0000000' AS DateTime2))
INSERT [dbo].[Players] ([PlayerID], [Name], [Nationality], [Position], [PlayerImage], [Age], [TeamId], [DOB]) VALUES (7, N'Umer', N'Pakistan', N'Attacker', N'/Images/player2.png', 22, 3, CAST(N'2023-08-16T16:18:00.0000000' AS DateTime2))
SET IDENTITY_INSERT [dbo].[Players] OFF
GO
SET IDENTITY_INSERT [dbo].[Products] ON 

INSERT [dbo].[Products] ([ProductId], [ProductName], [Description], [Quantity], [Price], [ImageUrl], [CategoryId]) VALUES (1, N'Gloves', N'Awesome Gloves', N'200', 200, N'\Images\product11.png', 1)
INSERT [dbo].[Products] ([ProductId], [ProductName], [Description], [Quantity], [Price], [ImageUrl], [CategoryId]) VALUES (2, N'Ball', N'Awesome Ball', N'200', 500, N'\Images\product4.png', 2)
INSERT [dbo].[Products] ([ProductId], [ProductName], [Description], [Quantity], [Price], [ImageUrl], [CategoryId]) VALUES (3, N'Grass', N'Awesome Grass', N'200', 600, N'\Images\product5.png', 2)
INSERT [dbo].[Products] ([ProductId], [ProductName], [Description], [Quantity], [Price], [ImageUrl], [CategoryId]) VALUES (4, N'Shoes', N'Awesome Shoes', N'6000', 800, N'\Images\product2.png', 3)
INSERT [dbo].[Products] ([ProductId], [ProductName], [Description], [Quantity], [Price], [ImageUrl], [CategoryId]) VALUES (5, N'Shoes', N'Awesome Shoes', N'200', 800, N'\Images\product2.png', 2)
INSERT [dbo].[Products] ([ProductId], [ProductName], [Description], [Quantity], [Price], [ImageUrl], [CategoryId]) VALUES (6, N'Shirt', N'Awesome Shoes', N'200', 800, N'\Images\product1.png', 4)
SET IDENTITY_INSERT [dbo].[Products] OFF
GO
SET IDENTITY_INSERT [dbo].[Reminder] ON 

INSERT [dbo].[Reminder] ([Id], [UserId], [MatchId]) VALUES (1, 3, 1)
INSERT [dbo].[Reminder] ([Id], [UserId], [MatchId]) VALUES (2, 3, 3)
INSERT [dbo].[Reminder] ([Id], [UserId], [MatchId]) VALUES (3, 3, 3)
SET IDENTITY_INSERT [dbo].[Reminder] OFF
GO
SET IDENTITY_INSERT [dbo].[Teams] ON 

INSERT [dbo].[Teams] ([TeamId], [Name], [Country], [LogoUrl]) VALUES (1, N'Istanbul', N'Turkey', N'/Images/brash-thugs.png')
INSERT [dbo].[Teams] ([TeamId], [Name], [Country], [LogoUrl]) VALUES (2, N'Italy', N'Italy', N'/Images/clubber-langs.png')
INSERT [dbo].[Teams] ([TeamId], [Name], [Country], [LogoUrl]) VALUES (3, N'France', N'France', N'/Images/cougars.png')
INSERT [dbo].[Teams] ([TeamId], [Name], [Country], [LogoUrl]) VALUES (4, N'Germany', N'Germany', N'/Images/fumble-this.png')
INSERT [dbo].[Teams] ([TeamId], [Name], [Country], [LogoUrl]) VALUES (5, N'Chicago', N'America', N'/Images/Junior-Mints.png')
INSERT [dbo].[Teams] ([TeamId], [Name], [Country], [LogoUrl]) VALUES (6, N'Brazil', N'Brazil', N'/Images/king-pins.png')
INSERT [dbo].[Teams] ([TeamId], [Name], [Country], [LogoUrl]) VALUES (7, N'Team A', N'Pakistan', N'/Images/clubber-langs.png')
INSERT [dbo].[Teams] ([TeamId], [Name], [Country], [LogoUrl]) VALUES (8, N'Tigers', N'Pakistan', N'/Images/clubber-langs.png')
SET IDENTITY_INSERT [dbo].[Teams] OFF
GO
SET IDENTITY_INSERT [dbo].[User] ON 

INSERT [dbo].[User] ([UserId], [Username], [FullName], [Email], [PhoneNo], [Password], [ConfirmPassword], [IsAdmin], [Address]) VALUES (1, N'umerwahiid', N'Umer', N'umer@gmail.com', N'umerwahiid', N'12345', N'12345', 0, N'')
INSERT [dbo].[User] ([UserId], [Username], [FullName], [Email], [PhoneNo], [Password], [ConfirmPassword], [IsAdmin], [Address]) VALUES (2, N'sfcAwesome', N'admin', N'admin@gmail.com', N'12345678901', N'12345', N'12345', 1, N'')
INSERT [dbo].[User] ([UserId], [Username], [FullName], [Email], [PhoneNo], [Password], [ConfirmPassword], [IsAdmin], [Address]) VALUES (3, N'rehman897', N'Abdul Rehman', N'rehman@gmail.com', N'03876543213', N'12345', N'12345', 0, N'Your Address')
SET IDENTITY_INSERT [dbo].[User] OFF
GO
/****** Object:  Index [IX_Carts_ProductId]    Script Date: 9/20/2023 5:33:12 AM ******/
CREATE NONCLUSTERED INDEX [IX_Carts_ProductId] ON [dbo].[Carts]
(
	[ProductId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Carts_UserId]    Script Date: 9/20/2023 5:33:12 AM ******/
CREATE NONCLUSTERED INDEX [IX_Carts_UserId] ON [dbo].[Carts]
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Feedbacks_UserId]    Script Date: 9/20/2023 5:33:12 AM ******/
CREATE NONCLUSTERED INDEX [IX_Feedbacks_UserId] ON [dbo].[Feedbacks]
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Matches_AwayTeamId]    Script Date: 9/20/2023 5:33:12 AM ******/
CREATE NONCLUSTERED INDEX [IX_Matches_AwayTeamId] ON [dbo].[Matches]
(
	[AwayTeamId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Matches_HomeTeamId]    Script Date: 9/20/2023 5:33:12 AM ******/
CREATE NONCLUSTERED INDEX [IX_Matches_HomeTeamId] ON [dbo].[Matches]
(
	[HomeTeamId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Orders_UserId]    Script Date: 9/20/2023 5:33:12 AM ******/
CREATE NONCLUSTERED INDEX [IX_Orders_UserId] ON [dbo].[Orders]
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Players_TeamId]    Script Date: 9/20/2023 5:33:12 AM ******/
CREATE NONCLUSTERED INDEX [IX_Players_TeamId] ON [dbo].[Players]
(
	[TeamId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Products_CategoryId]    Script Date: 9/20/2023 5:33:12 AM ******/
CREATE NONCLUSTERED INDEX [IX_Products_CategoryId] ON [dbo].[Products]
(
	[CategoryId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Reminder_MatchId]    Script Date: 9/20/2023 5:33:12 AM ******/
CREATE NONCLUSTERED INDEX [IX_Reminder_MatchId] ON [dbo].[Reminder]
(
	[MatchId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Reminder_UserId]    Script Date: 9/20/2023 5:33:12 AM ******/
CREATE NONCLUSTERED INDEX [IX_Reminder_UserId] ON [dbo].[Reminder]
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
ALTER TABLE [dbo].[User] ADD  DEFAULT (N'') FOR [Address]
GO
ALTER TABLE [dbo].[Carts]  WITH CHECK ADD  CONSTRAINT [FK_Carts_Products_ProductId] FOREIGN KEY([ProductId])
REFERENCES [dbo].[Products] ([ProductId])
GO
ALTER TABLE [dbo].[Carts] CHECK CONSTRAINT [FK_Carts_Products_ProductId]
GO
ALTER TABLE [dbo].[Carts]  WITH CHECK ADD  CONSTRAINT [FK_Carts_User_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[User] ([UserId])
GO
ALTER TABLE [dbo].[Carts] CHECK CONSTRAINT [FK_Carts_User_UserId]
GO
ALTER TABLE [dbo].[Feedbacks]  WITH CHECK ADD  CONSTRAINT [FK_Feedbacks_User_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[User] ([UserId])
GO
ALTER TABLE [dbo].[Feedbacks] CHECK CONSTRAINT [FK_Feedbacks_User_UserId]
GO
ALTER TABLE [dbo].[Matches]  WITH CHECK ADD  CONSTRAINT [FK_Matches_Teams_AwayTeamId] FOREIGN KEY([AwayTeamId])
REFERENCES [dbo].[Teams] ([TeamId])
GO
ALTER TABLE [dbo].[Matches] CHECK CONSTRAINT [FK_Matches_Teams_AwayTeamId]
GO
ALTER TABLE [dbo].[Matches]  WITH CHECK ADD  CONSTRAINT [FK_Matches_Teams_HomeTeamId] FOREIGN KEY([HomeTeamId])
REFERENCES [dbo].[Teams] ([TeamId])
GO
ALTER TABLE [dbo].[Matches] CHECK CONSTRAINT [FK_Matches_Teams_HomeTeamId]
GO
ALTER TABLE [dbo].[Orders]  WITH CHECK ADD  CONSTRAINT [FK_Orders_User_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[User] ([UserId])
GO
ALTER TABLE [dbo].[Orders] CHECK CONSTRAINT [FK_Orders_User_UserId]
GO
ALTER TABLE [dbo].[Players]  WITH CHECK ADD  CONSTRAINT [FK_Players_Teams_TeamId] FOREIGN KEY([TeamId])
REFERENCES [dbo].[Teams] ([TeamId])
GO
ALTER TABLE [dbo].[Players] CHECK CONSTRAINT [FK_Players_Teams_TeamId]
GO
ALTER TABLE [dbo].[Products]  WITH CHECK ADD  CONSTRAINT [FK_Products_Category_CategoryId] FOREIGN KEY([CategoryId])
REFERENCES [dbo].[Category] ([CategoryId])
GO
ALTER TABLE [dbo].[Products] CHECK CONSTRAINT [FK_Products_Category_CategoryId]
GO
ALTER TABLE [dbo].[Reminder]  WITH CHECK ADD  CONSTRAINT [FK_Reminder_Matches_MatchId] FOREIGN KEY([MatchId])
REFERENCES [dbo].[Matches] ([MatchId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Reminder] CHECK CONSTRAINT [FK_Reminder_Matches_MatchId]
GO
ALTER TABLE [dbo].[Reminder]  WITH CHECK ADD  CONSTRAINT [FK_Reminder_User_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[User] ([UserId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Reminder] CHECK CONSTRAINT [FK_Reminder_User_UserId]
GO
USE [master]
GO
ALTER DATABASE [SoccerClub] SET  READ_WRITE 
GO
