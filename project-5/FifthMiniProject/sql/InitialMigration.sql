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

CREATE TABLE [People] (
    [PersonId] int NOT NULL IDENTITY,
    [PersonName] nvarchar(max) NOT NULL,
    [PeselNumber] PESEL NOT NULL,
    [person_type] nvarchar(max) NOT NULL,
    [BuyerId] int NULL,
    [Email] EMAIL NULL,
    [SellerId] int NULL,
    [Address] nvarchar(max) NULL,
    CONSTRAINT [PK_People] PRIMARY KEY ([PersonId])
);
GO

CREATE TABLE [CreditCards] (
    [BuyerPersonId] int NOT NULL,
    [CreditCardNumber] nvarchar(max) NOT NULL,
    [CvcNumber] nvarchar(max) NOT NULL,
    [ExpirationDate] datetime2 NOT NULL,
    CONSTRAINT [PK_CreditCards] PRIMARY KEY ([BuyerPersonId]),
    CONSTRAINT [FK_CreditCards_People_BuyerPersonId] FOREIGN KEY ([BuyerPersonId]) REFERENCES [People] ([PersonId]) ON DELETE CASCADE
);
GO

CREATE TABLE [Orders] (
    [OrderId] int NOT NULL IDENTITY,
    [ShippingAddress] nvarchar(max) NOT NULL,
    [BuyerPersonId] int NOT NULL,
    CONSTRAINT [PK_Orders] PRIMARY KEY ([OrderId]),
    CONSTRAINT [FK_Orders_People_BuyerPersonId] FOREIGN KEY ([BuyerPersonId]) REFERENCES [People] ([PersonId]) ON DELETE CASCADE
);
GO

CREATE TABLE [Products] (
    [ProductId] int NOT NULL IDENTITY,
    [ProductName] nvarchar(max) NOT NULL,
    [OrderId] int NULL,
    [SellerPersonId] int NULL,
    CONSTRAINT [PK_Products] PRIMARY KEY ([ProductId]),
    CONSTRAINT [FK_Products_Orders_OrderId] FOREIGN KEY ([OrderId]) REFERENCES [Orders] ([OrderId]),
    CONSTRAINT [FK_Products_People_SellerPersonId] FOREIGN KEY ([SellerPersonId]) REFERENCES [People] ([PersonId])
);
GO

CREATE INDEX [IX_Orders_BuyerPersonId] ON [Orders] ([BuyerPersonId]);
GO

CREATE UNIQUE INDEX [IX_People_PeselNumber] ON [People] ([PeselNumber]);
GO

CREATE INDEX [IX_Products_OrderId] ON [Products] ([OrderId]);
GO

CREATE INDEX [IX_Products_SellerPersonId] ON [Products] ([SellerPersonId]);
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20220528231225_InitialMigration', N'6.0.5');
GO

COMMIT;
GO
