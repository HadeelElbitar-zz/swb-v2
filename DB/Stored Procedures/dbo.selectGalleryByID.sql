SET QUOTED_IDENTIFIER ON
GO
SET ANSI_NULLS ON
GO
-- =============================================
-- Author:		Abdallah
-- Create date: 29 - 3 - 2013
-- Description:	Select Galley By ID
-- =============================================
CREATE PROCEDURE [dbo].[selectGalleryByID] 
	-- Add the parameters for the stored procedure here
	@galleryID int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT * from Gallery where ID = @galleryID 
END
GO
