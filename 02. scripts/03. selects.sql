
select * from [Campeonato]

INSERT INTO Bolao.dbo.Campeonato (Descricao,DtInicio,DtFim,UrlImagem,Status)
    VALUES (N'Copa do Mundo da FIFA Catar 2022','2022-11-20','2022-12-18',N'https://upload.wikimedia.org/wikipedia/pt/thumb/e/e3/2022_FIFA_World_Cup.svg/1713px-2022_FIFA_World_Cup.svg.png',N'S');


select * from [Time]

select * from [CampeonatoTime]

insert into CampeonatoTime (IdCampeonato,IdTime)
select 1 IdCampeonato,IdTime from [Time]
order by IdTime


select * from [Estadio]

insert into Estadio (Nome,UrlImagem) values ('Estádio 1','http://www.google.com')


select * from [CampeonatoPartida]

select * from [Usuario]

select * from [Bolao]

select * from [Regra]

select * from [BolaoRegra]

select * from [BolaoUsuario]

select * from [BolaoPalpite]
