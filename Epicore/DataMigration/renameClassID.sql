select Distinct Case 
	When CharIndex('-',PartNum,1)>0 then
		Substring(partnum,1,CharIndex('-',PartNum,1)-1) 
	Else
		PartNum
	end as Part
	, Case
		When left(PartNum,2)='SC' and CharIndex('-',PartNum,1)>0 then
			right(Substring(partnum,1,CharIndex('-',PartNum,1)-1), len(Substring(partnum,1,CharIndex('-',PartNum,1)-1))-4) 

		When CharIndex('-',PartNum,1)>0 then
			Substring(partnum,1,CharIndex('-',PartNum,1)-1) 
		Else 
			right(PartNum,len(partnum)-2)
		end as _tempClass
	, ClassID
	, tempClass
from part
where classid is null
and tempClass is null


