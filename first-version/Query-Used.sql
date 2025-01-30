USE DVLD;


--People Table CRUD
SELECT * FROM People;
SELECT * FROM People WHERE PersonID = 1; 
SELECT * FROM People WHERE NationalNo = 'N0001'; 
SELECT PersonID, FirstName + ' ' + SecondName + ' ' + COALESCE(ThirdName, '') + ' ' + LastName AS FullName FROM People; --note: COALESCE replaces any NULL value with an empty string (''


---INSERT INTO People
--VALUES
--('N0001','Reda','Bassam','Bader','Hilal', '2004-8-6', 0,'Muscat Oman', 91238321, 'reda@hilal.com', 169,null),
--('N5321','Fatima','Ahmed',null,'Khalid', '2004-1-12', 1,'Muscat Oman', 75454321, 'fatima@gmail.com', 169,null)

--Countries Table
SELECT * FROM Countries;
SELECT CountryName FROM Countries WHERE CountryID = 100;


--Users Table CRUD
SELECT * FROM Users;
SELECT * FROM Users WHERE UserID = 1;
SELECT 1 FROM Users WHERE UserID = 18;
SELECT 1 FROM Users WHERE UserName = 'msaqer77';
--INSERT INTO [dbo].[Users]
--    ([PersonID], [UserName], [Password], [IsActive])
--VALUES (1033 , 'user33' , '1234' , 1 )
--SELECT SCOPE_IDENTITY();

--CREATE VIEW PublicUsersList AS
SELECT Users.UserID, People.PersonID, 
People.FirstName + ' ' + People.SecondName + ' ' + COALESCE(People.ThirdName, '') + ' ' + People.LastName AS FullName, 
Users.UserName, Users.IsActive
FROM Users JOIN People ON Users.PersonID = People.PersonID;

SELECT * FROM PublicUsersList;

--ApplicationTypes Table CRUD
SELECT * FROM ApplicationTypes;
SELECT * FROM ApplicationTypes WHERE ApplicationTypeID = 2;
SELECT 1 FROM ApplicationTypes WHERE ApplicationTypeID = 99;


--TestTypes Table CRUD
SELECT * FROM TestTypes;
SELECT * FROM TestTypes WHERE TestTypeID = 3;
SELECT 1 FROM TestTypes WHERE TestTypeID = 1;


--Local Driving License Application List Screen (my view)
--CREATE VIEW LocalDrivingLicenseApplications_View2 AS
SELECT 
	LocalDrivingLicenseApplications.LocalDrivingLicenseApplicationID,
	LicenseClasses.ClassName,
	People.NationalNo,
	People.FirstName + ' ' + People.SecondName + ' ' + COALESCE(People.ThirdName, '') + ' ' + People.LastName AS FullName,
	Applications.ApplicationDate,
	(SELECT COUNT(TestAppointments.TestTypeID)
	FROM Tests JOIN TestAppointments ON Tests.TestAppointmentID = TestAppointments.TestAppointmentID
	WHERE TestAppointments.LocalDrivingLicenseApplicationID = LocalDrivingLicenseApplications.LocalDrivingLicenseApplicationID
	AND Tests.TestResult = 1) AS PassedTestsCount,
	(CASE 
		WHEN (Applications.ApplicationStatus = 1) THEN 'New'
		WHEN (Applications.ApplicationStatus = 2) THEN 'Cancelled'
		WHEN (Applications.ApplicationStatus = 3) THEN 'Completed'
	END) AS ApplicationStatus

FROM LocalDrivingLicenseApplications 
	JOIN Applications ON LocalDrivingLicenseApplications.ApplicationID = Applications.ApplicationID
	JOIN LicenseClasses ON LocalDrivingLicenseApplications.LicenseClassID = LicenseClasses.LicenseClassID
	JOIN People ON Applications.ApplicantPersonID = People.PersonID;

SELECT * FROM LocalDrivingLicenseApplications_View; 
SELECT * FROM LocalDrivingLicenseApplications_View2; --I recreate this view to practice (command is above) --note: 1 = new, 2 = cancelled, 3 = completed

-- Application CRUD
SELECT * FROM LicenseClasses;
SELECT * FROM Applications;
SELECT * FROM LocalDrivingLicenseApplications

--query to check if a person can a apply for a new appliction 
--(a person cannot apply for another application with the same class if he has an application that is 1-new or 3-completed.) 
SELECT 1
	FROM LocalDrivingLicenseApplications
	JOIN Applications ON LocalDrivingLicenseApplications.ApplicationID = Applications.ApplicationID
	JOIN LicenseClasses ON LocalDrivingLicenseApplications.LicenseClassID = LicenseClasses.LicenseClassID
	JOIN People ON People.PersonID = Applications.ApplicantPersonID
WHERE ApplicationStatus IN (1,3) AND ApplicantPersonID = 1 
AND LicenseClasses.LicenseClassID = 3 



SELECT 1 FROM Applications WHERE ApplicationID = 50;
SELECT 1 FROM LocalDrivingLicenseApplications WHERE LocalDrivingLicenseApplicationID = 5000;


SELECT * FROM LocalDrivingLicenseApplications_View WHERE LocalDrivingLicenseApplicationID = 32;
SELECT ClassName FROM LicenseClasses WHERE LicenseClassID = 1;
SELECT PassedTestCount FROM LocalDrivingLicenseApplications_View WHERE LocalDrivingLicenseApplicationID = 30;

SELECT * FROM Applications;
--Test appointments
SELECT * FROM TestAppointments;
SELECT * FROM Tests;


SELECT * FROM TestAppointments WHERE TestAppointmentID = 70;
SELECT * FROM Tests WHERE TestID = 30;

SELECT TestAppointmentID, AppointmentDate, PaidFees, IsLocked FROM TestAppointments 
WHERE LocalDrivingLicenseApplicationID = 31 AND TestTypeID = 3;


--CREATE VIEW Test_Application_View AS
SELECT TestAppointmentID, TestTypeID, LocalDrivingLicenseApplications.LocalDrivingLicenseApplicationID, Applications.ApplicationID, ApplicationTypeID, ApplicantPersonID, IsLocked
FROM TestAppointments 
JOIN LocalDrivingLicenseApplications ON LocalDrivingLicenseApplications.LocalDrivingLicenseApplicationID =TestAppointments.LocalDrivingLicenseApplicationID
JOIN Applications ON LocalDrivingLicenseApplications.ApplicationID = Applications.ApplicationID 

SELECT IsLocked FROM TestAppointments WHERE TestAppointmentID = 70;

--query to get the retake test application ID for any person 
SELECT ApplicationID FROM Applications WHERE ApplicationTypeID = 8 AND ApplicantPersonID = 1

--CREATE VIEW ConductedTests_View AS
SELECT TestID, Tests.TestAppointmentID,TestTypeID, TestResult, AppointmentDate, LocalDrivingLicenseApplications.LocalDrivingLicenseApplicationID FROM Tests
JOIN TestAppointments ON Tests.TestAppointmentID = TestAppointments.TestAppointmentID
JOIN LocalDrivingLicenseApplications ON LocalDrivingLicenseApplications.LocalDrivingLicenseApplicationID = TestAppointments.LocalDrivingLicenseApplicationID

--check if a person passed a specific test
SELECT 1 FROM ConductedTests_View
WHERE TestResult = 1 AND TestTypeID = 3 AND LocalDrivingLicenseApplicationID = 31;

--check if this is a retake test (failed the test before)
SELECT 1 FROM ConductedTests_View
WHERE TestResult = 0 AND TestTypeID = 2 AND LocalDrivingLicenseApplicationID = 31;

--check if a person has an active test appointment
SELECT 1 FROM TestAppointments 
WHERE TestTypeID = 1 AND IsLocked = 0  AND LocalDrivingLicenseApplicationID = 59;

--get the number of trials for any test
SELECT COUNT(*) FROM TestAppointments WHERE LocalDrivingLicenseApplicationID = 31 AND TestTypeID = 2;

--check if appointment is Locked
SELECT 1 FROM TestAppointments WHERE IsLocked = 1 AND TestAppointmentID = 70;

SELECT ApplicationStatus FROM Applications WHERE ApplicationID = 50

SELECT * FROM Tests
SELECT * FROM TestAppointments
SELECT * FROM LocalDrivingLicenseApplications
SELECT * FROM Applications

--Issue License 
SELECT * FROM Licenses;
SELECT * FROM Drivers;

SELECT * FROM Licenses WHERE LicenseID = 10;
SELECT * FROM Drivers WHERE PersonID = 1;

SELECT MinimumAllowedAge FROM LicenseClasses WHERE LicenseClassID = 1;

SELECT LicenseID FROM Licenses WHERE ApplicationID = 65;

--CREATE VIEW LicenseBasic_view AS
SELECT LicenseID, ApplicationID, DriverID, LicenseClasses.ClassName, IssueDate, ExpirationDate, IsActive FROM Licenses 
JOIN LicenseClasses ON LicenseClasses.LicenseClassID = Licenses.LicenseClass;

SELECT * FROM LicenseBasic_view WHERE DriverID = 10;

SELECT 1 FROM Drivers WHERE PersonID = 1;

SELECT * FROM Licenses;
SELECT COUNT(*) FROM Licenses WHERE DriverID = 10;

--drivers view
--CREATE VIEW Drivers_view AS
SELECT Drivers.DriverID, Drivers.PersonID, People.NationalNo,
People.FirstName + ' ' + People.SecondName + ' ' + COALESCE(People.ThirdName, '') + ' ' + People.LastName AS FullName,
Drivers.CreatedDate, 
(SELECT COUNT(LicenseID) FROM Licenses WHERE DriverID = Drivers.DriverID AND IsActive = 1) AS ActiveLicenses
FROM Drivers
JOIN People ON People.PersonID = Drivers.PersonID

SELECT * FROM Drivers_View;



SELECT * FROM InternationalLicenses;

--check if a driver has an active ordinary driving license, (this is a requirment for an international license)
SELECT 1 FROM Licenses WHERE LicenseClass = 3 AND IsActive = 1 AND DriverID = 15;

SELECT * FROM InternationalLicenses WHERE DriverID = 9;
SELECT 1 FROM InternationalLicenses WHERE IsActive = 1 AND DriverID = 9;

--Renew licenses
SELECT * FROM LocalDrivingLicenseApplications;
SELECT * FROM ApplicationTypes;
SELECT * FROM Applications;
SELECT * From LicenseClasses;
SELECT * FROM Licenses;

--License Replacement
SELECT * FROM Licenses

--License Detain & Release
SELECT * FROM DetainedLicenses;

--CREATE VIEW DetainedLicenses_People_view AS
SELECT DetainedLicenses.DetainID, DetainedLicenses.LicenseID, DetainedLicenses.DetainDate, DetainedLicenses.FineFees,
People.NationalNo, People.FirstName + ' ' + People.SecondName + ' ' + COALESCE(People.ThirdName, '') + ' ' + People.LastName AS FullName,
DetainedLicenses.IsReleased, DetainedLicenses.ReleaseApplicationID, DetainedLicenses.ReleaseDate
FROM DetainedLicenses
JOIN Licenses ON Licenses.LicenseID = DetainedLicenses.LicenseID
JOIN Drivers ON Drivers.DriverID = Licenses.DriverID
JOIN People ON People.PersonID = Drivers.PersonID;

SELECT * FROM DetainedLicenses_People_view;

SELECT 1 FROM DetainedLicenses WHERE LicenseID = 31 AND IsReleased = 0;

SELECT * FROM People;
SELECT * FROM Countries;
SELECT * FROM Users;
SELECT * FROM ApplicationTypes;
SELECT * FROM Applications;
SELECT * FROM LocalDrivingLicenseApplications;
SELECT * FROM LicenseClasses;
SELECT * FROM Licenses;
SELECT * FROM Drivers;
SELECT * FROM InternationalLicenses;
SELECT * FROM TestAppointments;
SELECT * FROM TestTypes;
SELECT * FROM Tests;
SELECT * FROM DetainedLicenses;


