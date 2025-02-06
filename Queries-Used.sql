USE [DVLDv2]

--Get All People View
--CREATE VIEW vPeople AS
SELECT 
    Person.ID, 
    Person.NationalNo, 
    FirstName + ' ' + SecondName + 
    CASE 
        WHEN ThirdName IS NOT NULL THEN ' ' + ThirdName 
        ELSE '' 
    END + ' ' + LastName AS FullName,
    CASE
        WHEN Person.Gender = 1 THEN 'Male'
        ELSE 'Female'
    END AS Gender,
    Person.DateOfBirth,
    Country.CountryName AS Nationality, 
    Person.Phone, 
    Person.Email
FROM 
    [Person] 
JOIN 
    [Country] ON Person.NationalityCountryID = Country.ID;

SELECT * FROM vPeople;

--Get User by username and password for login
SELECT * FROM [User] WHERE Username = 'Admin' AND Password = '1234';

--change password
UPDATE [dbo].[User] SET [Password] = '1234' WHERE Username = 'Admin';

--CREATE VIEW vUsers AS
SELECT [User].ID, vPeople.ID AS PersonID, vPeople.FullName AS 'Full Name', [User].Username, [User].IsActive AS 'Active Status'
FROM [User] JOIN vPeople ON vPeople.ID = [User].PersonID;

SELECT * FROM vUsers;
SELECT * FROM [User];


--change application status
UPDATE [Application] SET [Status] = 1 WHERE [ID] = 1;


SELECT * FROM [User] WHERE ID = 8;


SELECT * FROM [Application];


--CREATE VIEW vLocalLicenseApplications AS
SELECT 
	[LocalLicenseApplication].ID,
	[vPeople].NationalNo,
	[vPeople].FullName,
	[LicenseClass].Title,
	[Application].ApplicationDate,
	(
	SELECT COUNT([TestAppointment].TestTypeID) 
	FROM [Test] JOIN [TestAppointment] ON [TestAppointment].ID = [Test].TestAppointmentID
	WHERE [TestAppointment].LocalLicenseApplicationID = [LocalLicenseApplication].ID AND [Test].Result = 1
	) AS PassedTests,
	(CASE
			WHEN [Application].[Status] = 1 THEN 'New'
			WHEN [Application].[Status] = 2 THEN 'Canceled'
			WHEN [Application].[Status] = 3 THEN 'Completed'

	END)
FROM [LocalLicenseApplication]
	JOIN [Application] ON [Application].ID = [LocalLicenseApplication].ApplicationID
	JOIN [LicenseClass] ON [LicenseClass].ID = [LocalLicenseApplication].LicenseClass
	JOIN [vPeople] ON [vPeople].ID = [Application].ApplicantPersonID



SELECT * FROM [Country];
SELECT * FROM [Person];
SELECT * FROM [User];
SELECT * FROM [ApplicationType];
SELECT * FROM [LicenseClass];
SELECT * FROM [Application];
SELECT * FROM [License];
SELECT * FROM [LocalLicenseApplication];
SELECT * FROM [InternationalLicense];
SELECT * FROM [DetainedLicense];
SELECT * FROM [Driver];
SELECT * FROM [TestType];
SELECT * FROM [TestAppointment];
SELECT * FROM [Test];