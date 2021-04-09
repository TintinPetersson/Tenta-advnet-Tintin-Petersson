USE [master]
GO
/****** Object:  Database [advTintinPetersson]    Script Date: 2021-04-09 18:45:27 ******/
CREATE DATABASE [advTintinPetersson]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'advTintinPetersson', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\advTintinPetersson.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'advTintinPetersson_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\advTintinPetersson_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [advTintinPetersson] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [advTintinPetersson].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [advTintinPetersson] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [advTintinPetersson] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [advTintinPetersson] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [advTintinPetersson] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [advTintinPetersson] SET ARITHABORT OFF 
GO
ALTER DATABASE [advTintinPetersson] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [advTintinPetersson] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [advTintinPetersson] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [advTintinPetersson] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [advTintinPetersson] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [advTintinPetersson] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [advTintinPetersson] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [advTintinPetersson] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [advTintinPetersson] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [advTintinPetersson] SET  ENABLE_BROKER 
GO
ALTER DATABASE [advTintinPetersson] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [advTintinPetersson] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [advTintinPetersson] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [advTintinPetersson] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [advTintinPetersson] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [advTintinPetersson] SET READ_COMMITTED_SNAPSHOT ON 
GO
ALTER DATABASE [advTintinPetersson] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [advTintinPetersson] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [advTintinPetersson] SET  MULTI_USER 
GO
ALTER DATABASE [advTintinPetersson] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [advTintinPetersson] SET DB_CHAINING OFF 
GO
ALTER DATABASE [advTintinPetersson] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [advTintinPetersson] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [advTintinPetersson] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [advTintinPetersson] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [advTintinPetersson] SET QUERY_STORE = OFF
GO
USE [advTintinPetersson]
GO
/****** Object:  Table [dbo].[Activities]    Script Date: 2021-04-09 18:45:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Activities](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ActivityType] [int] NOT NULL,
	[StartTime] [datetime2](7) NULL,
	[EndTime] [datetime2](7) NULL,
	[ActivityLogId] [int] NULL,
 CONSTRAINT [PK_Activities] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ActivityLogs]    Script Date: 2021-04-09 18:45:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ActivityLogs](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Date] [nvarchar](max) NULL,
	[HamsterId] [int] NULL,
 CONSTRAINT [PK_ActivityLogs] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Cages]    Script Date: 2021-04-09 18:45:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Cages](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[MaxCapacity] [int] NOT NULL,
	[Gender] [int] NULL,
 CONSTRAINT [PK_Cages] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ExerciseAreas]    Script Date: 2021-04-09 18:45:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ExerciseAreas](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[MaxCapacity] [int] NOT NULL,
	[Gender] [int] NULL,
 CONSTRAINT [PK_ExerciseAreas] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Hamsters]    Script Date: 2021-04-09 18:45:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Hamsters](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NULL,
	[Gender] [int] NOT NULL,
	[Age] [int] NOT NULL,
	[OwnerId] [int] NOT NULL,
	[CurrentActivity] [nvarchar](max) NULL,
	[CageId] [int] NULL,
	[OldCageId] [int] NULL,
	[ExerciseAreaId] [int] NULL,
	[CheckInTime] [datetime2](7) NULL,
	[TimeOfLastExercise] [datetime2](7) NULL,
 CONSTRAINT [PK_Hamsters] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Owners]    Script Date: 2021-04-09 18:45:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Owners](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NULL,
 CONSTRAINT [PK_Owners] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Index [IX_Activities_ActivityLogId]    Script Date: 2021-04-09 18:45:27 ******/
CREATE NONCLUSTERED INDEX [IX_Activities_ActivityLogId] ON [dbo].[Activities]
(
	[ActivityLogId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_ActivityLogs_HamsterId]    Script Date: 2021-04-09 18:45:27 ******/
CREATE NONCLUSTERED INDEX [IX_ActivityLogs_HamsterId] ON [dbo].[ActivityLogs]
(
	[HamsterId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Hamsters_CageId]    Script Date: 2021-04-09 18:45:27 ******/
CREATE NONCLUSTERED INDEX [IX_Hamsters_CageId] ON [dbo].[Hamsters]
(
	[CageId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Hamsters_ExerciseAreaId]    Script Date: 2021-04-09 18:45:27 ******/
CREATE NONCLUSTERED INDEX [IX_Hamsters_ExerciseAreaId] ON [dbo].[Hamsters]
(
	[ExerciseAreaId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Hamsters_OwnerId]    Script Date: 2021-04-09 18:45:27 ******/
CREATE NONCLUSTERED INDEX [IX_Hamsters_OwnerId] ON [dbo].[Hamsters]
(
	[OwnerId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Activities]  WITH CHECK ADD  CONSTRAINT [FK_Activities_ActivityLogs_ActivityLogId] FOREIGN KEY([ActivityLogId])
REFERENCES [dbo].[ActivityLogs] ([Id])
GO
ALTER TABLE [dbo].[Activities] CHECK CONSTRAINT [FK_Activities_ActivityLogs_ActivityLogId]
GO
ALTER TABLE [dbo].[ActivityLogs]  WITH CHECK ADD  CONSTRAINT [FK_ActivityLogs_Hamsters_HamsterId] FOREIGN KEY([HamsterId])
REFERENCES [dbo].[Hamsters] ([Id])
GO
ALTER TABLE [dbo].[ActivityLogs] CHECK CONSTRAINT [FK_ActivityLogs_Hamsters_HamsterId]
GO
ALTER TABLE [dbo].[Hamsters]  WITH CHECK ADD  CONSTRAINT [FK_Hamsters_Cages_CageId] FOREIGN KEY([CageId])
REFERENCES [dbo].[Cages] ([Id])
GO
ALTER TABLE [dbo].[Hamsters] CHECK CONSTRAINT [FK_Hamsters_Cages_CageId]
GO
ALTER TABLE [dbo].[Hamsters]  WITH CHECK ADD  CONSTRAINT [FK_Hamsters_ExerciseAreas_ExerciseAreaId] FOREIGN KEY([ExerciseAreaId])
REFERENCES [dbo].[ExerciseAreas] ([Id])
GO
ALTER TABLE [dbo].[Hamsters] CHECK CONSTRAINT [FK_Hamsters_ExerciseAreas_ExerciseAreaId]
GO
ALTER TABLE [dbo].[Hamsters]  WITH CHECK ADD  CONSTRAINT [FK_Hamsters_Owners_OwnerId] FOREIGN KEY([OwnerId])
REFERENCES [dbo].[Owners] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Hamsters] CHECK CONSTRAINT [FK_Hamsters_Owners_OwnerId]
GO
USE [master]
GO
ALTER DATABASE [advTintinPetersson] SET  READ_WRITE 
GO
