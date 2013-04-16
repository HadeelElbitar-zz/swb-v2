SET QUOTED_IDENTIFIER ON
GO
SET ANSI_NULLS ON
GO
-- =============================================
-- Author:		Alhassan Nageh
-- Create date: 4/4/13
-- Description:	Basics
-- =============================================
create PROCEDURE [dbo].[AddHRComments] 
	-- Add the parameters for the stored procedure here
@Barcode nvarchar (max),
@Comments nvarchar (max)
 
AS
BEGIN
 	update Participant set HRComments = @Comments where Barcode=@Barcode;
END
GO
