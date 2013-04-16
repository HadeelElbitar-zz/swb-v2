SET QUOTED_IDENTIFIER ON
GO
SET ANSI_NULLS ON
GO
-- =============================================
-- Author:		Alhassan Nageh
-- Create date: 4/4/13
-- Description:	Add Many to Many
-- =============================================
CREATE PROCEDURE [dbo].[AddEventUniversity] 
	-- Add the parameters for the stored procedure here
	@UniversityID int = 0, 
	@EventID int = 0
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	insert into EventUniversity(UniversityID, EventID) values(@UniversityID, @EventID)
END
GO
