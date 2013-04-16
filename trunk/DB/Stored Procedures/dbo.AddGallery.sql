SET QUOTED_IDENTIFIER ON
GO
SET ANSI_NULLS ON
GO
-- =============================================
-- Author:		Abdallah
-- Create date: 28 - 3 - 2012
-- Description:	Add Gallery
-- =============================================
CREATE PROCEDURE [dbo].[AddGallery] 
	-- Add the parameters for the stored procedure here
	@eventID int,
	@name nvarchar(MAX),
	@type nvarchar(MAX),
	@location nvarchar(MAX),
	@comments nvarchar (MAX) = null
	
	
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	insert into Gallery( EventID, Name, Type, Location, Comments )
Values(@eventID,@name,@type,@location,@comments)
END
GO
