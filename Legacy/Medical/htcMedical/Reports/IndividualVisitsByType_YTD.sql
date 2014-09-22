/*
USE htcMedical

GO

IF EXISTS (SELECT * FROM sysobjects WHERE NAME='spIndividualVisitsByType_YTD' AND TYPE='P')
	DROP PROCEDURE spCases_Provider_YTD
GO


Create Procedure spIndividualVisitsByType_YTD

	@FromDate smalldatetime
	, @ToDate smalldatetime

AS
*/

Create Table #Temp(
	Name varchar(100)
	, Service varchar(15)
	, Cases int
	, year int
	, City varchar(25)
--	, VisitType varchar(7)
)

--Testing

Declare @FromDate datetime
Declare @ToDate datetime

Set @FromDate = '1/1/2010'
Set @ToDate = '12/31/2010'

--exec spCases_Provider_YTD @FromDate, @ToDate

insert into #Temp(Name, Service, Cases, Year, City)
exec spCases_Provider_ytd @FromDate, @ToDate

EXECUTE crosstab 'Select Name, Year, City from #Temp Group by Name, Year ,City Order by Year, Name'
	, 'sum(Cases)'
	, 'Service'
	, '#Temp'

drop table #Temp;