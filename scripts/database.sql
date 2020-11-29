USE master
GO

IF EXISTS(SELECT * FROM sys.databases WHERE name='GuildCars')
DROP DATABASE GuildCars
GO

CREATE DATABASE GuildCars
GO