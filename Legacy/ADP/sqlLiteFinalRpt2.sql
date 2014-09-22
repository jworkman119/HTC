
Select Company
	, Name
	, DisabilityCode
	, Disability	
	, Gross
	, Gross_NoOT
	, Hours
	, HourRate
	, case 
		When Hours_wOT = Hours then
			null
		Else
			Hours_wOT
	  End as Hours_wOT
	, case 
		When Hours_wOT = Hours then
			null
		Else
			HourRate_wOT
	  End as HourRate_wOT
from Payroll
	Left Join Disabled on Payroll.SSN = Disabled.SSN

Select Company
	, Disability 
	, sum(Gross) as Gross
	, sum(Gross_noOT) as Gross_noOT
	, sum(Hours) as Hours
	, round(avg(HourRate),2) as HourRate
	, sum(Hours_wOT) as Hours_wOT
	, round(avg(HourRate_wOT),2) as HourRate_wOT
From Payroll	
	Join Disabled on Payroll.SSN = Disabled.SSN
Group By
	Company
	, Disability
