USE [DVLDv2]

--Get All People View
--CREATE VIEW vPeople AS
SELECT Person.ID, Person.NationalNo, 
FirstName + ' ' + SecondName + ' ' + COALESCE(ThirdName, '') + ' ' + LastName AS FullName,
CASE
	WHEN Person.Gender = 1 THEN 'Male'
	ELSE 'Female'
END AS Gender,
Person.DateOfBirth,
Country.CountryName AS Nationality, Person.Phone, Person.Email
FROM [Person] JOIN [Country] ON Person.NationalityCountryID = Country.ID;

SELECT * FROM vPeople;


SELECT * FROM [Country];
SELECT * FROM [Person];
SELECT * FROM [User];
SELECT * FROM [LicenseClass];
SELECT * FROM [ApplicationType];
SELECT * FROM [Application];
SELECT * FROM [License];
SELECT * FROM [LocalLicenseApplication];
SELECT * FROM [InternationalLicense];
SELECT * FROM [DetainedLicense];
SELECT * FROM [Driver];
SELECT * FROM [TestType];
SELECT * FROM [TestAppointment];
SELECT * FROM [Test];