Select ticket.ID 
	, Submitter.FULL_NAME Submitted_By
	, Priority.NAME as Priority
	, ticket.Title as Title
	, Comments.Comment
	, Category.Name
from HD_TICKET as ticket
	Join USER as Submitter on ticket.SUBMITTER_ID = Submitter.ID
	Join USER as Owner on ticket.OWNER_ID = Owner.ID
	left Join HD_PRIORITY as Priority ON Priority.ID = ticket.HD_PRIORITY_ID
	left Join HD_STATUS AS Status on Status.ID = ticket.HD_STATUS_ID
	left Join HD_CATEGORY AS Category on Category.ID = ticket.HD_CATEGORY_ID
	left Join HD_QUEUE as Que on Que.ID = ticket.HD_QUEUE_ID
	Left Join (
					select HD_TICKET_ID as ID
						, COMMENT as Comment
						, min(TIMESTAMP) as TimeStamp
					from HD_TICKET_CHANGE
					group by HD_TICKET_ID
				) Comments on Comments.ID = ticket.ID
WHERE  Priority.NAME = 'High' 
	and Que.Name = 'The HTC IT Help Desk'
	and Status.NAME != 'Closed'
order by ticket.CREATED DESC