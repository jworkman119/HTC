Update cicmpy 
set cicmpy.cmp_status = 'E'
From cicmpy
	join oelinhst_sql as OE on OE.cus_no = cicmpy.cmp_code 
	join oehdrhst_sql as Orders on Orders.ord_no = OE.ord_no
			and oe.inv_no = orders.inv_no
where Orders.entered_dt < '2009-01-01'
	and cicmpy.cmp_status = 'A'
	and (
			(len(ltrim(cicmpy.cmp_code)) > 6
				and left(ltrim(cicmpy.cmp_code),1)not in ('1','2'))
		 or
		 	(len(ltrim(cicmpy.cmp_code)) <= 6)
		 )
	and cicmpy.cmp_code not in
	(
		select distinct Customers.cmp_code
		from  oelinhst_sql as OE --oehdrhst_sql as Orders -- arcusfil_sql
			join oehdrhst_sql as Orders on Orders.ord_no = OE.ord_no
					and oe.inv_no = orders.inv_no
		join cicmpy as Customers on OE.cus_no = Customers.cmp_code
		where Orders.entered_dt > '2009-01-01'
	)

