SET QUOTED_IDENTIFIER ON
GO
SET ANSI_NULLS ON
GO
-- =============================================
-- Author:		Manar yousry
-- Create date: 29/3/2013
-- Description:	Edit
-- =============================================
CREATE PROCEDURE [dbo].[EditText] 
	-- Add the parameters for the stored procedure here
	@ID int ,
	@Name nvarchar (max) ,
	@text nvarchar(max)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	UPDATE StaticPage
	
    SET Content=@text, Name=@Name
    where(ID = @ID)
END
GO
