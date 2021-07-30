-- Database export via SQLPro (https://www.sqlprostudio.com/allapps.html)
-- Exported by camilo at 29-07-2021 17:50.
-- WARNING: This file may contain descructive statements such as DROPs.
-- Please ensure that you are running the script at the proper location.

CREATE DATABASE PruebaTecnica
GO


CREATE TABLE PruebaTecnica.dbo.Build (
	Id int NOT NULL IDENTITY(1,1),
	Name varchar(256) NOT NULL,
	Address varchar(256) NOT NULL,
	Tower varchar(10) NULL,
	[Create] datetime NULL,
	Modify datetime NULL
);
GO

ALTER TABLE PruebaTecnica.dbo.Build ADD CONSTRAINT PK__Build__3214EC07EE330569 PRIMARY KEY (Id);
GO

INSERT INTO PruebaTecnica.dbo.Build (Name, Address, Tower, [Create], Modify) VALUES
('Cactus 12121', 'calle 105555555', '2', NULL, NULL),
('Torre eifel', 'calle 12', '0', NULL, NULL),
( 'Solar', 'calle 3434', '4', NULL, NULL),
('Cactus 4', 'calle 105555555', '2', NULL, NULL),
('Cactus 444', 'calle 105555555', '2', NULL, NULL),
('Alcantara 23', 'calle 43323 carrer23123a', '4', NULL, NULL),
('Alcantara nuevo sector', 'calle 43323 carrera', '4', NULL, NULL),
('Alcantara prueba', 'calle 43323 carrera', '4', NULL, NULL);

-- END TABLE dbo.Build

-- BEGIN TABLE dbo.Departament
IF OBJECT_ID('PruebaTecnica.dbo.Departament', 'U') IS NOT NULL
DROP TABLE PruebaTecnica.dbo.Departament;
GO

CREATE TABLE PruebaTecnica.dbo.Departament (
	Id int NOT NULL IDENTITY(1,1),
	Number varchar(100) NOT NULL,
	[Create] datetime NULL,
	Modify datetime NULL,
	OwerId int NOT NULL,
	BuildId int NOT NULL,
	Price decimal(18,0) NULL,
	[Image] varchar(256) NULL
);
GO

ALTER TABLE PruebaTecnica.dbo.Departament ADD CONSTRAINT PK__Departam__3214EC07BEAC7919 PRIMARY KEY (Id);
GO

-- Inserting 5 rows into dbo.Departament
-- Insert batch #1
INSERT INTO PruebaTecnica.dbo.Departament (Number, [Create], Modify, OwerId, BuildId, Price, [Image]) VALUES
('casa', NULL, NULL, 1, 2, 1212, NULL),
('1905', NULL, NULL, 1, 2, 250000000, NULL),
('33905', NULL, NULL, 1, 2, 250000000, NULL),
('35905', NULL, NULL, 1, 2, 676745, NULL),
('77874', NULL, NULL, 1, 2, 12121, NULL);

-- END TABLE dbo.Departament

-- BEGIN TABLE dbo.Owner
IF OBJECT_ID('PruebaTecnica.dbo.Owner', 'U') IS NOT NULL
DROP TABLE dbo.Owner;
GO

CREATE TABLE PruebaTecnica.dbo.Owner (
	Id int NOT NULL IDENTITY(1,1),
	FullName varchar(256) NOT NULL,
	[Create] datetime NULL,
	Modify datetime NULL,
	Adress varchar(256) NULL,
	Phone varchar(30) NULL
);
GO

ALTER TABLE PruebaTecnica.dbo.Owner ADD CONSTRAINT PK__Owner__3214EC079E82CF50 PRIMARY KEY (Id);
GO

-- Inserting 1 row into dbo.Owner
-- Insert batch #1
INSERT INTO PruebaTecnica.dbo.Owner (FullName, [Create], Modify, Adress, Phone) VALUES
('sdsdsd', NULL, NULL, NULL, NULL);

-- END TABLE dbo.Owner

-- BEGIN TABLE dbo.security
IF OBJECT_ID('PruebaTecnica.dbo.security', 'U') IS NOT NULL
DROP TABLE PruebaTecnica.dbo.security;
GO

CREATE TABLE PruebaTecnica.dbo.security (
	Id int NOT NULL IDENTITY(1,1),
	Name varchar(50) NOT NULL,
	Username varchar(50) NULL,
	Password varchar(200) NOT NULL,
	Code varchar(10) NOT NULL,
	Email varchar(100) NOT NULL,
	[Create] datetime NULL,
	Modify datetime NULL
);
GO

ALTER TABLE PruebaTecnica.dbo.security ADD CONSTRAINT PK__security__3214EC074820AA6B PRIMARY KEY (Id);
GO

-- Inserting 3 rows into dbo.security
-- Insert batch #1
INSERT INTO PruebaTecnica.dbo.security (Name, Username, Password, Code, Email, [Create], Modify) VALUES
('cristian', 'cristian0113', '123', '0113', 'clope@hot.com', NULL, NULL),
('test', 'test123', '$2a$11$T3rp.Kw8Z.ldgoWcgbtgEOrRoP4UtIXpXQhIMnPRmfF3za9T/gpxe', '0111', 'test@hot.com', NULL, NULL),
('test', 'test123', '$2a$11$JHxpN1CxVNPonGD3PdW5r.pqz6jPNUjk3OlFbsrPzKQMq9s5DF07K', '0111', 'testPrueba@hot.com', NULL, NULL);

-- END TABLE dbo.security

IF OBJECT_ID('PruebaTecnica.dbo.Owner', 'U') IS NOT NULL AND OBJECT_ID('PruebaTecnica.dbo.Owner', 'U') IS NOT NULL
	ALTER TABLE PruebaTecnica.dbo.Departament
	ADD CONSTRAINT FK_Departament_Owner
	FOREIGN KEY (OwerId)
	REFERENCES PruebaTecnica.dbo.Owner (Id)
	ON DELETE Cascade
	ON UPDATE Cascade;

IF OBJECT_ID('PruebaTecnica.dbo.Build', 'U') IS NOT NULL AND OBJECT_ID('PruebaTecnica.dbo.Build', 'U') IS NOT NULL
	ALTER TABLE PruebaTecnica.dbo.Departament
	ADD CONSTRAINT FK_Departament_BuildID
	FOREIGN KEY (BuildId)
	REFERENCES PruebaTecnica.dbo.Build (Id);

