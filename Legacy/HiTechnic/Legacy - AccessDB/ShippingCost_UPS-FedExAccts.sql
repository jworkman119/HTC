SELECT UPS_FedExAcct.RefNumber
	, UPS_FedExAcct.Customer
	, Format(dbo_arshtfil2_sql.shippeddate,"mm/dd/yyyy") AS ShippedDate
	, UPS_FedExAcct.TxnDate
	, sum(UPS_FedExAcct.[TxnLine Quantity]) as Qty
	, iif(sum([TxnLine Quantity])>19, format(5.00,"Standard") + 2.80,	Format((sum([TxnLine Quantity]) * .23) + 2.80,"Standard")) as HTC_Charges
	, UPS_FedExAcct.[Ship Method] as Carrier
	, dbo_arshtfil2_sql.ship_cost
	, "'" + dbo_arshtfil2_sql.tracking_no + "'" as Tracking_No
	, "'" + [FedEx Acc No] + "'"  as FedEx_No
	, TS
FROM UPS_FedExAcct
	left JOIN dbo_arshtfil2_sql ON dbo_arshtfil2_sql.ord_no=UPS_FedExAcct.refnumber
WHERE 
		ts >= #12/1/2010#
GROUP BY 
	UPS_FedExAcct.RefNumber
	, UPS_FedExAcct.Customer
	, UPS_FedExAcct.[Ship Method] 
	, dbo_arshtfil2_sql.ship_cost
	, dbo_arshtfil2_sql.tracking_no
	, dbo_arshtfil2_sql.shippeddate
	, UPS_FedExAcct.TxnDate
	, [FedEx Acc No] 
	, TS
Order By TS