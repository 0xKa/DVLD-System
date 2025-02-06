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





SELECT * FROM [Application];




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