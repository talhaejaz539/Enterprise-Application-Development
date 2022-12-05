USE [PointOfSale]
GO

/****** Object: Table [dbo].[Items] Script Date: 04/12/2022 12:09:30 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Items] (
    [ItemId]       INT          IDENTITY (1, 1) NOT NULL,
    [Description]  VARCHAR (50) NOT NULL,
    [Price]        INT          NOT NULL,
    [Quantity]     INT          NOT NULL,
    [CreationDate] DATETIME     NOT NULL
);


