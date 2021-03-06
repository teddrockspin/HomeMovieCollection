USE [master]
GO
/****** Object:  Database [HomeMovieCollection]    Script Date: 1/5/2016 6:28:58 AM ******/
CREATE DATABASE [HomeMovieCollection] ON  PRIMARY 
( NAME = N'HomeMovieCollection', FILENAME = N'c:\Program Files\Microsoft SQL Server\MSSQL10_50.SQLEXPRESS\MSSQL\DATA\HomeMovieCollection.mdf' , SIZE = 2048KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'HomeMovieCollection_log', FILENAME = N'c:\Program Files\Microsoft SQL Server\MSSQL10_50.SQLEXPRESS\MSSQL\DATA\HomeMovieCollection_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [HomeMovieCollection] SET COMPATIBILITY_LEVEL = 100
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [HomeMovieCollection].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [HomeMovieCollection] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [HomeMovieCollection] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [HomeMovieCollection] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [HomeMovieCollection] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [HomeMovieCollection] SET ARITHABORT OFF 
GO
ALTER DATABASE [HomeMovieCollection] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [HomeMovieCollection] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [HomeMovieCollection] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [HomeMovieCollection] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [HomeMovieCollection] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [HomeMovieCollection] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [HomeMovieCollection] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [HomeMovieCollection] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [HomeMovieCollection] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [HomeMovieCollection] SET  DISABLE_BROKER 
GO
ALTER DATABASE [HomeMovieCollection] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [HomeMovieCollection] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [HomeMovieCollection] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [HomeMovieCollection] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [HomeMovieCollection] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [HomeMovieCollection] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [HomeMovieCollection] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [HomeMovieCollection] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [HomeMovieCollection] SET  MULTI_USER 
GO
ALTER DATABASE [HomeMovieCollection] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [HomeMovieCollection] SET DB_CHAINING OFF 
GO
USE [HomeMovieCollection]
GO
/****** Object:  Table [dbo].[Actor]    Script Date: 1/5/2016 6:28:58 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Actor](
	[ActorId] [int] IDENTITY(1,1) NOT NULL,
	[Description] [nvarchar](max) NULL,
	[FirstName] [nvarchar](100) NOT NULL,
	[LastName] [nvarchar](100) NOT NULL,
	[UrlSlug] [nvarchar](500) NOT NULL,
 CONSTRAINT [PK__Actor__57B3EA4B4E88ABD4] PRIMARY KEY CLUSTERED 
(
	[ActorId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Genre]    Script Date: 1/5/2016 6:28:58 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Genre](
	[GenreId] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](100) NOT NULL,
	[Description] [nvarchar](200) NULL,
	[UrlSlug] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK__Genre__0385057E534D60F1] PRIMARY KEY CLUSTERED 
(
	[GenreId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Movie]    Script Date: 1/5/2016 6:28:58 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Movie](
	[MovieId] [int] IDENTITY(1,1) NOT NULL,
	[Title] [nvarchar](200) NOT NULL,
	[Summary] [nvarchar](500) NULL,
	[Description] [nvarchar](max) NULL,
	[Cover] [nvarchar](250) NULL,
	[Format] [nvarchar](100) NULL,
	[Region] [nvarchar](500) NULL,
	[UrlSlug] [nvarchar](500) NOT NULL,
	[ReleaseDate] [datetime] NULL,
	[RunTime] [int] NULL,
	[AddedOn] [datetime] NOT NULL,
	[Modified] [datetime] NULL,
	[GenreId] [int] NOT NULL,
	[Director] [nvarchar](100) NULL,
	[Rating] [int] NULL,
 CONSTRAINT [PK__Movie__4BD2941A571DF1D5] PRIMARY KEY CLUSTERED 
(
	[MovieId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[MovieActorsMap]    Script Date: 1/5/2016 6:28:58 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MovieActorsMap](
	[Actor_id] [int] NOT NULL,
	[Movie_id] [int] NOT NULL
) ON [PRIMARY]

GO
ALTER TABLE [dbo].[MovieActorsMap]  WITH CHECK ADD  CONSTRAINT [FKCEEF8BCE312A80C4] FOREIGN KEY([Movie_id])
REFERENCES [dbo].[Movie] ([MovieId])
GO
ALTER TABLE [dbo].[MovieActorsMap] CHECK CONSTRAINT [FKCEEF8BCE312A80C4]
GO
ALTER TABLE [dbo].[MovieActorsMap]  WITH CHECK ADD  CONSTRAINT [FKCEEF8BCE7D76E22F] FOREIGN KEY([Actor_id])
REFERENCES [dbo].[Actor] ([ActorId])
GO
ALTER TABLE [dbo].[MovieActorsMap] CHECK CONSTRAINT [FKCEEF8BCE7D76E22F]
GO
USE [master]
GO
ALTER DATABASE [HomeMovieCollection] SET  READ_WRITE 
GO
