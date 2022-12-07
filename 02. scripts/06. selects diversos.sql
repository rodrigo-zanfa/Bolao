
-- Pontos totais
select sum(bp.Pontuacao) from [BolaoPalpite] bp


-- Total de jogos enquadrados dentro de cada regra
select
  bp.IdRegra,
  r.Descricao,
  r.Pontuacao,
  TotalPalpites.TotalPalpites,
  count(*) TotalNaRegra,
  cast((cast(count(*) as float) / cast(TotalPalpites.TotalPalpites as float) * 100) as numeric(4,2)) PercentSobreTotal
from [BolaoPalpite] bp
inner join Regra r on bp.IdRegra = r.IdRegra
  cross join (
              select sum(a.Total) TotalPalpites
              from (
                    select bp.IdRegra, count(*) Total
                    from [BolaoPalpite] bp
                    where bp.IdBolaoUsuario = 1
                    group by bp.IdRegra
                   ) a
             ) TotalPalpites
where bp.IdBolaoUsuario = 1
group by bp.IdRegra, r.Descricao, r.Pontuacao, TotalPalpites.TotalPalpites
order by bp.IdRegra


-- Total de pontos por dia
select
  cast(cp.DtPartida as date) DtPartida,
  count(cp.IdCampeonatoPartida) TotalJogosDia,
  PontuacaoDia.MaxPontuacaoDia,
  sum(bp.Pontuacao) TotalPontuacaoDia,
  cast((cast(sum(bp.Pontuacao) as float) / cast(PontuacaoDia.MaxPontuacaoDia as float) * 100) as numeric(4,2)) PercentAproveitamentoDia
from [CampeonatoPartida] cp
  left join (
             select cast(cp1.DtPartida as date) DtPartida, sum(cp1.Peso * r1.Pontuacao) MaxPontuacaoDia
             from [CampeonatoPartida] cp1
               cross join [Regra] r1
             where r1.IdRegra = 1
             group by cast(cp1.DtPartida as date)
            ) PontuacaoDia on cast(cp.DtPartida as date) = PontuacaoDia.DtPartida
  left join [BolaoPalpite] bp on bp.IdBolaoUsuario = 1 -- bu.IdBolaoUsuario = bp.IdBolaoUsuario
                             and cp.IdCampeonatoPartida = bp.IdCampeonatoPartida
group by cast(cp.DtPartida as date), PontuacaoDia.MaxPontuacaoDia
order by cast(cp.DtPartida as date)
