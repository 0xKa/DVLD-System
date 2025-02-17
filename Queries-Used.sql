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

SELECT * FROM vPeople
ORDER BY ID DESC;

--Get User by username and password for login
SELECT * FROM [User] WHERE Username = 'Admin' AND Password = '1234';

--change password
UPDATE [dbo].[User] SET [Password] = '1234' WHERE Username = 'Admin';

--CREATE VIEW vUsers AS
SELECT [User].ID, vPeople.ID AS PersonID, vPeople.FullName AS 'Full Name', [User].Username, [User].IsActive AS 'Active Status'
FROM [User] JOIN vPeople ON vPeople.ID = [User].PersonID;

SELECT * FROM vUsers ORDER BY ID DESC;
SELECT * FROM [User];


--change application status
UPDATE [Application] SET [Status] = 1 WHERE [ID] = 1;



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

SELECT * FROM vLocalLicenseApplications 
ORDER BY ApplicationDate DESC;

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
AND [LicenseClass].ID = 1;


--Get passed tests of the LL Application
SELECT PassedTests FROM vLocalLicenseApplications WHERE ID = 1;


--CREATE VIEW vTestAppointments AS
SELECT [TestAppointment].ID, 
[vLocalLicenseApplications].ID AS LLApplicationID,
[TestType].Title AS TestType,
[TestAppointment].AppointmentDate,
[vLocalLicenseApplications].FullName,
[vLocalLicenseApplications].LicenseClass,
[TestAppointment].PaidFees,
[TestAppointment].IsLocked
FROM TestAppointment
JOIN vLocalLicenseApplications ON vLocalLicenseApplications.ID = TestAppointment.LocalLicenseApplicationID 
JOIN TestType ON TestType.ID = TestAppointment.TestTypeID

SELECT * FROM vTestAppointments
ORDER BY AppointmentDate DESC;

--Get the Last Test Appointment of a certain applicaton
SELECT TOP(1)* FROM TestAppointment
WHERE TestTypeID = 1 
AND LocalLicenseApplicationID = 1
ORDER BY ID DESC;

--Get all/any Test Appointments for a cerain application 
SELECT ID, AppointmentDate, PaidFees, IsLocked FROM TestAppointment 
WHERE LocalLicenseApplicationID = 1 AND TestTypeID = 1
ORDER BY ID DESC;

--Check if the application has passed the test
SELECT 1 FROM Test 
JOIN TestAppointment ON TestAppointment.ID = Test.TestAppointmentID
WHERE LocalLicenseApplicationID = 1 AND TestTypeID = 1 AND Result = 1;

--Check if the application have any active test
SELECT 1 FROM TestAppointment 
WHERE TestTypeID = 111 AND IsLocked = 0  AND LocalLicenseApplicationID = 111

--check if the application last test was faild
SELECT 1 FROM Test 
JOIN TestAppointment ON TestAppointment.ID = Test.TestAppointmentID
WHERE LocalLicenseApplicationID = 1 AND TestTypeID = 1 AND Result = 0;

--Gets the test trials for a specific test type 
SELECT COUNT(*) FROM TestAppointment 
WHERE LocalLicenseApplicationID = 1 AND TestTypeID = 1;

--Check if Appointment is locked
SELECT 1 FROM TestAppointment WHERE IsLocked = 1 AND ID = 2;

--CREATE VIEW vDrivers AS
SELECT Driver.ID, vPeople.ID AS PersonID, vPeople.NationalNo, vPeople.FullName, Driver.CreatedDate,
(SELECT COUNT(License.ID) FROM License WHERE License.DriverID = Driver.ID AND License.IsActive = 1) AS ActiveLicenses
FROM Driver
JOIN vPeople ON vPeople.ID = Driver.PersonID

SELECT * FROM vDrivers;

--Deactivate a License
UPDATE License SET IsActive = 0 WHERE ID = 5;

--check is a driver has an Active license of a certain class
SELECT 1 FROM License WHERE IsActive = 1 AND DriverID = 2 AND LicenseClassID = 7;

--Link a new ApplicationID with LocalApplicationID (this for renew and replacement applications)
UPDATE LocalLicenseApplication SET ApplicationID = 27 WHERE ApplicationID = 20;

--Get all local licenses of a certain driver
SELECT License.ID, ApplicationID, LicenseClass.Title AS LicenseClass, IssueDate, ExpirationDate, IsActive
FROM License JOIN LicenseClass ON LicenseClass.ID = License.LicenseClassID
WHERE DriverID = 1 ORDER BY IsActive DESC, License.ID DESC;

--Get all international licenses of a certain driver
SELECT ID, ApplicationID, LocalLicenseID, IssueDate, ExpirationDate, IsActive
FROM InternationalLicense WHERE DriverID = 1 ORDER BY IsActive DESC, ID DESC;


--CREATE VIEW vDetainedLicenses AS
SELECT DetainedLicense.ID, LicenseID, DetainDate, FineFees, vDrivers.NationalNo, vDrivers.FullName,
IsReleased, ReleaseApplicationID, ReleasedDate
FROM DetainedLicense 
JOIN License ON License.ID = DetainedLicense.LicenseID
JOIN vDrivers ON vDrivers.ID = License.DriverID;

SELECT * FROM vDetainedLicenses ORDER BY ID DESC;

--check if license is detained
SELECT 1 FROM DetainedLicense WHERE LicenseID = 17 AND IsReleased = 0;



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

