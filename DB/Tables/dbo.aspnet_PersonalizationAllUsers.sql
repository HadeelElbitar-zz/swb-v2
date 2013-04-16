CREATE TABLE [dbo].[aspnet_PersonalizationAllUsers]
(
[PathId] [uniqueidentifier] NOT NULL,
[PageSettings] [image] NOT NULL,
[LastUpdatedDate] [datetime] NOT NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
ALTER TABLE [dbo].[aspnet_PersonalizationAllUsers] ADD CONSTRAINT [PK__aspnet_Personali__56B3DD81] PRIMARY KEY CLUSTERED  ([PathId]) ON [PRIMARY]
GO
ALTER TABLE [dbo].[aspnet_PersonalizationAllUsers] ADD CONSTRAINT [FK__aspnet_Pe__PathI__57A801BA] FOREIGN KEY ([PathId]) REFERENCES [dbo].[aspnet_Paths] ([PathId])
GO
