SET QUOTED_IDENTIFIER ON
GO
SET ANSI_NULLS ON
GO
-- =============================================
-- Author:		Alhassan Nageh
-- Create date: 4/4/13
-- Description:	Basics
-- =============================================
CREATE PROCEDURE [dbo].[FirstFormFill] 
	-- Add the parameters for the stored procedure here
@barcode nvarchar (max)
 
AS
BEGIN
Select Barcode from Participant where (HRComments is not null and Barcode =@barcode)
END
GO
