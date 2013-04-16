SET QUOTED_IDENTIFIER ON
GO
SET ANSI_NULLS ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date, ,>
-- Description:	<Description, ,>
-- =============================================
CREATE FUNCTION [dbo].[GetMemberId]
(
	@MemberMobile nvarchar
)
RETURNS int
AS
BEGIN
	-- Declare the return variable here
	DECLARE @MemberId int

	-- Add the T-SQL statements to compute the return value here
	SELECT @MemberId = ID
	From Member
	Where Mobile = @MemberMobile;

	-- Return the result of the function
	RETURN @MemberId

END
GO
