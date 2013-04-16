CREATE ROLE [aspnet_Profile_ReportingAccess]
AUTHORIZATION [C345526_bondo2]
GO
EXEC sp_addrolemember N'aspnet_Profile_ReportingAccess', N'aspnet_Profile_FullAccess'
GO
