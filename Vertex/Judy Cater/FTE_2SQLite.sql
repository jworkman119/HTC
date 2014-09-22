 select 
     Dec.CostCenter
	, Dec.Job
	, Dec.JobDescription
	, round(sum(Dec.Hours)/165,2) as Disabled 
    ,  ifNull(Dec2.FTE_NonDisabled,0) as NonDisabled
    
from Dec
	Left Join(
				Select Dec.CostCenter
					, Dec.Job
					, Dec.JobDescription
					, round(sum(Dec.Hours)/165,2) as FTE_NonDisabled 
				from Dec 
				Where Dec.DisabilityCode = 3  
				group by
					   Dec.CostCenter
					 , Dec.Job
					 , Dec.JobDescription
		) as Dec2 On Dec2.CostCenter = Dec.CostCenter
			and Dec2.Job = Dec.Job
			and Dec2.JobDescription = Dec.JobDescription
Where Dec.DisabilityCode <> 3		
group by
   Dec.CostCenter
 , Dec.Job
 , Dec.JobDescription	