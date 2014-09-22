
Declare @Date varchar(10)

set @Date = convert(varchar(10), DateAdd(dd,-1,GetDate()), 101)

Set @Date = '1/1/2012'


select Distinct Customers.cmp_name as Company
		, cmp_fadd1 as Address1
		, cmp_fadd2 + ', ' + cmp_fadd3 as Address2
		, cmp_fcity + ', ' + StateCode + ' ' + cmp_fpc as CityStateZip
		, cmp_tel as phone
from  oelinhst_sql as OE 
	 join oehdrhst_sql as Orders on Orders.ord_no = OE.ord_no
			and oe.inv_no = orders.inv_no
	join cicmpy as Customers on OE.cus_no = Customers.cmp_code
where billed_dt >= @Date
	and billed_dt < GetDate()
	and qty_ordered = qty_to_ship
	and Orders.status = 'p'
	and Orders.rma_no is null
order by cmp_name


select *
from BarbPC