


-- DROP TABLE Contact 
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Contact]') AND type in (N'U'))
BEGIN
	CREATE TABLE dbo.Contact (
	[ContactId] [int] IDENTITY(1,1) NOT NULL PRIMARY KEY,
		FirstName NVARCHAR(256) NULL,
		LastName NVARCHAR(256) NULL,
		Email NVARCHAR(256) NULL,
		PhoneNumber NVARCHAR(256) NULL
	);
END;
GO

IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID('sp_ContactInsert') AND type in (N'P'))
BEGIN
	DROP PROCEDURE sp_ContactInsert;
END;
GO

CREATE PROCEDURE sp_ContactInsert
	@FirstName NVARCHAR(256) = NULL,
	@LastName NVARCHAR(256) = NULL,
	@Email NVARCHAR(256) = NULL,
	@PhoneNUmber NVARCHAR(256) = NULL
AS
BEGIN
/*
	EXEC sp_ContactInsert @FirstName='first', @LastName='last'

	SELECT * FROM Contact;
*/

	INSERT INTO Contact (FirstName, LastName, Email, PhoneNumber)
	VALUES (@FirstName, @LastName, @Email, @PhoneNUmber);
	
	SELECT CONVERT(INT, SCOPE_IDENTITY()) [ContactId];

END;
GO


IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID('sp_ContactUpdate') AND type in (N'P'))
BEGIN
	DROP PROCEDURE sp_ContactUpdate;
END;
GO

CREATE PROCEDURE sp_ContactUpdate
	@ContactId INT,
	@FirstName NVARCHAR(256) NULL,
	@LastName NVARCHAR(256) NULL,
	@Email NVARCHAR(256) NULL,
	@PhoneNUmber NVARCHAR(256) NULL
AS
BEGIN

	UPDATE Contact 
	SET
		FirstName = @FirstName,
		LastName = @LastName,
		Email = @Email,
		PhoneNumber = @PhoneNUmber
	WHERE ContactId = @ContactId;

END;
GO


IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID('sp_ContactDelete') AND type in (N'P'))
BEGIN
	DROP PROCEDURE sp_ContactDelete;
END;
GO

CREATE PROCEDURE sp_ContactDelete
	@ContactID	INT
AS
BEGIN

	DELETE FROM Contact WHERE ContactId = @ContactId;

END;
GO


IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID('sp_Contact') AND type in (N'P'))
BEGIN
	DROP PROCEDURE sp_Contact;
END;
GO

CREATE PROCEDURE sp_Contact
	@ContactID	INT
AS
BEGIN

	SELECT ContactId, FirstName, LastName, Email, PhoneNumber 
	FROM Contact
	WHERE ContactId = @ContactId;

END;
GO
