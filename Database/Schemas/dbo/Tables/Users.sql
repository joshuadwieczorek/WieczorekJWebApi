CREATE TABLE [dbo].[Users]
(
		[UserId]		UNIQUEIDENTIFIER	NOT NULL DEFAULT NEWID()
	,	[Username]		VARCHAR(250)		NOT NULL 
	,	[FirstName]		NVARCHAR(100)		NULL
	,	[LastName]		NVARCHAR(100)		NULL
	,	[EmailAddress]	VARCHAR(250)		NOT NULL
	,	[Status]		SMALLINT			NOT NULL DEFAULT 0
	,	[LastLoginAt]	DATETIME2(7)		NULL
	,	[RegisteredBy]	NVARCHAR(250)		NOT NULL
	,	[RegisteredAt]	DATETIME2(7)		NOT NULL	
	,	[CreatedBy]		NVARCHAR(250)		NOT NULL DEFAULT SUSER_NAME()
	,	[CreatedAt]		DATETIME2(7)		NOT NULL
	,	[UpdatedBy]		NVARCHAR(250)		NULL
	,	[UpdatedAt]		DATETIME2(7)		NULL
	,	CONSTRAINT [PK_Dbo_Users_UserId] PRIMARY KEY ([UserId])
	,	CONSTRAINT [AK_Dbo_Users_Username] UNIQUE ([Username])
	,	CONSTRAINT [AK_Dbo_Users_EmailAddress] UNIQUE ([EmailAddress])
);