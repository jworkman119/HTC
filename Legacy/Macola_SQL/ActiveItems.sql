select isNull(rtrim(Family.fam1), '*N/A') as FamilyCode 
	, itemcode
	, description
--	, userfield_10 as ActivityCode
from items
	left join zzzhtc_family as Family on items.itemcode = Family.item
Where items.warehouse = 700
	and userfield_10 = 'A'
Order by FamilyCode


