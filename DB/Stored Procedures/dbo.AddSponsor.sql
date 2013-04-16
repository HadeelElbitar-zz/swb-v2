SET QUOTED_IDENTIFIER ON
GO
SET ANSI_NULLS ON
GO
-- =============================================
-- Author:		Gemi
-- Create date: 28/3/2013
-- Description:	Insert New
-- =============================================
CREATE PROCEDURE [dbo].[AddSponsor] 
	-- Add the parameters for the stored procedure here
    @SponsorName varchar(max),
    @SponsorEmail varchar(max),
    @SponsorWebsite varchar(max),
	@SponsorMobile varchar(max), 
	@SponsorComment varchar(max) = null
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	INSERT INTO Sponsor (Name, Website, Email,ContactNumber,Comments)  
    VALUES (@SponsorName, @SponsorWebsite,@SponsorEmail, @SponsorMobile,@SponsorComment);
END
GO
