
select
  cp.IdCampeonatoPartida,
  dateadd(hour, -6, cp.DtPartida) DtPartida,
  cp.IdEstadio,
  e.Nome,
  cp.IdCampeonatoTime1,
  ct1.IdTime,
  t1.Nome,
  t1.Sigla,
  cp.IdCampeonatoTime2,
  ct2.IdTime,
  t2.Nome,
  t2.Sigla,
  cp.Peso,
  cp.PlacarTime1,
  cp.PlacarTime2,
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
order by DtPartida, IdCampeonatoPartida
