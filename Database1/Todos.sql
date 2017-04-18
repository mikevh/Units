﻿CREATE TABLE [dbo].[Todos]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY,
	[Name] nvarchar(255) not null,
	[IsDone] bit not null default(0),
	[CreatedBy] nvarchar(255) not null,
	[UpdatedBy] nvarchar(255) not null,
	[CreatedOn] datetime2 not null default(getutcdate()),
	[UpdatedOn] datetime2 not null
)
