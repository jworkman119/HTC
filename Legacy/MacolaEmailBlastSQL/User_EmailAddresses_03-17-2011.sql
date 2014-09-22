select 
 ltrim(rtrim(cmp_e_mail)) as Email
 /*
, replace(ltrim(rtrim(cmp_name)),',',' ') as Name
, ltrim(rtrim(cmp_code)) as company
*/
	
from cicmpy
where cmp_e_mail is not null
and ltrim(cmp_code)
	in (
'93440'
,'93039'
,'85682'
,'86178'
,'89062'
,'90954'
,'89567'
,'93490'
,'92814'
,'92082'
,'92568'
,'75908'
,'75869'
,'82765'
,'74418'
,'92766'
,'89569'
,'81623'
,'73359'
,'93490'
,'70606'
,'93643'
,'82415'
,'93672'
,'76845'
,'91973'
,'93446'
,'93192'
,'89891'
,'72639'
,'89891'
,'85532'
,'87619'
,'73992'
,'71308'
,'88102'
,'93259'
,'93211'
,'92342'
,'92939'
,'77374'
,'77333'
,'92853'
,'74859'
,'93653'
,'77326'
,'93993'
,'70748'
,'80107'
,'78250'
,'92491'
,'92600'
,'74682'
,'92860'
,'75273'
,'88520'
,'85041'
,'92007'
,'76064'
,'78282'
,'93473'
,'86223'
,'93541'
,'83058'
,'83322'
,'71728'
,'77355'
,'82107'
,'87261'
,'92573'
,'74331'
,'80582'
,'92497'
,'93364'
,'92918'
,'72227'
,'74272'
,'91394'
,'93311'
,'73652'
,'79608'
,'93363'
,'80178'
,'71766'
,'87317'
,'90539'
,'82859'
,'84297'
,'93589'
,'92981'
,'79886'
,'77424'
,'81625'
,'90759'
,'92109'
,'81519'
,'92049'
,'92752'
,'92240'
,'82064'
,'92114'
,'81607'
,'81804'
,'89869'
,'93718'
,'88838'
,'92260'
,'92641'
,'79240'
,'88189'
,'75034'
,'77134'
,'80297'
,'92514'
,'92845'
,'93718'
,'93623'
,'82395'
,'93104'
,'91256'
,'73071'
,'93489'
,'85612'
,'83920'
,'93086'
,'89468'
,'72610'
,'89511'
,'88951'
,'72629'
,'92799'
,'92213'
,'92976'
,'79608'
,'93514'
,'78323'
,'71308'
,'92618'
,'81804'
,'80016'
,'83939'
,'80911'
,'74329'
,'93644'
,'91232'
,'93092'
,'93737'
,'92618'
,'93470'
,'93712'
,'79886'
,'92834'
,'92789'
,'81605'
,'90240'
)