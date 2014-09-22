
USE htcMedical

GO

IF EXISTS (SELECT * FROM sysobjects WHERE NAME='spCases_Provider_YTD' AND TYPE='P')
	DROP PROCEDURE spCases_Provider_YTD
GO

Create Procedure spCases_Provider_YTD 

	@FromDate smalldatetime
	, @ToDate smalldatetime

AS


/*
Declare @FromDate datetime
Declare @ToDate datetime

Set @FromDate = '1/1/2010'
Set @ToDate = '12/31/2010'
*/

select 
		case Provider.Last_Name 
			When 'Bushan' then
				'Langer' + ', ' + left(Provider.First_Name,1)
			else
				Provider.Last_Name + ', ' + left(Provider.First_Name,1) 
		End as Name
	, Service.ID as Service
	, Count(Visit.ID) as Cases
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
	join Service on Service.ID = Visit.Service_ID
	join Facility on Facility.ID = Provider.primeFacility_ID
	join BHPD on BHPD.Provider_ID = Provider.Id
Where visit.date >= @FromDate
	and visit.date <= @ToDate
	and provider.id in (select wdpm.provider_id from wdpm)
group by 
	Provider.Last_Name
	, Provider.First_Name
	, Service.ID
	, year(Visit.date)
	, service.allottedTime
	, Facility.City
	, Service.Weight
order by Facility.City, Name,  VisitType asc , Service.ID



	-- retrieving all data from temptable
	select distinct Name
		, Service
		, Cases
		, year
		, city
	from #tempTB

UNION
	-- getting all booked cases
	select Name
		, 'Booked'as VisitType
		, sum(cases)
		, Year
		, City
	from #tempTB
	group by name, year,city

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
		, Year
		, City
	from #tempTB
	group by name, visittype, year,city

 drop table #tempTB;
