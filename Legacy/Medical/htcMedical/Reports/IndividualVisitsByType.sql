/*
ALTER Procedure spIndividualVisitsByType 

	@FromDate smalldatetime
	, @ToDate smalldatetime

AS
*/

Create Table #Temp(
	Name varchar(100)
	, Service varchar(15)
	, Cases int
	, month varchar(15)
	, month2 int
	, Quarter int
	, year int
	, City varchar(25)
--	, VisitType varchar(7)
)

Declare @FromDate datetime
Declare @ToDate datetime

Set @FromDate = '3/1/2011'
Set @ToDate = '3/28/2011'


insert into #Temp(Name, Service, Cases, Month, Month2,Quarter, Year, City)
exec spCases_Provider @FromDate, @ToDate

/* Need to perform union to get services in result set that are 0 for the time frame */
select 'NoCases' as Name 
	, Service.ID as Service
	, 0 as Cases
	, DateName(month,@FromDate) as Month
	, Month(@FromDate) as Month2
	, '-' as Quarter
	 , year(@FromDate) as Year
	, 'City' as City
Into #Temp2
From Service
where Service.ID not in (Select Service from #Temp)
Union
Select * From #Temp

drop table #Temp

EXECUTE crosstab 'Select Name, Month2, Month,Quarter, Year, City from #Temp2 Group by Name, Month2,Month, Quarter, Year ,City Order by Year, Month2, Name'
	, 'sum(Cases)'
	, 'Service'
	, '#Temp2'

drop table #Temp2;