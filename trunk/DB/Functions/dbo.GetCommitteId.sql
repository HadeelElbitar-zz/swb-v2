SET QUOTED_IDENTIFIER ON
GO
SET ANSI_NULLS ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date, ,>
-- Description:	<Description, ,>
-- =============================================
CREATE FUNCTION [dbo].[GetCommitteId] 
(
	@CommitteName nvarchar
)
RETURNS int
AS
BEGIN
	-- Declare the return variable here
	DECLARE @CommId int

	-- Add the T-SQL statements to compute the return value here
	SELECT @CommId = ID 
	from  Committee 
	where Name = @CommitteName;

	-- Return the result of the function
	RETURN @CommId;

END
GO
