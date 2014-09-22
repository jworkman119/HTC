Select Company
	, Department
	, Name
	, Case Disabled
		When -1 then
			'Yes'
		else
			'No'
	 End as Disabled
	, Disability	
	, sum(Hours) as Hours
	, sum(Gross) as Gross	
from Payroll
	Left Join Disabled on Payroll.SSN = Disabled.SSN
	Where Payroll.LastName = 'Looman'
Group by 
	 Company
	, Department
	, Name
	, Disabled
	, Disability
Order by Gross desc 		
	
	