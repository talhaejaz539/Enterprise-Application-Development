USE [PointOfSale]
GO

/****** Object: Table [dbo].[Receipts] Script Date: 04/12/2022 12:09:42 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Receipts] (
    [ReceiptNo]   INT  IDENTITY (1, 1) NOT NULL,
    [ReceiptDate] DATE NOT NULL,
    [OrderId]     INT  NOT NULL,
    [Amount]      INT  NOT NULL
);


