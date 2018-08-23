
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 08/22/2018 11:39:22
-- Generated from EDMX file: C:\Users\Feracios\Documents\GitHub\ASP.NET\BookStore\AdoNetModelFirst\AdoNetModelFirst\Model1.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [LibraryDB];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------


-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------


-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'UsersSet'
CREATE TABLE [dbo].[UsersSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'BooksSet'
CREATE TABLE [dbo].[BooksSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'AuthorsSet'
CREATE TABLE [dbo].[AuthorsSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'LogBooksSet'
CREATE TABLE [dbo].[LogBooksSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [IsDebtor] bit  NOT NULL,
    [UsersId] int  NOT NULL,
    [BooksId] int  NOT NULL
);
GO

-- Creating table 'AuthorsBooks'
CREATE TABLE [dbo].[AuthorsBooks] (
    [Authors_Id] int  NOT NULL,
    [Books_Id] int  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id] in table 'UsersSet'
ALTER TABLE [dbo].[UsersSet]
ADD CONSTRAINT [PK_UsersSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'BooksSet'
ALTER TABLE [dbo].[BooksSet]
ADD CONSTRAINT [PK_BooksSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'AuthorsSet'
ALTER TABLE [dbo].[AuthorsSet]
ADD CONSTRAINT [PK_AuthorsSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'LogBooksSet'
ALTER TABLE [dbo].[LogBooksSet]
ADD CONSTRAINT [PK_LogBooksSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Authors_Id], [Books_Id] in table 'AuthorsBooks'
ALTER TABLE [dbo].[AuthorsBooks]
ADD CONSTRAINT [PK_AuthorsBooks]
    PRIMARY KEY CLUSTERED ([Authors_Id], [Books_Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [Authors_Id] in table 'AuthorsBooks'
ALTER TABLE [dbo].[AuthorsBooks]
ADD CONSTRAINT [FK_AuthorsBooks_Authors]
    FOREIGN KEY ([Authors_Id])
    REFERENCES [dbo].[AuthorsSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [Books_Id] in table 'AuthorsBooks'
ALTER TABLE [dbo].[AuthorsBooks]
ADD CONSTRAINT [FK_AuthorsBooks_Books]
    FOREIGN KEY ([Books_Id])
    REFERENCES [dbo].[BooksSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_AuthorsBooks_Books'
CREATE INDEX [IX_FK_AuthorsBooks_Books]
ON [dbo].[AuthorsBooks]
    ([Books_Id]);
GO

-- Creating foreign key on [UsersId] in table 'LogBooksSet'
ALTER TABLE [dbo].[LogBooksSet]
ADD CONSTRAINT [FK_UsersLogBooks]
    FOREIGN KEY ([UsersId])
    REFERENCES [dbo].[UsersSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_UsersLogBooks'
CREATE INDEX [IX_FK_UsersLogBooks]
ON [dbo].[LogBooksSet]
    ([UsersId]);
GO

-- Creating foreign key on [BooksId] in table 'LogBooksSet'
ALTER TABLE [dbo].[LogBooksSet]
ADD CONSTRAINT [FK_BooksLogBooks]
    FOREIGN KEY ([BooksId])
    REFERENCES [dbo].[BooksSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_BooksLogBooks'
CREATE INDEX [IX_FK_BooksLogBooks]
ON [dbo].[LogBooksSet]
    ([BooksId]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------