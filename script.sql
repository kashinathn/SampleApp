USE master
GO

IF (EXISTS (SELECT name FROM master.dbo.sysdatabases WHERE ('[' + name + ']' = 'SampleApp' OR name = 'SampleApp')))
begin	
	ALTER DATABASE [SampleApp] SET  SINGLE_USER WITH ROLLBACK IMMEDIATE
	DROP DATABASE SampleApp 
end
GO

CREATE DATABASE SampleApp
GO

USE [SampleApp]
GO

if exists (select 1 from INFORMATION_SCHEMA.TABLES where TABLE_NAME='User')
	DROP TABLE [dbo].[User]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[User](
	[UserId] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](100) NOT NULL,
	[EmailAddress] [varchar](100) NOT NULL,
	[AddressLine1] [varchar](100) NULL,
	[AddressLine2] [varchar](100) NULL,
	[PostCode] [varchar](10) NULL,
	[CreatedDate] [datetime] not NULL default getdate()
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

insert into [User] (Name,EmailAddress,AddressLine1,AddressLine2,PostCode)
values ('User 1','user1@email.com','Addr1','Addr2','SL3 7GQ')
		,('User 2','user2@email.com','Addr1','Addr2','SL3 7GQ') 
		,('User 3','user3@email.com','Addr1','Addr2','SL3 7GQ') 
		,('User 4','user4@email.com','Addr1','Addr2','SL3 7GQ') 
		,('User 5','user5@email.com','Addr1','Addr2','SL3 7GQ') 
go


select * from [User] 
go

