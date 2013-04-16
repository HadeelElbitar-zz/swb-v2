SET QUOTED_IDENTIFIER ON
GO
SET ANSI_NULLS ON
GO
-- =============================================
-- Author:		Alhassan Nageh
-- Create date: 4/4/13
-- Description:	Basics
-- =============================================
CREATE PROCEDURE [dbo].[EditCollege]
	-- Add the parameters for the stored procedure here
	@ID int,
	@Name nvarchar (max),
	@location nvarchar (max)=null,
	@comments nvarchar (max)=null
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	update College set Name=@Name, Location=@location, Comments=@comments where ID=@ID
END
GO
