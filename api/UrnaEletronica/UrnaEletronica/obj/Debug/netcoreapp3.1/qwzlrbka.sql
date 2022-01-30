IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;

GO

CREATE TABLE [Candidatos] (
    [Id] int NOT NULL IDENTITY,
    [NomeCompleto] nvarchar(max) NULL,
    [NomeVice] nvarchar(max) NULL,
    [DataDeRegistro] datetime2 NOT NULL,
    [Legenda] int NOT NULL,
    CONSTRAINT [PK_Candidatos] PRIMARY KEY ([Id])
);

GO

CREATE TABLE [Votos] (
    [Id] int NOT NULL IDENTITY,
    [CandidatoId] int NULL,
    [IdCandidato] int NOT NULL,
    [DataDoVoto] datetime2 NOT NULL,
    CONSTRAINT [PK_Votos] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Votos_Candidatos_CandidatoId] FOREIGN KEY ([CandidatoId]) REFERENCES [Candidatos] ([Id]) ON DELETE NO ACTION
);

GO

CREATE INDEX [IX_Votos_CandidatoId] ON [Votos] ([CandidatoId]);

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20220125133231_initial', N'3.1.0');

GO

