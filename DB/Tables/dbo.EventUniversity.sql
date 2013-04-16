CREATE TABLE [dbo].[EventUniversity]
(
[EventID] [int] NOT NULL,
[UniversityID] [int] NOT NULL
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[EventUniversity] ADD CONSTRAINT [FK_EventUniversity_Event] FOREIGN KEY ([EventID]) REFERENCES [dbo].[Event] ([ID])
GO
ALTER TABLE [dbo].[EventUniversity] ADD CONSTRAINT [FK_EventUniversity_University] FOREIGN KEY ([UniversityID]) REFERENCES [dbo].[University] ([ID]) ON DELETE CASCADE ON UPDATE CASCADE
GO
