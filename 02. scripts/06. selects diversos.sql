
-- Pontos totais
select sum(Pontuacao) from [BolaoPalpite]

-- Total de jogos enquadrados dentro de cada regra
select p.IdRegra, r.Descricao, r.Pontuacao, count(*) Total
from [BolaoPalpite] p
inner join Regra r on p.IdRegra = r.IdRegra
group by p.IdRegra, r.Descricao , r.Pontuacao
order by p.IdRegra
