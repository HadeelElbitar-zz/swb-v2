SET QUOTED_IDENTIFIER ON
GO
SET ANSI_NULLS ON
GO
-- =============================================
-- Author:		Alhassan Nageh
-- Create date: 29/3/2013
-- Description:	Get Events Names
-- =============================================
create PROCEDURE [dbo].[GetParticipant] 
	-- Add the parameters for the stored procedure here
	@ID int = 0,
	@Barcode nvarchar (max) = null
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT * from Participant where ID=@ID OR Barcode=@Barcode;
END
GO
