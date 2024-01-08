--added on 08-01-2024 by PP-------------------------------------------START---------------------------------------------

CREATE DATABASE Connexcel


IF NOT EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_SCHEMA = 'dbo' AND TABLE_NAME = 'UserMst')
BEGIN 
	CREATE TABLE UserMst(
			UserID int IDENTITY(1,1) Primary Key NOT NULL,
			IsActive bit NOT NULL,
			IsDelete bit NULL,
			CreatedBy int NOT NULL,
			CreatedDate DateTime NOT NULL,
			UpdatedBy int NULL,
			UpdatedDate DateTime NULL,
			UserType varchar(50) NOT NULL,
			FirstName nvarchar(100) NOT NULL,
			LastName nvarchar(100) NOT NULL,
			PhoneNo  nvarchar(30) NOT NULL,
			EmailId nvarchar(50) NOT NULL,
			DefaultRate nvarchar(50) NOT NULL,
			TimeZone nvarchar(50) NOT NULL,
			Localization nvarchar(50) NOT NULL,
			GuardianName nvarchar(100) NULL,
			GuardianPhoneno nvarchar(30) NULL,
			Password nvarchar(50) NOT NULL,
	);
PRINT 'UserMst Table Created' 
END
ELSE
BEGIN 
	PRINT 'UserMst Table Already Exist' 
END

IF NOT EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_SCHEMA = 'dbo' AND  
			TABLE_NAME = 'TokenMst')
BEGIN 
	CREATE TABLE dbo.TokenMst(
		    TokenId int identity(1,1) primary key NOT NULL,
	        CreatedDate datetime NOT NULL,
			UpdatedDate datetime NULL,
			UserID int NOT NULL,
			Token nvarchar(max) NOT NULL,
			TokenExpiryTime datetime NOT NULL,
			RefreshToken nvarchar(max) NOT NULL,
			RefreshTokenExpiryTime datetime NOT NULL,
			);
	PRINT 'TokenMst Table Created' 
END
ELSE
BEGIN 
	PRINT 'TokenMst Table Already Exist' 
END

--added on 08-01-2024 by PP-------------------------------------------END-----------------------------------------------
--executed on local by PP on 08-01-2024---------------------------------------------------------------------------------
