SET QUOTED_IDENTIFIER ON
GO
SET ANSI_NULLS ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date, ,>
-- Description:	<Description, ,>
-- =============================================
CREATE FUNCTION [dbo].[GetCollegeName]
(
	-- Add the parameters for the function here
	@CollegeId int
)
RETURNS nvarchar
AS
BEGIN
	-- Declare the return variable here
	DECLARE @CollegeName nvarchar 

	-- Add the T-SQL statements to compute the return value here
	SELECT @CollegeName = Name 
	From College 
	Where ID = @CollegeId

	-- Return the result of the function
	RETURN @CollegeName

END
GO
