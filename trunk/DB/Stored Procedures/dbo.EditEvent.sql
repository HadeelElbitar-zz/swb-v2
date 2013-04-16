SET QUOTED_IDENTIFIER ON
GO
SET ANSI_NULLS ON
GO
-- =============================================
-- Author:		Alhassan Nageh
-- Create date: 29/3/2013
-- Description:	Edit Event
-- =============================================
CREATE PROCEDURE [dbo].[EditEvent] 
	-- Add the parameters for the stored procedure here
	@ID int, 
	@Name nvarchar(max)
      ,@StartDate DateTime
      ,@EndDate DateTime
      ,@Description nvarchar(max)
      ,@ShortDescription nvarchar(max)
      ,@Comments nvarchar(max)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	UPDATE Event
	SET [Name] = @Name
      ,[StartDate] = @StartDate
      ,[EndDate] = @EndDate
      ,[Description] = @Description
      ,[ShortDescription] = @ShortDescription
      ,[Comments] = @Comments
	WHERE Event.ID = @ID
END
GO
