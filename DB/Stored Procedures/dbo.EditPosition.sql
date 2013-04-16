SET QUOTED_IDENTIFIER ON
GO
SET ANSI_NULLS ON
GO
-- =============================================
-- Author:		Alhassan Nageh
-- Create date: 4/4/13
-- Description:	Basics
-- =============================================
CREATE PROCEDURE [dbo].[EditPosition]
	-- Add the parameters for the stored procedure here
	@ID int,
	@Position nvarchar (max),
	@comments nvarchar (max)=null
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	update Position set Name=@Position, Comments=@comments where ID=@ID
END
GO
