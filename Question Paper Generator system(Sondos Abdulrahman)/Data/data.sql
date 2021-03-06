USE [master]
GO
/****** Object:  Database [Question]    Script Date: 11/14/2016 12:05:37 ******/
CREATE DATABASE [Question] ON  PRIMARY 
( NAME = N'Question', FILENAME = N'c:\Program Files\Microsoft SQL Server\MSSQL10.SQLEXPRESS\MSSQL\DATA\Question.mdf' , SIZE = 2304KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'Question_log', FILENAME = N'c:\Program Files\Microsoft SQL Server\MSSQL10.SQLEXPRESS\MSSQL\DATA\Question_log.LDF' , SIZE = 504KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [Question] SET COMPATIBILITY_LEVEL = 100
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Question].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Question] SET ANSI_NULL_DEFAULT OFF
GO
ALTER DATABASE [Question] SET ANSI_NULLS OFF
GO
ALTER DATABASE [Question] SET ANSI_PADDING OFF
GO
ALTER DATABASE [Question] SET ANSI_WARNINGS OFF
GO
ALTER DATABASE [Question] SET ARITHABORT OFF
GO
ALTER DATABASE [Question] SET AUTO_CLOSE ON
GO
ALTER DATABASE [Question] SET AUTO_CREATE_STATISTICS ON
GO
ALTER DATABASE [Question] SET AUTO_SHRINK OFF
GO
ALTER DATABASE [Question] SET AUTO_UPDATE_STATISTICS ON
GO
ALTER DATABASE [Question] SET CURSOR_CLOSE_ON_COMMIT OFF
GO
ALTER DATABASE [Question] SET CURSOR_DEFAULT  GLOBAL
GO
ALTER DATABASE [Question] SET CONCAT_NULL_YIELDS_NULL OFF
GO
ALTER DATABASE [Question] SET NUMERIC_ROUNDABORT OFF
GO
ALTER DATABASE [Question] SET QUOTED_IDENTIFIER OFF
GO
ALTER DATABASE [Question] SET RECURSIVE_TRIGGERS OFF
GO
ALTER DATABASE [Question] SET  ENABLE_BROKER
GO
ALTER DATABASE [Question] SET AUTO_UPDATE_STATISTICS_ASYNC OFF
GO
ALTER DATABASE [Question] SET DATE_CORRELATION_OPTIMIZATION OFF
GO
ALTER DATABASE [Question] SET TRUSTWORTHY OFF
GO
ALTER DATABASE [Question] SET ALLOW_SNAPSHOT_ISOLATION OFF
GO
ALTER DATABASE [Question] SET PARAMETERIZATION SIMPLE
GO
ALTER DATABASE [Question] SET READ_COMMITTED_SNAPSHOT OFF
GO
ALTER DATABASE [Question] SET HONOR_BROKER_PRIORITY OFF
GO
ALTER DATABASE [Question] SET  READ_WRITE
GO
ALTER DATABASE [Question] SET RECOVERY SIMPLE
GO
ALTER DATABASE [Question] SET  MULTI_USER
GO
ALTER DATABASE [Question] SET PAGE_VERIFY CHECKSUM
GO
ALTER DATABASE [Question] SET DB_CHAINING OFF
GO
USE [Question]
GO
/****** Object:  Table [dbo].[Teach]    Script Date: 11/14/2016 12:05:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Teach](
	[TId] [varchar](50) NULL,
	[TName] [varchar](50) NULL,
	[TPass] [varchar](50) NULL,
	[TMobile] [varchar](50) NULL,
	[TEmail] [varchar](50) NULL
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
INSERT [dbo].[Teach] ([TId], [TName], [TPass], [TMobile], [TEmail]) VALUES (N'1', N'Kajal', N'admin', N'9076613215', N'teach@gmail.com')
INSERT [dbo].[Teach] ([TId], [TName], [TPass], [TMobile], [TEmail]) VALUES (N'2', N'sam', N'123', N'7123456789', N'samymary1@gmail.com')
/****** Object:  Table [dbo].[Ques]    Script Date: 11/14/2016 12:05:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Ques](
	[QId] [varchar](50) NULL,
	[Ques] [varchar](1000) NULL,
	[Difficulty] [varchar](50) NULL,
	[Mod] [varchar](50) NULL,
	[Subject] [varchar](50) NULL,
	[Sem] [varchar](50) NULL,
	[Branch] [varchar](50) NULL
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
INSERT [dbo].[Ques] ([QId], [Ques], [Difficulty], [Mod], [Subject], [Sem], [Branch]) VALUES (N'1001', N'What are Principles of Security? 1', N'Easy', N'1', N'NS', N'5', N'BScIT')
INSERT [dbo].[Ques] ([QId], [Ques], [Difficulty], [Mod], [Subject], [Sem], [Branch]) VALUES (N'1002', N'List Types of Attacks ? 1', N'Easy', N'1', N'NS', N'5', N'BScIT')
INSERT [dbo].[Ques] ([QId], [Ques], [Difficulty], [Mod], [Subject], [Sem], [Branch]) VALUES (N'1003', N'Explain Steganography? 1', N'Easy', N'1', N'NS', N'5', N'BScIT')
INSERT [dbo].[Ques] ([QId], [Ques], [Difficulty], [Mod], [Subject], [Sem], [Branch]) VALUES (N'1004', N'Explain Data Encryption Standard (DES) 2', N'Easy', N'2', N'NS', N'5', N'BScIT')
INSERT [dbo].[Ques] ([QId], [Ques], [Difficulty], [Mod], [Subject], [Sem], [Branch]) VALUES (N'1005', N'Explain International 2', N'Easy', N'2', N'NS', N'5', N'BScIT')
INSERT [dbo].[Ques] ([QId], [Ques], [Difficulty], [Mod], [Subject], [Sem], [Branch]) VALUES (N'1006', NULL, N'Easy', N'1', N'JAVA', N'4', N'EXTC')
INSERT [dbo].[Ques] ([QId], [Ques], [Difficulty], [Mod], [Subject], [Sem], [Branch]) VALUES (N'1007', N'Explain Advanced Encryption 2', N'Easy', N'2', N'NS', N'5', N'BScIT')
INSERT [dbo].[Ques] ([QId], [Ques], [Difficulty], [Mod], [Subject], [Sem], [Branch]) VALUES (N'1008', N'Explain RSA algorithm 3', N'Easy', N'3', N'NS', N'5', N'BScIT')
INSERT [dbo].[Ques] ([QId], [Ques], [Difficulty], [Mod], [Subject], [Sem], [Branch]) VALUES (N'1009', N'Knapsack Algorithm 3', N'Easy', N'3', N'NS', N'5', N'BScIT')
INSERT [dbo].[Ques] ([QId], [Ques], [Difficulty], [Mod], [Subject], [Sem], [Branch]) VALUES (N'1010', N'Explain ElGamal Algorithm 3 ', N'Easy', N'3', N'NS', N'5', N'BScIT')
INSERT [dbo].[Ques] ([QId], [Ques], [Difficulty], [Mod], [Subject], [Sem], [Branch]) VALUES (N'1011', N'Explain Digital Certificates? 4', N'Easy', N'4', N'NS', N'5', N'BScIT')
INSERT [dbo].[Ques] ([QId], [Ques], [Difficulty], [Mod], [Subject], [Sem], [Branch]) VALUES (N'1012', N'Explain Hash function 4', N'Easy', N'4', N'NS', N'5', N'BScIT')
INSERT [dbo].[Ques] ([QId], [Ques], [Difficulty], [Mod], [Subject], [Sem], [Branch]) VALUES (N'1013', N'Explain Diffie-Hellman Key-Exchange algorithm 4', N'Easy', N'4', N'NS', N'5', N'BScIT')
INSERT [dbo].[Ques] ([QId], [Ques], [Difficulty], [Mod], [Subject], [Sem], [Branch]) VALUES (N'1014', N'What are Virtual Private Networks 5', N'Easy', N'5', N'NS', N'5', N'BScIT')
INSERT [dbo].[Ques] ([QId], [Ques], [Difficulty], [Mod], [Subject], [Sem], [Branch]) VALUES (N'1015', N'What is Secure Socket Layer? 5', N'Easy', N'5', N'NS', N'5', N'BScIT')
INSERT [dbo].[Ques] ([QId], [Ques], [Difficulty], [Mod], [Subject], [Sem], [Branch]) VALUES (N'1016', NULL, N'Easy', N'2', N'JAVA', N'4', N'EXTC')
INSERT [dbo].[Ques] ([QId], [Ques], [Difficulty], [Mod], [Subject], [Sem], [Branch]) VALUES (N'1017', N'Explain Secure Electronic Transaction 5', N'Easy', N'5', N'NS', N'5', N'BScIT')
INSERT [dbo].[Ques] ([QId], [Ques], [Difficulty], [Mod], [Subject], [Sem], [Branch]) VALUES (N'1018', N'What is role of  Key Distribution Center 6', N'Easy', N'6', N'NS', N'5', N'BScIT')
INSERT [dbo].[Ques] ([QId], [Ques], [Difficulty], [Mod], [Subject], [Sem], [Branch]) VALUES (N'1019', N'Biometric Authentication 6', N'Easy', N'6', N'NS', N'5', N'BScIT')
INSERT [dbo].[Ques] ([QId], [Ques], [Difficulty], [Mod], [Subject], [Sem], [Branch]) VALUES (N'1020', N'What is  Single Sign On (SSO) Approaches 6', N'Easy', N'6', N'NS', N'5', N'BScIT')
INSERT [dbo].[Ques] ([QId], [Ques], [Difficulty], [Mod], [Subject], [Sem], [Branch]) VALUES (N'1021', N'Explain Master Pages 1', N'Easy ', N'1', N'Asp.Net', N'6', N'BScIT')
INSERT [dbo].[Ques] ([QId], [Ques], [Difficulty], [Mod], [Subject], [Sem], [Branch]) VALUES (N'1022', N'How does it works?', N'Easy', N'6', N'NS', N'5', N'BScIT')
INSERT [dbo].[Ques] ([QId], [Ques], [Difficulty], [Mod], [Subject], [Sem], [Branch]) VALUES (N'1023', N'HI', N'Easy', N'5', N'NS', N'5', N'BScIT')
INSERT [dbo].[Ques] ([QId], [Ques], [Difficulty], [Mod], [Subject], [Sem], [Branch]) VALUES (N'1024', N'hsdfksh', N'Easy', N'4', N'NS', N'5', N'BScIT')
INSERT [dbo].[Ques] ([QId], [Ques], [Difficulty], [Mod], [Subject], [Sem], [Branch]) VALUES (N'1025', N'heeloo', N'Easy', N'1', N'Maths', N'1', N'BSC IT')
/****** Object:  Table [dbo].[QLog]    Script Date: 11/14/2016 12:05:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[QLog](
	[QId] [varchar](50) NULL,
	[QName] [varchar](50) NULL,
	[QCode] [varchar](50) NULL,
	[Date] [varchar](50) NULL
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
INSERT [dbo].[QLog] ([QId], [QName], [QCode], [Date]) VALUES (N'1001', N'NS Q142', N'14275', N'05-01-15')
INSERT [dbo].[QLog] ([QId], [QName], [QCode], [Date]) VALUES (N'1002', N'A', N'1', N'11/14/2016')
/****** Object:  Table [dbo].[Exami]    Script Date: 11/14/2016 12:05:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Exami](
	[ID] [varchar](50) NULL,
	[Pass] [varchar](50) NULL
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
INSERT [dbo].[Exami] ([ID], [Pass]) VALUES (N'1', N'eax')
