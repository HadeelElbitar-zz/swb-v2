CREATE TABLE [dbo].[Participant]
(
[ID] [int] NOT NULL IDENTITY(1, 1),
[FullName] [nchar] (255) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
[Mobile] [nchar] (20) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
[Email] [nchar] (255) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
[HomePhone] [nchar] (20) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
[CollegeID] [int] NOT NULL,
[UniverstyID] [int] NOT NULL,
[WorkshopID] [int] NULL,
[InterviewID] [int] NULL,
[EventID] [int] NOT NULL,
[Barcode] [nvarchar] (100) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
[Comments] [nvarchar] (max) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
[timestamp] [datetime] NOT NULL,
[PRID] [int] NULL,
[LogOn] [bit] NULL,
[HRComments] [nvarchar] (max) COLLATE SQL_Latin1_General_CP1_CI_AS NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
ALTER TABLE [dbo].[Participant] ADD CONSTRAINT [PK_Participiants] PRIMARY KEY CLUSTERED  ([ID]) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Participant] ADD CONSTRAINT [FK_Participant_Member] FOREIGN KEY ([PRID]) REFERENCES [dbo].[Member] ([ID])
GO
