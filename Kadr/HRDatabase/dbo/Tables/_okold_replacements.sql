﻿CREATE TABLE [dbo].[_okold_replacements] (
    [id]             INT             NOT NULL,
    [itab_n]         INT             NULL,
    [ik_vidw]        INT             NULL,
    [dog_nom]        VARCHAR (50)    NULL,
    [dog_d]          DATETIME        NULL,
    [dog_db]         DATETIME        NULL,
    [dog_de]         DATETIME        NULL,
    [perev_d]        DATETIME        NULL,
    [ik_dep]         INT             NULL,
    [ik_prof]        INT             NULL,
    [ets]            INT             NULL,
    [ik_kateg]       INT             NULL,
    [ik_kvalif]      INT             NULL,
    [stavka]         NUMERIC (5, 2)  NULL,
    [prik_nom]       VARCHAR (50)    NULL,
    [prik_d]         DATETIME        NULL,
    [ik_vidper]      INT             NULL,
    [ik_prper]       INT             NULL,
    [VacancyID]      INT             NULL,
    [stake]          NUMERIC (5, 2)  NULL,
    [DeanBonus]      NUMERIC (12, 2) NULL,
    [ManageBonus]    NUMERIC (5, 2)  NULL,
    [OtherBonus]     NUMERIC (5, 2)  NULL,
    [StandingBonus]  NUMERIC (12, 2) NULL,
    [IncentiveBonus] NUMERIC (12, 2) NULL,
    [ReleaseDate]    DATETIME        NULL
);

