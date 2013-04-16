SET QUOTED_IDENTIFIER ON
GO
SET ANSI_NULLS ON
GO
-- =============================================
-- Author:		Gemi
-- Create date: 28/3/2013
-- Description:	Sponsor Edit
-- =============================================
CREATE PROCEDURE [dbo].[UpdateSponsor] 
	-- Add the parameters for the stored procedure here
	@SponsorID int , @SponsorName varchar(max),@SponsorEmail varchar(max),@SponsorWebsite varchar(max),
	@SponsorMobile varchar(max), @SponsorComment varchar(max) 
	
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	
	Update Sponsor
   SET Name = @SponsorName , Website = @SponsorWebsite ,
    Email = @SponsorEmail ,ContactNumber = @SponsorMobile , Comments = @SponsorComment
    where ID = @SponsorID
END
GO
