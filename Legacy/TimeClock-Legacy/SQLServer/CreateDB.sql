--Create Database TimeClock

use TimeClock

CREATE TABLE Role (
  ID VARCHAR(3)  NOT NULL,
  Description VARCHAR(40)  NULL,
PRIMARY KEY(ID));

Insert Into Role(ID, Description)
values('jan','Janitor');


Insert Into Role(ID, Description)
values('sup','Supervisor');

/*
CREATE TABLE DataDump(
  SSN VARCHAR(11)  NOT NULL,
  FirstName VARCHAR(25)  NOT NULL,
  LastName VARCHAR(35)  NOT NULL,
  PicPath varchar(500) NULL,
  Gender char(1) NULL,
  Under18 bit NULL,
  RoleID varchar(3) NULL
);
*/


 


CREATE TABLE Time (
  ID INTEGER NOT NULL   Identity(1,1), 	
  Time DATETIME  NULL  ,
  InOut VARCHAR(3)  NULL    ,
  In_ID int NULL,
  PRIMARY KEY(ID)  ,
Person_ID int references Person(ID));


CREATE TABLE Shift (
  ID INT NOT NULL  Identity(1,1),
  PRIMARY KEY(ID),
  Name VARCHAR(20) Not NULL,
  TimeIn DateTIME  NULL,
  TimeOut DateTIME  NULL,
Constraint Shiftname Unique(Name));


CREATE TABLE Schedule (
  ID INTEGER NOT NULL   Identity(1,1),
	PRIMARY KEY(ID)  ,
	Shift_ID Int references Shift(ID) Not NULL,
	Person_ID int references Person(ID) Not NULL,
 	Day DateTime Not NULL,
	Supervisor_ID int references Person(ID) NULL,
--Constraint UniquePerson_Shift Unique(Person_ID, Shift_ID)
);

/*
drop table DataDump
drop table Schedule;
drop table Time;
drop table Shift;
drop table Person;
drop table Role;
*/