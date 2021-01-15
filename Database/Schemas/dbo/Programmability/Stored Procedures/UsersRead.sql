CREATE PROCEDURE [dbo].[UsersRead]
(
	@UserId UNIQUEIDENTIFIER = NULL
)
AS
BEGIN

	SELECT		[UserId]		
			,	[Username]		
			,	[FirstName]		
			,	[LastName]		
			,	[EmailAddress]	
			,	[Status]		
			,	[LastLoginAt]	
			,	[RegisteredBy]	
			,	[RegisteredAt]	
			,	[CreatedBy]		
			,	[CreatedAt]		
			,	[UpdatedBy]		
			,	[UpdatedAt]		
	FROM		[dbo].[Users] (NOLOCK)
	WHERE	(
				@UserId IS NULL 
				OR
				[UserId] = @UserId
			);

END