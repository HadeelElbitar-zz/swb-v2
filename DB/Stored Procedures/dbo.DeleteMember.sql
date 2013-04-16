SET QUOTED_IDENTIFIER ON
GO
SET ANSI_NULLS ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[DeleteMember]
	-- Add the parameters for the stored procedure here
	@ID int
AS
BEGIN
	delete Member
	where ID = @ID;
END
GO
