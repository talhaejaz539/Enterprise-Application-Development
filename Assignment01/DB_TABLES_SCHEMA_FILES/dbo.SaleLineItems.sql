USE [PointOfSale]
GO

/****** Object: Table [dbo].[SaleLineItems] Script Date: 04/12/2022 12:09:53 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[SaleLineItems] (
    [LineNo]   INT IDENTITY (1, 1) NOT NULL,
    [OrderId]  INT NOT NULL,
    [ItemId]   INT NOT NULL,
    [Quantity] INT NOT NULL,
    [Amount]   INT NOT NULL
);


