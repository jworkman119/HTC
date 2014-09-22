select 
	ifnull(Staff.FULL_NAME,' Unassigned') as Staff
    , Round(AVG(SATISFACTION_RATING),1) as avgRating
	, Tickets.Total as Tickets
	, Concat(MonthName(HD_TICKET.TIME_CLOSED),' - ',Cast(Year(HD_TICKET.TIME_CLOSED) as CHAR(4))) as Month
from HD_TICKET
	left join HD_STATUS on HD_STATUS_ID = HD_STATUS.ID
	left join USER as Staff on HD_TICKET.OWNER_ID = Staff.ID
	left join 
		(
				Select 
					 OWNER_ID as OwnerID
				    , count(Ticket.ID) as Total	
			    From HD_TICKET as Ticket
					left join HD_STATUS on Ticket.HD_STATUS_ID = HD_STATUS.ID
				Where Ticket.HD_QUEUE_ID = 1 
					and HD_STATUS.STATE = 'closed' 
					and Ticket.TIME_CLOSED >= (now() - interval 1 month)
					and Ticket.TIME_CLOSED <=(LAST_DAY(now() - interval 1 month))
				Group by OWNER_ID
		) Tickets on HD_TICKET.OWNER_ID = Tickets.OwnerID
where HD_TICKET.HD_QUEUE_ID = 1 
	and HD_STATUS.STATE = 'closed' 
	and HD_TICKET.SATISFACTION_RATING != 0 
	and Month(HD_TICKET.TIME_CLOSED) = Month(Now()) - 1
	and Year(HD_TICKET.TIME_CLOSED) = YEAR(now() - interval 1 month)
Group By
	Staff.FULL_NAME
	, MonthName(HD_TICKET.TIME_CLOSED)
Order by Staff

