/*
ALTER Procedure spCases_Provider 

	@FromDate smalldatetime
	, @ToDate smalldatetime

AS
*/
Declare @FromDate datetime
Declare @ToDate datetime

Set @FromDate = '2/1/2011'
Set @ToDate = '2/28/2011'

select 
		case Provider.Last_Name 
			When 'Bushan' then
				'Langer' + ', ' + left(Provider.First_Name,1)
			else
				Provider.Last_Name + ', ' + left(Provider.First_Name,1) 
		End as Name
	, Service.ID as Service
	, Count(Visit.ID) as Cases
	, DateName(month,Visit.date) as Month
	, Month(visit.date) as Month2
	, Quarters.ID as Quarter
	, year(Visit.date) as Year
	, Facility.City
	, Case 
		When Service.Weight > 0 then
			'Visit'
		when Service.Weight = 0 then
			'Cancel'
	  End as VisitType
into #tempTB
from Provider
	join Visit on Visit.Provider_ID = Provider.ID
	join Quarters on month(Visit.date) >= Quarters.StartMonth
		 and month(Visit.date) <= Quarters.EndMonth
	join Service on Service.ID = Visit.Service_ID
	join Facility on Facility.ID = Provider.primeFacility_ID
	join BHPD on BHPD.Provider_ID = Provider.Id
Where visit.date >= @FromDate
	and visit.date <= @ToDate
	and provider.id in (select wdpm.provider_id 
						from wdpm
						where monthworked = month(@FromDate)
							and year = year(@FromDate)
						)
group by 
	Provider.Last_Name
	, Provider.First_Name
	, Service.ID
	, year(Visit.date)
	, datename(month,Visit.date)
	, Month(visit.date)
	, Quarters.ID
	, service.allottedTime
	, Facility.City
	, Service.Weight
order by Facility.City, Name, month2, VisitType asc , Service.ID



	-- retrieving all data from temptable
	select distinct Name
		, Service
		, Cases
		, month
		, month2
		, Quarter
		, year
		, city
	from #tempTB

UNION
	-- getting all booked cases
	select Name
		, 'Booked'as VisitType
		, sum(cases)
		, Month
		, Month2
		, Quarter
		, Year
		, City
	from #tempTB
	group by name,  month, month2,Quarter, year,city

UNION
	-- Getting canceled and actual visits
	select Name
		, Case VisitType
			when 'Cancel' then
				'NSC'
			when 'Visit' then
				'Visits'
			end as Service
		, sum(Cases) as Cases
		, Month
		, Month2
		, Quarter
		, Year
		, City
	from #tempTB
	group by name, visittype, month, month2,Quarter, year,city

 drop table #tempTB;

