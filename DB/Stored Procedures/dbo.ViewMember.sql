SET QUOTED_IDENTIFIER ON
GO
SET ANSI_NULLS ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[ViewMember]
	-- Add the parameters for the stored procedure here
	@Mobile nvarchar
AS
BEGIN
	Select * 
	From Member
	Where Mobile = @Mobile;
	
END
GO
