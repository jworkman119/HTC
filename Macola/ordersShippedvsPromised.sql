Select Distinct OE.Ord_No
	, ltrim(Customers.cmp_code) as CompanyCode
	, Customers.cmp_Name as Company
	, convert(varchar(10),OE.ord_dt,101) as OrderDate
	, convert(varchar(10),OE2.promise_dt,101) as Promised
	, convert(varchar(10),OE.ord_dt_shipped,101) as ShipDate
	, datediff(d,OE2.promise_dt,OE.ord_dt_shipped) as Difference
	, OE2.Loc as LocationCode
from oehdrhst_sql as OE
	join oelinhst_sql as OE2 on OE.ord_no = OE2.ord_no
	join cicmpy as Customers on OE.cus_no = Customers.cmp_code
Where OE.ord_dt_shipped >= '2014-08-01'
	and OE.ord_dt_shipped <= '2014-08-31'
order by ShipDate


