SET QUOTED_IDENTIFIER ON
GO
SET ANSI_NULLS ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date, ,>
-- Description:	<Description, ,>
-- =============================================
CREATE FUNCTION [dbo].[GetUniversityId]
(
	@UnivName nvarchar
)
RETURNS int
AS
BEGIN
	-- Declare the return variable here
	DECLARE @UnivId int

	-- Add the T-SQL statements to compute the return value here
	SELECT @UnivId = ID
	From University
	where Name = @UnivId;

	-- Return the result of the function
	RETURN @UnivId;

END
GO
