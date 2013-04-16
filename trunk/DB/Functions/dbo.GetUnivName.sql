SET QUOTED_IDENTIFIER ON
GO
SET ANSI_NULLS ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date, ,>
-- Description:	<Description, ,>
-- =============================================
CREATE FUNCTION [dbo].[GetUnivName]
(
	-- Add the parameters for the function here
	@UnivId int
)
RETURNS nvarchar
AS
BEGIN
	-- Declare the return variable here
	DECLARE @UnivName nvarchar

	-- Add the T-SQL statements to compute the return value here
	SELECT @UnivId = Name
	From University
	Where ID = @UnivId;

	-- Return the result of the function
	RETURN @UnivName

END
GO
