CREATE TABLE [dbo].[Interview]
(
[ID] [int] NOT NULL IDENTITY(1, 1),
[Time] [nchar] (255) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
[Count] [int] NOT NULL,
[Comment] [nvarchar] (max) COLLATE SQL_Latin1_General_CP1_CI_AS NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
ALTER TABLE [dbo].[Interview] ADD CONSTRAINT [PK_Interview] PRIMARY KEY CLUSTERED  ([ID]) ON [PRIMARY]
GO
