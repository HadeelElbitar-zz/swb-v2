SET QUOTED_IDENTIFIER ON
GO
SET ANSI_NULLS ON
GO
-- =============================================
-- Author:		Alhassan Nageh
-- Create date: 4/4/13
-- Description:	Basics
-- =============================================
CREATE PROCEDURE [dbo].[AddParticipant] 
	-- Add the parameters for the stored procedure here
@FullName nvarchar (max)
,@Mobile nvarchar (max)
,@Email nvarchar (max)
,@HomePhone nvarchar (max) = null
,@CollegeID int
,@UniverstyID int
,@WorkshopID int = 0
,@InterviewID int = 0
,@EventID int
,@Barcode nvarchar (max) = null
,@Comments nvarchar (max) = null
,@TimeStamp datetime
	 
AS
BEGIN
    
	Insert Into Participant (
FullName
,Mobile
,Email
,HomePhone
,CollegeID
,UniverstyID
,WorkshopID
,InterviewID
,EventID
,Barcode
,Comments
,timestamp
)
	Values (
@FullName
,@Mobile
,@Email
,@HomePhone
,@CollegeID
,@UniverstyID
,@WorkshopID
,@InterviewID
,@EventID
,@Barcode
,@Comments
,@TimeStamp
	 );
END
GO
