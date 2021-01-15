CREATE PROCEDURE [dbo].[UsersDelete]
(
		@UserId UNIQUEIDENTIFIER
	,	@UpdatedBy NVARCHAR(250) = NULL
	,	@UpdatedAt DATETIME2(7) = NULL
	,	@SoftDelete BIT = 1
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
		@UpdatedBy = (
			CASE 
				WHEN (@UpdatedAt IS NULL)
					THEN GETDATE()
				ELSE @UpdatedAt
			END
		);

	IF (@SoftDelete = 1)
	BEGIN
		UPDATE	[dbo].[Users]
			SET	[Status] = 0 -- Or any other soft deleted status.
			,	[UpdatedBy] = @UpdatedBy
			,	[UpdatedAt] = @UpdatedAt
		WHERE	[UserId] = @UserId;
	END
	ELSE
	BEGIN
		DELETE FROM [dbo].[Users]
			WHERE [UserId] = @UserId;
	END

END