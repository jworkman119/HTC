Select Visitor.Company
, Visitor.LastName ||   ',  ' || Visitor.FirstName as Visitor
, Visitor.ID as VisitorID
,  Location.Description
, strftime( '%m/%d/%Y %H:%M', timestamp, 'localtime') as Date
From Visitor
	join Signature on Visitor.ID = Signature.Visitor_ID
	Left Join Location on Signature.Location_Id = Location.Id
Order by Company desc, Visitor.LastName desc, Date
