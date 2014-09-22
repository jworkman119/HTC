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
,'93671'
,'92814'
,'92082'
,'90101'
,'80265'
,'92568'
,'75908'
,'75869'
,'82765'
,'74418'
,'92766'
,'89569'
,'81623'
,'89256'
,'90141'
,'78494'
,'73359'
,'93490'
,'70606'
,'93643'
,'83781'
,'82415'
,'93672'
,'90070'
,'76845'
,'91973'
,'93446'
,'93192'
,'89891'
,'72639'
,'70666'
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
,'93295'
,'77374'
,'93162'
,'77333'
,'92853'
,'74859'
,'76040'
,'91290'
,'93653'
,'77326'
,'93993'
,'70748'
,'90860'
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
,'70228'
,'83058'
,'83322'
,'83514'
,'71728'
,'92847'
,'92847'
,'77355'
,'92847'
,'82107'
,'87261'
,'92573'
,'74331'
,'80582'
,'92497'
,'85933'
,'89129'
,'93364'
,'92918'
,'72227'
,'74272'
,'91394'
,'93311'
,'73652'
,'79608'
,'93363'
,'77706'
,'80178'
,'71766'
,'87317'
,'90539'
,'82859'
,'84297'
,'93589'
,'93315'
,'92981'
,'79886'
,'77424'
,'92901'
,'70819'
,'92088'
,'81625'
,'90759'
,'92109'
,'81519'
,'92049'
,'86465'
,'92752'
,'92240'
,'82064'
,'92114'
,'81607'
,'81804'
,'89869'
,'93718'
,'93718'
,'88838'
,'92260'
,'89706'
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
,'90344'
,'72610'
,'89511'
,'88951'
,'72629'
,'92799'
,'89891'
,'92213'
,'92976'
,'93052'
,'91585'
,'79608'
,'93514'
,'78323'
,'71308'
,'92618'
,'81804'
,'80016'
,'83939'
,'92027'
,'80911'
,'76037'
,'74329'
,'93644'
,'91232'
,'93092'
,'93737'
,'93638'
,'93571'
,'92618'
,'93470'
,'93712'
,'79886'
,'85455'
,'92834'
,'92789'
,'81605'
,'90240'
)