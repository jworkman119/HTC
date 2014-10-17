Select ticket.ID 
	, Submitter.FULL_NAME Submitted_By
	, priority.NAME as Priority
	, ticket.Title as Title
	, Category.Name
	 , Lower(DATE_FORMAT(ticket.CREATED, '%m-%d-%Y %l:%m %p')) as Created
	 , Status.State
	 , Owner.Full_Name
	 , Comments.Comment
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
WHERE 
	Submitter.FULL_NAME = 'Sara Nobis'
--	Owner.FULL_NAME = 'Jeremy Patterson'
--	and 
	
order by ticket.CREATED DESC

