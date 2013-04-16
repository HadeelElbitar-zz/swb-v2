SET QUOTED_IDENTIFIER ON
GO
SET ANSI_NULLS ON
GO
-- =============================================
-- Author:		Manar yousry
-- Create date: 29/3/2013
-- Description:	GetText
-- =============================================
create PROCEDURE [dbo].[GetStaticPages] 
	-- Add the parameters for the stored procedure here
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT * from StaticPage
END
GO
