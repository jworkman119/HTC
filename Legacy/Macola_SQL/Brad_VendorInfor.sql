
Alter Procedure htcBradInfo

As

SELECT ltrim(cicmpy.cmp_code) as cmp_code
	, cicmpy.crdcode
	, cicmpy.ClassificationId
	, cicmpy.cmp_name
	, cicmpy.cmp_fadd1
	, cicmpy.cmp_fadd2
	, cicmpy.cmp_fcity + ', ' + cicmpy.StateCode + ', ' + cicmpy.cmp_fpc as CityStateZip
	, cicmpy.cmp_web
	, cicmpy.cmp_e_mail
	, cicmpy.cmp_tel
	, cicntp.FullName
	, cicntp.cnt_f_tel
	, cicmpy.cmp_status
	, cicmpy.type_since
	, cicmpy.ID
	, cicmpy.crdnr
	, cicmpy.cmp_fctry
	, cicmpy.bankaccountnumber 
FROM cicmpy 
	LEFT OUTER JOIN cicntp ON cicmpy.cnt_id = cicntp.cnt_id  
WHERE 
	cmp_e_mail is NULL
	and ltrim(rtrim(cmp_code)) in (
	'1903600'
	,'601800'
	,'300900'
	,'2300600'
	,'100700'
	,'1000060'
	,'201470'
	,'1800340'
	,'1303810'
	,'1200580'
	,'201010'
	,'1100240'
	,'501430'
	,'500250'
	,'1902700'
	,'201520'
	,'301835'
	,'301000'
	,'1900800'
	,'501030'
	,'1600800'
	,'50'
	,'301750'
	,'600200'
	,'201610'
	,'2200250'
	,'1100080'
	,'400300'
	,'2200545'
	,'1602450'
	,'201540'
	,'1500950'
	,'1000404'
	,'1800225'
	,'302510'
	,'1500190'
	,'1601525'
	,'1900220'
	,'1903295'
	,'2300825'
	,'2100010'
	,'501420'
	,'801700'
	,'1903320'
	,'401500'
	,'802500'
	,'103600'
	,'2101200'
	,'102300'
	,'1100200'
	,'2500105'
	,'2301115'
	,'1200200'
	,'1200797'
	,'1800300'
	,'401295'
	,'1400075'
	,'1601555'
	,'1200900'
	,'201070'
	,'1401700'
	,'2000730'
	,'2300100'
	,'301140'
	,'300930'
	,'1500220'
	,'1800700'
	,'1601325'
	,'102290'
	,'600100'
	,'2300910'
	,'800770'
	,'800500'
	,'301670'
	,'301450'
	,'1800400'
	,'1901600'
	,'102800'
	,'500775'
	,'201450'
	,'1600715'
	,'2102100'
	,'1902400'
	,'301600'
	,'1900260'
	,'800590'
	,'701100'
	,'1300110'
	,'2200800'
	,'1900700'
	,'802010'
	,'200400'
	,'1403300'
	,'1400100'
	,'1403425'
	,'2000970'
	,'600210'
	,'101495'
	,'2300500'
	,'2000973'
	,'1301560'
	,'2101600'
	,'1400900'
	,'500210'
	,'2100160'
	,'1800915'
	,'1402800'
	,'2000115'
	,'1403450'
	,'900655'
	,'1403500'
	,'600850'
	,'400745'
	,'1301685'
	,'100030'
	,'1903900'
	,'75'
	,'300685'
	,'1903650'
	,'2200430'
	,'2001040'
	,'101100'
	,'302740'
	,'2000660'
	,'1801945'
	,'2300745'
	,'701690'
	,'1100090'
	,'100025'
	,'1400105'
	,'2000600'
	,'1700080'
	,'2000955'
	,'701180'
	,'2001500'
	,'200525'
	,'1300450'
	,'2001690'
	,'700095'
	,'800730'
	,'1900450'
	,'701670'
	,'701400'
	,'1200560'
	,'1500300'
	,'301655'
	,'802650'
	,'1200260'
	,'500170'
	,'1400890'
	,'1600650'
	,'1500185'
	,'1000045'
	,'500160'
	,'600795'
	,'1400905'
	,'2001585'
	,'1900444'
	,'1602430'
	,'401235'
	,'1600077'
	,'1201700'
	,'2100085'
	,'101060'
	,'1800950'
	,'100015'
	,'2102200'
	,'1900795'
	,'1903315'
	,'1303950'
	,'201510'
	,'501410'
	,'1200590'
	,'601100'
	,'801720'
	,'2200415'
	,'600900'
	,'1800093'
	,'100010'
	,'300410'
	,'300250'
	,'1402700'
	,'400365'
	,'201300'
	,'800300'
	,'1600900'
	,'2100180'
	,'2000975'
	,'1300400'
	,'201950'
	,'1304040'
	,'600800'
	,'2102060'
	,'701195'
	,'1903340'
	,'1801300'
	,'100890'
	,'1402480'
	,'100340'
	,'1801125'
	,'2500210'
	,'1403095'
	,'300585'
	,'2000835'
	,'1600910'
	,'1800210'
	,'2300400'
	,'300715'
	,'302285'
	,'802000'
	,'500180'
	,'1300700'
	,'501470'
	,'400410'
	,'130688'
	,'700795'
	,'2001505'
	,'301682'
	,'1400925'
	,'303015'
	,'102600'
	,'201475'
	,'101305'
	,'1403595'
	,'400345'
	,'2300840'
	,'500100'
	,'201715'
	,'800070'

)
order by cmp_name


