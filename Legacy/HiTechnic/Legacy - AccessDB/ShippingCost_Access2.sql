Select ord_no
	,Customer
	,ShippedDate
	, TxnDate
	, Qty
	, HTC_Charges
	, Carrier
	, Ship_Cost
	, Tracking_No
	
From
(
	SELECT distinct
		 dbo_arshtfil2_sql.ord_no
		, dailyfinal2.Customer as Customer
		, Format(dbo_arshtfil2_sql.shippeddate,"mm/dd/yyyy") AS ShippedDate
		, dailyfinal2.TxnDate
		, sum([TxnLine Quantity]) as Qty
		, iif(sum([TxnLine Quantity])>19, format(5.00,"Standard") + 2.80,	Format((sum([TxnLine Quantity]) * .23) + 2.80,"Standard")) as HTC_Charges
		, dbo_arshtfil2_sql.mode as Carrier
		, dbo_arshtfil2_sql.ship_cost
		, "'" + dbo_arshtfil2_sql.tracking_no + "'" as Tracking_No
	FROM dbo_arshtfil2_sql 
		left JOIN dailyfinal2 ON dbo_arshtfil2_sql.ord_no=dailyfinal2.refnumber
	WHERE 
		[txnDate]>= #4/1/2011#
		and [txnDate]<= #4/30/2011#
		and year(txnDate) = 2011
		And Ship_Cost > 0
		AND Left([mode],5) = 'FedEx'
	GROUP BY dbo_arshtfil2_sql.ord_no
		, dailyfinal2.Customer
		, dbo_arshtfil2_sql.mode
		, dbo_arshtfil2_sql.ship_cost
		, dbo_arshtfil2_sql.tracking_no
		, dbo_arshtfil2_sql.shippeddate
		, dailyfinal2.TxnDate


UNION ALL

	SELECT distinct
		 dbo_arshtfil2_sql.ord_no
		, dailyfinal2.Customer as Customer
		, Format(dbo_arshtfil2_sql.shippeddate,"mm/dd/yyyy") AS ShippedDate
		, dailyfinal2.TxnDate
		, sum([TxnLine Quantity]) as Qty
		, iif(sum([TxnLine Quantity])>19, format(5.00,"Standard") + 2.80,	Format((sum([TxnLine Quantity]) * .23) + 2.80,"Standard")) as HTC_Charges
		, dbo_arshtfil2_sql.mode as Carrier
		, dbo_arshtfil2_sql.ship_cost
		, "'" + dbo_arshtfil2_sql.tracking_no + "'" as Tracking_No
	FROM dbo_arshtfil2_sql 
		left JOIN dailyfinal2 ON dbo_arshtfil2_sql.ord_no=dailyfinal2.refnumber
	WHERE 
		[txnDate]>= #4/1/2011#
		and [txnDate]<= #4/30/2011#
		and year(txnDate) = 2011
		And Ship_Cost > 0
		AND Left([mode],5) <> 'FedEx'
	GROUP BY dbo_arshtfil2_sql.ord_no
		, dailyfinal2.Customer
		, dbo_arshtfil2_sql.mode
		, dbo_arshtfil2_sql.ship_cost
		, dbo_arshtfil2_sql.tracking_no
		, dbo_arshtfil2_sql.shippeddate
		, dailyfinal2.TxnDate
)
ORDER BY 
	Carrier
	,shippeddate
	, ord_no



