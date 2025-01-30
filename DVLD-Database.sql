USE DVLDv2;

--Creating Tables

CREATE TABLE [Country](
	ID INT IDENTITY(1,1) PRIMARY KEY,
	CounrtyName NVARCHAR(50) NOT NULL

);


CREATE TABLE [Person](
	ID INT IDENTITY(1,1) PRIMARY KEY,
	NationalNo NVARCHAR(20) UNIQUE NOT NULL,
	FirstName NVARCHAR(20) NOT NULL,
	SecondName NVARCHAR(20) NOT NULL,
	ThirdName NVARCHAR(20),
	LastName NVARCHAR(20) NOT NULL,
	DateOfBirth DATE NOT NULL,
	Gender TINYINT NOT NULL,
	Address NVARCHAR(500) NOT NULL,
	Phone NVARCHAR(20) NOT NULL,
	Email NVARCHAR(50),
	NationalityCountryID INT NOT NULL,
	ImagePath NVARCHAR(500),

	FOREIGN KEY (NationalityCountryID) REFERENCES Country(ID)
);


CREATE TABLE [User](
	ID INT IDENTITY(1,1) PRIMARY KEY,
	PersonID INT NOT NULL,
	Username NVARCHAR(20) UNIQUE NOT NULL,
	Password NVARCHAR(255) NOT NULL,
	IsActive BIT NOT NULL,

	FOREIGN KEY (PersonID) REFERENCES Person(ID)
);


CREATE TABLE [ApplicationType](
	ID INT IDENTITY(1,1) PRIMARY KEY,
	Title NVARCHAR(255) NOT NULL,
	Fees DECIMAL(10,2) NOT NULL,

);


CREATE TABLE [LicenseClass](
	ID INT IDENTITY(1,1) PRIMARY KEY,
	Title NVARCHAR(255)  NOT NULL,
	Description NVARCHAR(500) NOT NULL,
	MinimumAge TINYINT NOT NULL,
	ValidityYears TINYINT NOT NULL,
	Fees DECIMAL(10,2) NOT NULL,

);

CREATE TABLE [Application](
	ID INT IDENTITY(1,1) PRIMARY KEY,
	ApplicantPersonID INT NOT NULL,
	TypeID INT NOT NULL,
	ApplicationDate DATETIME2 NOT NULL,
	Status TINYINT NOT NULL,
	LastStatusDate DATETIME2 NOT NULL,
	Fees DECIMAL(10,2) NOT NULL,
	CreatedByUserID INT NOT NULL,

	FOREIGN KEY (ApplicantPersonID) REFERENCES Person(ID),
	FOREIGN KEY (TypeID) REFERENCES ApplicationType(ID),
	FOREIGN KEY (CreatedByUserID) REFERENCES [User](ID)
);


CREATE TABLE [LocalLicenseApplication](
	ID INT IDENTITY(1,1) PRIMARY KEY,
	ApplicationID INT NOT NULL,
	LicenseClass INT NOT NULL,

	FOREIGN KEY (ApplicationID) REFERENCES [Application](ID),
	FOREIGN KEY (LicenseClass) REFERENCES [LicenseClass](ID)
);


CREATE TABLE [Driver](
	ID INT IDENTITY(1,1) PRIMARY KEY,
	PersonID INT NOT NULL,
	CreatedDate DATETIME2 NOT NULL,
	CreatedByUserID INT NOT NULL,

	FOREIGN KEY (PersonID) REFERENCES Person(ID),
	FOREIGN KEY (CreatedByUserID) REFERENCES [User](ID)
);


CREATE TABLE [License](
	ID INT IDENTITY(1,1) PRIMARY KEY,
	ApplicationID INT NOT NULL,
	DriverID INT NOT NULL,
	LicenseClassID INT NOT NULL,
	IssueDate DATETIME2 NOT NULL,
	ExpirationDate DATETIME2 NOT NULL,
	Notes NVARCHAR(500),
	PaidFees DECIMAL(10,2) NOT NULL,
	IsActive BIT NOT NULL,
	IssueReason TINYINT NOT NULL,
	CreatedByUserID INT NOT NULL,

	FOREIGN KEY (ApplicationID) REFERENCES [Application](ID),
	FOREIGN KEY (DriverID) REFERENCES Driver(ID),
	FOREIGN KEY (LicenseClassID) REFERENCES LicenseClass(ID),
	FOREIGN KEY (CreatedByUserID) REFERENCES [User](ID)
);

CREATE TABLE [InternationalLicense](
	ID INT IDENTITY(1,1) PRIMARY KEY,
	ApplicationID INT NOT NULL,
	DriverID INT NOT NULL,
	LocalLicenseID INT NOT NULL,
	IssueDate DATETIME2 NOT NULL,
	ExpirationDate DATETIME2 NOT NULL,
	IsActive BIT NOT NULL,
	CreatedByUserID INT NOT NULL,

	FOREIGN KEY (ApplicationID) REFERENCES [Application](ID),
	FOREIGN KEY (DriverID) REFERENCES [Driver](ID),
	FOREIGN KEY (LocalLicenseID) REFERENCES [License](ID),
	FOREIGN KEY (CreatedByUserID) REFERENCES [User](ID)
);

CREATE TABLE [DetainedLicense](
	ID INT IDENTITY(1,1) PRIMARY KEY,
	LicenseID INT NOT NULL,
	DetainDate DATETIME2 NOT NULL,
	FineFees DECIMAL(10,2) NOT NULL,
	CreatedByUserID INT NOT NULL,
	IsReleased BIT NOT NULL,
	ReleasedDate DATETIME2,
	ReleasedByUserID INT,
	ReleaseApplicationID INT,

	FOREIGN KEY (LicenseID) REFERENCES [License](ID),
	FOREIGN KEY (CreatedByUserID) REFERENCES [User](ID),
	FOREIGN KEY (ReleasedByUserID) REFERENCES [User](ID),
	FOREIGN KEY (ReleaseApplicationID) REFERENCES [Application](ID)
);

CREATE TABLE [TestType](
	ID INT IDENTITY(1,1) PRIMARY KEY,
	Title NVARCHAR(50) NOT NULL,
	Description NVARCHAR(500) NOT NULL,
	Fees DECIMAL(10,2) NOT NULL

);

CREATE TABLE [TestAppointment](
	ID INT IDENTITY(1,1) PRIMARY KEY,
	TestTypeID INT NOT NULL,
	LocalLicenseApplicationID INT NOT NULL,
	AppointmentDate DATETIME2 NOT NULL,
	PaidFees DECIMAL(10,2) NOT NULL,
	IsLocked BIT NOT NULL,
	CreatedByUserID INT NOT NULL,

	FOREIGN KEY (TestTypeID) REFERENCES [TestType](ID),
	FOREIGN KEY (LocalLicenseApplicationID) REFERENCES [LocalLicenseApplication](ID),
	FOREIGN KEY (CreatedByUserID) REFERENCES [User](ID)
);


CREATE TABLE [Test](
	ID INT IDENTITY(1,1) PRIMARY KEY,
	TestAppointmentID INT NOT NULL,
	Result BIT NOT NULL,
	Notes NVARCHAR(500),
	CreatedByUserID INT NOT NULL,

	FOREIGN KEY (TestAppointmentID) REFERENCES [TestAppointment](ID),
	FOREIGN KEY (CreatedByUserID) REFERENCES [User](ID)
);


--Inserting Initial Values

INSERT INTO ApplicationType VALUES
('New Local Driving License', 10),
('Renew Driving License', 5),
('Replacement for a Damaged Driving License', 7),
('Replacement for a Lost Driving License', 10),
('Release Detained Driving Licsense', 15),
('New International License', 50),
('Retake Test', 5.5)

INSERT INTO LicenseClass VALUES
('Small Motorcycle', 'It allows the driver to drive small motorcycles, It is suitable for motorcycles with small capacity and limited power.', 18, 5, 15),
('Heavy Motorcycle', 'Heavy Motorcycle License (Large Motorcycle License)', 21, 5, 30),
('Ordinary Driving License', 'Ordinary driving license (car licence)', 18, 2, 20),
('Commercial', 'Commercial driving license (taxi/limousine)', 21, 5, 200),
('Agricultural', 'Agricultural and work vehicles used in farming or construction, (tractors / tillage machinery)', 23, 10, 50),
('Small & Medium Bus', 'A license to drive public transportation vehicles (buses).', 23, 10, 120),
('Truck & Heavy Vehicle', 'A license to operate heavy machinery and construction vehicles.', 23, 10, 500)

INSERT INTO TestType VALUES
('Vision Test', 'This test checks whether the applicant meets the minimum vision requirements, such as being able to read license plates from a certain distance or having 20/40 vision or better (depending on local standards).', 10),
('Theory Test', 'This test usually includes multiple-choice questions and covers topics like speed limits, right-of-way rules, and understanding road signs. It is a requirement before taking the practical street driving test.', 15),
('Practical Test', 'The applicant is required to perform a series of driving maneuvers (e.g., parallel parking, lane changes, and stop signs) while being observed by a licensed examiner. This test ensures that the applicant can apply their theoretical knowledge to real-world driving.', 20)

INSERT INTO [Person] VALUES
('N0', 'Reda', 'Bassam', 'Bader', 'Hilal', '2004-8-6', 1, 'Earth', '10101010', '0x@Reda', 168, NULL);

INSERT INTO [User] VALUES
(1, 'Admin', '1234', 1)

INSERT INTO Country VALUES
('Afghanistan'),
('Albania'),
('Algeria'),
('Andorra'),
('Angola'),
('Antigua and Barbuda'),
('Argentina'),
('Armenia'),
('Australia'),
('Austria'),
('Azerbaijan'),
('Bahamas'),
('Bahrain'),
('Bangladesh'),
('Barbados'),
('Belarus'),
('Belgium'),
('Belize'),
('Benin'),
('Bhutan'),
('Bolivia'),
('Bosnia and Herzegovina'),
('Botswana'),
('Brazil'),
('Brunei'),
('Bulgaria'),
('Burkina Faso'),
('Burundi'),
('Cabo Verde'),
('Cambodia'),
('Cameroon'),
('Canada'),
('Central African Republic'),
('Chad'),
('Chile'),
('China'),
('Colombia'),
('Comoros'),
('Congo (Congo-Brazzaville)'),
('Costa Rica'),
('Croatia'),
('Cuba'),
('Cyprus'),
('Czechia'),
('Democratic Republic of the Congo'),
('Denmark'),
('Djibouti'),
('Dominica'),
('Dominican Republic'),
('Ecuador'),
('Egypt'),
('El Salvador'),
('Equatorial Guinea'),
('Eritrea'),
('Estonia'),
('Eswatini (Swaziland)'),
('Ethiopia'),
('Fiji'),
('Finland'),
('France'),
('Gabon'),
('Gambia'),
('Georgia'),
('Germany'),
('Ghana'),
('Greece'),
('Grenada'),
('Guatemala'),
('Guinea'),
('Guinea-Bissau'),
('Guyana'),
('Haiti'),
('Honduras'),
('Hungary'),
('Iceland'),
('India'),
('Indonesia'),
('Iran'),
('Iraq'),
('Ireland'),
('Italy'),
('Jamaica'),
('Japan'),
('Jordan'),
('Kazakhstan'),
('Kenya'),
('Kiribati'),
('Kuwait'),
('Kyrgyzstan'),
('Laos'),
('Latvia'),
('Lebanon'),
('Lesotho'),
('Liberia'),
('Libya'),
('Liechtenstein'),
('Lithuania'),
('Luxembourg'),
('Madagascar'),
('Malawi'),
('Malaysia'),
('Maldives'),
('Mali'),
('Malta'),
('Marshall Islands'),
('Mauritania'),
('Mauritius'),
('Mexico'),
('Micronesia'),
('Moldova'),
('Monaco'),
('Mongolia'),
('Montenegro'),
('Morocco'),
('Mozambique'),
('Myanmar (Burma)'),
('Namibia'),
('Nauru'),
('Nepal'),
('Netherlands'),
('New Zealand'),
('Nicaragua'),
('Niger'),
('Nigeria'),
('North Korea'),
('North Macedonia'),
('Norway'),
('Oman'),
('Pakistan'),
('Palau'),
('Palestine'),
('Panama'),
('Papua New Guinea'),
('Paraguay'),
('Peru'),
('Philippines'),
('Poland'),
('Portugal'),
('Qatar'),
('Romania'),
('Russia'),
('Rwanda'),
('Saint Kitts and Nevis'),
('Saint Lucia'),
('Saint Vincent and the Grenadines'),
('Samoa'),
('San Marino'),
('Sao Tome and Principe'),
('Saudi Arabia'),
('Senegal'),
('Serbia'),
('Seychelles'),
('Sierra Leone'),
('Singapore'),
('Slovakia'),
('Slovenia'),
('Solomon Islands'),
('Somalia'),
('South Africa'),
('South Korea'),
('South Sudan'),
('Spain'),
('Sri Lanka'),
('Sudan'),
('Suriname'),
('Sweden'),
('Switzerland'),
('Syria'),
('Tajikistan'),
('Tanzania'),
('Thailand'),
('Timor-Leste'),
('Togo'),
('Tonga'),
('Trinidad and Tobago'),
('Tunisia'),
('Turkey'),
('Turkmenistan'),
('Tuvalu'),
('Uganda'),
('Ukraine'),
('United Arab Emirates'),
('United Kingdom'),
('United States'),
('Uruguay'),
('Uzbekistan'),
('Vanuatu'),
('Vatican City'),
('Venezuela'),
('Vietnam'),
('Yemen'),
('Zambia'),
('Zimbabwe');
