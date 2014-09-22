select 
	HD_CATEGORY.NAME as Category 
    , Round(AVG(SATISFACTION_RATING),1) as avgRating
    , Count(HD_TICKET.ID) as Tickets
    , ifnull(Staff.FULL_NAME,' Unassigned') as Staff
from HD_TICKET
	left join HD_CATEGORY on HD_CATEGORY_ID = HD_CATEGORY.ID
	left join HD_STATUS on HD_STATUS_ID = HD_STATUS.ID
	left join HD_PRIORITY on HD_PRIORITY_ID = HD_PRIORITY.ID
	left join HD_IMPACT on HD_IMPACT_ID = HD_IMPACT.ID
	left join MACHINE on HD_TICKET.MACHINE_ID = MACHINE.ID
	left join USER as Staff on HD_TICKET.OWNER_ID = Staff.ID
where (HD_TICKET.HD_QUEUE_ID = 1) 
	and HD_STATUS.STATE = 'closed' 
	and HD_TICKET.SATISFACTION_RATING != 0 
	and HD_TICKET.TIME_CLOSED > DATE_SUB(NOW(), INTERVAL 31 DAY)
Group By
	HD_CATEGORY.NAME
	, Staff.FULL_NAME
Order by Staff, Category