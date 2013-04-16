SET QUOTED_IDENTIFIER ON
GO
SET ANSI_NULLS ON
GO
-- =============================================
-- Author:		Manar yousry
-- Create date: 29/3/2013
-- Description:	Delete
-- =============================================
CREATE PROCEDURE [dbo].[DeleteText] 
	-- Add the parameters for the stored procedure here
	@ID int 
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	Delete from StaticPage
	where(ID=@ID)
END
GO
