
Alter Procedure spIndividualVisitsByType_Qtr 

	@FromDate smalldatetime
	, @ToDate smalldatetime

AS

Create Table #Temp(
	Name varchar(100)
	, Service varchar(15)
	, Cases int
	, Quarter int
	, year int
	, City varchar(25)
)

-- Testing
/*
Declare @FromDate datetime
Declare @ToDate datetime

Set @FromDate = '1/1/2011'
Set @ToDate = '3/31/2011'
*/
-- End Testing

-- Need to pass Year and Quarter to 3rd SQL statement
Declare @Qtr int
Declare @Yr int

Set @Yr = year(@ToDate)

Select @Qtr= Quarters.ID
from quarters
where month(@ToDate) = quarters.EndMonth
and month(@FromDate)= quarters.StartMonth


-- Second SQL statement
insert into #Temp(Name, Service, Cases, Quarter, Year, City)
exec spCases_Provider_Qtr @FromDate, @ToDate

/* 3rd SQL Statement - Need to perform union to get services in result set that are 0 for the time frame */
select 'NoCases' as Name 
	, Service.ID as Service
	, 0 as Cases
	, @Qtr as Quarter
	, @Yr as Year
	, 'City' as City
Into #Temp2
From Service
where Service.ID not in (Select Service from #Temp)
Union
Select * From #Temp


drop table #Temp


EXECUTE crosstab 'Select Name, Quarter, Year, City from #Temp Group by Name, Quarter, Year ,City Order by Year, Quarter, Name'
	, 'sum(Cases)'
	, 'Service'
	, '#Temp2'

drop table #Temp2;