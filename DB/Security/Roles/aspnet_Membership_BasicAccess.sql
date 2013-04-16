CREATE ROLE [aspnet_Membership_BasicAccess]
AUTHORIZATION [C345526_bondo2]
GO
EXEC sp_addrolemember N'aspnet_Membership_BasicAccess', N'aspnet_Membership_FullAccess'
GO
