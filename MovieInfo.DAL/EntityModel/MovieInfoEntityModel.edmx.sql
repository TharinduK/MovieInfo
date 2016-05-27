
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 05/18/2016 09:48:17
-- Generated from EDMX file: C:\Users\103155\Desktop\SearchProject\MovieInfo.DAL\EntityModel\MovieInfoEntityModel.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [MovieDB2013];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------


-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[Movie]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Movie];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Movies'
CREATE TABLE [dbo].[Movies] (
    [Id] int  NOT NULL,
    [Name] nvarchar(50)  NOT NULL,
    [Year] datetime  NULL,
    [Genre] int  NULL,
    [Description] nvarchar(4000)  NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id] in table 'Movies'
ALTER TABLE [dbo].[Movies]
ADD CONSTRAINT [PK_Movies]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------