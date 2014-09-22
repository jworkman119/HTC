SELECT MonthName(dbo_arshtfil2_sql.shippeddate) AS MonthShipped
	, dbo_arshtfil2_sql.ord_no
	, dailyfinal2.Customer
	, Format(dbo_arshtfil2_sql.shippeddate,"mm-dd-yyyy") AS ShippedDate
	, dbo_arshtfil2_sql.mode
	, dbo_arshtfil2_sql.ship_cost
	, dbo_arshtfil2_sql.tracking_no
FROM dbo_arshtfil2_sql 
	INNER JOIN dailyfinal2 ON dbo_arshtfil2_sql.ord_no=dailyfinal2.refnumber
WHERE Month([shippeddate])= 5 
	AND Left([mode],5)='FedEx'
GROUP BY dbo_arshtfil2_sql.ord_no
	, dailyfinal2.Customer
	, dbo_arshtfil2_sql.mode
	, dbo_arshtfil2_sql.ship_cost
	, dbo_arshtfil2_sql.tracking_no
	, dbo_arshtfil2_sql.shippeddate
ORDER BY dbo_arshtfil2_sql.shippeddate
;
