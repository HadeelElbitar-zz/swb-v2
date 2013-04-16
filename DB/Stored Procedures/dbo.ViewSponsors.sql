SET QUOTED_IDENTIFIER ON
GO
SET ANSI_NULLS ON
GO
-- =============================================
-- Author:		GEMI
-- Create date: 29/3/2013
-- Description:	Sponsor View
-- =============================================
CREATE PROCEDURE [dbo].[ViewSponsors] 
	-- Add the parameters for the stored procedure here
	
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT     dbo.Sponsor.ID, dbo.Event.Name, dbo.Event.StartDate, dbo.Event.EndDate, dbo.Workshop.Name AS Expr1, dbo.Workshop.EventID, dbo.Workshop.Comments, dbo.Sponsor.Name AS Expr2
FROM         dbo.Sponsor INNER JOIN
                      dbo.Event ON dbo.Sponsor.ID = dbo.Event.ID INNER JOIN
                      dbo.Workshop ON dbo.Sponsor.ID = dbo.Workshop.ID
END
GO
