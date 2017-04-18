CREATE TABLE [dbo].[Grades]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY,
	[StudentId] int not null,
	[CourseId] int not null,
	[Letter] nvarchar(2) not null,
	[CreatedBy] nvarchar(255) not null,
	[UpdatedBy] nvarchar(255) not null,
	[CreatedOn] datetime2 not null default(getutcdate()),
	[UpdatedOn] datetime2 not null,
	constraint FK_Student_StudentId foreign key (StudentId) references Students(Id),
	constraint FK_Course_CourseId foreign key (CourseId) references Courses(Id)
)

