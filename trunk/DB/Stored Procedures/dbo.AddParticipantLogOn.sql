SET QUOTED_IDENTIFIER ON
GO
SET ANSI_NULLS ON
GO
-- =============================================
-- Author:		Alhassan Nageh
-- Create date: 4/4/13
-- Description:	Basics
-- =============================================
Create PROCEDURE [dbo].[AddParticipantLogOn] 
	-- Add the parameters for the stored procedure here
@Barcode nvarchar (max),
@LogState bit
 
AS
BEGIN
 	update Participant set LogOn = @LogState where Barcode=@Barcode;
END
GO
