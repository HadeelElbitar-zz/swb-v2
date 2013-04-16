SET QUOTED_IDENTIFIER ON
GO
SET ANSI_NULLS ON
GO
-- =============================================
-- Author:		Alhassan Nageh
-- Create date: 4/4/13
-- Description:	Basics
-- =============================================
CREATE PROCEDURE [dbo].[AddCollege] 
	-- Add the parameters for the stored procedure here
	@Name nvarchar (max),
	@location nvarchar (max) = null,
	@Comment nvarchar (max) = null
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	insert into College(Name, Location, Comments) values(@Name, @location, @Comment);
END
GO
