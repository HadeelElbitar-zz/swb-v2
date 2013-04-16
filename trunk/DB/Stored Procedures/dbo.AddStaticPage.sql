SET QUOTED_IDENTIFIER ON
GO
SET ANSI_NULLS ON
GO
-- =============================================
-- Author:		Manar yousry
-- Create date: 29/3/2013
-- Description:	Add
-- =============================================
Create PROCEDURE [dbo].[AddStaticPage]
	-- Add the parameters for the stored procedure her
	@name nvarchar(max),
	@text nvarchar(max) 
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	insert into StaticPage(Name,content)
	values(@name,@text)
END
GO
