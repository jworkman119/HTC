Create Table Person(
	ID Integer Not Null Primary Key AutoIncrement
	, FirstName varchar(25) NULL
	, LastName varchar(35) NULL
);

Create Table Time(
	ID Integer Not Null Primary Key AutoIncrement
	, Time DateTime NOT NULL
	, LocalStatus VarChar(10)
	, Status VarChar(10)
	, Person_ID Integer references Person(ID)
);