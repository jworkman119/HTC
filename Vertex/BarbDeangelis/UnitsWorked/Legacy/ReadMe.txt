Barb needs a quarterly report, that tracks the hours worked by month.
The hard part the days worked need to be broken up by: third, half, full.

1. Run vertexQuery.sql - make sure you update the time frame
2. Import the data into BarbDatabase.sqlite, name the new table accordingly. ex: ThirdQtr2014
	- It's ok to drop tables that are over a couple of years old.
3. Create view,sqlite_CreateVw.sql , that calculates whether a day worked was: third, half, full.
4. run FinalQuery_SQLite.sql - take results and export to excel spreadsheet, update formatting.

* At end of year she will request an annual report, you will have to run sqlite_CreateVw_yr.sql