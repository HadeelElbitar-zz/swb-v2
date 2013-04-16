SET QUOTED_IDENTIFIER ON
GO
SET ANSI_NULLS ON
GO
-- =============================================
-- Author:		Alhassan Nageh
-- Create date: 4/4/13
-- Description:	Basics
-- =============================================
CREATE PROCEDURE [dbo].[GetParticipantLogOn] 
	-- Add the parameters for the stored procedure here
@Barcode nvarchar (max)
 
AS
BEGIN
 	select LogOn from Participant where Barcode=@Barcode;
END
GO
