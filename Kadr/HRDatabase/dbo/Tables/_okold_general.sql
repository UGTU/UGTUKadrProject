﻿CREATE TABLE [dbo].[_okold_general] (
    [id]           INT           NOT NULL,
    [arc]          INT           NULL,
    [itab_n]       INT           NULL,
    [clastname]    VARCHAR (50)  NULL,
    [cfirstname]   VARCHAR (50)  NULL,
    [cotch]        VARCHAR (50)  NULL,
    [fio]          VARCHAR (150) NULL,
    [csex]         VARCHAR (10)  NULL,
    [birth_d]      DATETIME      NULL,
    [birth_cplace] VARCHAR (100) NULL,
    [ik_grazd]     INT           NULL,
    [pasp_ser]     VARCHAR (10)  NULL,
    [pasp_nom]     VARCHAR (10)  NULL,
    [pasp_date]    DATETIME      NULL,
    [pasp_kem]     VARCHAR (100) NULL,
    [cphone]       VARCHAR (50)  NULL,
    [ik_sempol]    INT           NULL,
    [ik_uvoln]     INT           NULL,
    [uvoln_d]      DATETIME      NULL,
    [uvoln_npr]    VARCHAR (100) NULL,
    [uvoln_dpr]    DATETIME      NULL,
    [profosn]      VARCHAR (100) NULL,
    [profan]       VARCHAR (100) NULL,
    [ik_harakter]  INT           NULL,
    [nstr]         VARCHAR (14)  NULL,
    [inn]          VARCHAR (30)  NULL,
    [d_zapoln]     DATETIME      NULL,
    [ost]          INT           NULL,
    [perw_db]      DATETIME      NULL
);

