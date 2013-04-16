SET QUOTED_IDENTIFIER ON
GO
SET ANSI_NULLS ON
GO
-- =============================================
-- Author:		Abdallah
-- Create date: 28 - 3 - 2013
-- Description:	Select gallery
-- =============================================
create PROCEDURE [dbo].[getEventGallery] 
	-- Add the parameters for the stored procedure here
	@eventID int,
	@Type nvarchar(20)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT * from Gallery where EventID = @eventID and Type = @Type
END
GO
