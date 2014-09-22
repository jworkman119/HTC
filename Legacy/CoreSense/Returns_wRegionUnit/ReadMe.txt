1. CoreSense
	a. Export all USFS customers 
		- Order Processing -> Customer Manager
		- Save as csv
	b. Export all orders by Customer No
		- Reports -> Saved Reports -> Returns_CustomerNo
		- Save as csv
	c. Export all Return Data
		- Accounting -> Saved Reports -> usfs-ReturnItems

* Remember to change the dates to the appropriate timeline for each report.
2. Excel
	a. Filter 1a, so it only has client_id, region, subunit
		
* change all headers, so they are one word ex: Client Id -> ClientID

3. SQLite
	a. truncate all tables
	b. import data into appropriate tables
	c. remove duplicates by importing the data from OrderCustomer -> OrderCustomer2
		- solution is in SQL
	d. run detailed, aggregate SQL statements
	e. export data to Excel.