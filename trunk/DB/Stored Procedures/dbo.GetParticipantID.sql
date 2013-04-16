SET QUOTED_IDENTIFIER ON
GO
SET ANSI_NULLS ON
GO
-- =============================================
-- Author:		Alhassan Nageh
-- Create date: 4/4/13
-- Description:	Basics
-- =============================================
create PROCEDURE [dbo].[GetParticipantID] 
	-- Add the parameters for the stored procedure here
@Mobile nvarchar (max)
	 
AS
BEGIN
   
	 select ID from Participant where Mobile = @Mobile
END
GO
