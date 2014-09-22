select cmp_name as customer
	, rtrim(Family.fam1) as FamilyCode
	,Family.Fam2 as Description
	, cast(sum(oe.qty_ordered)as Int) as Qty 
	, year(request_dt) as year
from oelinhst_sql as OE 
	join cicmpy as Customers on OE.cus_no = Customers.cmp_code
	join items on OE.item_no = items.ItemCode
	left join zzzhtc_family as Family on items.itemcode = Family.item
where Family.fam1 is not NULL 
	and ltrim(cus_no) in (
	'92951'
	,'70829'
	,'93067'
	,'85145'
	,'92463'
	,'85148'
	,'91283'
	,'88388'
	,'81124'
	,'72351'
	,'72582'
	,'72867'
	,'73151'
	,'90514'
	,'79401'
	,'78854'
	,'91287'
	,'73566'
	,'73663'
	,'81743'
	,'78659'
	,'73817'
	,'91292'
	,'90315'
	,'84185'
	,'91297'
	,'75023'
	,'86003'
	,'91303'
	,'80703'
	,'90318'
	,'77751'
	,'90721'
	)

group by cmp_name 
	, Family.fam1
	,Family.Fam2 	
	, year(request_dt) 
order by cmp_name, year



