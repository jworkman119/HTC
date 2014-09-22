select cmp_code
	, cmp_name
	, cicmpy.cmp_e_mail
from cicmpy
where cicmpy.cmp_e_mail is not NULL
