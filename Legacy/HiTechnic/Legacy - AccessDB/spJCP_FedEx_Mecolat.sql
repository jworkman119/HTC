SELECT convert(varchar(10),arshtfil2_sql.shippeddate, 101) as [Ship Date]
	, arshtfil2_sql.ord_no
	, arshtfil2_sql.extra_1 as Customer
--, Format(dbo_arshtfil2_sql.shippeddate,"mm-dd-yyyy") AS ShippedDate
	, arshtfil2_sql.mode as Carrier
	, arshtfil2_sql.ship_cost
	, '"' + arshtfil2_sql.tracking_no + '"' as Tracking#
FROM arshtfil2_sql 
--	left JOIN dailyfinal2 ON dbo_arshtfil2_sql.ord_no=dailyfinal2.refnumber
WHERE Month([shippeddate])= 9 
	AND Left([mode],5) != 'FedEx'

GROUP BY arshtfil2_sql.ord_no
--	, dailyfinal2.Customer
	, arshtfil2_sql.extra_1
	, arshtfil2_sql.mode
	, arshtfil2_sql.ship_cost
	, arshtfil2_sql.tracking_no
	, arshtfil2_sql.shippeddate
ORDER BY arshtfil2_sql.shippeddate;


