CREATE TABLE [dbo].[Todos]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY,
	[Name] nvarchar(255) not null,
	[IsDone] bit not null default(0)
)
