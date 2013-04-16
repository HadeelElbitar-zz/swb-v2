SET QUOTED_IDENTIFIER ON
GO
SET ANSI_NULLS ON
GO
-- =============================================
-- Author:		Alhassan Nageh
-- Create date: 4/4/13
-- Description:	Basics
-- =============================================
create PROCEDURE [dbo].[EditCommittee]
	-- Add the parameters for the stored procedure here
	@ID int,
	@Name nvarchar (max),
	@Description nvarchar (max)=null
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	update Committee set Name=@Name, Description=@Description where ID=@ID
END
GO
