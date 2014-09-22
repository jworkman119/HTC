SELECT 
	 dbo_arshtfil2_sql.ord_no
	, Format(dbo_arshtfil2_sql.shippeddate,"mm/dd/yyyy") AS ShippedDate
	, sum([TxnLine Quantity]) as Qty
	, dbo_arshtfil2_sql.mode as Carrier
	, dbo_arshtfil2_sql.ship_cost
	, "'" + dbo_arshtfil2_sql.tracking_no + "'" as Tracking_No
	, TS
FROM dbo_arshtfil2_sql 
	left JOIN dailyfinal2 ON dbo_arshtfil2_sql.ord_no=dailyfinal2.refnumber
WHERE 
	[txnDate]>= #1/1/2010#
	and [txnDate]<= #12/31/2010#
	and year(txnDate) = 2010
	And Ship_Cost > 0
GROUP BY dbo_arshtfil2_sql.ord_no
	, dbo_arshtfil2_sql.extra_1
	, dbo_arshtfil2_sql.mode
	, dbo_arshtfil2_sql.ship_cost
	, dbo_arshtfil2_sql.tracking_no
	, dbo_arshtfil2_sql.shippeddate
	, dailyfinal2.TxnDate
	, TS
ORDER BY 
	dbo_arshtfil2_sql.ord_no
	, dbo_arshtfil2_sql.shippeddate
	, dbo_arshtfil2_sql.mode;


