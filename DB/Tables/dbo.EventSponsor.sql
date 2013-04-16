CREATE TABLE [dbo].[EventSponsor]
(
[EventID] [int] NOT NULL,
[SponsorID] [int] NOT NULL
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[EventSponsor] ADD CONSTRAINT [FK_EventSponsor_Event] FOREIGN KEY ([EventID]) REFERENCES [dbo].[Event] ([ID]) ON DELETE CASCADE ON UPDATE CASCADE
GO
ALTER TABLE [dbo].[EventSponsor] ADD CONSTRAINT [FK_EventSponsor_Sponsor] FOREIGN KEY ([SponsorID]) REFERENCES [dbo].[Sponsor] ([ID]) ON DELETE CASCADE ON UPDATE CASCADE
GO
