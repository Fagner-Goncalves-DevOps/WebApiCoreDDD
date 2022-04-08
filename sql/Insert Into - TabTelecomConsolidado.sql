USE [ModeloTelecom]
GO

/****** Object: Table [dbo].[TabTelecomConsolidado] Script Date: 05/04/2022 21:17:37 ******/
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


ALTER TABLE  [dbo].[TabTelecomConsolidado] ALTER COLUMN [Dia] DATE

use ModeloTelecom
insert into [TabTelecomConsolidado]
select '2022-04-05'	,4029	,'Algar','MACHINE','REDIR',72656,17220,'SrvCar' union all
select '2022-04-06' ,5000	,'Algar','MACHINE','REDIR',78956,25220,'SrvCar2'


select * from  ModeloTelecom.dbo.[TabTelecomConsolidado]

--drop table  [TabTelecomConsolidado]


select '2022-02-25'	,4022	,'Algar CtaG2'   ,'MACHINE'	,'MACHINE'	,'vc1'	    ,30     ,15100	,469.04	,0	,0	,1	,'car2'union all
select '2022-02-25'	,4029	,'Apollo'        ,'MACHINE'	,'MACHINE'	,'vc1'	    ,270	,12400	,254.32	,0	,0	,7	,'car3'union all
select '2022-02-25'	,4046	,'Attus ITX'     ,'REDIR'	,'MACHINE'	,'vc1'	    ,300	,13510	,364.35	,0	,0	,3	,'car4'union all
select '2022-02-25'	,4034	,'Attus ITX'     ,'REDIR'	,'MACHINE'	,'vc3'	    ,186	,14800	,542.22	,0	,0	,2	,'car5'union all 
select '2022-02-25'	,4031	,'Vivo E1'       ,'MACHINE'	,'REDIR'	,'local'	,300	,19700	,906.22	,0	,0	,2	,'car6'union all
select '2022-02-25'	,4032	,'Embratel'      ,'MACHINE'	,'REDIR'	,'vc1'	    ,250	,12600	,700.22	,0	,0	,3	,'car7'union all
select '2022-02-25'	,4033	,'Embratel'      ,'MACHINE'	,'REDIR'	,'vc3'	    ,142	,17300	,446.22	,0	,0	,4	,'car8'union all
select '2022-02-25'	,4037	,'Mutant'        ,'REDIR'	,'REDIR'	,'vc1'	    ,172	,13200	,267.22	,0	,0	,5	,'car9'union all
select '2022-02-25'	,4038	,'COPEL'         ,'REDIR'	,'REDIR'	,'vc3'	    ,182	,16800	,323.22	,0	,0	,2	,'car10'


