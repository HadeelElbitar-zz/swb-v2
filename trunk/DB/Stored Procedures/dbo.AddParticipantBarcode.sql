SET QUOTED_IDENTIFIER ON
GO
SET ANSI_NULLS ON
GO
-- =============================================
-- Author:		Alhassan Nageh
-- Create date: 4/4/13
-- Description:	Basics
-- =============================================
CREATE PROCEDURE [dbo].[AddParticipantBarcode] 
	-- Add the parameters for the stored procedure here
@Barcode nvarchar (max),
@ID int
 
AS
BEGIN
 	update Participant set Barcode = @Barcode where Participant.ID=@ID;
END
GO
