CREATE ROLE [aspnet_Roles_BasicAccess]
AUTHORIZATION [C345526_bondo2]
GO
EXEC sp_addrolemember N'aspnet_Roles_BasicAccess', N'aspnet_Roles_FullAccess'
GO
