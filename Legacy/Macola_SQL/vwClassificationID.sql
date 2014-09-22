Create View vwHTC_ClassificationID

With SchemaBinding

as

select Distinct Customers.cmp_code
	, case Customers.classificationid
		When 'FSE' then
			'USF'
		Else
			rtrim(Customers.classificationid)
		End as ClassificationID
	, case Customers.classificationid
		When 'FSE' then
			'US Forest Service'
		Else
			rtrim(Classifications.Description)
		End as Description
From dbo.Cicmpy as Customers
	Inner join dbo.Classifications on Customers.ClassificationID = Classifications.ClassificationID


