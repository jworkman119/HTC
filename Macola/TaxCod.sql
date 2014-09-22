/* drop procedure htcTaxCodeRpt */

Create Procedure htcTaxCodeRpt
	@FromDate DateTime
	, @ToDate	DateTime
as

/*
Declare @FromDate varchar(10)
Declare @ToDate varchar(10)

Set @FromDate = '1-01-2014'
Set @ToDate = '1-31-2014'
*/

select 'Detail' as Type 
	, ltrim(TaxDetl.tax_cd) as TaxCode
	, TaxDetl.Tax_Cd_Description as TaxDetail
	, Case
		When Services.Invoice_Date is not null then
			convert(varchar(10),Services.Invoice_Date,101)
		else
			convert(varchar(10),TaxHst.Doc_dt,101)
		End as DocDt
	, TaxHst.Cus_Vend_No as CustomerNo
	, cicmpy.cmp_name as Customer
	, ltrim(inv_vchr) as Invoice
	, TaxHst.jnl_src as Journal
	, State
	, tax_meth as Method
	,  convert(varchar(10),TaxHst.gl_dt,101) as GlDt
	, TaxHst.sls_amt as SalesAmt
	, TaxHst.frt_amt as FreightAmt
	, TaxHst.misc_amt as MiscAmt
	, TaxHst.sls_amt + TaxHst.misc_amt as SubTotal
	, TaxHst.taxable_amt as TaxableAmt
	, TaxHst.tax_amt as TaxAmt
	, TaxHst.taxable_amt + tax_amt as DocTotalAmt
from taxdetl_sql as TaxDetl 
	left Join Sytaxhst_sql as TaxHst on TaxHst.tax_cd = TaxDetl.tax_cd
	left Join cicmpy on TaxHst.Cus_Vend_No = cicmpy.cmp_code
	Left Join arsrvhsh_sql as Services on Services.doc_no = TaxHst.inv_vchr
	
Where TaxDetl.tax_cd_percent > 0
			and  (
			(TaxHst.gl_dt >= @FromDate
			and TaxHst.gl_dt <= @ToDate
			and Invoice_Date is null)
			
			or
			(Invoice_Date >= @FromDate
				and
			 Invoice_Date <= @ToDate
			 )	
			or
			(Invoice_Date is null
				and 
			TaxHst.gl_dt is null)
		) 	

	
	
Union

select 'Total' as Type 
	, null as TaxCode
	, null as TaxDetail
	, null as DocDt
	, null as CustomerNo
	, null as Customer
	, null as Invoice
	, null as Journal
	, null as State
	, null as Method
	, null as GlDt
	, sum(TaxHst.sls_amt) as SalesAmt
	, sum(TaxHst.frt_amt) as FreightAmt
	, sum(TaxHst.misc_amt) as MiscAmt
	, sum(TaxHst.sls_amt + TaxHst.misc_amt) as SubTotal
	, sum(TaxHst.taxable_amt) as TaxableAmt
	, sum(TaxHst.tax_amt) as TaxAmt
	, sum(TaxHst.taxable_amt + tax_amt) as DocTotalAmt
from taxdetl_sql as TaxDetl 
	left Join Sytaxhst_sql as TaxHst on TaxHst.tax_cd = TaxDetl.tax_cd
	left Join cicmpy on TaxHst.Cus_Vend_No = cicmpy.cmp_code
	Left Join arsrvhsh_sql as Services on Services.doc_no = TaxHst.inv_vchr
where TaxDetl.tax_cd_percent > 0  		
	and  (
			(TaxHst.gl_dt >= @FromDate
			and TaxHst.gl_dt <= @ToDate
			and Invoice_Date is null)
			
			or
			(Invoice_Date >= @FromDate
				and
			 Invoice_Date <= @ToDate
			 )	
		)

order by Type, TaxCode, CustomerNo, GlDt 
