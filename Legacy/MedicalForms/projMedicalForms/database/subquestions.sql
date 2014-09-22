select question.question
	, ' - ' || subquestion.question as SubQuestion
from question
	join subquestion on question.id = subquestion.question_id
	join form on question.form_id = form.id

order by question.question


