-- Database export via SQLPro (https://www.sqlprostudio.com/allapps.html)
-- Exported by camilo at 17-03-2021 11:27.
-- WARNING: This file may contain descructive statements such as DROPs.
-- Please ensure that you are running the script at the proper location.


-- BEGIN TABLE dbo.product
CREATE TABLE dbo.product (
	id int NOT NULL IDENTITY(1,1),
	code varchar(10) NOT NULL,
	name varchar(100) NULL,
	quantity int NOT NULL,
	[value] decimal(18,0) NOT NULL
);
GO

ALTER TABLE dbo.product ADD CONSTRAINT PK__product__3213E83FBEC367F6 PRIMARY KEY (id);
GO

-- Inserting 4 rows into dbo.product
-- Insert batch #1
INSERT INTO dbo.product (id, code, name, quantity, [value]) VALUES
(1, '0113', 'prueba', 10, 50000),
(5, 'cbwcc', 'prueba', 22, 2323),
(6, 'qkvxd', 'repuesto moto', 10, 50000),
(7, 'ibtvu', 'celular xiaomi', 5, 50000);

-- END TABLE dbo.product

-- BEGIN TABLE dbo.sales
CREATE TABLE dbo.sales (
	id int NOT NULL IDENTITY(1,1),
	productId int NOT NULL,
	quantity int NOT NULL,
	total decimal(18,0) NULL
);
GO

ALTER TABLE dbo.sales ADD CONSTRAINT PK__sales__3213E83F718A281B PRIMARY KEY (id);
GO

-- Inserting 4 rows into dbo.sales
-- Insert batch #1
INSERT INTO dbo.sales (id, productId, quantity, total) VALUES
(1, 1, 2, 100),
(2, 5, 22, 51106),
(3, 6, 5, 250000),
(4, 7, 3, 150000);

-- END TABLE dbo.sales

-- BEGIN TABLE dbo.security
CREATE TABLE dbo.security (
	Id int NOT NULL IDENTITY(1,1),
	Name varchar(50) NOT NULL,
	UserName varchar(50) NOT NULL,
	Password varchar(50) NOT NULL,
	Code varchar(10) NOT NULL
);
GO

ALTER TABLE dbo.security ADD CONSTRAINT PK__security__3214EC074820AA6B PRIMARY KEY (Id);
GO

-- Inserting 1 row into dbo.security
-- Insert batch #1
INSERT INTO dbo.security (Id, Name, UserName, Password, Code) VALUES
(1, 'cristian', 'cristian0113', '123', '0113');

-- END TABLE dbo.security

IF OBJECT_ID('dbo.sales', 'U') IS NOT NULL AND OBJECT_ID('dbo.product', 'U') IS NOT NULL
	ALTER TABLE dbo.sales
	ADD CONSTRAINT FK__sales__productId__38996AB5
	FOREIGN KEY (productId)
	REFERENCES dbo.product (id);

