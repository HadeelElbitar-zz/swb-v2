SET QUOTED_IDENTIFIER ON
GO
SET ANSI_NULLS ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date, ,>
-- Description:	<Description, ,>
-- =============================================
CREATE FUNCTION [dbo].[GetCommitteName]
(
	-- Add the parameters for the function here
	@CommitteId int
)
RETURNS nvarchar
AS
BEGIN
	-- Declare the return variable here
	DECLARE @ComName nvarchar

	-- Add the T-SQL statements to compute the return value here
	SELECT @ComName = Name 
	From Committee
	where ID = @ComName;

	-- Return the result of the function
	RETURN @ComName

END
GO
