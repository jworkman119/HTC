SELECT --	Customers.ClassificationID as Customer  
		isNull (rtrim (Family.fam1) , '*N/A') AS FamilyCode
       , bin_no AS Bin#
		, items.itemcode AS [Item Code]
		, fam2 AS [Description]
FROM   items JOIN
       zzzhtc_family AS Family ON items.itemcode=Family.item LEFT JOIN
       iminvbin_sql ON items.itemcode=iminvbin_sql.item_no
WHERE  items.itemcode NOT IN (SELECT items.itemcode AS [Item Code]
                              FROM   items LEFT JOIN
                                     iminvbin_sql ON items.itemcode=iminvbin_sql.item_no LEFT JOIN
                                     oelinhst_sql AS OE ON items.ItemCode=OE.item_no LEFT JOIN
                                     oehdrhst_sql AS Orders ON Orders.ord_no=OE.ord_no 
       AND oe.inv_no=orders.inv_no LEFT JOIN
                                     zzzhtc_family AS Family ON items.itemcode=Family.item
                              WHERE  userfield_10 = 'A' 
       AND right (items.itemcode, 2) <> '99' 
       AND items.itemcode <> 'JobCode' 
       AND Year (oe.billed_dt) = '2009' GROUP BY items.itemcode) 