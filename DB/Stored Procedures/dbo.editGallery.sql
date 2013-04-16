SET QUOTED_IDENTIFIER ON
GO
SET ANSI_NULLS ON
GO
-- =============================================
-- Author:		Abdallah
-- Create date: 28 - 3 - 2013
-- Description:	edit gallery
-- =============================================
CREATE PROCEDURE [dbo].[editGallery] 
	-- Add the parameters for the stored procedure here
	@eventID int,
	@galleryID int,	
	@name nvarchar(MAX),
	@type nvarchar(MAX),
	@location nvarchar(MAX),
	@comments nvarchar (MAX)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	UPDATE Gallery
SET  Name = @name, Type = @type, Location = @location,Comments=@comments
where ID = @galleryID
END
GO
