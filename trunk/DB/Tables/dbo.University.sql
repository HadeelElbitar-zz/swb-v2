CREATE TABLE [dbo].[University]
(
[ID] [int] NOT NULL IDENTITY(1, 1),
[Name] [nvarchar] (max) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
[Location] [nvarchar] (max) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
ALTER TABLE [dbo].[University] ADD CONSTRAINT [PK_University] PRIMARY KEY CLUSTERED  ([ID]) ON [PRIMARY]
GO
