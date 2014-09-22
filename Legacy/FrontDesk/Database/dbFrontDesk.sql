CREATE TABLE Worker(
ID Integer Primary Key  AutoIncrement  Not Null Unique
,FirstName VarChar
,LastName VarChar
, Email VarChar
, Phone int
, Active boolean
);

Create Table TimeWorked(
	ID Integer Primary Key AutoIncrement Not Null Unique
	, TimeIn DateTime
	, TimeOut DateTime
	, Worker_ID int references Worker(ID)
);