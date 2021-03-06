USE [master]
GO
/****** Object:  Database [Hospital]    Script Date: 12/29/2019 2:46:11 AM ******/
CREATE DATABASE [Hospital]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Hospital', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\Hospital.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'Hospital_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\Hospital_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [Hospital] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Hospital].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Hospital] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Hospital] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Hospital] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Hospital] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Hospital] SET ARITHABORT OFF 
GO
ALTER DATABASE [Hospital] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [Hospital] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Hospital] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Hospital] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Hospital] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Hospital] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Hospital] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Hospital] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Hospital] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Hospital] SET  DISABLE_BROKER 
GO
ALTER DATABASE [Hospital] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Hospital] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Hospital] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Hospital] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Hospital] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Hospital] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [Hospital] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Hospital] SET RECOVERY FULL 
GO
ALTER DATABASE [Hospital] SET  MULTI_USER 
GO
ALTER DATABASE [Hospital] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Hospital] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Hospital] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Hospital] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [Hospital] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [Hospital] SET QUERY_STORE = OFF
GO
USE [Hospital]
GO
/****** Object:  Table [dbo].[Admin]    Script Date: 12/29/2019 2:46:11 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Admin](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[UserID] [int] NOT NULL,
	[Name] [varchar](20) NOT NULL,
	[Gender] [varchar](10) NOT NULL,
	[DoB] [date] NOT NULL,
	[Phone] [varchar](15) NOT NULL,
	[Address] [varchar](100) NOT NULL,
 CONSTRAINT [PK_Admin] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Cabin]    Script Date: 12/29/2019 2:46:11 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Cabin](
	[ID] [int] IDENTITY(2001,1) NOT NULL,
	[Catagory] [varchar](15) NOT NULL,
	[Status] [varchar](15) NOT NULL,
	[PatientID] [int] NULL,
 CONSTRAINT [PK_Cabin] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Doctor]    Script Date: 12/29/2019 2:46:11 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Doctor](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[UserID] [int] NOT NULL,
	[Name] [varchar](20) NOT NULL,
	[Gender] [varchar](10) NOT NULL,
	[DoB] [date] NOT NULL,
	[Phone] [varchar](15) NOT NULL,
	[Address] [varchar](100) NOT NULL,
	[Department] [varchar](20) NOT NULL,
 CONSTRAINT [PK_Doctor] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Login]    Script Date: 12/29/2019 2:46:11 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Login](
	[ID] [int] IDENTITY(1000,1) NOT NULL,
	[Password] [varchar](20) NOT NULL,
	[UserType] [varchar](15) NOT NULL,
 CONSTRAINT [PK_Login_1] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Medicine]    Script Date: 12/29/2019 2:46:11 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Medicine](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[PatientID] [int] NOT NULL,
	[Name] [varchar](100) NOT NULL,
	[DoctorID] [int] NOT NULL,
	[Date] [date] NOT NULL,
 CONSTRAINT [PK_Medicine] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Patient]    Script Date: 12/29/2019 2:46:11 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Patient](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](20) NOT NULL,
	[Gender] [varchar](10) NOT NULL,
	[DoB] [date] NOT NULL,
	[Phone] [varchar](15) NOT NULL,
	[Address] [varchar](100) NOT NULL,
	[DoctorID] [int] NULL,
 CONSTRAINT [PK_Patient] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Receptionist]    Script Date: 12/29/2019 2:46:11 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Receptionist](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[UserID] [int] NOT NULL,
	[Name] [varchar](20) NOT NULL,
	[Gender] [varchar](10) NOT NULL,
	[DoB] [date] NOT NULL,
	[Phone] [varchar](15) NOT NULL,
	[Address] [varchar](100) NOT NULL,
 CONSTRAINT [PK_Receptionist] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Schedule]    Script Date: 12/29/2019 2:46:11 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Schedule](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[PatientID] [int] NOT NULL,
	[DoctorID] [int] NOT NULL,
	[Date] [date] NOT NULL,
	[S_Time] [time](7) NOT NULL,
	[E_Time] [time](7) NOT NULL,
 CONSTRAINT [PK_Schedule] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Admin] ON 

INSERT [dbo].[Admin] ([ID], [UserID], [Name], [Gender], [DoB], [Phone], [Address]) VALUES (1, 1000, N'Prime', N'Male', CAST(N'1990-07-07' AS Date), N'01779641112', N'Gulshan')
SET IDENTITY_INSERT [dbo].[Admin] OFF
SET IDENTITY_INSERT [dbo].[Cabin] ON 

INSERT [dbo].[Cabin] ([ID], [Catagory], [Status], [PatientID]) VALUES (2001, N'Deluxe Suite', N'Empty', NULL)
INSERT [dbo].[Cabin] ([ID], [Catagory], [Status], [PatientID]) VALUES (2002, N'Deluxe Suite', N'Occupied', 4)
INSERT [dbo].[Cabin] ([ID], [Catagory], [Status], [PatientID]) VALUES (2003, N'Deluxe Suite', N'Occupied', 1)
INSERT [dbo].[Cabin] ([ID], [Catagory], [Status], [PatientID]) VALUES (2004, N'Deluxe Suite', N'Empty', NULL)
INSERT [dbo].[Cabin] ([ID], [Catagory], [Status], [PatientID]) VALUES (2005, N'Deluxe Suite', N'Occupied', 6)
INSERT [dbo].[Cabin] ([ID], [Catagory], [Status], [PatientID]) VALUES (2006, N'Deluxe Suite', N'Empty', NULL)
INSERT [dbo].[Cabin] ([ID], [Catagory], [Status], [PatientID]) VALUES (2007, N'Deluxe Suite', N'Empty', NULL)
INSERT [dbo].[Cabin] ([ID], [Catagory], [Status], [PatientID]) VALUES (2008, N'Deluxe Suite', N'Empty', NULL)
INSERT [dbo].[Cabin] ([ID], [Catagory], [Status], [PatientID]) VALUES (2009, N'Deluxe Suite', N'Occupied', 3)
INSERT [dbo].[Cabin] ([ID], [Catagory], [Status], [PatientID]) VALUES (2010, N'Standard Suite', N'Empty', NULL)
INSERT [dbo].[Cabin] ([ID], [Catagory], [Status], [PatientID]) VALUES (2011, N'Standard Suite', N'Empty', NULL)
INSERT [dbo].[Cabin] ([ID], [Catagory], [Status], [PatientID]) VALUES (2012, N'Standard Suite', N'Empty', NULL)
INSERT [dbo].[Cabin] ([ID], [Catagory], [Status], [PatientID]) VALUES (2013, N'Standard Suite', N'Empty', NULL)
INSERT [dbo].[Cabin] ([ID], [Catagory], [Status], [PatientID]) VALUES (2014, N'Standard Suite', N'Empty', NULL)
INSERT [dbo].[Cabin] ([ID], [Catagory], [Status], [PatientID]) VALUES (2015, N'Standard Suite', N'Empty', NULL)
INSERT [dbo].[Cabin] ([ID], [Catagory], [Status], [PatientID]) VALUES (2016, N'Standard Suite', N'Empty', NULL)
INSERT [dbo].[Cabin] ([ID], [Catagory], [Status], [PatientID]) VALUES (2017, N'Standard Suite', N'Empty', NULL)
INSERT [dbo].[Cabin] ([ID], [Catagory], [Status], [PatientID]) VALUES (2018, N'Standard Suite', N'Empty', NULL)
INSERT [dbo].[Cabin] ([ID], [Catagory], [Status], [PatientID]) VALUES (2019, N'Standard Suite', N'Empty', NULL)
INSERT [dbo].[Cabin] ([ID], [Catagory], [Status], [PatientID]) VALUES (2020, N'Standard Suite', N'Empty', NULL)
INSERT [dbo].[Cabin] ([ID], [Catagory], [Status], [PatientID]) VALUES (2021, N'Standard Suite', N'Empty', NULL)
INSERT [dbo].[Cabin] ([ID], [Catagory], [Status], [PatientID]) VALUES (2022, N'Standard Suite', N'Empty', NULL)
INSERT [dbo].[Cabin] ([ID], [Catagory], [Status], [PatientID]) VALUES (2023, N'Standard Suite', N'Empty', NULL)
INSERT [dbo].[Cabin] ([ID], [Catagory], [Status], [PatientID]) VALUES (2024, N'Standard Suite', N'Empty', NULL)
INSERT [dbo].[Cabin] ([ID], [Catagory], [Status], [PatientID]) VALUES (2025, N'Standard Suite', N'Empty', NULL)
INSERT [dbo].[Cabin] ([ID], [Catagory], [Status], [PatientID]) VALUES (2026, N'Standard Suite', N'Empty', NULL)
INSERT [dbo].[Cabin] ([ID], [Catagory], [Status], [PatientID]) VALUES (2027, N'Standard Suite', N'Empty', NULL)
INSERT [dbo].[Cabin] ([ID], [Catagory], [Status], [PatientID]) VALUES (2028, N'Standard Suite', N'Empty', NULL)
INSERT [dbo].[Cabin] ([ID], [Catagory], [Status], [PatientID]) VALUES (2029, N'Standard Suite', N'Empty', NULL)
INSERT [dbo].[Cabin] ([ID], [Catagory], [Status], [PatientID]) VALUES (2030, N'Standard Suite', N'Empty', NULL)
SET IDENTITY_INSERT [dbo].[Cabin] OFF
SET IDENTITY_INSERT [dbo].[Doctor] ON 

INSERT [dbo].[Doctor] ([ID], [UserID], [Name], [Gender], [DoB], [Phone], [Address], [Department]) VALUES (1, 1001, N'Chinmoy', N'Male', CAST(N'1998-07-07' AS Date), N'01764655633', N'Mirpur', N'Medicine')
INSERT [dbo].[Doctor] ([ID], [UserID], [Name], [Gender], [DoB], [Phone], [Address], [Department]) VALUES (2, 1002, N'Maisha', N'Female', CAST(N'1998-12-15' AS Date), N'01966647146', N'Badda', N'Ophthalmology')
INSERT [dbo].[Doctor] ([ID], [UserID], [Name], [Gender], [DoB], [Phone], [Address], [Department]) VALUES (3, 1003, N'Ayon', N'Male', CAST(N'1997-12-29' AS Date), N'01944562215', N'Mohommadpur', N'Ophthalmology')
INSERT [dbo].[Doctor] ([ID], [UserID], [Name], [Gender], [DoB], [Phone], [Address], [Department]) VALUES (4, 1004, N'Bishal', N'Male', CAST(N'1998-06-19' AS Date), N'01832964896', N'Rampura', N'Nephrology')
INSERT [dbo].[Doctor] ([ID], [UserID], [Name], [Gender], [DoB], [Phone], [Address], [Department]) VALUES (5, 1005, N'Saiful', N'Male', CAST(N'1996-12-17' AS Date), N'01832965874', N'Kuratoli', N'Orthopedics')
INSERT [dbo].[Doctor] ([ID], [UserID], [Name], [Gender], [DoB], [Phone], [Address], [Department]) VALUES (6, 1006, N'Muktasid', N'Male', CAST(N'1996-12-08' AS Date), N'01965478996', N'Uttara', N'Orthopedics')
SET IDENTITY_INSERT [dbo].[Doctor] OFF
SET IDENTITY_INSERT [dbo].[Login] ON 

INSERT [dbo].[Login] ([ID], [Password], [UserType]) VALUES (1000, N'12345', N'Admin')
INSERT [dbo].[Login] ([ID], [Password], [UserType]) VALUES (1001, N'1234', N'Doctor')
INSERT [dbo].[Login] ([ID], [Password], [UserType]) VALUES (1002, N'1234', N'Doctor')
INSERT [dbo].[Login] ([ID], [Password], [UserType]) VALUES (1003, N'1234', N'Doctor')
INSERT [dbo].[Login] ([ID], [Password], [UserType]) VALUES (1004, N'1234', N'Doctor')
INSERT [dbo].[Login] ([ID], [Password], [UserType]) VALUES (1005, N'1234', N'Doctor')
INSERT [dbo].[Login] ([ID], [Password], [UserType]) VALUES (1006, N'1234', N'Doctor')
INSERT [dbo].[Login] ([ID], [Password], [UserType]) VALUES (1007, N'123', N'Receptionist')
INSERT [dbo].[Login] ([ID], [Password], [UserType]) VALUES (1008, N'123', N'Receptionist')
INSERT [dbo].[Login] ([ID], [Password], [UserType]) VALUES (1009, N'123', N'Receptionist')
SET IDENTITY_INSERT [dbo].[Login] OFF
SET IDENTITY_INSERT [dbo].[Medicine] ON 

INSERT [dbo].[Medicine] ([ID], [PatientID], [Name], [DoctorID], [Date]) VALUES (1, 1, N'Paracetamnol', 1, CAST(N'2019-12-29' AS Date))
INSERT [dbo].[Medicine] ([ID], [PatientID], [Name], [DoctorID], [Date]) VALUES (2, 1, N'Montelucus', 1, CAST(N'2019-12-29' AS Date))
INSERT [dbo].[Medicine] ([ID], [PatientID], [Name], [DoctorID], [Date]) VALUES (3, 1, N'Amodics', 1, CAST(N'2019-12-29' AS Date))
INSERT [dbo].[Medicine] ([ID], [PatientID], [Name], [DoctorID], [Date]) VALUES (4, 4, N'Paracetamol', 1, CAST(N'2019-12-29' AS Date))
INSERT [dbo].[Medicine] ([ID], [PatientID], [Name], [DoctorID], [Date]) VALUES (5, 4, N'Amodics', 1, CAST(N'2019-12-29' AS Date))
INSERT [dbo].[Medicine] ([ID], [PatientID], [Name], [DoctorID], [Date]) VALUES (6, 2, N'Amodics', 1, CAST(N'2019-12-29' AS Date))
INSERT [dbo].[Medicine] ([ID], [PatientID], [Name], [DoctorID], [Date]) VALUES (7, 3, N'Paracetamol', 1, CAST(N'2019-12-29' AS Date))
SET IDENTITY_INSERT [dbo].[Medicine] OFF
SET IDENTITY_INSERT [dbo].[Patient] ON 

INSERT [dbo].[Patient] ([ID], [Name], [Gender], [DoB], [Phone], [Address], [DoctorID]) VALUES (1, N'Karim', N'Male', CAST(N'1999-12-29' AS Date), N'01796741852', N'Bashundhara', NULL)
INSERT [dbo].[Patient] ([ID], [Name], [Gender], [DoB], [Phone], [Address], [DoctorID]) VALUES (2, N'Jashim', N'Male', CAST(N'1999-04-05' AS Date), N'01978964123', N'Bashundhara', NULL)
INSERT [dbo].[Patient] ([ID], [Name], [Gender], [DoB], [Phone], [Address], [DoctorID]) VALUES (3, N'Ranjan', N'Male', CAST(N'1990-12-29' AS Date), N'01678963458', N'Shantinogor', NULL)
INSERT [dbo].[Patient] ([ID], [Name], [Gender], [DoB], [Phone], [Address], [DoctorID]) VALUES (4, N'Esha', N'Female', CAST(N'1998-03-15' AS Date), N'01965789416', N'Mirpur', NULL)
INSERT [dbo].[Patient] ([ID], [Name], [Gender], [DoB], [Phone], [Address], [DoctorID]) VALUES (5, N'Maliha', N'Female', CAST(N'1992-09-16' AS Date), N'01965987976', N'Lalmatia', NULL)
INSERT [dbo].[Patient] ([ID], [Name], [Gender], [DoB], [Phone], [Address], [DoctorID]) VALUES (6, N'Akash', N'Male', CAST(N'1995-01-16' AS Date), N'01965987976', N'Lalmatia', NULL)
SET IDENTITY_INSERT [dbo].[Patient] OFF
SET IDENTITY_INSERT [dbo].[Receptionist] ON 

INSERT [dbo].[Receptionist] ([ID], [UserID], [Name], [Gender], [DoB], [Phone], [Address]) VALUES (1, 1007, N'Chisty', N'Male', CAST(N'1999-02-02' AS Date), N'01689745456', N'Asad Gate')
INSERT [dbo].[Receptionist] ([ID], [UserID], [Name], [Gender], [DoB], [Phone], [Address]) VALUES (2, 1008, N'Snigdho', N'Male', CAST(N'1999-04-03' AS Date), N'01678456789', N'Gulshan')
INSERT [dbo].[Receptionist] ([ID], [UserID], [Name], [Gender], [DoB], [Phone], [Address]) VALUES (3, 1009, N'Tonmoy', N'Male', CAST(N'1998-06-04' AS Date), N'01965789412', N'Banani')
SET IDENTITY_INSERT [dbo].[Receptionist] OFF
SET IDENTITY_INSERT [dbo].[Schedule] ON 

INSERT [dbo].[Schedule] ([ID], [PatientID], [DoctorID], [Date], [S_Time], [E_Time]) VALUES (1, 5, 3, CAST(N'2020-01-29' AS Date), CAST(N'11:00:00' AS Time), CAST(N'11:30:00' AS Time))
INSERT [dbo].[Schedule] ([ID], [PatientID], [DoctorID], [Date], [S_Time], [E_Time]) VALUES (2, 2, 1, CAST(N'2020-01-02' AS Date), CAST(N'14:30:00' AS Time), CAST(N'15:00:00' AS Time))
INSERT [dbo].[Schedule] ([ID], [PatientID], [DoctorID], [Date], [S_Time], [E_Time]) VALUES (3, 4, 6, CAST(N'2020-01-02' AS Date), CAST(N'12:30:00' AS Time), CAST(N'13:00:00' AS Time))
SET IDENTITY_INSERT [dbo].[Schedule] OFF
ALTER TABLE [dbo].[Admin]  WITH CHECK ADD  CONSTRAINT [FK_Admin_Login] FOREIGN KEY([UserID])
REFERENCES [dbo].[Login] ([ID])
GO
ALTER TABLE [dbo].[Admin] CHECK CONSTRAINT [FK_Admin_Login]
GO
ALTER TABLE [dbo].[Cabin]  WITH CHECK ADD  CONSTRAINT [FK_Cabin_Patient] FOREIGN KEY([PatientID])
REFERENCES [dbo].[Patient] ([ID])
GO
ALTER TABLE [dbo].[Cabin] CHECK CONSTRAINT [FK_Cabin_Patient]
GO
ALTER TABLE [dbo].[Doctor]  WITH CHECK ADD  CONSTRAINT [FK_Doctor_Login] FOREIGN KEY([UserID])
REFERENCES [dbo].[Login] ([ID])
GO
ALTER TABLE [dbo].[Doctor] CHECK CONSTRAINT [FK_Doctor_Login]
GO
ALTER TABLE [dbo].[Medicine]  WITH CHECK ADD  CONSTRAINT [FK_Medicine_Doctor] FOREIGN KEY([DoctorID])
REFERENCES [dbo].[Doctor] ([ID])
GO
ALTER TABLE [dbo].[Medicine] CHECK CONSTRAINT [FK_Medicine_Doctor]
GO
ALTER TABLE [dbo].[Medicine]  WITH CHECK ADD  CONSTRAINT [FK_Medicine_Patient] FOREIGN KEY([PatientID])
REFERENCES [dbo].[Patient] ([ID])
GO
ALTER TABLE [dbo].[Medicine] CHECK CONSTRAINT [FK_Medicine_Patient]
GO
ALTER TABLE [dbo].[Patient]  WITH CHECK ADD  CONSTRAINT [FK_Patient_Patient] FOREIGN KEY([ID])
REFERENCES [dbo].[Patient] ([ID])
GO
ALTER TABLE [dbo].[Patient] CHECK CONSTRAINT [FK_Patient_Patient]
GO
ALTER TABLE [dbo].[Receptionist]  WITH CHECK ADD  CONSTRAINT [FK_Receptionist_Login] FOREIGN KEY([UserID])
REFERENCES [dbo].[Login] ([ID])
GO
ALTER TABLE [dbo].[Receptionist] CHECK CONSTRAINT [FK_Receptionist_Login]
GO
ALTER TABLE [dbo].[Schedule]  WITH CHECK ADD  CONSTRAINT [FK_Schedule_Doctor] FOREIGN KEY([DoctorID])
REFERENCES [dbo].[Doctor] ([ID])
GO
ALTER TABLE [dbo].[Schedule] CHECK CONSTRAINT [FK_Schedule_Doctor]
GO
ALTER TABLE [dbo].[Schedule]  WITH CHECK ADD  CONSTRAINT [FK_Schedule_Patient] FOREIGN KEY([PatientID])
REFERENCES [dbo].[Patient] ([ID])
GO
ALTER TABLE [dbo].[Schedule] CHECK CONSTRAINT [FK_Schedule_Patient]
GO
USE [master]
GO
ALTER DATABASE [Hospital] SET  READ_WRITE 
GO
