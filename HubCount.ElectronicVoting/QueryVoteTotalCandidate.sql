select 
	c.Id,
	c.Name, 
	count(*) qtd
from
	Votes v inner join VoteCandidates vc on v.Id = vc.VotesId
	inner join Candidates c on c.Id = vc.CandidatesId
group by
	c.Id, c.Name
order by qtd desc