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
	[LicenseClass].Title AS LicenseClass,
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

	END) AS ApplicationStatus
FROM [LocalLicenseApplication]
	JOIN [Application] ON [Application].ID = [LocalLicenseApplication].ApplicationID
	JOIN [LicenseClass] ON [LicenseClass].ID = [LocalLicenseApplication].LicenseClassID
	JOIN [vPeople] ON [vPeople].ID = [Application].ApplicantPersonID

SELECT * FROM vLocalLicenseApplications;

--Get Application Type Fees
SELECT Fees FROM ApplicationType WHERE ID = 1;

--Get License Length In Years
SELECT ValidityYears FROM LicenseClass WHERE ID = 1;
--Get Minimum Age for license
SELECT MinimumAge FROM LicenseClass WHERE ID = 1;
--Get license class fees
SELECT Fees FROM LicenseClass WHERE ID = 1;

--Checks if an applicant is not allowed to submit a new application for a specific license class. 
SELECT 1
FROM LocalLicenseApplication
JOIN [Application] ON [Application].ID = [LocalLicenseApplication].ApplicationID
JOIN [LicenseClass] ON [LocalLicenseApplication].LicenseClassID = LicenseClass.ID
WHERE [Application].Status IN (1,3) 
AND [Application].ApplicantPersonID = 1
AND [LicenseClass].ID = 3;


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