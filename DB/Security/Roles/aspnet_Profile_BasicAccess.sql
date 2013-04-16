CREATE ROLE [aspnet_Profile_BasicAccess]
AUTHORIZATION [C345526_bondo2]
GO
EXEC sp_addrolemember N'aspnet_Profile_BasicAccess', N'aspnet_Profile_FullAccess'
GO
