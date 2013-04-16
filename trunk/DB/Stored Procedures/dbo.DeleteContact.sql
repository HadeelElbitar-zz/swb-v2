SET QUOTED_IDENTIFIER ON
GO
SET ANSI_NULLS ON
GO
-- =============================================
-- Author:		manar
-- Create date: 29/3/2013
-- Description:	Delet
-- =============================================
CREATE PROCEDURE [dbo].[DeleteContact]
	-- Add the parameters for the stored procedure here
	
	
	@IDValue int 
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	Delete from ContactUs 
	where  ID=@IDValue
END
GO
