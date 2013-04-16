CREATE TABLE [dbo].[Member]
(
[ID] [int] NOT NULL IDENTITY(1, 1),
[FullName] [nvarchar] (max) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
[Mobile] [nchar] (12) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
[HomePhone] [nchar] (10) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
[Email] [nvarchar] (max) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
[CommitteeID] [int] NOT NULL,
[CollegeID] [int] NOT NULL,
[UniversityID] [int] NOT NULL,
[PositionID] [int] NOT NULL,
[state] [nchar] (20) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
[Address] [nvarchar] (max) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
[HireYear] [datetime] NOT NULL,
[Birthdate] [datetime] NOT NULL,
[ProfilePicture] [nvarchar] (max) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
[Comments] [nvarchar] (max) COLLATE SQL_Latin1_General_CP1_CI_AS NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
ALTER TABLE [dbo].[Member] ADD CONSTRAINT [PK_Member] PRIMARY KEY CLUSTERED  ([ID]) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Member] ADD CONSTRAINT [FK_Member_College] FOREIGN KEY ([CollegeID]) REFERENCES [dbo].[College] ([ID]) ON DELETE CASCADE ON UPDATE CASCADE
GO
ALTER TABLE [dbo].[Member] ADD CONSTRAINT [FK_Member_Committee] FOREIGN KEY ([CommitteeID]) REFERENCES [dbo].[Committee] ([ID])
GO
ALTER TABLE [dbo].[Member] ADD CONSTRAINT [FK_Member_Position] FOREIGN KEY ([PositionID]) REFERENCES [dbo].[Position] ([ID])
GO
