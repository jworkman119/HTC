Select ticket.ID 
	, Submitter.FULL_NAME Submitted_By
	, priority.NAME as Priority
	, ticket.Title as Title
	, Comments.Comment
	, Category.Name
	
from HD_TICKET as ticket
	Join USER as Submitter on ticket.SUBMITTER_ID = Submitter.ID
	Join USER as Owner on ticket.OWNER_ID = Owner.ID
	left Join HD_PRIORITY as priority ON priority.ID = ticket.HD_PRIORITY_ID
	left Join HD_STATUS AS Status on Status.ID = ticket.HD_STATUS_ID
	left Join HD_CATEGORY AS Category on Category.ID = ticket.HD_CATEGORY_ID
	Left Join (
					select HD_TICKET_ID as ID
						, COMMENT as Comment
						, min(TIMESTAMP) as TimeStamp
					from HD_TICKET_CHANGE
					group by HD_TICKET_ID
				) Comments on Comments.ID = ticket.ID
WHERE Owner.FULL_NAME = 'James Workman'
	and  Status.NAME = 'New' 
	and ticket.CUSTOM_FIELD_VALUE0 in ('MHCU','MHCR')
order by ticket.CREATED DESC