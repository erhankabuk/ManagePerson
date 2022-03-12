GO
CREATE DATABASE ManagePerson
GO
USE [ManagePerson]
GO
CREATE TABLE [dbo].[Persons](
	[Id] [uniqueidentifier] NOT NULL,
	[Gender] [nvarchar](50) NULL,
	[IsAdult] [bit] NOT NULL
	 CONSTRAINT [PK_Persons] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[HumanNames](
	[Id] [uniqueidentifier] NOT NULL,
	[Name] [nvarchar](300) NULL,
	[Family] [nvarchar](50) NULL,
	[Given] [nvarchar](100) NULL,
	[PersonId] [uniqueidentifier] NOT NULL,
 CONSTRAINT [PK_HumanNames] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[ContactPoints](
	[Id] [uniqueidentifier] NOT NULL,
	[System] [nvarchar](20) NOT NULL,
	[Value] [nvarchar](200) NOT NULL,
	[PersonId] [uniqueidentifier] NOT NULL,
	[IsArchive] [bit] NOT NULL,
 CONSTRAINT [PK_ContactPoints] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

INSERT INTO [dbo].[Persons]
       ([Id]
       ,[Gender]
       ,[IsAdult])
VALUES('1B2F6401-63CC-402B-A4D4-08D82CCD102E','Male', '0');
INSERT INTO [dbo].[HumanNames]
       ([Id]
       ,[Name]
       ,[Family]
       ,[Given]
       ,[PersonId])
VALUES('0CB46913-2CEC-4F8C-21F2-08D875B7E35C', 'Rani  S',	'S', 'Rani','1B2F6401-63CC-402B-A4D4-08D82CCD102E');
INSERT INTO [dbo].[ContactPoints]
      ([Id]
      ,[System]
      ,[Value]
      ,[PersonId]
      ,[IsArchive])
VALUES('BD8195C0-FA70-4EE0-6D7E-08D8377D5EF4',	'Email', 'reddy@yopmail.com','1B2F6401-63CC-402B-A4D4-08D82CCD102E', '0');
INSERT INTO [dbo].[ContactPoints]
      ([Id]
      ,[System]
      ,[Value]
      ,[PersonId]
      ,[IsArchive])
VALUES('597DDB3A-79C9-49E4-536E-08D8556E4BE8',	'Phone', '+919925516002','1B2F6401-63CC-402B-A4D4-08D82CCD102E', '0');