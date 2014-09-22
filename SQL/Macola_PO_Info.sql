SELECT 
	Val(Left([poordlin].[ord_no],6)) AS ord_no
	, Right([poordlin].[ord_no],2) AS RELEASE_NO
	, POORDLIN.line_no
	, POORDLIN.item_no
	, POORDLIN.item_desc_1
	, POORDLIN.item_desc_2
	, POORDLIN.ord_status
	, POORDLIN.purch_uom
	, POORDLIN.exp_unit_cost
	, POORDLIN.qty_ordered
	, POORDLIN.promise_dt
	, POORDLIN.qty_released
	, POORDLIN.qty_received
	, POORDLIN.qty_remaining
	, POORDHDR.vend_no
	, APVENFIL.vend_name
	, POORDHDR.ship_to_cd
	, POSHPFIL.ship_to_desc
	, POSHPFIL.Loc
FROM ((POORDHDR INNER JOIN POORDLIN ON POORDHDR.ord_no = POORDLIN.ord_no) 
INNER JOIN APVENFIL ON POORDHDR.vend_no = APVENFIL.vend_no) 
INNER JOIN POSHPFIL ON POORDHDR.ship_to_cd = POSHPFIL.ship_to_cd
WHERE (((Val(Left([poordlin].[ord_no],6)))=[Which PO?]) 
AND ((POORDLIN.ord_status)<>"U") 
AND ((POORDLIN.qty_remaining)>0));
