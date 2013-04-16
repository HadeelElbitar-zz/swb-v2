CREATE TABLE [dbo].[UniversityCollege]
(
[UniversityID] [int] NOT NULL,
[CollegeID] [int] NOT NULL
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[UniversityCollege] ADD CONSTRAINT [FK_UniversityCollege_College] FOREIGN KEY ([CollegeID]) REFERENCES [dbo].[College] ([ID]) ON DELETE CASCADE ON UPDATE CASCADE
GO
ALTER TABLE [dbo].[UniversityCollege] ADD CONSTRAINT [FK_UniversityCollege_University] FOREIGN KEY ([UniversityID]) REFERENCES [dbo].[University] ([ID]) ON DELETE CASCADE ON UPDATE CASCADE
GO
