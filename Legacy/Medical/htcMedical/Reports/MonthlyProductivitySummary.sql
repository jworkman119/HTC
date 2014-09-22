/*
USE htcMedical 

GO

IF EXISTS (SELECT * FROM sysobjects WHERE NAME='spMonthlyProductivity' AND TYPE='P')
	DROP PROCEDURE spMonthlyProductivity
GO


CREATE Procedure spMonthlyProductivity

	@FromDate smalldatetime
	, @ToDate smalldatetime

AS
*/


Declare @FromDate datetime
Declare @ToDate datetime

Set @FromDate = '2/1/2011'
Set @ToDate = '2/28/2011'


select 	DateName( month , DateAdd( month , Month(@FromDate) , 0 ) - 1 ) as [Month]
	, Month(@FromDate) as Month_No
	, case Provider.Last_Name 
			When 'Bushan' then
				'Langer' + ', ' + left(Provider.First_Name,1)
			else
				Provider.Last_Name + ', ' + left(Provider.First_Name,1) 
	End as Provider
	, TotalVisits.TotalVisits as [Scheduled Visits]
	, sum(VisitsSeen.DailyVisits) as Visits
	, Patients.PatientCount as Seen
	, sum(VisitsSeen.UnitsPerDay)as Units

	, round(WDPM.WDPM * (BHPD.BHPD *4),2) as [Standard Units]
	, round(sum(VisitsSeen.UnitsPerDay)/(WDPM.WDPM*7.5 * (BHPD.BHPD *4))*100,2) as Productivity_Test
	, round(sum(VisitsSeen.UnitsPerDay)/(WDPM.WDPM * (BHPD.BHPD *4))*100,2) as Productivity
	, convert(decimal(5,2),round(BHPD.BHPD,2)) as BHPD
	, convert(decimal(5,2),round(BHPD.BHPD *4,2)) as UPD
	, convert(decimal(5,2),round(WDPM.WDPM,2)) as WDPM

	, Facility.City
	, convert(decimal(5,2),round(cast(sum(VisitsSeen.UnitsPerDay) as float)/cast(count(VisitsSeen.provider_id) as float),2)) as [AVG-UPD]
	, convert(decimal(5,2),round((cast((TotalVisits.TotalVisits - sum(VisitsSeen.DailyVisits)) as float)/TotalVisits.TotalVisits)*100, 2)) as NSCRate
from Provider
	-- derived table that will hold the weighted visits
	Join (
		select provider_id
				, count(date)DailyVisits
				, sum(Service.units) as UnitsPerDay
				, cast(sum(Service.AllottedTime) as float) as HoursDay
			from visit
				join Service on visit.service_id = Service.ID
			Where 
				visit.date >= @FromDate
				and visit.date <= @ToDate
				and service.weight > 0
			group by provider_id, date
		) VisitsSeen on Provider.ID = VisitsSeen.Provider_ID 
	-- derived table that will hold the total visits
	Join (
			select provider_id
				, count(visit.id) as TotalVisits
				, cast(sum(allottedTime) as float) as BillableHours
			from visit
				join provider on visit.provider_id = provider.id
				join service on visit.service_id = service.id
			where
				visit.date >= @FromDate
				and visit.date <= @ToDate
			group by provider_id
			)TotalVisits on Provider.ID = TotalVisits.Provider_ID
    Join (
			select provider_id 
				, Count(Distinct Patient_Account) as PatientCount
			from visit
				join service on visit.service_id = service.id
			where visit.date >= @FromDate
				and visit.date <= @ToDate
				and service.weight > 0
			group by provider_id
			)Patients on Provider.ID = Patients.Provider_ID
	Join Facility on Facility.Id = Provider.primeFacility_ID
	Join BHPD on Provider.ID = BHPD.Provider_ID
	Join WDPM on Provider.ID = WDPM.Provider_ID
where WDPM.MonthWorked = month(@FromDate)
	and WDPM.Year = year(@FromDate)
group by VisitsSeen.provider_id
	, Provider.Last_Name
	, Provider.First_Name
	, Patients.PatientCount
	, TotalVisits.TotalVisits
	, TotalVisits.BillAbleHours
	, BHPD.BHPD
	, WDPM.WDPM
	, Facility.City
Order by Facility.City, Provider
	
