Select  HW.EmployeeNumber
,HW.Person
, Round(Sum(HW.HealthWelfare),2) as HealthWelfare
, Round(Hours.Hours,2) as Hours
, HW.CheckDate
from HealtherWelfare HW
Join Hours on  HW.EmployeeNumber = Hours.EmployeeNumber
and Hours.CheckDate = HW.CheckDate
Group by HW.EmployeeNumber
, HW.Person
,HW.CheckDate
Order by HW.Person
, HW.CheckDate desc