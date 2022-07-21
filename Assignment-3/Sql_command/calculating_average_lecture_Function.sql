use OBÝS
select * , dbo.[Func_calculating_average_lecture](Lecture_Midterm_Mark ,Lecture_Final_Mark) as GPA from StudentsLectures as sl 
