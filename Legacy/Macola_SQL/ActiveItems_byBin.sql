SELECT DISTINCT Customers.ClassificationID AS Customer
                , isNull (rtrim (Family.fam1) , '*N/A') AS FamilyCode
                , bin_no AS Bin#
                , items.itemcode AS [Item Code]
                , items.description AS [Description]
                , cast (count (oe.qty_ordered) AS int) AS #_of_Orders
                , cast (sum (oe.qty_ordered) AS Int) AS Qty
                
FROM   items 
	LEFT JOIN iminvbin_sql ON items.itemcode=iminvbin_sql.item_no 
	LEFT JOIN oelinhst_sql AS OE ON items.ItemCode=OE.item_no 
	LEFT JOIN oehdrhst_sql AS Orders ON Orders.ord_no=OE.ord_no 
       AND oe.inv_no=orders.inv_no 
	LEFT JOIN zzzhtc_family AS Family ON items.itemcode=Family.item 
	JOIN cicmpy AS Customers ON OE.cus_no=Customers.cmp_code
WHERE  
		items.warehouse  = 730
       AND userfield_10 = 'A' 
       AND right (items.itemcode, 2) <> '99' 
       AND items.itemcode <> 'JobCode' 
       AND fam1 IS NOT NULL 
       AND Year (oe.billed_dt) = '2009'
	--	and items.itemcode = 'COE024-251124322400814'
--	   and iminvbin_sql.bin_status = 'A'
--and rtrim(issue_priority) = '00000000' 
GROUP BY Family.fam1, bin_no, items.itemcode, items.description, Customers.ClassificationID
ORDER BY Customer, FamilyCode, items.itemcode

