USE [ModeloTelecom]
GO

/****** Object: Table [dbo].[TabTelecomConsolidado] Script Date: 05/04/2022 03:52:44 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[TabTelecomConsolidado] (
    [Id]            INT             IDENTITY (1, 1) NOT NULL,
    [Dia]           DATETIME        NOT NULL,
    [Fila]          INT             NULL,
    [Terminator]    VARCHAR (100)   NULL,
    [StatusInicial] VARCHAR (255)   NULL,
    [StatusFinal]   VARCHAR (100)   NOT NULL,
    [Disparos]      INT             NOT NULL,
    [Custo]         DECIMAL (18, 2) NOT NULL,
    [Servidor]      VARCHAR (100)   NULL
);

select * from ModeloTelecom.dbo.TabTelecomConsolidado
