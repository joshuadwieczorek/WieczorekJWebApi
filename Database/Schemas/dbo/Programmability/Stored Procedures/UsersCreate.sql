CREATE PROCEDURE [dbo].[UsersCreate]
(
		@UserId UNIQUEIDENTIFIER = NULL
	,	@Username VARCHAR(250)
	,	@FirstName NVARCHAR(100)
	,	@LastName NVARCHAR(100)
	,	@EmailAddress VARCHAR(250)
	,	@Status SMALLINT = 1 -- Or any other status that is active / registered
	,	@RegisteredBy NVARCHAR(250)
	,	@RegisteredAt DATETIME2(7)
)
AS
BEGIN

	INSERT INTO [dbo].[Users]
	(
			[UserId]		
		,	[Username]		
		,	[FirstName]		
		,	[LastName]		
		,	[EmailAddress]	
		,	[Status]		
		,	[RegisteredBy]	
		,	[RegisteredAt]	
		,	[CreatedBy]		
		,	[CreatedAt]			
	)
	VALUES
	(
			@UserId
		,	@Username
		,	@FirstName
		,	@LastName
		,	@EmailAddress
		,	@Status
		,	@RegisteredBy
		,	@RegisteredAt
		,	SUSER_NAME()
		,	GETDATE()
	);

END