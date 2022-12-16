
-- Pontos totais
select bp.IdBolaoUsuario, sum(bp.Pontuacao) from [BolaoPalpite] bp
group by bp.IdBolaoUsuario
order by bp.IdBolaoUsuario


-- Total de jogos enquadrados dentro de cada regra
select
  bp.IdRegra,
  r.Descricao,
  r.Pontuacao,
  TotalPalpites.TotalPalpites,
  count(*) TotalNaRegra,
  cast((cast(count(*) as float) / cast(TotalPalpites.TotalPalpites as float) * 100) as numeric(4,2)) PercentSobreTotal
from [BolaoPalpite] bp
inner join [Regra] r on bp.IdRegra = r.IdRegra
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


-- Total de palpites por usuário
select IdBolaoUsuario, count(*) TotalPalpites
from [BolaoPalpite]
group by IdBolaoUsuario
order by count(*) desc, IdBolaoUsuario


-- Total de palpites por jogo
select a.IdCampeonatoPartida, a.Sigla1, a.Sigla2, a.TotalPalpites,
  (select count(*) from [BolaoPalpite] bp1 where bp1.IdCampeonatoPartida = a.IdCampeonatoPartida and bp1.IdRegra is not null) TotalPalpitesAnalisados,
  (select count(*) from [BolaoPalpite] bp1 where bp1.IdCampeonatoPartida = a.IdCampeonatoPartida and bp1.IdRegra is null) TotalPalpitesNaoAnalisados
from (
      select bp.IdCampeonatoPartida, t1.Sigla Sigla1, t2.Sigla Sigla2, count(*) TotalPalpites
      from [BolaoPalpite] bp
        inner join [CampeonatoPartida] cp on cp.IdCampeonatoPartida = bp.IdCampeonatoPartida
        inner join [CampeonatoTime] ct1 on cp.IdCampeonatoTime1 = ct1.IdCampeonatoTime
        inner join [Time] t1 on ct1.IdTime = t1.IdTime
        inner join [CampeonatoTime] ct2 on cp.IdCampeonatoTime2 = ct2.IdCampeonatoTime
        inner join [Time] t2 on ct2.IdTime = t2.IdTime
      --where bp.IdBolaoUsuario <> 1
      group by bp.IdCampeonatoPartida, t1.Sigla, t2.Sigla
     ) a
order by a.IdCampeonatoPartida, a.Sigla1, a.Sigla2


-- Ranking conforme data da partida
select
  row_number() over (order by a.TotalPontuacao desc, a.DtInscricao) Posicao,
  a.*
from (
      select
        b.IdBolao, b.Descricao DescricaoBolao, b.UrlImagem UrlImagemBolao,
        b.IdCampeonato, c.Descricao DescricaoCampeonato, c.DtInicio, c.DtFim, c.UrlImagem UrlImagemCampeonato,
        bu.IdBolaoUsuario, bu.IdUsuario, bu.DtInscricao,
        u.Nome, u.Email, u.UrlImagem UrlImagemUsuario, u.DtCadastro, TotalPontuacao.TotalPontuacao
      from [Bolao] b
        inner join [Campeonato] c on b.IdCampeonato = c.IdCampeonato
        inner join [BolaoUsuario] bu on b.IdBolao = bu.IdBolao
        inner join [Usuario] u on bu.IdUsuario = u.IdUsuario
        left join (
                   select
                     bp.IdBolaoUsuario,
                     sum(bp.Pontuacao) TotalPontuacao
                   from [BolaoUsuario] bu
                     left join [BolaoPalpite] bp on bu.IdBolaoUsuario = bp.IdBolaoUsuario
                     left join [CampeonatoPartida] cp on bp.IdCampeonatoPartida = cp.IdCampeonatoPartida
                   where bu.IdBolao = 1
                     and cp.DtPartida <= '2022-12-20 19:00:00'
                   group by
                     bp.IdBolaoUsuario
                  ) TotalPontuacao on bu.IdBolaoUsuario = TotalPontuacao.IdBolaoUsuario
     ) a
