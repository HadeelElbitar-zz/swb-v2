CREATE TABLE [dbo].[ContactUs]
(
[ID] [int] NOT NULL IDENTITY(1, 1),
[Name] [nchar] (250) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
[Email] [nchar] (250) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
[Subject] [nchar] (250) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
[Message] [nvarchar] (max) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
ALTER TABLE [dbo].[ContactUs] ADD CONSTRAINT [PK_ContactUs] PRIMARY KEY CLUSTERED  ([ID]) ON [PRIMARY]
GO
