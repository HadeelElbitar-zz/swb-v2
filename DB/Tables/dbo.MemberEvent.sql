CREATE TABLE [dbo].[MemberEvent]
(
[MemberID] [int] NOT NULL,
[EventID] [int] NOT NULL
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[MemberEvent] ADD CONSTRAINT [FK_MemberEvent_Event] FOREIGN KEY ([EventID]) REFERENCES [dbo].[Event] ([ID]) ON DELETE CASCADE ON UPDATE CASCADE
GO
ALTER TABLE [dbo].[MemberEvent] ADD CONSTRAINT [FK_MemberEvent_Member] FOREIGN KEY ([MemberID]) REFERENCES [dbo].[Member] ([ID]) ON DELETE CASCADE ON UPDATE CASCADE
GO
