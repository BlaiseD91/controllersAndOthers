IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;
GO

BEGIN TRANSACTION;
GO

CREATE TABLE [ingatlanok] (
    [Id] int NOT NULL IDENTITY,
    [Leiras] nvarchar(max) NOT NULL,
    [HirdetesDatuma] datetime2 NOT NULL,
    [Tehermentes] bit NOT NULL,
    [Ar] bigint NOT NULL,
    [KepUrl] nvarchar(max) NOT NULL,
    [KategoriaId] int NOT NULL,
    CONSTRAINT [PK_ingatlanok] PRIMARY KEY ([Id])
);
GO

CREATE TABLE [kategoriak] (
    [Id] int NOT NULL IDENTITY,
    [Nev] nvarchar(max) NOT NULL,
    CONSTRAINT [PK_kategoriak] PRIMARY KEY ([Id])
);
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20240520162758_init', N'6.0.29');
GO

COMMIT;
GO

