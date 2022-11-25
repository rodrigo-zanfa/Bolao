
select * from [Campeonato]

insert into Campeonato (Descricao, DtInicio, DtFim, UrlImagem, Status) values
  ('Copa do Mundo da FIFA Catar 2022', '2022-11-20', '2022-12-18', 'https://upload.wikimedia.org/wikipedia/pt/thumb/e/e3/2022_FIFA_World_Cup.svg/1713px-2022_FIFA_World_Cup.svg.png', 'S')


select * from [Time]


select * from [CampeonatoTime]

insert into CampeonatoTime (IdCampeonato, IdTime)
select 1 IdCampeonato, IdTime from [Time]
order by IdTime


select * from [Estadio]

insert into Estadio (Nome, UrlImagem) values
  ('Estádio 1', 'http://www.google.com')


select * from [CampeonatoPartida]


select * from [Usuario]


select * from [Bolao]

insert into Bolao (IdCampeonato, IdUsuario, Descricao, QtLimiteParticipantes, DtLimiteAceiteParticipantes, UrlImagem, Status) values
  (1, null, 'Bolão Geral da Copa do Mundo da FIFA Catar 2022', 9999, '2022-11-20', 'https://upload.wikimedia.org/wikipedia/pt/thumb/e/e3/2022_FIFA_World_Cup.svg/1713px-2022_FIFA_World_Cup.svg.png', 'S')


select * from [Regra]

insert into Regra (Descricao, DescricaoDetalhada, Pontuacao, Ordem, Status) values
  ('Placar exato', 'Ex: você palpitou 0x0 e a partida acabou 0x0', 25, 1, 'S')
insert into Regra (Descricao, DescricaoDetalhada, Pontuacao, Ordem, Status) values
  ('Vencedor e número de gols do vencedor', 'Ex: você palpitou 3x1 e a partida acabou 3x2', 18, 2, 'S')
insert into Regra (Descricao, DescricaoDetalhada, Pontuacao, Ordem, Status) values
  ('Vencedor e diferença de gols', 'Ex: você palpitou 3x1 e a partida acabou 2x0', 15, 3, 'S')
insert into Regra (Descricao, DescricaoDetalhada, Pontuacao, Ordem, Status) values
  ('Empate', 'Ex: você palpitou 3x3 e a partida acabou 0x0', 15, 4, 'S')
insert into Regra (Descricao, DescricaoDetalhada, Pontuacao, Ordem, Status) values
  ('Vencedor e número de gols do perdedor', 'Ex: você palpitou 3x1 e a partida acabou 2x1', 12, 5, 'S')
insert into Regra (Descricao, DescricaoDetalhada, Pontuacao, Ordem, Status) values
  ('Apenas o vencedor', 'Ex: você palpitou 3x1 e a partida acabou 4x0', 10, 6, 'S')
insert into Regra (Descricao, DescricaoDetalhada, Pontuacao, Ordem, Status) values
  ('Empate garantido', 'Ex: você palpitou 1x1 e a partida acabou 2x1', 4, 7, 'S')


select * from [BolaoRegra]

insert into BolaoRegra (IdBolao, IdRegra)
select 1 IdBolao, IdRegra from [Regra]
order by IdRegra


select * from [BolaoUsuario]

insert into BolaoUsuario (IdBolao, IdUsuario, DtInscricao)
select 1 IdBolao, IdUsuario, '2022-11-20' DtInscricao from [Usuario]
order by IdUsuario


select * from [BolaoPalpite]
