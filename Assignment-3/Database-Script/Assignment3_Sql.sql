USE [OBİS]
GO
/****** Object:  UserDefinedFunction [dbo].[Func_calculating_average_lecture]    Script Date: 14/07/2022 11:10:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE Function [dbo].[Func_calculating_average_lecture]
(
	@Midterm_Exam float,
	@Final_Exam float
)

Returns float 

As 
Begin
		declare @Avarege float;
		set @Avarege = (@Midterm_Exam * 0.4) + (@Final_Exam * 0.6);

		return @Avarege

End
GO
/****** Object:  Table [dbo].[Lectures]    Script Date: 14/07/2022 11:10:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Lectures](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Lecture_Name] [nvarchar](50) NOT NULL,
	[Lecture_Credit] [int] NOT NULL,
 CONSTRAINT [PK_Lectures] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Students]    Script Date: 14/07/2022 11:10:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Students](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[Surname] [nvarchar](50) NOT NULL,
	[Student_Number] [numeric](9, 0) NOT NULL,
 CONSTRAINT [PK_Students] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Student_Lectures]    Script Date: 14/07/2022 11:10:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Student_Lectures](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Student_Id] [int] NOT NULL,
	[Lecture_Id] [int] NOT NULL,
	[Lecture_Semester] [int] NOT NULL,
	[Lecture_Midterm_Mark] [float] NOT NULL,
	[Lecture_Final_Mark] [float] NOT NULL,
 CONSTRAINT [PK_Student_Lectures] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  View [dbo].[StudentsLectures]    Script Date: 14/07/2022 11:10:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE View [dbo].[StudentsLectures]
As

select 
	s.Student_Number,
	s.Name,
	s.Surname,
	l.Lecture_Name,
	l.Lecture_Credit,
	sl.Lecture_Semester,
	sl.Lecture_Midterm_Mark,
	sl.Lecture_Final_Mark
from [Student_Lectures]  sl inner join Students s on s.Id = sl.Student_Id inner join Lectures l on l.Id = sl.Lecture_Id
GO
/****** Object:  UserDefinedFunction [dbo].[Func_StudentLecturesAndGradePointAverage]    Script Date: 14/07/2022 11:10:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE Function [dbo].[Func_StudentLecturesAndGradePointAverage]
(
)
Returns Table
As
Return

(
		Select 
		s.Id,
		s.Name,
		s.Surname,
		l.Lecture_Name,
		dbo.[Func_calculating_average_lecture](sl.Lecture_Midterm_Mark , sl.Lecture_Final_Mark) * l.Lecture_Credit as GPA
		from Student_Lectures sl inner join Students s on sl.Student_Id = s.Id inner join Lectures l on sl.Lecture_Id = l.Id
)
GO
SET IDENTITY_INSERT [dbo].[Lectures] ON 

INSERT [dbo].[Lectures] ([Id], [Lecture_Name], [Lecture_Credit]) VALUES (1, N'Yapay Zeka', 6)
INSERT [dbo].[Lectures] ([Id], [Lecture_Name], [Lecture_Credit]) VALUES (2, N'Formel Mantık', 5)
INSERT [dbo].[Lectures] ([Id], [Lecture_Name], [Lecture_Credit]) VALUES (3, N'Diferansiyel Denklemler', 6)
INSERT [dbo].[Lectures] ([Id], [Lecture_Name], [Lecture_Credit]) VALUES (4, N'Web Teknolojileri ve Programlama', 5)
INSERT [dbo].[Lectures] ([Id], [Lecture_Name], [Lecture_Credit]) VALUES (5, N'Formel Diller ve Otomata Teorisi', 4)
INSERT [dbo].[Lectures] ([Id], [Lecture_Name], [Lecture_Credit]) VALUES (6, N'Nesnelerin İnterneti', 6)
SET IDENTITY_INSERT [dbo].[Lectures] OFF
GO
SET IDENTITY_INSERT [dbo].[Student_Lectures] ON 

INSERT [dbo].[Student_Lectures] ([Id], [Student_Id], [Lecture_Id], [Lecture_Semester], [Lecture_Midterm_Mark], [Lecture_Final_Mark]) VALUES (1, 3, 1, 1, 78, 68)
INSERT [dbo].[Student_Lectures] ([Id], [Student_Id], [Lecture_Id], [Lecture_Semester], [Lecture_Midterm_Mark], [Lecture_Final_Mark]) VALUES (2, 3, 2, 1, 46, 96)
INSERT [dbo].[Student_Lectures] ([Id], [Student_Id], [Lecture_Id], [Lecture_Semester], [Lecture_Midterm_Mark], [Lecture_Final_Mark]) VALUES (3, 3, 2, 3, 58, 75)
INSERT [dbo].[Student_Lectures] ([Id], [Student_Id], [Lecture_Id], [Lecture_Semester], [Lecture_Midterm_Mark], [Lecture_Final_Mark]) VALUES (4, 3, 3, 1, 65, 66)
INSERT [dbo].[Student_Lectures] ([Id], [Student_Id], [Lecture_Id], [Lecture_Semester], [Lecture_Midterm_Mark], [Lecture_Final_Mark]) VALUES (5, 3, 4, 4, 100, 78)
INSERT [dbo].[Student_Lectures] ([Id], [Student_Id], [Lecture_Id], [Lecture_Semester], [Lecture_Midterm_Mark], [Lecture_Final_Mark]) VALUES (6, 3, 5, 2, 92, 67)
INSERT [dbo].[Student_Lectures] ([Id], [Student_Id], [Lecture_Id], [Lecture_Semester], [Lecture_Midterm_Mark], [Lecture_Final_Mark]) VALUES (7, 3, 6, 2, 68, 75)
INSERT [dbo].[Student_Lectures] ([Id], [Student_Id], [Lecture_Id], [Lecture_Semester], [Lecture_Midterm_Mark], [Lecture_Final_Mark]) VALUES (8, 2, 4, 1, 73, 49)
INSERT [dbo].[Student_Lectures] ([Id], [Student_Id], [Lecture_Id], [Lecture_Semester], [Lecture_Midterm_Mark], [Lecture_Final_Mark]) VALUES (9, 2, 3, 1, 56, 56)
INSERT [dbo].[Student_Lectures] ([Id], [Student_Id], [Lecture_Id], [Lecture_Semester], [Lecture_Midterm_Mark], [Lecture_Final_Mark]) VALUES (10, 2, 6, 2, 50, 88)
INSERT [dbo].[Student_Lectures] ([Id], [Student_Id], [Lecture_Id], [Lecture_Semester], [Lecture_Midterm_Mark], [Lecture_Final_Mark]) VALUES (11, 2, 4, 3, 45, 96)
INSERT [dbo].[Student_Lectures] ([Id], [Student_Id], [Lecture_Id], [Lecture_Semester], [Lecture_Midterm_Mark], [Lecture_Final_Mark]) VALUES (12, 2, 2, 1, 83, 58)
INSERT [dbo].[Student_Lectures] ([Id], [Student_Id], [Lecture_Id], [Lecture_Semester], [Lecture_Midterm_Mark], [Lecture_Final_Mark]) VALUES (13, 2, 1, 1, 80, 76)
INSERT [dbo].[Student_Lectures] ([Id], [Student_Id], [Lecture_Id], [Lecture_Semester], [Lecture_Midterm_Mark], [Lecture_Final_Mark]) VALUES (14, 2, 4, 2, 96, 61)
INSERT [dbo].[Student_Lectures] ([Id], [Student_Id], [Lecture_Id], [Lecture_Semester], [Lecture_Midterm_Mark], [Lecture_Final_Mark]) VALUES (15, 2, 5, 3, 73, 59)
SET IDENTITY_INSERT [dbo].[Student_Lectures] OFF
GO
SET IDENTITY_INSERT [dbo].[Students] ON 

INSERT [dbo].[Students] ([Id], [Name], [Surname], [Student_Number]) VALUES (2, N'Fatih', N'SAĞLAM', CAST(171805072 AS Numeric(9, 0)))
INSERT [dbo].[Students] ([Id], [Name], [Surname], [Student_Number]) VALUES (3, N'Batuhan', N'YILMAZ', CAST(171805058 AS Numeric(9, 0)))
INSERT [dbo].[Students] ([Id], [Name], [Surname], [Student_Number]) VALUES (4, N'Emrah', N'AKÇİN', CAST(171805074 AS Numeric(9, 0)))
INSERT [dbo].[Students] ([Id], [Name], [Surname], [Student_Number]) VALUES (5, N'Mustafa', N'SAĞLAM', CAST(161805070 AS Numeric(9, 0)))
INSERT [dbo].[Students] ([Id], [Name], [Surname], [Student_Number]) VALUES (6, N'Abdülkadir', N'Ömür', CAST(171805061 AS Numeric(9, 0)))
INSERT [dbo].[Students] ([Id], [Name], [Surname], [Student_Number]) VALUES (7, N'Yusuf', N'Yazıcı', CAST(171805097 AS Numeric(9, 0)))
SET IDENTITY_INSERT [dbo].[Students] OFF
GO
ALTER TABLE [dbo].[Student_Lectures]  WITH CHECK ADD  CONSTRAINT [FK_Student_Lectures_Lectures] FOREIGN KEY([Lecture_Id])
REFERENCES [dbo].[Lectures] ([Id])
GO
ALTER TABLE [dbo].[Student_Lectures] CHECK CONSTRAINT [FK_Student_Lectures_Lectures]
GO
ALTER TABLE [dbo].[Student_Lectures]  WITH CHECK ADD  CONSTRAINT [FK_Student_Lectures_Students] FOREIGN KEY([Student_Id])
REFERENCES [dbo].[Students] ([Id])
GO
ALTER TABLE [dbo].[Student_Lectures] CHECK CONSTRAINT [FK_Student_Lectures_Students]
GO
/****** Object:  StoredProcedure [dbo].[SpCreateLecture]    Script Date: 14/07/2022 11:10:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE Procedure [dbo].[SpCreateLecture]

	@Lecture_Name nvarchar(50),
	@Lecture_Credit numeric(9,0)
As

Begin

	insert into dbo.Lectures(Lecture_Name,Lecture_Credit)
	values(@Lecture_Name , @Lecture_Credit)

	Select * From Lectures

End
GO
/****** Object:  StoredProcedure [dbo].[SpCreateStudent]    Script Date: 14/07/2022 11:10:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE Procedure [dbo].[SpCreateStudent]

	@Name nvarchar(50),
	@Surname nvarchar(50),
	@Student_Number numeric(9,0)
As

Begin

	insert into dbo.Students([Name],Surname,Student_Number)
	values(@Name , @Surname , @Student_Number)

	Select * From Students

End
GO
/****** Object:  StoredProcedure [dbo].[SpStudentLectureCreate]    Script Date: 14/07/2022 11:10:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE Procedure [dbo].[SpStudentLectureCreate]
	
	@Student_Id int,
	@Lecture_Id int,
	@Lecture_Semester int,
	@Lecture_Midterm_Mark float,
	@Lecture_Final_Mark float

As

Begin
	insert into Student_Lectures(Student_Id,Lecture_Id,Lecture_Semester , Lecture_Midterm_Mark ,Lecture_Final_Mark )
	values(@Student_Id,@Lecture_Id,@Lecture_Semester ,@Lecture_Midterm_Mark,@Lecture_Final_Mark)

	Select * From Student_Lectures

End
GO
