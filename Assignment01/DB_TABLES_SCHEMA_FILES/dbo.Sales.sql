USE [PointOfSale]
GO

/****** Object: Table [dbo].[Sales] Script Date: 04/12/2022 12:09:59 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Sales] (
    [OrderId]    INT          IDENTITY (1, 1) NOT NULL,
    [CustomerId] INT          NOT NULL,
    [Status]     VARCHAR (50) NOT NULL,
    [Date]       DATETIME     NOT NULL
);


