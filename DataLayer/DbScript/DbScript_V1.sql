--added on 10-01-2024 by PP-------------------------------------------START---------------------------------------------

CREATE DATABASE ConnexcelDB

IF NOT EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_SCHEMA = 'dbo' AND TABLE_NAME = 'UserMst')
BEGIN 
	CREATE TABLE UserMst(
			Id int identity(1,1) primary key NOT NULL,
			IsActive bit NOT NULL,
			IsDelete bit NOT NULL,
			CreatedBy int NOT NULL,
			UpdatedBy int NOT NULL,
			CreatedDate	datetime NOT NULL,
			UpdatedDate	datetime NOT NULL,
			UserType nvarchar(50) NOT NULL,
			FirstName nvarchar(50) NOT NULL,
			LastName nvarchar(50) NOT NULL,
			PhoneNo	nvarchar(30) NOT NULL,
			Email nvarchar(50) NOT NULL,
			DefaultRate	decimal(10,3) NOT NULL,
			TimeZone nvarchar(50) NOT NULL,
			Localization nvarchar(50) NOT NULL,
			GuardianName nvarchar(100) NULL,
			GuardianPhone nvarchar(30) NULL,
			Password nvarchar(Max) NOT NULL,
			SchoolYearGroup	nvarchar(50)  NULL,
			DateofBirth	datetime  NULL,
			School	nvarchar(100)  NULL,
			UseableHours nvarchar(50)  NULL,
			HourlyRate nvarchar(50)  NULL,
			PlatformPreference nvarchar(50)  NULL,
			PlatformLink nvarchar(Max) NULL,
			LastLogin datetime  NULL
	        );
PRINT 'UserMst Table Created' 
END
ELSE
BEGIN 
	PRINT 'UserMst Table Already Exist' 
END

IF NOT EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_SCHEMA = 'dbo' AND  
			TABLE_NAME = 'TutorOfferingDetails')
BEGIN 
	CREATE TABLE dbo.TutorOfferingDetails(
		    Id int identity(1,1) primary key NOT NULL,
			IsActive bit NOT NULL,
			IsDelete bit NOT NULL,
			CreatedBy int NOT NULL,
			UpdatedBy int NOT NULL,
			CreatedDate	datetime NOT NULL,
			UpdatedDate	datetime NOT NULL,
			TutorId	int NOT NULL,
			Subject	nvarchar(100) NOT NULL,
			AgeGroup nvarchar(50) NOT NULL,
			HourlyRate nvarchar(50) NOT NULL
			);
	PRINT 'TutorOfferingDetails Table Created' 
END
ELSE
BEGIN 
	PRINT 'TutorOfferingDetails Table Already Exist' 
END


IF NOT EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_SCHEMA = 'dbo' AND  
			TABLE_NAME = 'TokenMst')
BEGIN 
	CREATE TABLE dbo.TokenMst(
		    Id int identity(1,1) primary key NOT NULL,
	        CreatedDate datetime NOT NULL,
			UpdatedDate datetime NULL,
			UserId int NOT NULL,
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


--added on 10-01-2024 by PP-------------------------------------------END-----------------------------------------------
--executed on local by PP on 10-01-2024---------------------------------------------------------------------------------

--added on 12-01-2024 by PP-------------------------------------------START---------------------------------------------

IF NOT EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_SCHEMA = 'dbo' AND TABLE_NAME = 'CourseMst')
BEGIN 
	CREATE TABLE CourseMst(
			Id int identity(1,1) primary key NOT NULL,
			IsActive bit NOT NULL,
			IsDelete bit NOT NULL,
			CreatedBy int NOT NULL,
			UpdatedBy int NOT NULL,
			CreatedDate	datetime NOT NULL,
			UpdatedDate	datetime NOT NULL,
			CourseType nvarchar(50) NOT NULL,
			NoofLessons	nvarchar(50) NOT NULL,
			StartDate datetime NOT NULL,
			EndDate	datetime NOT NULL,
			StudentDefaultRate	decimal(10,3) NOT NULL,
			CourseName nvarchar(100) NOT NULL,
			Frequency nvarchar(50) NOT NULL,
			Subject	nvarchar(100) NOT NULL,
			Tutors nvarchar(100) NOT NULL,
			CourseStatus nvarchar(50) NULL,
			CourseConversion nvarchar(50) NULL
	        );
PRINT 'CourseMst Table Created' 
END
ELSE
BEGIN 
	PRINT 'CourseMst Table Already Exist' 
END

--added on 12-01-2024 by PP-------------------------------------------END-----------------------------------------------
--executed on local by PP on 12-01-2024---------------------------------------------------------------------------------