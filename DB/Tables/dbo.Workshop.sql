CREATE TABLE [dbo].[Workshop]
(
[ID] [int] NOT NULL IDENTITY(1, 1),
[Name] [nchar] (10) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
[EventID] [int] NOT NULL,
[Comments] [nvarchar] (max) COLLATE SQL_Latin1_General_CP1_CI_AS NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
ALTER TABLE [dbo].[Workshop] ADD CONSTRAINT [PK_Workshops] PRIMARY KEY CLUSTERED  ([ID]) ON [PRIMARY]
GO
