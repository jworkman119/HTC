Select Full_Name as Owner
	  , Category.NAME as Category	
	  , Round(AVG(Floor( DateDiff(Ticket.TIME_CLOSED,Ticket.TIME_OPENED)/7 ) * 5 +                                         
			Case
				When DayOfWeek(Ticket.TIME_OPENED)=1 and DayOfWeek(Ticket.TIME_CLOSED)=7 Then
					5 
			    When DayOfWeek(Ticket.TIME_OPENED) in(7,1) and DayOfWeek(Ticket.TIME_CLOSED) in (7,1) Then 
					0
			    When DayOfWeek(Ticket.TIME_OPENED)=DayOfWeek(Ticket.TIME_CLOSED) Then 
					0 
			    When DayOfWeek(Ticket.TIME_OPENED) in(7,1) and DayOfWeek(Ticket.TIME_CLOSED) not in (7,1) Then 
					DayOfWeek(Ticket.TIME_CLOSED)-2 
			    When DayOfWeek(Ticket.TIME_OPENED) not in(7,1) and DayOfWeek(Ticket.TIME_CLOSED) in(7,1) Then 
					7-DayOfWeek(Ticket.TIME_OPENED) 
			    When DayOfWeek(Ticket.TIME_OPENED)<=DayOfWeek(Ticket.TIME_CLOSED) Then 
					DayOfWeek(Ticket.TIME_CLOSED)-DayOfWeek(Ticket.TIME_OPENED)
			    When DayOfWeek(Ticket.TIME_OPENED)>DayOfWeek(Ticket.TIME_CLOSED) Then 
					4-(DayOfWeek(Ticket.TIME_OPENED)-DayOfWeek(Ticket.TIME_CLOSED)-1)
			    Else
					0
          End),2) as BusinessDaysOpened
		, Count(Ticket.ID) as 'NoOfCases'
from HD_TICKET as Ticket
	left join HD_CATEGORY as Category on Ticket.HD_CATEGORY_ID = Category.ID
	left join HD_STATUS as Status on Ticket.HD_STATUS_ID = Status.ID
	Join HD_QUEUE as Que on Que.ID = Ticket.HD_QUEUE_ID
	Join USER on Ticket.OWNER_ID = USER.ID
where Status.STATE = 'closed' 
	and (Ticket.TIME_OPENED between DATE_FORMAT(NOW(), '%Y-01-01') and NOW())
	and Que.Name = 'The HTC IT Help Desk'
	and DateDiff(Ticket.TIME_CLOSED,Ticket.TIME_OPENED) is not null
Group By 
	Full_Name	
	, Category.NAME


Union

	Select Full_Name as Owner
		  , 'Total'	as Category
		  , Round(AVG(Floor( DateDiff(Ticket.TIME_CLOSED,Ticket.TIME_OPENED)/7 ) * 5 +                                         
				Case
					When DayOfWeek(Ticket.TIME_OPENED)=1 and DayOfWeek(Ticket.TIME_CLOSED)=7 Then
						5 
					When DayOfWeek(Ticket.TIME_OPENED) in(7,1) and DayOfWeek(Ticket.TIME_CLOSED) in (7,1) Then 
						0
					When DayOfWeek(Ticket.TIME_OPENED)=DayOfWeek(Ticket.TIME_CLOSED) Then 
						0 
					When DayOfWeek(Ticket.TIME_OPENED) in(7,1) and DayOfWeek(Ticket.TIME_CLOSED) not in (7,1) Then 
						DayOfWeek(Ticket.TIME_CLOSED)-2 
					When DayOfWeek(Ticket.TIME_OPENED) not in(7,1) and DayOfWeek(Ticket.TIME_CLOSED) in(7,1) Then 
						7-DayOfWeek(Ticket.TIME_OPENED) 
					When DayOfWeek(Ticket.TIME_OPENED)<=DayOfWeek(Ticket.TIME_CLOSED) Then 
						DayOfWeek(Ticket.TIME_CLOSED)-DayOfWeek(Ticket.TIME_OPENED)
					When DayOfWeek(Ticket.TIME_OPENED)>DayOfWeek(Ticket.TIME_CLOSED) Then 
						4-(DayOfWeek(Ticket.TIME_OPENED)-DayOfWeek(Ticket.TIME_CLOSED)-1)
					Else
						0
			  End),2) as BusinessDaysOpened
			, Count(Ticket.ID) as 'NoOfCases'
	from HD_TICKET as Ticket
		left join HD_CATEGORY as Category on Ticket.HD_CATEGORY_ID = Category.ID
		left join HD_STATUS as Status on Ticket.HD_STATUS_ID = Status.ID
		Join HD_QUEUE as Que on Que.ID = Ticket.HD_QUEUE_ID
		Join USER on Ticket.OWNER_ID = USER.ID
	where Status.STATE = 'closed' 
		and (Ticket.TIME_OPENED between DATE_FORMAT(NOW(), '%Y-01-01') and NOW())
		and Que.Name = 'The HTC IT Help Desk'
		and DateDiff(Ticket.TIME_CLOSED,Ticket.TIME_OPENED) is not null
	Group By 
		Full_Name	
Order by Owner, Category