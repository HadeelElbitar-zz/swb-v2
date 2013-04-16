CREATE TABLE [dbo].[College]
(
[ID] [int] NOT NULL IDENTITY(1, 1),
[Name] [nchar] (255) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
[Location] [nchar] (255) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
[Comments] [nvarchar] (max) COLLATE SQL_Latin1_General_CP1_CI_AS NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
ALTER TABLE [dbo].[College] ADD CONSTRAINT [PK_College] PRIMARY KEY CLUSTERED  ([ID]) ON [PRIMARY]
GO
