CREATE TABLE [dbo].[datadump](
	[ACCOUNT] [varchar](255) NULL,
	[Last_Name] [varchar](255) NULL,
	[First_Name] [varchar](255) NULL,
	[DOB] [varchar](255) NULL,
	[SEX] [varchar](255) NULL,
	[POWERFILE3] [varchar](255) NULL,
	[DATE] [varchar](255) NULL,
	[PROC] [varchar](255) NULL,
	[provider_first] [varchar](35) NULL,
	[provider_last] [varchar](255) NULL,
	[CARRIER] [varchar](255) NULL,
	[FACILITY] [varchar](255) NULL,
	[DX1] [varchar](255) NULL,
	[DX2] [varchar](255) NULL,
	[DX3] [varchar](255) NULL,
	[DX4] [varchar](255) NULL,
	[CHARGED] [varchar](255) NULL,
	[ALLOWED] [varchar](255) NULL,
	[PATPAID] [varchar](255) NULL,
	[PRIMARYPAID] [varchar](255) NULL,
	[OTHERINSPD] [varchar](255) NULL,
	[ADJ] [varchar](255) NULL,
	[PATBAL] [varchar](255) NULL,
	[TOTPAID] [varchar](255) NULL,
	[ZIPCODE] [varchar](255) NULL,
	[UNITS] [varchar](255) NULL,
	[LOCATION] [varchar](255) NULL,
	[FINCLASS] [varchar](255) NULL,
	[TIME] [varchar](255) NULL,
	[MOD1] [varchar](255) NULL,
	/*
	[JunkField1] varchar(50) NULL,
	[JunkField2] varchar(50) NULL,
	[JunkField3] varchar(50) NULL,
	*/
	BadData bit NULL
) ;


CREATE TABLE Patient (
  Account BIGINT NOT NULL,
  FirstName VARCHAR(25) NULL,
  LastName VARCHAR(35) NULL,
  DOB DATETIME NULL,
  Sex CHAR(1) NULL,
  PRIMARY KEY(Account)
);


Create Table Address(
  ID bigint Not Null Identity(1000, 1),
  Address VARCHAR(50) NULL,
  Address2 VARCHAR(50) NULL,
  City VARCHAR(50) NULL,
  State CHAR(2) NULL,
  Zip VARCHAR(10) NULL,
  CurrentAddress Bit NULL,
  PRIMARY KEY(ID),
  Patient_Account BIGINT references Patient(Account)
);



CREATE TABLE Facility (
  ID CHAR(1) NOT NULL,
  Full_Name VARCHAR(100) NULL,
  Address VARCHAR(50) NULL,
  Address_2 VARCHAR(50) NULL,
  City VARCHAR(35) NULL,
  State CHAR(2) NULL,
  Zip VARCHAR(10) NULL,
  PRIMARY KEY(ID)
);

CREATE TABLE Provider_Type (
  ID VARCHAR(15) NOT NULL,
  DESCRIPTION VARCHAR(75) NULL,
  PRIMARY KEY(ID)
);

CREATE TABLE Provider (
  ID INTEGER Identity(1000, 1),
  First_Name VARCHAR(25) NULL,
  Last_Name VARCHAR(35) NULL,
  Title VARCHAR(15) NULL,
  PRIMARY KEY(ID),
  Provider_Type_ID varchar(15) REFERENCES Provider_Type(ID),
  primeFacility_ID char(1) References Facility(ID), 
);

CREATE TABLE Service (
  ID CHAR(5) NOT NULL,
  DESCRIPTION VARCHAR(40) NULL,
  AllottedTime int NULL,
  Units int null,
  Weight float null
  PRIMARY KEY(ID)
);

CREATE TABLE Insurance (
  ID VARCHAR(5) NOT NULL,
  NAME VARCHAR(50) NULL,
  Address VARCHAR(50) NULL,
  Address2 VARCHAR(50) NULL,
  City VARCHAR(35) NULL,
  State CHAR(2) NULL,
  Zip VARCHAR(10) NULL,
  PRIMARY KEY(ID)
);

CREATE TABLE Visit (
  ID BIGINT NOT NULL Identity(1,1),
  date DATETime NULL,
  time DateTIME NULL,
  time_left DateTIME NULL,
  PRIMARY KEY(ID),
  Patient_Account BIGINT REFERENCES Patient(Account),
  Insurance_ID varchar(5) REFERENCES Insurance(ID),
  Provider_ID INTEGER REFERENCES Provider(ID),	  
  Service_ID CHAR(5) REFERENCES Service(ID), 
  Facility_ID CHAR(1) REFERENCES Facility(ID)
);

Create Table WDPM(
	ID BIGINT NOT NULL Identity(1,1),
	MonthWorked INT NULL,
	DateEntered datetime DEFAULT GETDATE(),
	WDPM FLOAT,
	Primary Key(ID),
	Provider_ID INTEGER REFERENCES Provider(ID),
);

Create Table BHPD(
	ID INT NOT NULL Identity(1,1),
	BHPD float NULL,
	PRIMARY KEY(ID),
	Provider_ID INTEGER REFERENCES Provider(ID)
	
);

Create Table Quarters(
ID int,
StartMonth int,
EndMonth int
);
