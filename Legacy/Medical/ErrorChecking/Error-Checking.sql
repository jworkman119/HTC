-- Rows, that have data that I don't track
select *
from datadump
where [proc] in ('CC','INJ','INT','PES','UPE')

select (finclass)
from DataDump
where Datadump.Account + '|' + DataDump.[Proc] + '|' + DataDump.[Date]
	Not in (
				select Datadump.Account + '|' + DataDump.[Proc] + '|' + DataDump.[Date]
				from datadump
					join Visit on DataDump.Account = Visit.Patient_Account
						and DataDump.Date = Visit.Date
						and DataDump.[Proc] = Visit.Service_ID
	)





select date
	, account
	, carrier
	, provider_last + ', ' + provider_first
	, Provider.ID
	, finclass
	, Location
from datadump
	left join Provider on datadump.Provider_Last = Provider.Last_Name
		and datadump.Provider_First = Provider.First_Name
where date >= '12/1/2010'
	and Provider.ID is NULL
order by date

select *
from datadump