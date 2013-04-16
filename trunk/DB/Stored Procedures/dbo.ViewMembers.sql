SET QUOTED_IDENTIFIER ON
GO
SET ANSI_NULLS ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[ViewMembers]
	
AS
BEGIN
	SET NOCOUNT ON;

	Select Fullname,
	 Mobile,
	 HomePhone,
	 Email,
	 dbo.GetCommitteName(CommitteeID) AS CommitteName,
	 dbo.GetCollegeName(CollegeID)AS CollegeName,
	 dbo.GetUnivName(UniversityID) AS UniversityName,
	 dbo.GetPosName(PositionID) AS PositionName,
	 Member.state,
	 Member.address, 
	 Member.HireYear, 
	 BirthDate, 
	 ProfilePicture, 
	 Comments 
	 from Member ;
END
GO
