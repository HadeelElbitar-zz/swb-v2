SET QUOTED_IDENTIFIER ON
GO
SET ANSI_NULLS ON
GO
-- =============================================
-- Author:		Alhassan Nageh
-- Create date: 4/4/13
-- Description:	Basics
-- =============================================
CREATE PROCEDURE [dbo].[GetHRSeenComment] 
	-- Add the parameters for the stored procedure here
@Type nvarchar (Max)
 
AS
BEGIN
Select * from Participant where HRComments like @Type+'%'
END
GO
