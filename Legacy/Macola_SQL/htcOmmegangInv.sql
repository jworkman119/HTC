Create Procedure htcOmmegangInv 

as

 SELECT iminvloc_sql.item_no
	, cast(iminvloc_sql.qty_on_hand as int) as qty_on_hand
	, iminvloc_sql.loc
	, imitmidx_sql.search_desc
 FROM   iminvloc_sql iminvloc_sql 
	INNER JOIN imitmidx_sql imitmidx_sql ON iminvloc_sql.item_no=imitmidx_sql.item_no
 WHERE  iminvloc_sql.loc='810'
	and iminvloc_sql.qty_on_hand  > 0
 ORDER BY iminvloc_sql.item_no