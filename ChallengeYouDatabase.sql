USE [ChallengeYouDatabase]
GO
/****** Object:  StoredProcedure [dbo].[getUser]    Script Date: 11/8/2021 5:28:12 PM ******/
DROP PROCEDURE [dbo].[getUser]
GO
ALTER TABLE [dbo].[Reaction] DROP CONSTRAINT [FK_USER_REACTION]
GO
ALTER TABLE [dbo].[Reaction] DROP CONSTRAINT [FK_POST_REACTION]
GO
ALTER TABLE [dbo].[Post] DROP CONSTRAINT [FK_USER_POST]
GO
ALTER TABLE [dbo].[Friendship] DROP CONSTRAINT [FK_USER_FRIENDSHIP2]
GO
ALTER TABLE [dbo].[Friendship] DROP CONSTRAINT [FK_USER_FRIENDSHIP1]
GO
ALTER TABLE [dbo].[Comment] DROP CONSTRAINT [FK_USER_COMMENT]
GO
ALTER TABLE [dbo].[Comment] DROP CONSTRAINT [FK_POST_COMMENT]
GO
/****** Object:  Table [dbo].[Reaction]    Script Date: 11/8/2021 5:28:12 PM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Reaction]') AND type in (N'U'))
DROP TABLE [dbo].[Reaction]
GO
/****** Object:  Table [dbo].[Post]    Script Date: 11/8/2021 5:28:12 PM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Post]') AND type in (N'U'))
DROP TABLE [dbo].[Post]
GO
/****** Object:  Table [dbo].[PlatformUser]    Script Date: 11/8/2021 5:28:12 PM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[PlatformUser]') AND type in (N'U'))
DROP TABLE [dbo].[PlatformUser]
GO
/****** Object:  Table [dbo].[Friendship]    Script Date: 11/8/2021 5:28:12 PM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Friendship]') AND type in (N'U'))
DROP TABLE [dbo].[Friendship]
GO
/****** Object:  Table [dbo].[Comment]    Script Date: 11/8/2021 5:28:12 PM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Comment]') AND type in (N'U'))
DROP TABLE [dbo].[Comment]
GO
USE [master]
GO
/****** Object:  Database [ChallengeYouDatabase]    Script Date: 11/8/2021 5:28:12 PM ******/
DROP DATABASE [ChallengeYouDatabase]
GO
/****** Object:  Database [ChallengeYouDatabase]    Script Date: 11/8/2021 5:28:12 PM ******/
CREATE DATABASE [ChallengeYouDatabase]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'ChallengeYouDatabase', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\ChallengeYouDatabase.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'ChallengeYouDatabase_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\ChallengeYouDatabase_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [ChallengeYouDatabase] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [ChallengeYouDatabase].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [ChallengeYouDatabase] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [ChallengeYouDatabase] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [ChallengeYouDatabase] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [ChallengeYouDatabase] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [ChallengeYouDatabase] SET ARITHABORT OFF 
GO
ALTER DATABASE [ChallengeYouDatabase] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [ChallengeYouDatabase] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [ChallengeYouDatabase] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [ChallengeYouDatabase] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [ChallengeYouDatabase] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [ChallengeYouDatabase] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [ChallengeYouDatabase] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [ChallengeYouDatabase] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [ChallengeYouDatabase] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [ChallengeYouDatabase] SET  DISABLE_BROKER 
GO
ALTER DATABASE [ChallengeYouDatabase] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [ChallengeYouDatabase] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [ChallengeYouDatabase] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [ChallengeYouDatabase] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [ChallengeYouDatabase] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [ChallengeYouDatabase] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [ChallengeYouDatabase] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [ChallengeYouDatabase] SET RECOVERY FULL 
GO
ALTER DATABASE [ChallengeYouDatabase] SET  MULTI_USER 
GO
ALTER DATABASE [ChallengeYouDatabase] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [ChallengeYouDatabase] SET DB_CHAINING OFF 
GO
ALTER DATABASE [ChallengeYouDatabase] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [ChallengeYouDatabase] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [ChallengeYouDatabase] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [ChallengeYouDatabase] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'ChallengeYouDatabase', N'ON'
GO
ALTER DATABASE [ChallengeYouDatabase] SET QUERY_STORE = OFF
GO
USE [ChallengeYouDatabase]
GO
/****** Object:  Table [dbo].[Comment]    Script Date: 11/8/2021 5:28:13 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Comment](
	[commentId] [int] NOT NULL,
	[userId] [int] NULL,
	[postId] [int] NULL,
	[creationDate] [date] NULL,
	[commentText] [varchar](500) NULL,
 CONSTRAINT [PK_Comment] PRIMARY KEY CLUSTERED 
(
	[commentId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Friendship]    Script Date: 11/8/2021 5:28:13 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Friendship](
	[friendship] [int] NOT NULL,
	[freind1] [int] NULL,
	[friend2] [int] NULL,
	[creationDate] [date] NULL,
	[status] [varchar](20) NULL,
 CONSTRAINT [PK_Friendship] PRIMARY KEY CLUSTERED 
(
	[friendship] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PlatformUser]    Script Date: 11/8/2021 5:28:13 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PlatformUser](
	[userId] [int] IDENTITY(1,1) NOT NULL,
	[email] [varchar](30) NULL,
	[username] [varchar](20) NULL,
	[pass] [varchar](20) NULL,
	[status] [varchar](20) NULL,
 CONSTRAINT [PK_PlatformUser] PRIMARY KEY CLUSTERED 
(
	[userId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Post]    Script Date: 11/8/2021 5:28:13 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Post](
	[postId] [int] NOT NULL,
	[userId] [int] NULL,
	[creationDate] [date] NULL,
	[title] [varchar](20) NULL,
	[contentPost] [image] NULL,
	[description] [varchar](1000) NULL,
	[reactions] [int] NULL,
	[postType] [varchar](20) NULL,
 CONSTRAINT [PK_Post] PRIMARY KEY CLUSTERED 
(
	[postId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Reaction]    Script Date: 11/8/2021 5:28:13 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Reaction](
	[reactionId] [int] NOT NULL,
	[userId] [int] NULL,
	[postId] [int] NULL,
	[reactionType] [varchar](10) NULL,
 CONSTRAINT [PK_Reaction] PRIMARY KEY CLUSTERED 
(
	[reactionId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[PlatformUser] ON 

INSERT [dbo].[PlatformUser] ([userId], [email], [username], [pass], [status]) VALUES (1, N'edi.herciu@gmail.com', N'Mirel', N'222222', N'nush')
SET IDENTITY_INSERT [dbo].[PlatformUser] OFF
GO
ALTER TABLE [dbo].[Comment]  WITH CHECK ADD  CONSTRAINT [FK_POST_COMMENT] FOREIGN KEY([postId])
REFERENCES [dbo].[Post] ([postId])
GO
ALTER TABLE [dbo].[Comment] CHECK CONSTRAINT [FK_POST_COMMENT]
GO
ALTER TABLE [dbo].[Comment]  WITH CHECK ADD  CONSTRAINT [FK_USER_COMMENT] FOREIGN KEY([userId])
REFERENCES [dbo].[PlatformUser] ([userId])
GO
ALTER TABLE [dbo].[Comment] CHECK CONSTRAINT [FK_USER_COMMENT]
GO
ALTER TABLE [dbo].[Friendship]  WITH CHECK ADD  CONSTRAINT [FK_USER_FRIENDSHIP1] FOREIGN KEY([freind1])
REFERENCES [dbo].[PlatformUser] ([userId])
GO
ALTER TABLE [dbo].[Friendship] CHECK CONSTRAINT [FK_USER_FRIENDSHIP1]
GO
ALTER TABLE [dbo].[Friendship]  WITH CHECK ADD  CONSTRAINT [FK_USER_FRIENDSHIP2] FOREIGN KEY([friend2])
REFERENCES [dbo].[PlatformUser] ([userId])
GO
ALTER TABLE [dbo].[Friendship] CHECK CONSTRAINT [FK_USER_FRIENDSHIP2]
GO
ALTER TABLE [dbo].[Post]  WITH CHECK ADD  CONSTRAINT [FK_USER_POST] FOREIGN KEY([userId])
REFERENCES [dbo].[PlatformUser] ([userId])
GO
ALTER TABLE [dbo].[Post] CHECK CONSTRAINT [FK_USER_POST]
GO
ALTER TABLE [dbo].[Reaction]  WITH CHECK ADD  CONSTRAINT [FK_POST_REACTION] FOREIGN KEY([postId])
REFERENCES [dbo].[Post] ([postId])
GO
ALTER TABLE [dbo].[Reaction] CHECK CONSTRAINT [FK_POST_REACTION]
GO
ALTER TABLE [dbo].[Reaction]  WITH CHECK ADD  CONSTRAINT [FK_USER_REACTION] FOREIGN KEY([reactionId])
REFERENCES [dbo].[PlatformUser] ([userId])
GO
ALTER TABLE [dbo].[Reaction] CHECK CONSTRAINT [FK_USER_REACTION]
GO
/****** Object:  StoredProcedure [dbo].[getUser]    Script Date: 11/8/2021 5:28:13 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[getUser] @username varchar(30),@password varchar(30)
AS
BEGIN
	SELECT email, username
	FROM  dbo.PlatformUser
	WHERE username=@username AND pass=@password
END
GO
USE [master]
GO
ALTER DATABASE [ChallengeYouDatabase] SET  READ_WRITE 
GO
