IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;

GO

CREATE TABLE [Cliente] (
    [IdCliente] int NOT NULL IDENTITY,
    [Nome] nvarchar(150) NOT NULL,
    [Email] nvarchar(100) NOT NULL,
    [Cpf] nvarchar(11) NOT NULL,
    [DataCriacao] date NOT NULL,
    CONSTRAINT [PK_Cliente] PRIMARY KEY ([IdCliente])
);

GO

CREATE UNIQUE INDEX [IX_Cliente_Cpf] ON [Cliente] ([Cpf]);

GO

CREATE UNIQUE INDEX [IX_Cliente_Email] ON [Cliente] ([Email]);

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20200606201335_Initial', N'3.1.4');

GO

