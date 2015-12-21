CREATE TABLE [dbo].[_okold_ok_fam] (
    [id]         INT           NOT NULL,
    [itab_n]     INT           NULL,
    [ik_memb]    INT           NULL,
    [fio]        VARCHAR (150) NULL,
    [d_birth]    VARCHAR (10)  NULL,
    [idEmployee] INT           DEFAULT ((0)) NOT NULL,
    [memb]       VARCHAR (255) NULL
);

