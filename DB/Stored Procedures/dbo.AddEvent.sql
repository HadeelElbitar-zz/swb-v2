SET QUOTED_IDENTIFIER ON
GO
SET ANSI_NULLS ON
GO
-- =============================================
-- Author:		Alhassan Nageh
-- Create date: 29/3/2013
-- Description:	Insert New Event
-- =============================================
CREATE PROCEDURE [dbo].[AddEvent] 
	-- Add the parameters for the stored procedure here
	@Name nvarchar(max)
      ,@StartDate DateTime
      ,@EndDate DateTime
      ,@Description nvarchar(max)
      ,@ShortDescription nvarchar(max)
      ,@Comments nvarchar(max) = null
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	insert into Event( [Name]
      ,[StartDate]
      ,[EndDate]
      ,[Description]
      ,[ShortDescription]
      ,[Comments] )
	Values(@Name
      ,@StartDate
      ,@EndDate
      ,@Description
      ,@ShortDescription
      ,@Comments)
END
GO
