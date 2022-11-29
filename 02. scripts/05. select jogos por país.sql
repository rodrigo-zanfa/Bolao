
declare
  @NomeTime varchar(100) = 'eng'

select * from (
select
  cp.IdCampeonatoPartida,
  dateadd(hour, -6, cp.DtPartida) DtPartida,
  --cp.IdEstadio,
  --e.Nome,
  --cp.IdCampeonatoTime1,
  --ct1.IdTime IdTimeT1,
  t1.Nome NomeT1,
  t1.Sigla SiglaT1,
  --cp.IdCampeonatoTime2,
  --ct2.IdTime IdTimeT2,
  t2.Nome NomeT2,
  t2.Sigla SiglaT2,
  cp.Peso,
  cp.PlacarTime1 PlacarTime1Jogo,
  cp.PlacarTime2 PlacarTime2Jogo,
  bp.PlacarTime1,
  bp.PlacarTime2,
  bp.DtPontuacao,
  bp.IdRegra,
  r.Descricao,
  r.DescricaoDetalhada,
  bp.Pontuacao
from [CampeonatoPartida] cp
  inner join [Estadio] e on cp.IdEstadio = e.IdEstadio
  inner join [CampeonatoTime] ct1 on cp.IdCampeonatoTime1 = ct1.IdCampeonatoTime
  inner join [CampeonatoTime] ct2 on cp.IdCampeonatoTime2 = ct2.IdCampeonatoTime
  inner join [Time] t1 on ct1.IdTime = t1.IdTime
  inner join [Time] t2 on ct2.IdTime = t2.IdTime
  --inner join [BolaoUsuario] bu on
  left join [BolaoPalpite] bp on bp.IdBolaoUsuario = 1 -- bu.IdBolaoUsuario = bp.IdBolaoUsuario 
                             and cp.IdCampeonatoPartida = bp.IdCampeonatoPartida
  left join [Regra] r on bp.IdRegra = r.IdRegra
) a
where a.NomeT1 like '%' + @NomeTime + '%'
   or a.NomeT2 like '%' + @NomeTime + '%'
order by a.DtPartida, a.IdCampeonatoPartida
