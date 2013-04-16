SET QUOTED_IDENTIFIER ON
GO
SET ANSI_NULLS ON
GO
-- =============================================
-- Author:		Alhassan Nageh
-- Create date: 4/4/13
-- Description:	Basics
-- =============================================
create PROCEDURE [dbo].[AddMemberID] 
	-- Add the parameters for the stored procedure here
@ID int ,
@MemberID int
 
AS
BEGIN
 	update Participant set PRID = @MemberID where Participant.ID=@ID;
END
GO
