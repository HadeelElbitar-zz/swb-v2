SET QUOTED_IDENTIFIER ON
GO
SET ANSI_NULLS ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[UpdateMember]
	-- Add the parameters for the stored procedure here
	@ID int,@fullname nvarchar(max), 
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
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	Update Member
	Set 	FullName = @fullname,
	Mobile = @Mobile,
	HomePhone = @HomePhone,
	Email = @Email, 
	CommitteeID = @CommitteeID,
	CollegeID = @CollegeID,
	UniversityID = @UniversityID,
	PositionID = @PositionID,
	Member.state = @state , 
	Member.Address = @address , 
	HireYear = @hiredate ,
	Birthdate = @BirthDate, 
	ProfilePicture = @ProfilePicture , 
	Comments = @Comments 
	where ID= @ID;
END
GO
