Create Table Orders
(
	Number 				VarChar(50) Not Null Primary Key
	, Company			varchar(150)
	, Contact			varchar(150)
	, ShipMethod 		varchar(75)
	, Email 			varchar(125) Default('Nancy@hitechnic') /*Default to Nancy*/
	, Telephone 		varchar(55)  Default('315-533-1195') /*Default to Nancy*/
	, ShippingAccount 	varchar(100)
	, AES				varchar(15)
	, SubTotal			Float
	, TS				DateTime Not NULL Default(datetime('now', 'localtime'))
);

Create Table Tracking
(
	ID Integer PRIMARY KEY AutoIncrement
	, Tracking	varchar(125)
	, ShipMethod varchar(75)
	, Weight	float
	, Cost		float
	, TS		DateTime Not NULL Default(datetime('now', 'localtime'))
	, Account   varchar(25)
	, Orders_Number	VarChar(50) Not Null References Orders(Number) 
	
);

CREATE TABLE ShipTo(
	ID Integer PRIMARY KEY AutoIncrement
	,Contact varchar(200)
	,Address1 varchar(200)
	,Address2 varchar(200)
	,Address3 varchar(200)
	,City varchar(100)
	,State char(2)
	,Zip varchar(20)
	,Country varchar(50) DEFAULT ('United States') 
	, Orders_Number	VarChar(50) Not Null References Orders(Number) On Delete Cascade
);

CREATE TABLE BillTo(
	ID Integer PRIMARY KEY AutoIncrement
	,Contact varchar(200)
	,Address1 varchar(200)
	,Address2 varchar(200)
	,Address3 varchar(200)
	,City varchar(100)
	,State char(2)
	,Zip varchar(20)
	,Country varchar(50) DEFAULT ('United States') 
	, Orders_Number	VarChar(50) Not Null References Orders(Number) On Delete Cascade
);


Create Table OrderDetails
(
	ID Integer PRIMARY KEY AutoIncrement
	, Qty	Integer 
	, PartID varchar(20) 
	, Description varchar(150)
	, Orders_Number	VarChar(50) Not Null References Orders(Number) On Delete Cascade
);

Create Table Country
(
	ID char(2) Primary Key
	, Name char(50)
);
