CREATE PROCEDURE [dbo].[UsersUpdate]
(
		@UserId UNIQUEIDENTIFIER 
	,	@Username VARCHAR(250) = NULL
	,	@FirstName NVARCHAR(100) = NULL
	,	@LastName NVARCHAR(100) = NULL
	,	@EmailAddress VARCHAR(250) = NULL
	,	@LastLoginAt DATETIME2(7) = NULL
	,	@Status SMALLINT = NULL
	,	@UpdatedBy NVARCHAR(250) = NULL
	,	@UpdatedAt DATETIME2(7) = NULL
)
AS
BEGIN

	SELECT @UpdatedBy = (
			CASE 
				WHEN (@UpdatedBy IS NULL)
					THEN SUSER_NAME()
				ELSE @UpdatedBy
			END
		),
		@UpdatedAt = (
			CASE 
				WHEN (@UpdatedAt IS NULL)
					THEN GETDATE()
				ELSE @UpdatedAt
			END
		);

	UPDATE	[dbo].[Users]
		SET	[Username] = COALESCE(@Username, [Username])
		,	[FirstName] = COALESCE(@FirstName, [FirstName])
		,	[LastName] = COALESCE(@LastName, [LastName])
		,	[EmailAddress] = COALESCE(@EmailAddress, [EmailAddress])
		,	[LastLoginAt] = COALESCE(@LastLoginAt, [LastLoginAt])
		,	[Status] = COALESCE(@Status, [Status])
		,	[UpdatedBy] = @UpdatedBy
		,	[UpdatedAt] = @UpdatedAt
	WHERE	[UserId] = @UserId;

END
