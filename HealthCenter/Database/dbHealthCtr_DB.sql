CREATE TABLE Resource (
  ID VarChar NOT NULL Primary Key AutoIncrement
  , FirstName VARCHAR  Not NULL  
  , LastName VARCHAR  Not NULL  
  , Location VARCHAR  NULL    
);

Create Table Patient (
  Account INTEGER NOT NULL Primary Key
  ,FirstName VARCHAR  Not NULL  
  ,LastName VARCHAR  Not NULL  
  , DOB DATE  NULL
  , Phone Varchar(15) NULL
  , Resource_ID Integer References Resource(ID)
);

Create Table TP(
	ID INTEGER NOT NULL Primary Key AutoIncrement  
	, Date DATE  Not NULL    
	, Patient_Account Int references Patient(Account)
	, Resource_ID Int references Resource(ID)
	, Location varchar(25)
)


Create Table WaitList(
	ID INTEGER NOT NULL Primary Key AutoIncrement
	, StartDate Date 
	, EndDate Date
	, Patient_Account Int references Patient(Account)
	, Resource_ID Int references Resource(ID)
)