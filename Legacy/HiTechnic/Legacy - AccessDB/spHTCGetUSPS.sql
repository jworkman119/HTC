--Alter Procedure htcGetFedEx (@StartDate as SmallDateTime = NULL, @EndDate as SmallDateTime = NULL) 
--	as 

 Declare @StartDate as SmallDateTime
 Declare @EndDate as SmallDateTime

set @startdate = '5/1/2010'
set @enddate = '5/31/2010'

If @StartDate is Null
	Set @StartDate = convert(varchar,GetDate(), 101)
If @EndDate is Null
	Set @EndDate = convert(varchar,GetDate()+1, 101)

select ord_no, mode, '"' + Tracking_no + '"' as tracking_no , ship_cost, convert(varchar,shippeddate, 101) as Ship_Date
from arshtfil2_sql
where shippeddate >= @StartDate
	 and shippeddate <= @EndDate
--	 and mode like 'FedEx%'
Order by Mode 

