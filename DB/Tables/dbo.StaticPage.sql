CREATE TABLE [dbo].[StaticPage]
(
[ID] [int] NOT NULL IDENTITY(1, 1),
[Name] [nchar] (255) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
[Content] [nvarchar] (max) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
ALTER TABLE [dbo].[StaticPage] ADD CONSTRAINT [PK_Static_page] PRIMARY KEY CLUSTERED  ([ID]) ON [PRIMARY]
GO
