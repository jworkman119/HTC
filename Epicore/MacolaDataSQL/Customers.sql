Select top 20 Customers.*
from oehdrhst_sql as Orders
join cicmpy as Customers on Orders.cus_no = Customers.cmp_code
Where ord_dt > DateAdd(yy,-3,GetDate())


Select top 20 Cmp_Code as 'Cicmpy.Cmp_Code'
	, cmp_name as 'Cicmpy.Cmp_Name'
	, 'C' as Type
	, cmp_fadd1 as 'Cicmpy.fadd1'
	, cmp_fadd2 as 'Cicmpy.fadd2'
	, cmp_fadd3 as 'Cicmpy.fadd3'
	, cmp_fcity as 'Cicmpy.cmp_fcity'
	, StateCode as 'Cicmpy.StateCode'
	, cmp_fpc as 'Cicmpy.fpc'
	, cmp_fctry as 'Cicmpy.cmp_fctry'
	, 'HTC' as Territory 
	, 'House' as SalesPerson
	, cmp_tel as 'Cicmpy.cmp_tel'
	, cmp_fax as 'Cicmpy.cmp_fax'
	, cmp_web as 'Cicmpy.cmp_web'
	, cmp_e_mail as 'Cicmpy.cmp_e_mail'
	, Orders.bill_to_name as 'oehdrhst_sql.bill_to_name'
	, Orders.bill_to_addr_1 as 'oehdrhst_sql.bill_to_addr_1'
	, Orders.bill_to_addr_2 as 'oehdrhst_sql.bill_to_addr_2'
	, Orders.bill_to_addr_3 as 'oehdrhst_sql.bill_to_addr_3'
	, Orders.bill_to_addr_4 as 'oehdrhst_sql.bill_to_addr_4'
	, Orders.bill_to_country as 'oehdrhst_sql.bill_to_country'
	, Orders.ship_to_name as 'oehdrhst_sql.ship_to_name'
	, Orders.ship_to_addr_1 as 'oehdrhst_sql.ship_to_addr_1'
	, Orders.ship_to_addr_2 as 'oehdrhst_sql.ship_to_addr_2'
	, Orders.ship_to_addr_3 as 'oehdrhst_sql.ship_to_addr_3'
	, Orders.ship_to_addr_4 as 'oehdrhst_sql.ship_to_addr_4'
	, Orders.ship_to_country as 'oehdrhst_sql.ship_to_Country'
	, '*** - Not Sure It''s In Here - ***' as CreditLimit
	, 'False' as CreditHoldFlag 
from oehdrhst_sql as Orders
join cicmpy as Customers on Orders.cus_no = Customers.cmp_code
Where ord_dt > DateAdd(yy,-3,GetDate())