SET QUOTED_IDENTIFIER ON
GO
SET ANSI_NULLS ON
GO
-- =============================================
-- Author:		Alhassan Nageh
-- Create date: 4/4/13
-- Description:	Basics
-- =============================================
CREATE PROCEDURE [dbo].[GetHRSeenComments] 
	-- Add the parameters for the stored procedure here

 
AS
BEGIN
Select * from Participant where HRComments like 'Result:%'
END
GO
