SET QUOTED_IDENTIFIER ON
GO
SET ANSI_NULLS ON
GO
-- =============================================
-- Author:		Alhassan Nageh
-- Create date: 29/3/2013
-- Description:	Get An Event
-- =============================================
CREATE PROCEDURE [dbo].[GetEvent] 
	-- Add the parameters for the stored procedure here
	@ID int = 0
	
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT * from Event where Event.ID = @ID;
	
END
GO
