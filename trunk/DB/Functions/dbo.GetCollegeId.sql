SET QUOTED_IDENTIFIER ON
GO
SET ANSI_NULLS ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date, ,>
-- Description:	<Description, ,>
-- =============================================
CREATE FUNCTION [dbo].[GetCollegeId]
(
	@CollegeName nvarchar
)
RETURNS int
AS
BEGIN
	-- Declare the return variable here
	DECLARE @CollegeId int
	
	-- Add the T-SQL statements to compute the return value here
	SELECT @CollegeId = ID
	from College
	where Name = @CollegeId;

	-- Return the result of the function
	RETURN @CollegeId;

END
GO
