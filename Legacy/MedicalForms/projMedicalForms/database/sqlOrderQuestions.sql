--Create Temporary Table tempTB as 
select Question.Question
	, count(Question.Question) as Total
	, min(form.SortOrder) as SortOrder
from Question
	Join Form on Form.ID = Question.Form_ID
where Question = 'Addiction'
Group By Question.Question






