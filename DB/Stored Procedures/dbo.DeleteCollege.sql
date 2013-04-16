SET QUOTED_IDENTIFIER ON
GO
SET ANSI_NULLS ON
GO
-- =============================================
-- Author:		Alhassan Nageh
-- Create date: 4/4/13
-- Description:	Basics
-- =============================================
CREATE PROCEDURE [dbo].[DeleteCollege]
	-- Add the parameters for the stored procedure here
	@ID int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	delete College where ID=@ID;
	delete UniversityCollege where CollegeID=@ID;
END
GO
