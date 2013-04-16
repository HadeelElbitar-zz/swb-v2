SET QUOTED_IDENTIFIER ON
GO
SET ANSI_NULLS ON
GO
-- =============================================
-- Author:		Abdallah
-- Create date: 28 - 3 - 2013
-- Description:	Delete
-- =============================================
CREATE PROCEDURE [dbo].[deleteGallery] 
	-- Add the parameters for the stored procedure here
	@galleryID int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	delete from Gallery
where Id = @galleryID
END
GO
