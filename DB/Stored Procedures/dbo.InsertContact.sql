SET QUOTED_IDENTIFIER ON
GO
SET ANSI_NULLS ON
GO
-- =============================================
-- Author:		Manar yousry
-- Create date: 29/3/2013
-- Description:	Insert
-- =============================================
CREATE PROCEDURE [dbo].[InsertContact]
	-- Add the parameters for the stored procedure here
	@ContactName nvarchar(250),
	@ContactEmail nvarchar(250),
	@ContactSubject nvarchar(250),
	@ContactMessage nvarchar(250)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	insert into ContactUs( Name, Email, Subject, Message )
    Values(@ContactMessage,@ContactEmail,@ContactSubject,@ContactMessage)
END
GO
