SET QUOTED_IDENTIFIER ON
GO
SET ANSI_NULLS ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[AddMember]
	-- Add the parameters for the stored procedure here
	@fullname nvarchar(max), 
	@Mobile nvarchar(11), 
	@HomePhone nvarchar(10),
	@Email nvarchar,
	@CommitteeID int
	,@CollegeID int
	,@UniversityID int
	,@PositionID int
	,@state nchar(20), 
	@address nvarchar, 
	@hiredate datetime, 
	@BirthDate datetime, 
	@ProfilePicture nvarchar, 
	@Comments nvarchar = null
	 
AS
BEGIN
    
	Insert Into Member (
FullName,
Mobile,
HomePhone
,Email
,CommitteeID
,CollegeID
,UniversityID
,PositionID
,state
,Address
,HireYear
,Birthdate
,ProfilePicture
,Comments
)
	Values (@Fullname,
	 @Mobile,
	 @HomePhone,
	 @Email,
	 @CommitteeID
	,@CollegeID
	,@UniversityID
	,@PositionID
	 ,@state,
	 @address, 
	 @hiredate, 
	 @BirthDate, 
	 @ProfilePicture, 
	 @Comments
	 );
	
END
GO
