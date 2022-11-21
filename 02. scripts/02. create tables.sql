
/*

DROP TABLE [Campeonato]

DROP TABLE [Time]

DROP TABLE [CampeonatoTime]

DROP TABLE [Estadio]

DROP TABLE [CampeonatoPartida]

DROP TABLE [Usuario]

DROP TABLE [Bolao]

DROP TABLE [Regra]

DROP TABLE [BolaoRegra]

DROP TABLE [BolaoUsuario]

DROP TABLE [BolaoPalpite]

*/


BEGIN TRANSACTION;
GO

CREATE TABLE [Campeonato] (
    [IdCampeonato] int NOT NULL IDENTITY,
    [Descricao] varchar(100) NOT NULL,
    [DtInicio] datetime NOT NULL,
    [DtFim] datetime NOT NULL,
    [UrlImagem] varchar(255) NOT NULL,
    [Status] varchar(1) NOT NULL,
    CONSTRAINT [PK_Campeonato] PRIMARY KEY ([IdCampeonato])
);
GO

CREATE TABLE [Time] (
    [IdTime] int NOT NULL IDENTITY,
    [IdTimeAux] int NOT NULL,
    [Nome] varchar(100) NOT NULL,
    [Sigla] varchar(3) NOT NULL,
    [UrlImagem] varchar(255) NOT NULL,
    CONSTRAINT [PK_Time] PRIMARY KEY ([IdTime])
);
GO

CREATE TABLE [CampeonatoTime] (
    [IdCampeonatoTime] int NOT NULL IDENTITY,
    [IdCampeonato] int NOT NULL,
    [IdTime] int NOT NULL,
    CONSTRAINT [PK_CampeonatoTime] PRIMARY KEY ([IdCampeonatoTime]),
    CONSTRAINT [FK_CampeonatoTime_Campeonato_IdCampeonato] FOREIGN KEY ([IdCampeonato]) REFERENCES [Campeonato] ([IdCampeonato]),
    CONSTRAINT [FK_CampeonatoTime_Time_IdTime] FOREIGN KEY ([IdTime]) REFERENCES [Time] ([IdTime])
);
GO

CREATE INDEX [IX_CampeonatoTime_IdCampeonato] ON [CampeonatoTime] ([IdCampeonato]);
GO

CREATE INDEX [IX_CampeonatoTime_IdTime] ON [CampeonatoTime] ([IdTime]);
GO

CREATE TABLE [Estadio] (
    [IdEstadio] int NOT NULL IDENTITY,
    [Nome] varchar(100) NOT NULL,
    [UrlImagem] varchar(255) NOT NULL,
    CONSTRAINT [PK_Estadio] PRIMARY KEY ([IdEstadio])
);
GO

CREATE TABLE [CampeonatoPartida] (
    [IdCampeonatoPartida] int NOT NULL IDENTITY,
    [DtPartida] datetime NOT NULL,
    [IdEstadio] int NOT NULL,
    [IdCampeonatoTime1] int NOT NULL,
    [IdCampeonatoTime2] int NOT NULL,
    [PlacarTime1] int NULL,
    [PlacarTime2] int NULL,
    CONSTRAINT [PK_CampeonatoPartida] PRIMARY KEY ([IdCampeonatoPartida]),
    CONSTRAINT [FK_CampeonatoPartida_Estadio_IdEstadio] FOREIGN KEY ([IdEstadio]) REFERENCES [Estadio] ([IdEstadio]),
    CONSTRAINT [FK_CampeonatoPartida_CampeonatoTime_IdCampeonatoTime1] FOREIGN KEY ([IdCampeonatoTime1]) REFERENCES [CampeonatoTime] ([IdCampeonatoTime]),
    CONSTRAINT [FK_CampeonatoPartida_CampeonatoTime_IdCampeonatoTime2] FOREIGN KEY ([IdCampeonatoTime2]) REFERENCES [CampeonatoTime] ([IdCampeonatoTime])
);
GO

CREATE INDEX [IX_CampeonatoPartida_IdEstadio] ON [CampeonatoPartida] ([IdEstadio]);
GO

CREATE INDEX [IX_CampeonatoPartida_IdCampeonatoTime1] ON [CampeonatoPartida] ([IdCampeonatoTime1]);
GO

CREATE INDEX [IX_CampeonatoPartida_IdCampeonatoTime2] ON [CampeonatoPartida] ([IdCampeonatoTime2]);
GO

CREATE TABLE [Usuario] (
    [IdUsuario] int NOT NULL IDENTITY,
    [Nome] varchar(100) NOT NULL,
    [Email] varchar(100) NOT NULL,
    [Senha] varchar(100) NOT NULL,
    [UrlImagem] varchar(255) NOT NULL,
    [DtCadastro] datetime NOT NULL,
    CONSTRAINT [PK_Usuario] PRIMARY KEY ([IdUsuario])
);
GO

CREATE TABLE [Bolao] (
    [IdBolao] int NOT NULL IDENTITY,
    [IdCampeonato] int NOT NULL,
    [IdUsuario] int NULL,
    [Descricao] varchar(100) NOT NULL,
    [QtLimiteParticipantes] int NOT NULL,
    [DtLimiteAceiteParticipantes] datetime NOT NULL,
    [UrlImagem] varchar(255) NOT NULL,
    [Status] varchar(1) NOT NULL,
    CONSTRAINT [PK_Bolao] PRIMARY KEY ([IdBolao]),
    CONSTRAINT [FK_Bolao_Campeonato_IdCampeonato] FOREIGN KEY ([IdCampeonato]) REFERENCES [Campeonato] ([IdCampeonato]),
    CONSTRAINT [FK_Bolao_Usuario_IdUsuario] FOREIGN KEY ([IdUsuario]) REFERENCES [Usuario] ([IdUsuario])
);
GO

CREATE INDEX [IX_Bolao_IdCampeonato] ON [Bolao] ([IdCampeonato]);
GO

CREATE INDEX [IX_Bolao_IdUsuario] ON [Bolao] ([IdUsuario]);
GO

CREATE TABLE [Regra] (
    [IdRegra] int NOT NULL IDENTITY,
    [Descricao] varchar(100) NOT NULL,
    [Pontuacao] int NOT NULL,
    [Ordem] int NOT NULL,
    [Status] varchar(1) NOT NULL,
    CONSTRAINT [PK_Regra] PRIMARY KEY ([IdRegra])
);
GO

CREATE TABLE [BolaoRegra] (
    [IdBolaoRegra] int NOT NULL IDENTITY,
    [IdBolao] int NOT NULL,
    [IdRegra] int NOT NULL,
    CONSTRAINT [PK_BolaoRegra] PRIMARY KEY ([IdBolaoRegra]),
    CONSTRAINT [FK_BolaoRegra_Bolao_IdBolao] FOREIGN KEY ([IdBolao]) REFERENCES [Bolao] ([IdBolao]),
    CONSTRAINT [FK_BolaoRegra_Regra_IdRegra] FOREIGN KEY ([IdRegra]) REFERENCES [Regra] ([IdRegra])
);
GO

CREATE INDEX [IX_BolaoRegra_IdBolao] ON [BolaoRegra] ([IdBolao]);
GO

CREATE INDEX [IX_BolaoRegra_IdRegra] ON [BolaoRegra] ([IdRegra]);
GO

CREATE TABLE [BolaoUsuario] (
    [IdBolaoUsuario] int NOT NULL IDENTITY,
    [IdBolao] int NOT NULL,
    [IdUsuario] int NOT NULL,
    [DtInscricao] datetime NOT NULL,
    CONSTRAINT [PK_BolaoUsuario] PRIMARY KEY ([IdBolaoUsuario]),
    CONSTRAINT [FK_BolaoUsuario_Bolao_IdBolao] FOREIGN KEY ([IdBolao]) REFERENCES [Bolao] ([IdBolao]),
    CONSTRAINT [FK_BolaoUsuario_Usuario_IdUsuario] FOREIGN KEY ([IdUsuario]) REFERENCES [Usuario] ([IdUsuario])
);
GO

CREATE INDEX [IX_BolaoUsuario_IdBolao] ON [BolaoUsuario] ([IdBolao]);
GO

CREATE INDEX [IX_BolaoUsuario_IdUsuario] ON [BolaoUsuario] ([IdUsuario]);
GO

CREATE TABLE [BolaoPalpite] (
    [IdBolaoPalpite] int NOT NULL IDENTITY,
    [IdBolaoUsuario] int NOT NULL,
    [IdCampeonatoPartida] int NOT NULL,
    [PlacarTime1] int NOT NULL,
    [PlacarTime2] int NOT NULL,
    [DtCadastro] datetime NOT NULL,
    [DtAlteracao] datetime NOT NULL,
    [DtPontuacao] datetime NULL,
    [IdRegra] int NULL,
    [Pontuacao] int NULL,
    CONSTRAINT [PK_BolaoPalpite] PRIMARY KEY ([IdBolaoPalpite]),
    CONSTRAINT [FK_BolaoPalpite_BolaoUsuario_IdBolaoUsuario] FOREIGN KEY ([IdBolaoUsuario]) REFERENCES [BolaoUsuario] ([IdBolaoUsuario]),
    CONSTRAINT [FK_BolaoPalpite_CampeonatoPartida_IdCampeonatoPartida] FOREIGN KEY ([IdCampeonatoPartida]) REFERENCES [CampeonatoPartida] ([IdCampeonatoPartida]),
    CONSTRAINT [FK_BolaoPalpite_Regra_IdRegra] FOREIGN KEY ([IdRegra]) REFERENCES [Regra] ([IdRegra])
);
GO

CREATE INDEX [IX_BolaoPalpite_IdBolaoUsuario] ON [BolaoPalpite] ([IdBolaoUsuario]);
GO

CREATE INDEX [IX_BolaoPalpite_IdCampeonatoPartida] ON [BolaoPalpite] ([IdCampeonatoPartida]);
GO

CREATE INDEX [IX_BolaoPalpite_IdRegra] ON [BolaoPalpite] ([IdRegra]);
GO

COMMIT;
GO
