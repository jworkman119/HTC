--ALTER PROCEDURE dbo.ZZZAllSalesCP1  AS

DELETE FROM  ZZZHTC_AllSales

INSERT INTO ZZZHTC_AllSales(
							ord_no
							, ord_type
							, entered_dt
							, item_no
							, qty_ordered
							, month_end
							, Description
							, Description2
							, loc
							, rma
							, cus_no
							, inv_no
							, inv_dt
							, cmt_1
							, cmt_2
							, cmt_3
							, orig_ord_type
							, orig_ord_no
							, uom_ratio
							, Sales
							, bill_to_name
							, ship_to_name
							, shipped_dt
							, oe_po_no
							, shipping_dt
							, bill_to_state
							)
SELECT  oeordlin_sql.ord_no
	, oeordlin_sql.ord_type
	, CONVERT(varchar(10), oeordhdr_sql.entered_dt, 101) AS entered_dt
	, oeordlin_sql.item_no
	, CAST(oeordlin_sql.qty_ordered AS int) AS qty_ordered
	, DATENAME(MM, oeordhdr_sql.entered_dt) + ' ' + CAST(YEAR(oeordhdr_sql.entered_dt) AS VARCHAR(4)) AS month_end
	, oeordlin_sql.item_desc_1
	, oeordlin_sql.item_desc_2
	, oeordlin_sql.loc
	, oeordhdr_sql.rma_no
	, oeordhdr_sql.cus_no
	, oeordhdr_sql.inv_no
	, oeordhdr_sql.inv_dt
	, oeordhdr_sql.cmt_1
	, oeordhdr_sql.cmt_2
	, oeordhdr_sql.cmt_3
	, oeordhdr_sql.orig_ord_type
	, oeordhdr_sql.orig_ord_no
	, oeordlin_sql.uom_ratio
	, oeordlin_sql.qty_ordered * oeordlin_sql.unit_price AS Sales1
	, oeordhdr_sql.bill_to_name
	, oeordhdr_sql.ship_to_name
	, oeordlin_sql.shipped_dt
	, oeordhdr_sql.oe_po_no
	, oeordhdr_sql.shipping_dt
	, oeordhdr_sql.bill_to_state
FROM oeordlin_sql 
	INNER JOIN oeordhdr_sql ON oeordlin_sql.ord_no = oeordhdr_sql.ord_no 
		AND oeordlin_sql.ord_type = oeordhdr_sql.ord_type
WHERE (oeordlin_sql.item_no NOT IN ('ALLOCATION', 'JOBCODE')) 
		AND (oeordhdr_sql.ord_type <> 'C')

INSERT INTO ZZZHTC_AllSales
        (ord_no
		, ord_type
		, entered_dt
		, item_no
		, qty_ordered
		, month_end
		, Description
		, Description2
		, Sales
		, loc
		, rma
		, cus_no
		, inv_dt
		, cmt_1
		, cmt_2
		, cmt_3
		, orig_ord_type
		, orig_ord_no
		, uom_ratio
		, CQtyOrdered
		, bill_to_name
		, ship_to_name
		, shipped_dt
		, oe_po_no
		, inv_no
		, line_seq_no
		, line_no
		, rma_seq
		, bill_to_state
)
SELECT     oelinhst_sql.ord_no
		, oelinhst_sql.ord_type
		, CONVERT(varchar(10)
		, oehdrhst_sql.entered_dt, 101) AS entered_dt
		, oelinhst_sql.item_no
		, CAST(oelinhst_sql.qty_to_ship AS int) AS qty_ordered
		, DATENAME(MM, oehdrhst_sql.entered_dt) + ' ' + CAST(YEAR(oehdrhst_sql.entered_dt) AS VARCHAR(4)) AS month_end
		, oelinhst_sql.item_desc_1
		, oelinhst_sql.item_desc_2
		, oelinhst_sql.sls_amt
		, oelinhst_sql.loc
		, oehdrhst_sql.rma_no
		, oehdrhst_sql.cus_no
		, oehdrhst_sql.inv_dt
		, oehdrhst_sql.cmt_1
		, oehdrhst_sql.cmt_2
		, oehdrhst_sql.cmt_3
		, oehdrhst_sql.orig_ord_type
		, oehdrhst_sql.orig_ord_no
		, oelinhst_sql.uom_ratio
		, oelinhst_sql.qty_ordered AS Qty2
		, oehdrhst_sql.bill_to_name
		, oehdrhst_sql.ship_to_name
		, oelinhst_sql.shipped_dt
		, oehdrhst_sql.oe_po_no
		, oehdrhst_sql.inv_no
		, oelinhst_sql.line_seq_no
		, oelinhst_sql.line_no
		, oelinhst_sql.rma_seq
		, oehdrhst_sql.bill_to_state
FROM oelinhst_sql 
	RIGHT OUTER JOIN oehdrhst_sql ON oelinhst_sql.inv_no = oehdrhst_sql.inv_no
WHERE (oelinhst_sql.item_no NOT IN ('ALLOCATION', 'JOBCODE')) 
	AND (oehdrhst_sql.ord_type <> 'Q') 
	AND (oehdrhst_sql.inv_no <> ' ')

UPDATE    ZZZHTC_AllSales
SET MonthEndSort = DATEADD(dd, - DAY(DATEADD(mm, 1, entered_dt)), DATEADD(mm, 1, entered_dt))

UPDATE   ZZZHTC_AllSales
SET              EnteredSort = CAST(entered_dt AS datetime)

UPDATE ZZZHTC_AllSales
SET qty_ordered = CQtyOrdered
WHERE (orig_ord_type= 'C')


UPDATE    ZZZHTC_AllSales
SET              qty_ordered = qty_ordered * uom_ratio * - 1
WHERE     (orig_ord_type = 'C')

--Removes Backordes
DELETE FROM ZZZHTC_AllSales
WHERE (qty_ordered = 0)


UPDATE
ZZZHTC_AllSales
SET
ZZZHTC_AllSales.Color =  Xscitems.Color
FROM
Xscitems
WHERE
Xscitems.[Part No.] = ZZZHTC_AllSales.Item_no;