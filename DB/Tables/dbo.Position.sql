CREATE TABLE [dbo].[Position]
(
[ID] [int] NOT NULL IDENTITY(1, 1),
[Name] [nchar] (10) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
[Comments] [nvarchar] (max) COLLATE SQL_Latin1_General_CP1_CI_AS NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
ALTER TABLE [dbo].[Position] ADD CONSTRAINT [PK_Position] PRIMARY KEY CLUSTERED  ([ID]) ON [PRIMARY]
GO
