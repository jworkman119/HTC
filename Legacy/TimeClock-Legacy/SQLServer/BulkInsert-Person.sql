Use TimeClock

Bulk Insert DataDump From 'C:\Users\jeremyp\Documents\Development\TimeClock\db_htcTimeClock\StateFair2010-Data.csv' with (fieldterminator = ',')

Insert into Person (SSN,FirstName,LastName,PicPath,Gender,Under18,Role_ID) 
Select *
from DataDump

drop table DataDump



