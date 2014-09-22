
SELECT Distinct ltrim(cicmpy.cmp_code) as cmp_code
	, cicmpy.ClassificationId
	, replace(rtrim(cicmpy.cmp_name), ',', '@') as Company
	, Case
		When cicmpy.cmp_fadd2 is NULL Then
			cicmpy.cmp_fadd1 
			+ '|' + cicmpy.cmp_fcity + '@ ' + cicmpy.StateCode + '@ ' + cicmpy.cmp_fpc
		else
			cicmpy.cmp_fadd1 
			+ '|' + cicmpy.cmp_fadd2
			+ '|' + cicmpy.cmp_fcity + '@ ' + cicmpy.StateCode + '@ ' + cicmpy.cmp_fpc
		End as Address
FROM cicmpy 
	join polinaud_sql on cicmpy.cmp_code = polinaud_sql.vend_no
WHERE 
	(classificationID in ('se')
	or classificationID is NULL)
	and aud_dt > '1/1/2009'
Order by ClassificationID, Company


