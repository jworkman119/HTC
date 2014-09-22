Create Table "Document" (
	"Id" 			Integer Primary Key Autoincrement Not Null 
	,"Name" 		Varchar(75) 		Not Null 
	,"Filename"		Varchar(75)			Not Null
)

Create Table "Visitor" (
	"Id" Integer Primary Key  Autoincrement Not Null
	, "Firstname"	Varchar(25)
	, "Lastname"	Varchar(35)
	, "Company"		Varchar(75)
	
)

Create Table "Location"(
	"Id" 			Varchar(10) Primary Key  Autoincrement Not Null
	,"Description"	Varchar(35)
)

Create Table "Signature" (
	"Id" 			Integer 	Primary Key  Autoincrement  Not Null  Unique
	, "Badge_No"	Integer		Not Null
	, "Timestamp" 	Datetime 	Not Null  Unique  Default Current_Timestamp
	, "Signature" 	Text
	, "Document_Id"	Integer		Not Null References Documents(Id)
	, "Visitor_Id"	Integer		Not Null References Visitor(Id)
	, "Location_Id"	Varchar		Not Null References Location(Id)	
)