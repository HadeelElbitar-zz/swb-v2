CREATE ROLE [aspnet_Personalization_BasicAccess]
AUTHORIZATION [C345526_bondo2]
GO
EXEC sp_addrolemember N'aspnet_Personalization_BasicAccess', N'aspnet_Personalization_FullAccess'
GO
