		select provider_id 
			, facility_id
			, count(facility_id) as Visits
		into #tempTB
		from visit
		group by provider_id, facility_id
		order by provider_id, Visits desc

Update Provider
Set primeFacility_ID = #TempTB.facility_ID
from (
		select provider_id, max(visits) as MaxVisits
		from #tempTB
		group by #tempTB.provider_id
	)as Totals
	Join #tempTB on Totals.Provider_ID = #tempTB.Provider_ID
		and Totals.MaxVisits = #tempTB.Visits
	Join Provider on #tempTB.Provider_ID = Provider.ID
--Order By Last_Name

