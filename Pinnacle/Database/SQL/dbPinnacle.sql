Create Table Role(
	ID varchar(3)
	, Description varchar(25)
);


Create Table Staff (
	ID Integer Not Null Primary Key AutoIncrement
	, FirstName VarChar(25)  Null  
	, LastName VarChar(50)  Null  
	, Active Bool  Null    
	, Role_ID varchar(3) Not Null references Role(ID)
);

Create Table Funding (
  ID Integer Not Null Primary Key AutoIncrement
  , Description VarChar(100)  Null
);


Create Table Disability (
    ID VarChar(5) Primary Key  Not Null  
	,Description varchar(75) Not Null 
);



Create Table Consumer (
  ID Integer Not Null Primary Key AutoIncrement
  , FirstName VarChar(25)  Null  
  , LastName VarChar(50)  Null  
  , SSN VarChar(9)  Null  
  , HiredDate Date  Null  
  , AVR VarChar(10)  Null  
  , Units Integer NULL
  , Funding_ID VarChar(5) References Funding(ID) NULL
  , Disability_ID varchar(5) references Disability(ID) NULL
  , Created TimeStamp DEFAULT (datetime(current_timestamp,'localtime')) NULL
  , Active Bool default 'true'
);


CREATE TABLE Pay (
  ID INTEGER  Not Null Primary Key   AutoIncrement
  , Date DATE  NULL
  , EndDate DATE NULL
  , Rate FLOAT  NULL    
  , Staff_ID Integer References Staff(ID) Not Null
)

Create Table Administrative(
	ID Integer Not Null Primary Key AutoIncrement
	, Description VarChar(250)	Not NULL
	, Date	Date Not NULL
	, StartTime Time Not Null
	, EndTime Time Not Null
	, Staff_ID Integer References Staff(ID) Not NULL
	)

Create Table Job (
  ID Integer Not Null Primary Key AutoIncrement
  , Title VarChar  Null
  , Description VarChar  Null  
  , Employer VarChar  Null
  , Address VarChar NULL
  , City VarChar(35) NULL
  , Zip VarChar(10) null
  , PlacementDate Date  Null
  , ExtendedDate Date  Null 
  , Consumer_ID Integer Not Null References Consumer(ID)
  , EndDate Date Null
);

Create Table Meeting(
	ID Integer Not Null Primary Key AutoIncrement
	, Description VarChar(25) NULL
);

Create Table Review (
  ID Integer Not Null Primary Key AutoIncrement
  , Date Date  Null
  , DesiredOutcome varchar(200) NULL
  , Barriers varchar(200) NULL
  , Note text  NULL  	
  , TimeIn Time
  , TimeOut Time
  , Job_ID Integer Null References Job(ID)
  , Staff_ID Integer Not Null References Staff(ID)  
  , Meeting_ID Integer Not Null References Meeting(ID)	
  , Consumer_ID Integer Not Null References Consumer(ID)
  , Funding_ID Integer Null References Funding(ID)
);

Create Table ReportColumns(
	ID Integer Not Null Primary Key AutoIncrement
	, Name VarChar(10) NULL
	, Description VarChar(100) NULL
);