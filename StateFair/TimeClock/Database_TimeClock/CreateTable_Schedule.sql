CREATE TABLE Role (
  ID varchar(3) NOT NULL
  , Description varchar(25) DEFAULT NULL
  , PRIMARY KEY (`ID`)
) ENGINE=Innodb DEFAULT CHARSET=utf8;



CREATE TABLE Person (
  ID int NOT NULL AUTO_INCREMENT
  , FirstName varchar(25) DEFAULT NULL
  , LastName varchar(35) DEFAULT NULL
  , PicPath varchar(255) DEFAULT NULL
  , Gender char(1) NOT NULL
  , Role_ID varchar(3) Not NULL
  , under18 tinyint(1) NOT NULL
  , VertexID int DEFAULT NULL
  , PRIMARY KEY (ID)
  , FOREIGN KEY (Role_ID) REFERENCES Role(Id)
 )ENGINE=Innodb DEFAULT CHARSET=utf8;

) 

Create Table Zone(
	ID varchar(50) NOT NULL
	, Description varchar(100)
	, Primary Key (ID)
)ENGINE=Innodb DEFAULT CHARSET=utf8;

Create Table Schedule(
	ID int NOT NULL AUTO_INCREMENT
	, Person_ID int Not Null
	, Date Date Not Null
	, TimeIn Time
	, TimeOut Time
	, Zone_ID varchar(50) Not Null
	, Supervisor_ID int
	, PRIMARY KEY (ID)
	, Foreign KEY (Person_ID) References Person(ID)
	, Foreign KEY (Zone_ID) References Zone(ID)
) ENGINE=Innodb DEFAULT CHARSET=utf8;
	  




