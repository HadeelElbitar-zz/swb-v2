SET QUOTED_IDENTIFIER ON
GO
SET ANSI_NULLS ON
GO
-- =============================================
-- Author:		Alhassan Nageh
-- Create date: 29/3/2013
-- Description:	Delete Event
-- =============================================
CREATE PROCEDURE [dbo].[DeleteEvent] 
	-- Add the parameters for the stored procedure here
	@ID int = 0
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	delete from Event where ID = @ID;
	delete from Gallery where EventID = @ID;
	delete from EventSponsor where EventID = @ID;
	delete from EventUniversity where EventID = @ID;
END
GO
