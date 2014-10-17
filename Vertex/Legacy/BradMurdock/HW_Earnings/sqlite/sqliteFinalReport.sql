select Earnings2012_Q2.JobNumber
, Earnings2012_Q2.JobDsc
, round(HoursWorked,2) as HoursWorked
, round(Earnings,2) as Earnings
, round(HW2012_Q2.HealthWelfare,2) as HealthWelfare_Premium
, round(Earnings + HW2012_Q2.HealthWelfare,2) as TotalCompensation
from Earnings2012_Q2
         Left Join HW2012_Q2 on Earnings2012_Q2.JobNumber = HW2012_Q2.JobNumber
          and  Earnings2012_Q2.JobDSC = HW2012_Q2.JobDescription
order by Earnings2012_Q2.JobNumber