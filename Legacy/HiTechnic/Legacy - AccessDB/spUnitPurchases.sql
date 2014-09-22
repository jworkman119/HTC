
 SELECT Classifications.ClassificationID
	, imitmidx_sql.item_note_4
	, humres.usr_id
	, cicmpy.sct_code
	, cicmpy.textfield1 as Region
	, cicmpy.textfield2 as Unit
	, cicmpy.textfield3 as SubUnit
	, oehdrhst_sql.ord_no
	, oelinhst_sql.unit_price
	, convert(varchar(10),oelinhst_sql.shipped_dt,101) as Shipped_Dt
	, oelinhst_sql.tot_qty_ordered
	, oelinhst_sql.item_no
	, humres.first_name
	, humres.sur_name
	, imitmidx_sql.item_desc_1
	, imitmidx_sql.item_desc_2
	, oelinhst_sql.qty_bkord
	, oelinhst_sql.qty_to_ship
	, oelinhst_sql.sls_amt
 FROM   
	cicmpy cicmpy 
	INNER JOIN oehdrhst_sql  ON cicmpy.cmp_code=oehdrhst_sql.cus_no 
	INNER JOIN Classifications ON cicmpy.ClassificationId=Classifications.ClassificationID    
	INNER JOIN humres ON cicmpy.cmp_wwn=humres.cmp_wwn
	INNER JOIN oelinhst_sql ON oehdrhst_sql.inv_no=oelinhst_sql.inv_no 
	INNER JOIN imitmidx_sql ON oelinhst_sql.item_no=imitmidx_sql.item_no
 WHERE  Classifications.ClassificationID='USF' 
	AND oelinhst_sql.billed_dt>= '10-1-2009' --{ts '2010-06-21 00:00:00'} 
--	AND oelinhst_sql.shipped_dt< '6-21-2010' --{ts '2010-06-22 00:00:00'}) 
	AND  NOT (oelinhst_sql.item_no='ALLOCATION' OR oelinhst_sql.item_no='JOBCODE')
	AND cicmpy.sct_code='USFUNIT'
--	and unit_price > 300
	and cicmpy.textfield1='05'
	and cicmpy.textfield2='11'
order by 
 shipped_dt
	
