USE [PointOfSale]
GO

/****** Object: Table [dbo].[Customers] Script Date: 04/12/2022 12:08:34 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Customers] (
    [CustomerId]    INT          IDENTITY (1, 1) NOT NULL,
    [Name]          VARCHAR (50) NOT NULL,
    [Address]       VARCHAR (50) NOT NULL,
    [Phone]         VARCHAR (50) NOT NULL,
    [Email]         VARCHAR (50) NOT NULL,
    [AmountPayable] INT          NOT NULL,
    [SalesLimit]    INT          NOT NULL
);


