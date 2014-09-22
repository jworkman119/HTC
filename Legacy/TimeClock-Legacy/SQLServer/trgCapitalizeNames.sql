USE TimeClock

GO

IF EXISTS (SELECT * FROM sysobjects WHERE NAME='trgCapitalizeNames' AND TYPE='TR')
	DROP Trigger trgCapitalizeNames
GO

Create Trigger trgCapitalizeNames

	On Person
	For Insert
As 

Update Person
Set FirstName = UPPER(left(FirstName,1)) +  right(FirstName, len(FirstName) - 1)
	, LastName = UPPER(left(LastName,1)) +  right(LastName, len(LastName) - 1)
from Person



