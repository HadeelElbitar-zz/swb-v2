SET QUOTED_IDENTIFIER ON
GO
SET ANSI_NULLS ON
GO
-- =============================================
-- Author:		Gemi
-- Create date: 28/3/2013
-- Description:	Sponsers Operations
-- =============================================
CREATE PROCEDURE [dbo].[GETSponsors]  
	-- Add the parameters for the stored procedure here
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT * From Sponsor
END
GO
