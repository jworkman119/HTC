ALTER PROCEDURE dbo.ZZFSAllSales AS

DELETE FROM  ZHTC_AllSales

INSERT INTO ZHTC_AllSales (ord_no, ord_type, entered_dt, item_no, qty_ordered, month_end, Description)
SELECT oeordlin_sql.ord_no
	, oeordlin_sql.ord_type
	, CONVERT(varchar(10)
	, oeordhdr_sql.entered_dt, 101) AS entered_dt
	, oeordlin_sql.item_no
	, CAST(oeordlin_sql.qty_ordered AS int) AS qty_ordered
	, DATENAME(MM, oeordhdr_sql.entered_dt) + ' ' +   CAST(YEAR(oeordhdr_sql.entered_dt) AS VARCHAR(4)) AS month_end
	, Items.Description
FROM oeordlin_sql (nolock)
	INNER JOIN oeordhdr_sql (nolock) ON oeordlin_sql.ord_no = oeordhdr_sql.ord_no 
		AND oeordlin_sql.ord_type = oeordhdr_sql.ord_type 
	LEFT OUTER JOIN Items (nolock)ON oeordlin_sql.item_no = Items.ItemCode
WHERE (oeordlin_sql.loc = '700') 
	AND (oeordlin_sql.item_no NOT IN ('ALLOCATION', 'JOBCODE')) 
	AND (oeordhdr_sql.ord_type <> 'C')
 
INSERT INTO ZHTC_AllSales (ord_no, ord_type, entered_dt, item_no, qty_ordered, Description, month_end)
SELECT oelinhst_sql.ord_no
	, oelinhst_sql.ord_type
	, CONVERT(varchar(10), oehdrhst_sql.entered_dt, 101) AS entered_dt
	, oelinhst_sql.item_no
	, CAST(oelinhst_sql.qty_to_ship AS int) AS qty_ordered
	, Items.Description
	, DATENAME(MM, oehdrhst_sql.entered_dt) + ' ' + CAST(YEAR(oehdrhst_sql.entered_dt) AS VARCHAR(4)) AS month_end
FROM oelinhst_sql (nolock)
	INNER JOIN oehdrhst_sql (nolock) ON oelinhst_sql.inv_no = oehdrhst_sql.inv_no 
	LEFT OUTER JOIN Items (nolock) ON oelinhst_sql.item_no = Items.ItemCode
WHERE (oelinhst_sql.loc = '700') 
	AND (oelinhst_sql.item_no NOT IN ('ALLOCATION', 'JOBCODE')) 
	AND (oehdrhst_sql.ord_type <> 'Q') 
	AND (oehdrhst_sql.inv_no <> '')		

UPDATE    ZHTC_ALLSALES
SET             Left5 = LEFT(item_no, 5), Left6 = LEFT(item_no, 6), Left7 = LEFT(item_no, 7)

UPDATE    ZHTC_ALLSALES
SET              Left5 = Left7
WHERE     (Left7 = 'FS1349A') OR
                      (Left7 = 'FS1349B') OR
                      (Left7 = 'FS1402A') 

UPDATE    ZHTC_ALLSALES
SET              Left5 = '7158'
WHERE     (Left5 = '71580') OR
                      (Left5 = '71581') OR
                      (Left5 = '71582') OR
                      (Left5 = '71583') OR
                      (Left5 = '71584') OR
                      (Left5 = '71585') OR
                      (Left5 = '71586') OR
                      (Left5 = '71587') OR
                      (Left5 = '71588') OR
                      (Left5 = '71589')


UPDATE    ZHTC_ALLSALES
SET              Left5 = 'FS0176'
WHERE     (Left5 = 'FS017')

UPDATE    ZHTC_ALLSALES
SET              Left5 = Left6
WHERE     (Left6 = 'FS509A') 

UPDATE    ZHTC_ALLSALES
SET              Type2 = 'FIELD AND DRESS UNIFORMS', ValueAdd = 'HEMMING', Description2 = 'DARK GREEN FIELD PANTS - MEN'
WHERE     (Left5 = '0176')

UPDATE    ZHTC_ALLSALES
SET              Type2 = 'FIELD AND DRESS UNIFORMS', ValueAdd = 'HEMMING', Description2 = 'PC JEANS - MEN'
WHERE     (Left5 = 'FS240')

UPDATE    ZHTC_ALLSALES
SET              Type2 = 'FIELD AND DRESS UNIFORMS', ValueAdd = 'HEMMING', Description2 = 'PC JEANS - WOMEN'
WHERE     (Left5 = 'FS241')

UPDATE    ZHTC_ALLSALES
SET              Type2 = 'FIELD AND DRESS UNIFORMS', ValueAdd = 'HEMMING', Description2 = 'FIELD SLACKS - MEN'
WHERE     (Left5 = 'FS300')

UPDATE    ZHTC_ALLSALES
SET              Type2 = 'FIELD AND DRESS UNIFORMS', ValueAdd = 'HEMMING', Description2 = 'FIELD SLACKS WOMEN'
WHERE     (Left5 = 'FS301')

UPDATE    ZHTC_ALLSALES
SET              Type2 = 'FIELD AND DRESS UNIFORMS', ValueAdd = 'HEMMING', Description2 = 'FLANNEL – LINED – JEANS - MEN'
WHERE     (Left5 = 'FS245')

UPDATE    ZHTC_ALLSALES
SET              Type2 = 'FIELD AND DRESS UNIFORMS', ValueAdd = 'HEMMING', Description2 = 'FLANNEL – LINED – JEANS - WOMEN'
WHERE     (Left5 = 'FS246')

UPDATE    ZHTC_ALLSALES
SET              Type2 = 'FIELD AND DRESS UNIFORMS', ValueAdd = 'HEMMING', Description2 = 'DRESS TROUSERS - MEN'
WHERE     (Left5 = 'FS610')

UPDATE    ZHTC_ALLSALES
SET              Type2 = 'FIELD AND DRESS UNIFORMS', ValueAdd = 'HEMMING', Description2 = 'DRESS TROUSERS -WOMEN'
WHERE     (Left5 = 'FS611')

UPDATE    ZHTC_ALLSALES
SET              Type2 = 'FIELD AND DRESS UNIFORMS', ValueAdd = 'HEMMING', Description2 = 'DRESS TROUSERS - MEN'
WHERE     (Left5 = 'FS610')

UPDATE    ZHTC_ALLSALES
SET              Type2 = 'FIELD AND DRESS UNIFORMS', ValueAdd = 'HEMMING', Description2 = 'COTTON JEANS - MEN'
WHERE     (Left5 = 'FS250')

UPDATE    ZHTC_ALLSALES
SET              Type2 = 'FIELD AND DRESS UNIFORMS', ValueAdd = 'HEMMING', Description2 = 'COTTON JEANS - WOMEN'
WHERE     (Left5 = 'FS251')

UPDATE    ZHTC_ALLSALES
SET              Type2 = 'FIELD AND DRESS UNIFORMS', ValueAdd = 'HEMMING', Description2 = 'DARK GREEN FIELD PANTS WOMEN'
WHERE     (Left5 = '7158')

UPDATE    ZHTC_ALLSALES
SET              Type2 = 'FIELD AND DRESS UNIFORMS', ValueAdd = 'HEMMING', Description2 = 'HONOR GUARD TROUSERS - MEN'
WHERE     (Left5 = 'HG200')

UPDATE    ZHTC_ALLSALES
SET              Type2 = 'FIELD AND DRESS UNIFORMS', ValueAdd = 'HEMMING', Description2 = 'HONOR GUARD TROUSERS - WOMEN'
WHERE     (Left5 = 'HG201')

UPDATE    ZHTC_ALLSALES
SET              Type2 = 'FIELD AND DRESS UNIFORMS', ValueAdd = 'HEMMING', Description2 = 'TRIAL SHORTS - MEN'
WHERE     (Left5 = 'FS314')

UPDATE    ZHTC_ALLSALES
SET              Type2 = 'FIELD AND DRESS UNIFORMS', ValueAdd = 'HEMMING', Description2 = 'TRIAL SHORTS - WOMEN'
WHERE     (Left5 = 'FS315')

UPDATE    ZHTC_ALLSALES
SET              Type2 = 'FIELD AND DRESS UNIFORMS', ValueAdd = 'HEMMING', Description2 = 'DRESS SKIRT WOMEN'
WHERE     (Left5 = 'FS603')

UPDATE    ZHTC_ALLSALES
SET              Type2 = 'HAT/CAPS AND ACCESSORIES', ValueAdd = 'PATCH', Description2 = 'POLAR CAP - UNISEX'
WHERE     (Left5 = 'FS368')

UPDATE    ZHTC_ALLSALES
SET              Type2 = 'HAT/CAPS AND ACCESSORIES', ValueAdd = 'PATCH', Description2 = 'WOOL STOCKING CAP'
WHERE     (Left5 = 'FS356')

UPDATE    ZHTC_ALLSALES
SET              Type2 = 'HAT/CAPS AND ACCESSORIES', ValueAdd = 'EMBROIDERY', Description2 = 'TWILL BASEBALL CAP'
WHERE     (Left5 = 'FS328')

UPDATE    ZHTC_ALLSALES
SET              Type2 = 'HAT/CAPS AND ACCESSORIES', ValueAdd = 'ENGRAVE', Description2 = 'PLASTIC NAMEPLATE'
WHERE     (Left5 = 'FS601')

UPDATE    ZHTC_ALLSALES
SET              Type2 = 'HAT/CAPS AND ACCESSORIES', ValueAdd = 'ENGRAVE', Description2 = ' NAMEPLATES, GOLD-PLATED'
WHERE     (Left5 = 'FS600')

UPDATE    ZHTC_ALLSALES
SET              Type2 = 'LAW ENFORCEMENT UNIFORM', ValueAdd = 'PATCH', Description2 = 'PC SHIRT – LONG SLEEVE - MEN'
WHERE     (Left5 = 'FS800')

UPDATE    ZHTC_ALLSALES
SET              Type2 = 'LAW ENFORCEMENT UNIFORM', ValueAdd = 'PATCH', Description2 = 'PC SHIRT – LONG SLEEVE - WOMEN'
WHERE     (Left5 = 'FS801')

UPDATE    ZHTC_ALLSALES
SET              Type2 = 'LAW ENFORCEMENT UNIFORM', ValueAdd = 'PATCH', Description2 = 'PC SHIRT – SHORT SLEEVE - MEN'
WHERE     (Left5 = 'FS810')

UPDATE    ZHTC_ALLSALES
SET              Type2 = 'LAW ENFORCEMENT UNIFORM', ValueAdd = 'PATCH', Description2 = 'PC SHIRT – SHORT SLEEVE - WOMEN'
WHERE     (Left5 = 'FS811')

UPDATE    ZHTC_ALLSALES
SET              Type2 = 'LAW ENFORCEMENT UNIFORM', ValueAdd = 'HEMMING', Description2 = 'CARGO PANTS - MEN'
WHERE     (Left5 = 'FS820')

UPDATE    ZHTC_ALLSALES
SET              Type2 = 'LAW ENFORCEMENT UNIFORM', ValueAdd = 'HEMMING', Description2 = 'CARGO PANTS - WOMEN'
WHERE     (Left5 = 'FS821')

UPDATE    ZHTC_ALLSALES
SET              Type2 = 'LAW ENFORCEMENT UNIFORM', ValueAdd = 'EMBROIDERY AND PATCH', Description2 = 'TWILL BASEBALL CAP'
WHERE     (Left5 = 'FS841')

UPDATE    ZHTC_ALLSALES
SET              Type2 = 'LAW ENFORCEMENT UNIFORM', ValueAdd = 'ENGRAVE', Description2 = 'SILVER NAMEPLATE'
WHERE     (Left5 = 'FS875')

UPDATE    ZHTC_ALLSALES
SET              Type2 = 'LAW ENFORCEMENT UNIFORM', ValueAdd = 'PATCH', Description2 = 'BLACK SWEATER UNISEX'
WHERE     (Left5 = '1402A')

UPDATE    ZHTC_ALLSALES
SET              Type2 = 'MATERNITY', ValueAdd = 'HEMMING', Description2 = 'MATERNITY SLACKS'
WHERE     (Left5 = 'FS432')

UPDATE    ZHTC_ALLSALES
SET              Type2 = 'MATERNITY', ValueAdd = 'HEMMING', Description2 = 'MATERNITY SHIRT – LONG SLEEVE'
WHERE     (Left5 = 'FS401')

UPDATE    ZHTC_ALLSALES
SET              Type2 = 'MATERNITY', ValueAdd = 'HEMMING', Description2 = 'MATERNITY SHIRT – SHORT SLEEVE'
WHERE     (Left5 = 'FS411')

UPDATE    ZHTC_ALLSALES
SET              Type2 = 'OUTERWEAR AND WINTER CLOTHING', ValueAdd = 'HEMMING', Description2 = 'WOOL FIELD PANTS - MEN'
WHERE     (Left5 = 'FS400')

UPDATE    ZHTC_ALLSALES
SET              Type2 = 'OUTERWEAR AND WINTER CLOTHING', ValueAdd = 'HEMMING', Description2 = 'WOOL BIBS - UNISEX'
WHERE     (Left5 = 'FS452')

UPDATE    ZHTC_ALLSALES
SET              Type2 = 'OUTERWEAR AND WINTER CLOTHING', ValueAdd = 'HEMMING', Description2 = 'WOOL FIELD PANTS - WOMEN'
WHERE     (Left5 = 'FS451')

UPDATE    ZHTC_ALLSALES
SET              Type2 = 'VOLUNTEER AND SCSEP UNIFORM', ValueAdd = 'PATCH', Description2 = 'SCSEP VEST - UNISEX'
WHERE     (Left5 = 'FS509A')

UPDATE    ZHTC_ALLSALES
SET              Type2 = 'VOLUNTEER AND SCSEP UNIFORM', ValueAdd = 'PATCH', Description2 = 'VOLUNTEER VEST - UNISEX'
WHERE     (Left5 = 'FS509')

UPDATE    ZHTC_ALLSALES
SET              Type2 = 'VOLUNTEER AND SCSEP UNIFORM', ValueAdd = 'PATCH', Description2 = 'VOLUNTEER MESH BASEBALL CAP'
WHERE     (Left5 = 'FS520')

UPDATE    ZHTC_ALLSALES
SET              Type2 = 'VOLUNTEER AND SCSEP UNIFORM', ValueAdd = 'PATCH', Description2 = 'SCSEP WINDBREAKER'
WHERE     (Left5 = 'FS1349B')

UPDATE    ZHTC_ALLSALES
SET              Type2 = 'VOLUNTEER AND SCSEP UNIFORM', ValueAdd = 'PATCH', Description2 = 'VOLUNTEER WINDBREAKER - UNISEX'
WHERE     (Left5 = 'FS1349A')

UPDATE    ZHTC_ALLSALES
SET              Type2 = 'VOLUNTEER AND SCSEP UNIFORM', ValueAdd = 'PATCH', Description2 = 'VOLUNTEER TWILL BASEBALL CAP'
WHERE     (Left5 = 'FS540')

UPDATE    ZHTC_ALLSALES
SET              Type2 = 'VOLUNTEER AND SCSEP UNIFORM', ValueAdd = 'PATCH', Description2 = 'SCSEP MESH BASEBALL CAP'
WHERE     (Left5 = 'FS521')

UPDATE    ZHTC_AllSales
SET              Vendor = 'FAYCO ENTERPRISES'
WHERE     (Left5 = 'FS610') OR
                      (Left5 = 'FS611')

UPDATE    ZHTC_AllSales
SET              Vendor = 'OSWEGO INDUSTRIES'
WHERE     (Left5 = 'FS213') OR
                      (Left5 = 'FS214') OR
                      (Left5 = 'FS212') OR
                      (Left5 = 'FS201') OR
                      (Left5 = 'FS211') OR
                      (Left5 = 'FS210') OR
                      (Left5 = 'FS200') OR
                      (Left5 = 'FS800') OR
                      (Left5 = 'FS810') OR
                      (Left5 = 'FS801') OR
                      (Left5 = 'FS811')

UPDATE    ZHTC_AllSales
SET              Vendor = 'HERKIMER  INDUSTRIES'
WHERE     (Left5 = '7158') OR
                      (Left5 = 'FS0176') 

UPDATE    ZHTC_AllSales
SET              Vendor = 'GOODWILL INDUSTRIES'
WHERE     (Left5 = 'FS300') OR
                      (Left5 = 'FS301') OR
                      (Left5 = 'FS314') OR
                      (Left5 = 'FS315') OR
                      (Left5 = 'FS240') OR
                      (Left5 = 'FS241') OR
                      (Left5 = 'FS250') OR	
                      (Left5 = 'FS251') OR
                      (Left5 = 'FS245') OR
                      (Left5 = 'FS246')

UPDATE    ZHTC_AllSales
SET              Vendor = 'ERICKSON INDUSTRIES'
WHERE     (Left5 = 'FS314') OR
                      (Left5 = 'FS315') OR
                      (Left5 = 'FS362') OR
                      (Left5 = 'FS363') OR
                      (Left5 = 'FS364') OR
                      (Left5 = 'FS365') OR
                      (Left5 = 'FS366') OR	
                      (Left5 = 'FS367') OR
                      (Left5 = 'FS368') OR
                      (Left5 = 'FS372') OR	
                      (Left5 = 'FS373') OR	
                      (Left5 = 'FS376') OR
                      (Left5 = 'FS392') OR
                      (Left5 = 'FS100') 

UPDATE    ZHTC_AllSales
SET              Vendor = 'BIMIIDJI MILLS'
WHERE     (Left5 = 'FS314') OR
                      (Left5 = 'FS452') OR
                      (Left5 = 'FS451') OR
                      (Left5 = 'FS400') OR
                      (Left5 = 'FS340') OR
                      (Left5 = 'FS320') 

UPDATE    ZHTC_AllSales
SET              Vendor = 'BLAUER'
WHERE     (Left5 = 'FS820') OR
                      (Left5 = 'FS1402A') 

UPDATE    ZHTC_AllSales
SET              Vendor = 'SCHARF AND BREIT'
WHERE     (Left5 = 'FS225') OR
                      (Left5 = 'FS226') 


UPDATE    ZHTC_AllSales
SET              MonthEndSort = DATEADD(dd, - DAY(DATEADD(mm, 1, entered_dt)), DATEADD(mm, 1, entered_dt))

UPDATE    ZHTC_AllSales
SET              EnteredSort = CAST(entered_dt AS datetime)

DELETE FROM ZHTC_AllSales
WHERE     (qty_ordered = 0)

UPDATE
ZHTC_AllSales
SET
ZHTC_AllSales.Color =  Xscitems.Color
FROM
Xscitems
WHERE
Xscitems.[Part No.] = ZHTC_AllSales.Item_no

SELECT     TOP 100 PERCENT MonthEndSort, month_end, Left5, item_no, Color, Description, SUM(qty_ordered) AS Ordered
FROM         ZHTC_AllSales
GROUP BY MonthEndSort, Left5, month_end, item_no, Description, Color
ORDER BY MonthEndSort, month_end, Left5;