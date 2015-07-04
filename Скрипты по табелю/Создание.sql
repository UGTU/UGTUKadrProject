
--------***----непосредственно ТАБЕЛЬ-------***-----
CREATE SCHEMA [ShemaTabel] AUTHORIZATION [UGTU\tvokueva]
GO
 Create Role tab;

--------------------------------------


GO

CREATE TABLE [ShemaTabel].[ApproverType](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[ApproverTypeName] [varchar](50) NOT NULL,
 CONSTRAINT [ApproverTypePrimary] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY],
 CONSTRAINT [SostavitelTypeNameSostavitelTypeUnique] UNIQUE NONCLUSTERED 
(
	[ApproverTypeName] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]


go
alter table ShemaTabel.ApproverType
add ApproveNumber int


GO

CREATE TABLE [ShemaTabel].[DayStatus](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[DayStatusName] [varchar](5) NOT NULL,
	[DayStatusFullName] [varchar](100) NOT NULL,
 CONSTRAINT [DayStatusPrimary] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY],
 CONSTRAINT [DayStatusFullNameDayStatusUnique] UNIQUE NONCLUSTERED 
(
	[DayStatusFullName] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY],
 CONSTRAINT [DayStatusNameDayStatusUnique] UNIQUE NONCLUSTERED 
(
	[DayStatusName] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]


GO

CREATE TABLE [ShemaTabel].[Approver](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[DateBegin] [datetime] NOT NULL,
	[DateEnd] [datetime] NULL,
	[ForAllDepartments] [bit] NOT NULL,
	[idApproverType] [int] NOT NULL,
	[idFactStaff] [int] NOT NULL,
 CONSTRAINT [ApproverPrimary] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [ShemaTabel].[Approver]  WITH CHECK ADD  CONSTRAINT [ApproverTypeApproverForeign] FOREIGN KEY([idApproverType])
REFERENCES [ShemaTabel].[ApproverType] ([id])
GO

ALTER TABLE [ShemaTabel].[Approver] CHECK CONSTRAINT [ApproverTypeApproverForeign]
GO

ALTER TABLE [ShemaTabel].[Approver]  WITH CHECK ADD  CONSTRAINT [KadrovikFactStaffForeign] FOREIGN KEY([idFactStaff])
REFERENCES [dbo].[FactStaff] ([id])
GO

ALTER TABLE [ShemaTabel].[Approver] CHECK CONSTRAINT [KadrovikFactStaffForeign]
GO

ALTER TABLE [ShemaTabel].[Approver]  WITH CHECK ADD  CONSTRAINT [CheckApproverDateBegin] CHECK  (([DateBegin]<=[DateEnd] OR [DateEnd] IS NULL))
GO

ALTER TABLE [ShemaTabel].[Approver] CHECK CONSTRAINT [CheckApproverDateBegin]
GO



GO

CREATE TABLE [ShemaTabel].[RepeatRate](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[DaysRepeat] [int] NOT NULL,
 CONSTRAINT [RepeatRatePrimary] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY],
 CONSTRAINT [RepeatRateDaysRepeatUnique] UNIQUE NONCLUSTERED 
(
	[DaysRepeat] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]


GO

CREATE TABLE [ShemaTabel].[WorkShedule](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[NameShedule] [varchar](50) NOT NULL,
 CONSTRAINT [ShedulePrimary] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY],
 CONSTRAINT [SheduleNameSheduleUniqeu] UNIQUE NONCLUSTERED 
(
	[NameShedule] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]



GO

CREATE TABLE [ShemaTabel].[WorkSheduleEvent](
	[idEventSuperType] [int] NOT NULL,
	[KolHourMPS] [float] NOT NULL,
	[KolHourMNS] [float] NOT NULL,
	[KolHourGPS] [float] NOT NULL,
	[KolHourGNS] [float] NOT NULL,
	[idShedule] [int] NOT NULL,
	[idRepeatRate] [int] NOT NULL,
	[Data_Agr] [date] NULL,
 CONSTRAINT [ShemaTabelWorkSheduleEventPrimary] PRIMARY KEY CLUSTERED 
(
	[idEventSuperType] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [ShemaTabel].[WorkSheduleEvent]  WITH CHECK ADD  CONSTRAINT [WorkSheduleEventRepeatRateForeign] FOREIGN KEY([idRepeatRate])
REFERENCES [ShemaTabel].[RepeatRate] ([id])
GO

ALTER TABLE [ShemaTabel].[WorkSheduleEvent] CHECK CONSTRAINT [WorkSheduleEventRepeatRateForeign]
GO

ALTER TABLE [ShemaTabel].[WorkSheduleEvent]  WITH CHECK ADD  CONSTRAINT [WorkSheduleEventSheduleForeign] FOREIGN KEY([idShedule])
REFERENCES [ShemaTabel].[WorkShedule] ([id])
GO

ALTER TABLE [ShemaTabel].[WorkSheduleEvent] CHECK CONSTRAINT [WorkSheduleEventSheduleForeign]
GO

ALTER TABLE [ShemaTabel].[WorkSheduleEvent]  WITH CHECK ADD  CONSTRAINT [WorkSheduleEventSuperTypeEventForeign] FOREIGN KEY([idEventSuperType])
REFERENCES [ShemaTabel].[EventSuperType] ([id])
GO

ALTER TABLE [ShemaTabel].[WorkSheduleEvent] CHECK CONSTRAINT [WorkSheduleEventSuperTypeEventForeign]
GO



GO

CREATE TABLE [ShemaTabel].[EventSuperType](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[idDayStatus] [int] NOT NULL,
	[BeginDate] [date] NOT NULL,
	[EndDate] [date] NULL,
	[FirstEventDate] [datetime] NOT NULL,
	[ViewDay] [varchar](15) NOT NULL,
 CONSTRAINT [EventSuperTypePrimary] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

ALTER TABLE [ShemaTabel].[EventSuperType]  WITH CHECK ADD  CONSTRAINT [EventSuperTypeDayStatusForeign] FOREIGN KEY([idDayStatus])
REFERENCES [ShemaTabel].[DayStatus] ([id])
GO

ALTER TABLE [ShemaTabel].[EventSuperType] CHECK CONSTRAINT [EventSuperTypeDayStatusForeign]
GO

ALTER TABLE [ShemaTabel].[EventSuperType]  WITH CHECK ADD  CONSTRAINT [CheckEventSuperTypeDateBegin] CHECK  (([BeginDate]<=[EndDate] OR [EndDate] IS NULL))
GO

ALTER TABLE [ShemaTabel].[EventSuperType] CHECK CONSTRAINT [CheckEventSuperTypeDateBegin]
GO


GO

CREATE TABLE [ShemaTabel].[EmployeeEvent](
	[idEventSuperType] [int] NOT NULL,
	[idFactStaff] [int] NOT NULL,
 CONSTRAINT [ShemaTabelEmployeeEventPrimary] PRIMARY KEY CLUSTERED 
(
	[idEventSuperType] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [ShemaTabel].[EmployeeEvent]  WITH CHECK ADD  CONSTRAINT [EmployeeEventFactStaffForeign] FOREIGN KEY([idFactStaff])
REFERENCES [dbo].[FactStaff] ([id])
GO

ALTER TABLE [ShemaTabel].[EmployeeEvent] CHECK CONSTRAINT [EmployeeEventFactStaffForeign]
GO

ALTER TABLE [ShemaTabel].[EmployeeEvent]  WITH CHECK ADD  CONSTRAINT [EmployeeEventSuperTypeEventForeign] FOREIGN KEY([idEventSuperType])
REFERENCES [ShemaTabel].[EventSuperType] ([id])
GO

ALTER TABLE [ShemaTabel].[EmployeeEvent] CHECK CONSTRAINT [EmployeeEventSuperTypeEventForeign]
GO


GO

CREATE TABLE [ShemaTabel].[TimeSheet](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[idDepartment] [int] NOT NULL,
	[idCreater] [int] NOT NULL,
	[DateBeginPeriod] [date] NOT NULL,
	[DateEndPeriod] [date] NOT NULL,
	[DateComposition] [datetime] NOT NULL,
 CONSTRAINT [TablePrimary] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY],
 CONSTRAINT [DateAndDepartmentUnique] UNIQUE NONCLUSTERED 
(
	[idDepartment] ASC,
	[DateBeginPeriod] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [ShemaTabel].[TimeSheet]  WITH CHECK ADD  CONSTRAINT [TabelApproverForeign] FOREIGN KEY([idCreater])
REFERENCES [ShemaTabel].[Approver] ([id])
GO

ALTER TABLE [ShemaTabel].[TimeSheet] CHECK CONSTRAINT [TabelApproverForeign]
GO

ALTER TABLE [ShemaTabel].[TimeSheet]  WITH CHECK ADD  CONSTRAINT [TabelDepartmentForeign] FOREIGN KEY([idDepartment])
REFERENCES [dbo].[Department] ([id])
GO

ALTER TABLE [ShemaTabel].[TimeSheet] CHECK CONSTRAINT [TabelDepartmentForeign]
GO

ALTER TABLE [ShemaTabel].[TimeSheet]  WITH CHECK ADD  CONSTRAINT [CheckTabelDateBegin] CHECK  (([DateBeginPeriod]<=[DateEndPeriod]))
GO

ALTER TABLE [ShemaTabel].[TimeSheet] CHECK CONSTRAINT [CheckTabelDateBegin]
GO


GO

CREATE TABLE [ShemaTabel].[TimeSheetRecord](
	[IDTimeSheetRecord] [int] IDENTITY(1,1) NOT NULL,
	[RecordDate] [datetime] NOT NULL,
	[JobTimeCount] [float] NOT NULL,
	[idTimeSheet] [int] NOT NULL,
	[idDayStatus] [int] NOT NULL,
	[idFactStaff] [int] NOT NULL,
 CONSTRAINT [TimeSheetRecordTablePrimary] PRIMARY KEY CLUSTERED 
(
	[IDTimeSheetRecord] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY],
 CONSTRAINT [DateIDTabelIdFactStaffUnique] UNIQUE NONCLUSTERED 
(
	[RecordDate] ASC,
	[idTimeSheet] ASC,
	[idFactStaff] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [ShemaTabel].[TimeSheetRecord]  WITH CHECK ADD  CONSTRAINT [TimeSheetRecordTimeSheetForeign] FOREIGN KEY([idTimeSheet])
REFERENCES [ShemaTabel].[TimeSheet] ([id])
GO

ALTER TABLE [ShemaTabel].[TimeSheetRecord] CHECK CONSTRAINT [TimeSheetRecordTimeSheetForeign]
GO

ALTER TABLE [ShemaTabel].[TimeSheetRecord]  WITH CHECK ADD  CONSTRAINT [ZapisTabelDayStatusForeign] FOREIGN KEY([idDayStatus])
REFERENCES [ShemaTabel].[DayStatus] ([id])
GO

ALTER TABLE [ShemaTabel].[TimeSheetRecord] CHECK CONSTRAINT [ZapisTabelDayStatusForeign]
GO

ALTER TABLE [ShemaTabel].[TimeSheetRecord]  WITH CHECK ADD  CONSTRAINT [ZapisTabelFactStaffForeign] FOREIGN KEY([idFactStaff])
REFERENCES [dbo].[FactStaff] ([id])
GO

ALTER TABLE [ShemaTabel].[TimeSheetRecord] CHECK CONSTRAINT [ZapisTabelFactStaffForeign]
GO





GO
CREATE TABLE ShemaTabel.Exception --исключение
(id INT IDENTITY not null
CONSTRAINT ExceptionPrimary PRIMARY KEY,
ExceptionName VARCHAR(50) NOT NULL unique,
DateException Date not null,
idDayStatus INT not null,
idEventSuperType INT not null,
idPrikaz INT not null,
CONSTRAINT ExceptionDayStatusForeign FOREIGN KEY (idDayStatus)
            REFERENCES ShemaTabel.DayStatus, --внешний ключ
CONSTRAINT ExceptionSuperTypeEventForeign FOREIGN KEY (idEventSuperType)
            REFERENCES ShemaTabel.EventSuperType, --внешний ключ
CONSTRAINT ExceptionPrikazForeign FOREIGN KEY (idPrikaz)
            REFERENCES Prikaz --внешний ключ
);

GO

GO

CREATE TABLE [ShemaTabel].[TimeSheetApproval](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[idApprover] [int] NOT NULL,
	[idTimeSheet] [int] NOT NULL,
	[ApprovalDate] [datetime] NOT NULL,
	[Result] [bit] NOT NULL,
	[Comment] [varchar](1000) NULL,
 CONSTRAINT [PK_TimeSheetApproval] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

ALTER TABLE [ShemaTabel].[TimeSheetApproval]  WITH CHECK ADD  CONSTRAINT [FK_TimeSheetApproval_Approver] FOREIGN KEY([idApprover])
REFERENCES [ShemaTabel].[Approver] ([id])
GO

ALTER TABLE [ShemaTabel].[TimeSheetApproval] CHECK CONSTRAINT [FK_TimeSheetApproval_Approver]
GO

ALTER TABLE [ShemaTabel].[TimeSheetApproval]  WITH CHECK ADD  CONSTRAINT [FK_TimeSheetApproval_TimeSheet] FOREIGN KEY([idTimeSheet])
REFERENCES [ShemaTabel].[TimeSheet] ([id])
GO

ALTER TABLE [ShemaTabel].[TimeSheetApproval] CHECK CONSTRAINT [FK_TimeSheetApproval_TimeSheet]
GO








------------------------------------------
GO
ALTER TABLE PlanStaff
ADD IDShedule INT 
GO
ALTER TABLE PlanStaff  --добавим внешний ключ в таблицу план ставки
WITH NOCHECK
ADD CONSTRAINT PlanStaffWorkSheduleForeign
FOREIGN KEY (IDShedule) REFERENCES ShemaTabel.WorkShedule (id)
---------------------------------
-----------*** ЗАПОЛНЕНИЕ ТЕСТОВЫМИ ДАННЫМИ***----------------------------
---------------------------------------------------
/*INSERT INTO PrikazSuperType(PrikazSuperTypeName)
VALUES ('На сотрудника')
INSERT INTO PrikazSuperType(PrikazSuperTypeName)
VALUES ('На отдел')
INSERT INTO PrikazSuperType(PrikazSuperTypeName)
VALUES ('На университет')
---------------------------------------
INSERT INTO PrikazType(PrikazTypeName,idPrikazSuperType)
VALUES ('На ежегодный оплачиваемый отпуск',1)
INSERT INTO PrikazType(PrikazTypeName,idPrikazSuperType)
VALUES ('На учебный отпуск',1)
INSERT INTO PrikazType(PrikazTypeName,idPrikazSuperType)
VALUES ('На командировку',1)
INSERT INTO PrikazType(PrikazTypeName,idPrikazSuperType)
VALUES ('На отпуск без сохранения з/п',1)
INSERT INTO PrikazType(PrikazTypeName,idPrikazSuperType)
VALUES ('О переносе выходного дня',3)
-------------------------------------
INSERT INTO Prikaz(PrikazName,DateBegin,DatePrikaz,idPrikazType)
VALUES ('О переносе выходного дня 9 мая 2011','2011-05-09 00:00:00.000','2011-05-03 00:00:00.000',5)
INSERT INTO Prikaz(PrikazName,DateBegin,DatePrikaz,idPrikazType)
VALUES ('На направлении в командировку','2011-04-18 00:00:00.000','2011-04-10 00:00:00.000',3)
INSERT INTO Prikaz(PrikazName,DateBegin,DatePrikaz,idPrikazType)
VALUES ('О предоставлении учебного отпуска работнику','2011-03-09 00:00:00.000','2011-03-01 00:00:00.000',2)
--------------------------------------
INSERT INTO PKGroup(GroupNumber,GroupName)
VALUES (1,'высшая')
INSERT INTO PKGroup(GroupNumber,GroupName)
VALUES (2,'главная')
INSERT INTO PKGroup(GroupNumber,GroupName)
VALUES (5,'младшая')
------------------------------------
INSERT INTO PKCategory(idPKGroup,PKCategoryNumber)
VALUES (1,1)
INSERT INTO PKCategory(idPKGroup,PKCategoryNumber)
VALUES (3,2)
--------------------------------------
INSERT INTO Category(id, CategoryName, CategorySmallName ,OrderBy,IsPPS)
VALUES (1,'1я категория','1к',1,0)
INSERT INTO Category(id, CategoryName, CategorySmallName ,OrderBy,IsPPS)
VALUES (2,'2я категория','2к',2,1)
-----------------------------------
--------------------------------------
INSERT INTO EducDocumentType(DocTypeName)
VALUES ('Диплом о высшем профессиональном образовании')
INSERT INTO EducDocumentType(DocTypeName)
VALUES ('Диплом о высшем среднеспециальном образовании')
INSERT INTO EducDocumentType(DocTypeName)
VALUES ('Сертификат')
---------------------------------
INSERT INTO EducDocument(idEducDocType,DocSeries,DocNumber,DocDate)
VALUES (1,'A11',5367,'2002-01-06 00:00:00.000')
INSERT INTO EducDocument(idEducDocType,DocSeries,DocNumber,DocDate)
VALUES (1,'A13',5353,'2006-03-07 00:00:00.000')
INSERT INTO EducDocument(idEducDocType,DocSeries,DocNumber,DocDate)
VALUES (2,'C35',62752,'2007-09-08 00:00:00.000')
-------------------------------------
INSERT INTO BonusSuperType(BonusSuperTypeName)
VALUES ('По характеру работы')
INSERT INTO BonusSuperType(BonusSuperTypeName)
VALUES ('По условию труда')
---------------------------------------
INSERT INTO BonusMeasure(MeasureName,Sign)
VALUES ('процент','%')
INSERT INTO BonusMeasure(MeasureName,Sign)
VALUES ('доля','/')
INSERT INTO BonusMeasure(MeasureName,Sign)
VALUES ('сумма','руб')
--------------------------------------
INSERT INTO BonusType(BonusTypeName,BonusTypeShortName,idBonusSuperType,idBonusMeasure,HasEnvironmentBonus,IsStaffRateable)
VALUES ('за работу в выходные и праздничные','ВиП',1,3,0,1)
INSERT INTO BonusType(BonusTypeName,BonusTypeShortName,idBonusSuperType,idBonusMeasure,HasEnvironmentBonus,IsStaffRateable)
VALUES ('за многосменный режим','МР',2,1,1,1)
INSERT INTO BonusType(BonusTypeName,BonusTypeShortName,idBonusSuperType,idBonusMeasure,HasEnvironmentBonus,IsStaffRateable)
VALUES ('за работу в ночное время','НВ',2,1,1,0)
--------------------------------------
INSERT INTO PKCategorySalary(SalarySize,DateBegin,DateEnd,idPKCategory)
VALUES (1000,'2010-01-04 00:00:00.000',null,1)
INSERT INTO PKCategorySalary(SalarySize,DateBegin,DateEnd,idPKCategory)
VALUES (2000,'2009-07-12 00:00:00.000',null,1)
----------------------------------
INSERT INTO Degree(id, DegreeName,DegreeShortName,DegreeAbbrev,DegreeOrder)
VALUES (1,'доктор наук','доктор','ДН',1)
INSERT INTO Degree(id,DegreeName,DegreeShortName,DegreeAbbrev,DegreeOrder)
VALUES (2,'кандидат наук','кандидат','КН',2)
-----------------------------------
INSERT INTO DepartmentType(DepartmentTypeName)
VALUES ('отдел')
INSERT INTO DepartmentType(DepartmentTypeName)
VALUES ('служба')
------------------------------------
INSERT INTO GlobalPrikaz(PrikazName, DateBegin, PrikazNumber)
VALUES ('приказ', '2011-01-04 00:00:00.000',1)
INSERT INTO GlobalPrikaz(PrikazName, DateBegin, PrikazNumber)
VALUES ('положение', '2010-01-04 00:00:00.000',2)
-----------------------------------------
INSERT INTO Grazd(grazdName,KadrID)
VALUES ('российское',1)
INSERT INTO Grazd(grazdName,KadrID)
VALUES ('украинское',2)
INSERT INTO Grazd(grazdName,KadrID)
VALUES ('литовское',3)
------------------------------------------
INSERT INTO SemPol(sempolName,KadrID)
VALUES ('женат',1)
INSERT INTO SemPol(sempolName,KadrID)
VALUES ('не женат',1)
----------------------------------------
INSERT INTO ScienceType(ScienceTypeName,ScienceTypeAbbrev,ScienceTypeShortName)
VALUES ('математика','М','мат')
INSERT INTO ScienceType(ScienceTypeName,ScienceTypeAbbrev,ScienceTypeShortName)
VALUES ('архитектура','А','арх')
-------------------------------------
INSERT INTO Post(PostName,PostShortName,ManagerBit,idGlobalPrikaz,idPKCategory,idCategory)
VALUES ('ректор УГТУ','ректор',0,1,1,1)
INSERT INTO Post(PostName,PostShortName,ManagerBit,idGlobalPrikaz,idPKCategory,idCategory)
VALUES ('начальник','нач.',0,1,1,1)
INSERT INTO Post(PostName,PostShortName,ManagerBit,idGlobalPrikaz,idPKCategory,idCategory)
VALUES ('заместитель начальника','зам.нач.',1,1,1,1)
INSERT INTO Post(PostName,PostShortName,ManagerBit,idGlobalPrikaz,idPKCategory,idCategory)
VALUES ('техник','тех',1,1,1,2)
INSERT INTO Post(PostName,PostShortName,ManagerBit,idGlobalPrikaz,idPKCategory,idCategory)
VALUES ('старший преподаватель','ст.пр.',1,1,1,2)
INSERT INTO Post(PostName,PostShortName,ManagerBit,idGlobalPrikaz,idPKCategory,idCategory)
VALUES ('инженер','инж.',1,1,1,2)
-----------------------------------------
INSERT INTO Rank(RankName,KadrID,RankOrder)
VALUES ('первый',1,1)
INSERT INTO Rank(RankName,KadrID,RankOrder)
VALUES ('второй',2,1)
----------------------------------------
INSERT INTO WorkSuperType(WorkSuperTypeName,WorkSuperTypeShortName)
VALUES ('основная','осн')
INSERT INTO WorkSuperType(WorkSuperTypeName,WorkSuperTypeShortName)
VALUES ('совместительство','совм')
--------------------------------------
INSERT INTO WorkType(TypeWorkName,TypeWorkShortName,IsReplacement,IsMain,idWorkSuperType)
VALUES ('внешнее','внеш',1,0,2)
INSERT INTO WorkType(TypeWorkName,TypeWorkShortName,IsReplacement,IsMain,idWorkSuperType)
VALUES ('внутреннее','внутр',1,1,2)
---------------------------------------
INSERT INTO Department(DepartmentName,DepartmentSmallName,idDepartmentType,dateCreate,idBeginPrikaz)
VALUES ('Отдел маркетинга','ОМ',1,'2000-01-05 00:00:00.000',1)
INSERT INTO Department(DepartmentName,DepartmentSmallName,idDepartmentType,dateCreate,idBeginPrikaz)
VALUES ('Информационно-вычислительный центр','ИВЦ',1,'2000-01-05 00:00:00.000',1)
INSERT INTO Department(DepartmentName,DepartmentSmallName,idDepartmentType,dateCreate,idBeginPrikaz)
VALUES ('Международный отдел','МО',1,'2000-01-05 00:00:00.000',1)
INSERT INTO Department(DepartmentName,DepartmentSmallName,idDepartmentType,dateCreate,idBeginPrikaz)
VALUES ('Кафедра ИСТ','ИСТ',1,'2000-01-05 00:00:00.000',1)
--------------------------------------
INSERT INTO PlanStaff(StaffCount,idDepartment,idPost,idBeginPrikaz,DateBegin,IDShedule)
VALUES (3,4,4,1,'2009-01-05 00:00:00.000',1)
INSERT INTO PlanStaff(StaffCount,idDepartment,idPost,idBeginPrikaz,DateBegin,IDShedule)
VALUES (1,4,2,1,'2009-01-05 00:00:00.000',1)
INSERT INTO PlanStaff(StaffCount,idDepartment,idPost,idBeginPrikaz,DateBegin,IDShedule)
VALUES (2,5,4,1,'2009-01-05 00:00:00.000',1)
INSERT INTO PlanStaff(StaffCount,idDepartment,idPost,idBeginPrikaz,DateBegin,IDShedule)
VALUES (1,5,2,1,'2009-01-05 00:00:00.000',1)
INSERT INTO PlanStaff(StaffCount,idDepartment,idPost,idBeginPrikaz,DateBegin,IDShedule)
VALUES (3,7,5,1,'2009-01-05 00:00:00.000',2)
INSERT INTO PlanStaff(StaffCount,idDepartment,idPost,idBeginPrikaz,DateBegin,IDShedule)
VALUES (1,7,2,1,'2009-01-05 00:00:00.000',1)
INSERT INTO PlanStaff(StaffCount,idDepartment,idPost,idBeginPrikaz,DateBegin,IDShedule)
VALUES (3,6,6,1,'2009-01-05 00:00:00.000',2)-----------------------------------------------------
INSERT INTO PlanStaff(StaffCount,idDepartment,idPost,idBeginPrikaz,DateBegin,IDShedule)
VALUES (1,6,2,1,'2009-01-05 00:00:00.000',1)
-----------------------------
INSERT INTO FinancingSource(FinancingSourceName,OrderBy)
VALUES ('бюджет',1)
INSERT INTO FinancingSource(FinancingSourceName,OrderBy)
VALUES ('внебюджет',1)
------------------------------
INSERT INTO Bonus(BonusCount,DateBegin,idBonusType,idPrikaz,idEndPrikaz)
VALUES (300,'2009-01-05 00:00:00.000',1,1,1)
INSERT INTO Bonus(BonusCount,DateBegin,idBonusType,idPrikaz,idEndPrikaz)
VALUES (200,'2010-01-05 00:00:00.000',1,1,1)
---------------------------------
INSERT INTO BonusPost(idBonus,idPost)
VALUES (2,6)
INSERT INTO BonusPost(idBonus,idPost)
VALUES (1,3)
------------------------
INSERT INTO Employee(itab_n,FirstName,LastName,Otch,BirthDate,BirthPlace,SexBit,idGrazd,idSemPol,SeverKoeff,RayonKoeff,GUID)
VALUES (1002,'Иванов','Иван', 'Иванович', '1978-01-05 00:00:00.000','г.Ухта',0, 1, 1, 50,20,'6F9619FF-8B86-D011-B42D-00C04FC964FF')
INSERT INTO Employee(itab_n,FirstName,LastName,Otch,BirthDate,BirthPlace,SexBit,idGrazd,idSemPol,SeverKoeff,RayonKoeff,GUID)
VALUES (1003,'Петров','Петр', 'Петрович', '1973-01-05 00:00:00.000','г.Ухта',0, 1, 1, 50,20,'6F9619FF-8B86-D014-B48D-00C04FC933FF')
INSERT INTO Employee(itab_n,FirstName,LastName,Otch,BirthDate,BirthPlace,SexBit,idGrazd,idSemPol,SeverKoeff,RayonKoeff,GUID)
VALUES (1004,'Сидорова','Елизавета', 'Павловна', '1981-09-03 00:00:00.000','г.Ухта',1, 1, 2, 30,20,'6F9619FF-8C65-E011-B48D-00A14FC542EF')
INSERT INTO Employee(itab_n,FirstName,LastName,Otch,BirthDate,BirthPlace,SexBit,idGrazd,idSemPol,SeverKoeff,RayonKoeff,GUID)
VALUES (1005,'Пупкина','Мария', 'Эдуардовна', '1985-11-16 00:00:00.000','г.Сыктывкар',1, 1, 1, 50,20,'3F9789FF-2E61-E514-C48A-00B14FC748EC')
INSERT INTO Employee(itab_n,FirstName,LastName,Otch,BirthDate,BirthPlace,SexBit,idGrazd,idSemPol,SeverKoeff,RayonKoeff,GUID)
VALUES (1006,'Глушко','Анатолий', 'Фомич', '1974-02-28 00:00:00.000','г.Киев',0, 2, 1, 20,20,'4B9386FF-6B61-E514-B48B-00B14BC849EA')
INSERT INTO Employee(itab_n,FirstName,LastName,Otch,BirthDate,BirthPlace,SexBit,idGrazd,idSemPol,SeverKoeff,RayonKoeff,GUID)
VALUES (1007,'Невский','Александр', 'Ярославич', '1985-11-14 00:00:00.000','г.Киев',0, 2, 1, 20,20,'4B8886FF-6B61-E514-B88B-00B14FC888EC')
INSERT INTO Employee(itab_n,FirstName,LastName,Otch,BirthDate,BirthPlace,SexBit,idGrazd,idSemPol,SeverKoeff,RayonKoeff,GUID)
VALUES (1008,'Васильева','Валерия', 'Викторовна', '1973-01-15 00:00:00.000','г.Ухта',1, 1, 1, 50,20,'6F9292FF-8B81-D014-B48D-18C04FC673FF')
INSERT INTO Employee(itab_n,FirstName,LastName,Otch,BirthDate,BirthPlace,SexBit,idGrazd,idSemPol,SeverKoeff,RayonKoeff,GUID)
VALUES (1009, 'Верховенский','Степан','Трофимович', '1988-06-13 00:00:00.000','г.Ухта',0, 1, 1, 50,20,'6F8339FF-6B86-D893-B48D-00C04FC933FF')
INSERT INTO Employee(itab_n,FirstName,LastName,Otch,BirthDate,BirthPlace,SexBit,idGrazd,idSemPol,SeverKoeff,RayonKoeff,GUID)
VALUES (1010,'Карамазов','Дмитрий', 'Петрович', '1982-01-05 00:00:00.000','г.Ухта',0, 1, 1, 50,20,'6F9000FF-8B86-D000-B48D-00C04FC000FF')
INSERT INTO Employee(itab_n,FirstName,LastName,Otch,BirthDate,BirthPlace,SexBit,idGrazd,idSemPol,SeverKoeff,RayonKoeff,GUID)
VALUES (1011,'Штерн','Юлия', 'Михайловна', '1989-07-27 00:00:00.000','г.Ухта',1, 1, 1, 50,20,'6F9444FF-4B86-D440-B44D-00C04FC000FF')
INSERT INTO Employee(itab_n,FirstName,LastName,Otch,BirthDate,BirthPlace,SexBit,idGrazd,idSemPol,SeverKoeff,RayonKoeff,GUID)
VALUES (1012,'Москвин','Емельян', 'Борисович', '1979-01-18 00:00:00.000','г.Ухта',0, 1, 1, 50,20,'6F9565FF-8B86-D098-B48D-00C04FC989FF')
---------------------------------------------------
---------------------------------------------------
INSERT INTO BonusEmployee(idBonus,idEmployee)
VALUES (2,3)
INSERT INTO BonusEmployee(idBonus,idEmployee)
VALUES (1,6)
----------------------------------------
INSERT INTO EmployeeDegree(idEducDocument,degreeDate,DissertCouncil,diplWhere,idDegree,idScienceType,idEmployee)
VALUES (1,'2001-04-17 00:00:00.000','Иванов К.И.,Плеханов П.В','МГУ им.Ломоносова',1,1,6)
INSERT INTO EmployeeDegree(idEducDocument,degreeDate,DissertCouncil,diplWhere,idDegree,idScienceType,idEmployee)
VALUES (2,'2008-09-12 00:00:00.000','Волошин И.М.,Коробейнокова К.В','СыктГУ',2,2,7)
-----------------------------------------
---------------------------------------------------------------------------------------   -----
INSERT INTO EmployeeRank(idEducDocument,idEmployee,idRank,rankWhere)
VALUES (1,6,1,'УГТУ')
INSERT INTO EmployeeRank(idEducDocument,idEmployee,idRank,rankWhere)
VALUES (2,7,2,'УГТУ')
-------------------------------------------
INSERT INTO OKBufferEmployeeDegree(itab_n,degreeDate,DissertCouncil,dokSer,dokNum,diplDate,diplWhere,idDegree,idScienceType)
VALUES (1003,'2001-04-17 00:00:00.000','Иванов К.И.,Плеханов П.В','A11','5367','1998-07-28 00:00:00.000','МГУ им.Ломоносова',1,1)
--------------------------------------------
INSERT INTO OKBufferEmployeeRank(idRank,dokSer,dokNum,rankDate,rankWhere,itab_n)
VALUES (1,'A11','5367','2010-03-05 00:00:00.000','УГТУ',1003)
INSERT INTO OKBufferEmployeeRank(idRank,dokSer,dokNum,rankDate,rankWhere,itab_n)
VALUES (1,'A13','5353','2008-07-05 00:00:00.000','УГТУ',1004)
--------------------------------------------
INSERT INTO PlanStaffSalary(SalarySize,DateBegin,idPlanStaff)
VALUES (400,'2008-07-05 00:00:00.000',6)
INSERT INTO PlanStaffSalary(SalarySize,DateBegin,idPlanStaff)
VALUES (500,'2008-07-05 00:00:00.000',10)
INSERT INTO PlanStaffSalary(SalarySize,DateBegin,idPlanStaff)
VALUES (600,'2008-07-05 00:00:00.000',12)
-------------------------------------------
INSERT INTO TimeSheet(TimeSheetMonth,TimeSheetYear,TimeSheetAllDayCount,TimeSheetWorkingDayCount,IsClosed,IsFilled)
VALUES (02,2011,28,19,1,0)
INSERT INTO TimeSheet(TimeSheetMonth,TimeSheetYear,TimeSheetAllDayCount,TimeSheetWorkingDayCount,IsClosed,IsFilled)
VALUES (03,2011,31,22,1,0)
-----------------------------------------
INSERT INTO TimeSheetScheduleType(ScheduleTypeName)
VALUES ('5дневка')
INSERT INTO TimeSheetScheduleType(ScheduleTypeName)
VALUES ('6дневка')
----------------------------
INSERT INTO FactStaff(idEmployee,idTypeWork,idBeginPrikaz,StaffCount,DateBegin,IsReplacement,idPlanStaff)
VALUES (1,1,1,1,'2008-06-05 00:00:00.000',1,6)
INSERT INTO FactStaff(idEmployee,idTypeWork,idBeginPrikaz,StaffCount,DateBegin,IsReplacement,idPlanStaff)
VALUES (7,1,1,1,'2008-06-05 00:00:00.000',1,8)
INSERT INTO FactStaff(idEmployee,idTypeWork,idBeginPrikaz,StaffCount,DateBegin,IsReplacement,idPlanStaff)
VALUES (6,1,1,0.5,'2008-06-05 00:00:00.000',1,10)
INSERT INTO FactStaff(idEmployee,idTypeWork,idBeginPrikaz,StaffCount,DateBegin,IsReplacement,idPlanStaff)
VALUES (9,1,1,1,'2008-06-05 00:00:00.000',1,15)

INSERT INTO FactStaff(idEmployee,idTypeWork,idBeginPrikaz,StaffCount,DateBegin,IsReplacement,idPlanStaff)
VALUES (10,1,1,1,'2008-06-05 00:00:00.000',1,14)
INSERT INTO FactStaff(idEmployee,idTypeWork,idBeginPrikaz,StaffCount,DateBegin,IsReplacement,idPlanStaff)
VALUES (2,1,1,1,'2008-06-05 00:00:00.000',1,13)
INSERT INTO FactStaff(idEmployee,idTypeWork,idBeginPrikaz,StaffCount,DateBegin,IsReplacement,idPlanStaff)
VALUES (3,1,1,1,'2008-06-05 00:00:00.000',1,11)
INSERT INTO FactStaff(idEmployee,idTypeWork,idBeginPrikaz,StaffCount,DateBegin,IsReplacement,idPlanStaff)
VALUES (4,1,1,1,'2008-06-05 00:00:00.000',1,12)
INSERT INTO FactStaff(idEmployee,idTypeWork,idBeginPrikaz,StaffCount,DateBegin,IsReplacement,idPlanStaff)
VALUES (5,1,1,1,'2008-06-05 00:00:00.000',1,12)
INSERT INTO FactStaff(idEmployee,idTypeWork,idBeginPrikaz,StaffCount,DateBegin,IsReplacement,idPlanStaff)
VALUES (11,1,1,1,'2008-06-05 00:00:00.000',1,14)
INSERT INTO FactStaff(idEmployee,idTypeWork,idBeginPrikaz,StaffCount,DateBegin,IsReplacement,idPlanStaff)
VALUES (12,1,1,1,'2008-06-05 00:00:00.000',1,13)
*/
----------Заполнение справочника статус дня-------------
GO
EXEC AddDayStatus  'Б'
GO
EXEC AddDayStatus  'Я'
GO
EXEC AddDayStatus  'Н'
GO
EXEC AddDayStatus  'РП'
GO
EXEC AddDayStatus  'С'
GO
EXEC AddDayStatus  'К'
GO
EXEC AddDayStatus  'ОТ'
GO
EXEC AddDayStatus  'ОД'
GO
EXEC AddDayStatus  'У'
GO
EXEC AddDayStatus  'Р'
GO
EXEC AddDayStatus  'ОЖ'
GO
EXEC AddDayStatus  'ДО'
GO
EXEC AddDayStatus  'ОЗ'
GO
EXEC AddDayStatus  'В'
GO
EXEC AddDayStatus  'ПР'
-----------Заполнение справочника Частота повторений---------
GO
EXEC AddRepeatRate  '7'
GO
EXEC AddRepeatRate '14'  
-----------Заполнение справочника Режим работы---------------
GO
EXEC AddWorkShedule 'Пятидневная рабочая неделя'
GO
EXEC AddWorkShedule 'Шестидневная рабочая неделя' 
-----------Заполнение справочника Тип составителя --------------
GO
EXEC AddSostavitelType 'Табельщик'
GO
EXEC AddSostavitelType 'Начальник СП'
GO
EXEC AddSostavitelType 'Кадровый работник'
-----------Заполнение событий и событий графика работы
--пон
INSERT INTO ShemaTabel.SuperTypeEvent(IDDayStatus,
FirstEventDate,ViewDay)
VALUES (1,'2011-05-02 00:00:00.000','Раб')
--втор
INSERT INTO ShemaTabel.SuperTypeEvent(IDDayStatus,
FirstEventDate,ViewDay)
VALUES (1,'2011-05-03 00:00:00.000','Раб')
--сред
INSERT INTO ShemaTabel.SuperTypeEvent(IDDayStatus,
FirstEventDate,ViewDay)
VALUES (1,'2011-05-04 00:00:00.000','Раб')
--четв
INSERT INTO ShemaTabel.SuperTypeEvent(IDDayStatus,
FirstEventDate,ViewDay)
VALUES (1,'2011-05-05 00:00:00.000','Раб')
--пятн
INSERT INTO ShemaTabel.SuperTypeEvent(IDDayStatus,
FirstEventDate,ViewDay)
VALUES (1,'2011-05-06 00:00:00.000','Раб')
--суб
INSERT INTO ShemaTabel.SuperTypeEvent(IDDayStatus,
FirstEventDate,ViewDay)
VALUES (2,'2011-05-07 00:00:00.000','Вых')
--воск
INSERT INTO ShemaTabel.SuperTypeEvent(IDDayStatus,
FirstEventDate,ViewDay)
VALUES (2,'2011-05-08 00:00:00.000','Вых')
----шестидн--
--пон 6дн
INSERT INTO ShemaTabel.SuperTypeEvent(IDDayStatus,
FirstEventDate,ViewDay)
VALUES (1,'2011-05-02 00:00:00.000','Раб')
--втор 6дн
INSERT INTO ShemaTabel.SuperTypeEvent(IDDayStatus,
FirstEventDate,ViewDay)
VALUES (1,'2011-05-03 00:00:00.000','Раб')
---сред 6дн
INSERT INTO ShemaTabel.SuperTypeEvent(IDDayStatus,
FirstEventDate,ViewDay)
VALUES (1,'2011-05-04 00:00:00.000','Раб')
--четв 6дн
INSERT INTO ShemaTabel.SuperTypeEvent(IDDayStatus,
FirstEventDate,ViewDay)
VALUES (1,'2011-05-05 00:00:00.000','Раб')
--птн 6дн
INSERT INTO ShemaTabel.SuperTypeEvent(IDDayStatus,
FirstEventDate,ViewDay)
VALUES (1,'2011-05-06 00:00:00.000','Раб')
--суб 6дн
INSERT INTO ShemaTabel.SuperTypeEvent(IDDayStatus,
FirstEventDate,ViewDay)
VALUES (1,'2011-05-07 00:00:00.000','Раб')
---воск 6дн
INSERT INTO ShemaTabel.SuperTypeEvent(IDDayStatus,
FirstEventDate,ViewDay)
VALUES (2,'2011-05-08 00:00:00.000','Вых')


----***ДЛЯ ПЯТИДНЕВКИ СОБЫТИЯ ГРАФИКА НА НЕДЕЛЮ **----
---понедельник----
INSERT INTO ShemaTabel.WorkSheduleEvent(IDShedule,
IDSuperTypeEvent,KolHourGNS,KolHourGPS,KolHourMNS,
KolHourMPS,IDRepeatRate)
VALUES (1,1,7.2,7.5,8,8,1)
---вторник--
INSERT INTO ShemaTabel.WorkSheduleEvent(IDShedule,
IDSuperTypeEvent,KolHourGNS,KolHourGPS,KolHourMNS,
KolHourMPS,IDRepeatRate)
VALUES (1,2,7.2,7.5,8,8,1)
---среда-------
INSERT INTO ShemaTabel.WorkSheduleEvent(IDShedule,
IDSuperTypeEvent,KolHourGNS,KolHourGPS,KolHourMNS,
KolHourMPS,IDRepeatRate)
VALUES (1,3,7.2,7.5,8,8,1)
---четверг----
INSERT INTO ShemaTabel.WorkSheduleEvent(IDShedule,
IDSuperTypeEvent,KolHourGNS,KolHourGPS,KolHourMNS,
KolHourMPS,IDRepeatRate)
VALUES (1,4,7.2,7.5,8,8,1)
---пятница----
INSERT INTO ShemaTabel.WorkSheduleEvent(IDShedule,
IDSuperTypeEvent,KolHourGNS,KolHourGPS,KolHourMNS,
KolHourMPS,IDRepeatRate)
VALUES (1,5,7.2,6,8,8,1)
---суббота----
INSERT INTO ShemaTabel.WorkSheduleEvent(IDShedule,
IDSuperTypeEvent,KolHourGNS,KolHourGPS,KolHourMNS,
KolHourMPS,IDRepeatRate)
VALUES (1,6,0,0,0,0,1)
---восскресенье---
INSERT INTO ShemaTabel.WorkSheduleEvent(IDShedule,
IDSuperTypeEvent,KolHourGNS,KolHourGPS,KolHourMNS,
KolHourMPS,IDRepeatRate)
VALUES (1,7,0,0,0,0,1)

----***ДЛЯ ШЕСТИДНЕВКИ СОБЫТИЯ ГРАФИКА НА НЕДЕЛЮ **----
---примечание! для всех (м и ж) ППС = ЖПС
---понедельник-----
INSERT INTO ShemaTabel.WorkSheduleEvent(IDShedule,
IDSuperTypeEvent,KolHourGNS,KolHourGPS,KolHourMNS,
KolHourMPS,IDRepeatRate)
VALUES (2,8,6,6.2,6.6,7,1)
---вторник---
INSERT INTO ShemaTabel.WorkSheduleEvent(IDShedule,
IDSuperTypeEvent,KolHourGNS,KolHourGPS,KolHourMNS,
KolHourMPS,IDRepeatRate)
VALUES (2,9,6,6.2,6.6,7,1)
---среда---
INSERT INTO ShemaTabel.WorkSheduleEvent(IDShedule,
IDSuperTypeEvent,KolHourGNS,KolHourGPS,KolHourMNS,
KolHourMPS,IDRepeatRate)
VALUES (2,10,6,6.2,6.6,7,1)
---четверг---
INSERT INTO ShemaTabel.WorkSheduleEvent(IDShedule,
IDSuperTypeEvent,KolHourGNS,KolHourGPS,KolHourMNS,
KolHourMPS,IDRepeatRate)
VALUES (2,11,6,6.2,6.6,7,1)
---пятница---
INSERT INTO ShemaTabel.WorkSheduleEvent(IDShedule,
IDSuperTypeEvent,KolHourGNS,KolHourGPS,KolHourMNS,
KolHourMPS,IDRepeatRate)
VALUES (2,12,6,6.2,6.6,7,1)
---суббота---
INSERT INTO ShemaTabel.WorkSheduleEvent(IDShedule,
IDSuperTypeEvent,KolHourGNS,KolHourGPS,KolHourMNS,
KolHourMPS,IDRepeatRate)
VALUES (2,13,6,5,6.6,5,1)
---воскресенье---
INSERT INTO ShemaTabel.WorkSheduleEvent(IDShedule,
IDSuperTypeEvent,KolHourGNS,KolHourGPS,KolHourMNS,
KolHourMPS,IDRepeatRate)
VALUES (2,14,0,0,0,0,1)
------------------------------------
/*Нерабочими праздничными днями в Российской Федерации являются:
1, 2, 3, 4 и 5 января - Новогодние каникулы;
7 января - Рождество Христово;
23 февраля - День защитника Отечества;
8 марта - Международный женский день;
1 мая - Праздник Весны и Труда;
9 мая - День Победы;
12 июня - День России;
4 ноября - День народного единства.
(часть первая в ред. Федерального закона от 29.12.2004 N 201-ФЗ)
При совпадении выходного и нерабочего праздничного дней выходной день переносится на следующий после праздничного рабочий день.
*/
-----------
INSERT INTO ShemaTabel.SuperTypeEvent(IDDayStatus,FirstEventDate,ViewDay)
VALUES (2,'2009-03-08 00:00:00.000','Вых')--8 марта
INSERT INTO ShemaTabel.SuperTypeEvent(IDDayStatus,FirstEventDate,ViewDay)
VALUES (2,'2009-01-01 00:00:00.000','Вых') --новогодние каникулы
INSERT INTO ShemaTabel.SuperTypeEvent(IDDayStatus,FirstEventDate,ViewDay)
VALUES (2,'2009-01-02 00:00:00.000','Вых')--новогодние каникулы
INSERT INTO ShemaTabel.SuperTypeEvent(IDDayStatus,FirstEventDate,ViewDay)
VALUES (2,'2009-01-03 00:00:00.000','Вых')--новогодние каникулы
INSERT INTO ShemaTabel.SuperTypeEvent(IDDayStatus,FirstEventDate,ViewDay)
VALUES (2,'2009-01-04 00:00:00.000','Вых')--новогодние каникулы
INSERT INTO ShemaTabel.SuperTypeEvent(IDDayStatus,FirstEventDate,ViewDay)
VALUES (2,'2009-01-05 00:00:00.000','Вых')--новогодние каникулы
INSERT INTO ShemaTabel.SuperTypeEvent(IDDayStatus,FirstEventDate,ViewDay)
VALUES (2,'2009-01-07 00:00:00.000','Вых')--рождество
INSERT INTO ShemaTabel.SuperTypeEvent(IDDayStatus,FirstEventDate,ViewDay)
VALUES (2,'2009-02-23 00:00:00.000','Вых')--23 февраля
INSERT INTO ShemaTabel.SuperTypeEvent(IDDayStatus,FirstEventDate,ViewDay)
VALUES (2,'2009-05-01 00:00:00.000','Вых')--праздник весны и труда
INSERT INTO ShemaTabel.SuperTypeEvent(IDDayStatus,FirstEventDate,ViewDay)
VALUES (2,'2009-05-09 00:00:00.000','Вых')--день победы
INSERT INTO ShemaTabel.SuperTypeEvent(IDDayStatus,FirstEventDate,ViewDay)
VALUES (2,'2009-06-12 00:00:00.000','Вых')--день россии
INSERT INTO ShemaTabel.SuperTypeEvent(IDDayStatus,FirstEventDate,ViewDay)
VALUES (2,'2009-11-04 00:00:00.000','Вых')--день народного единства
-----------
INSERT INTO ShemaTabel.Exception(NameException,DateException,IDDayStatus,IDSuperTypeEvent,idPrikaz)
VALUES ('8 марта','2009-03-08',2,15,1)
INSERT INTO ShemaTabel.Exception(NameException,DateException,IDDayStatus,IDSuperTypeEvent,idPrikaz)
VALUES ('новогодние каникулы','2009-01-01',2,16,1)
INSERT INTO ShemaTabel.Exception(NameException,DateException,IDDayStatus,IDSuperTypeEvent,idPrikaz)
VALUES ('новогодние каникулы','2009-01-02',2,17,1)
INSERT INTO ShemaTabel.Exception(NameException,DateException,IDDayStatus,IDSuperTypeEvent,idPrikaz)
VALUES ('новогодние каникулы','2009-01-03',2,18,1)
INSERT INTO ShemaTabel.Exception(NameException,DateException,IDDayStatus,IDSuperTypeEvent,idPrikaz)
VALUES ('новогодние каникулы','2009-01-04',2,19,1)
INSERT INTO ShemaTabel.Exception(NameException,DateException,IDDayStatus,IDSuperTypeEvent,idPrikaz)
VALUES ('новогодние каникулы','2009-01-05',2,20,1)
INSERT INTO ShemaTabel.Exception(NameException,DateException,IDDayStatus,IDSuperTypeEvent,idPrikaz)
VALUES ('рождество','2009-01-07',2,21,1)
INSERT INTO ShemaTabel.Exception(NameException,DateException,IDDayStatus,IDSuperTypeEvent,idPrikaz)
VALUES ('день защитника отечества','2009-02-23',2,22,1)
INSERT INTO ShemaTabel.Exception(NameException,DateException,IDDayStatus,IDSuperTypeEvent,idPrikaz)
VALUES ('праздник весны и труда','2009-05-01',2,23,1)
INSERT INTO ShemaTabel.Exception(NameException,DateException,IDDayStatus,IDSuperTypeEvent,idPrikaz)
VALUES ('день победы','2009-05-09',2,24,1)
INSERT INTO ShemaTabel.Exception(NameException,DateException,IDDayStatus,IDSuperTypeEvent,idPrikaz)
VALUES ('день России','2009-06-12',2,25,1)
INSERT INTO ShemaTabel.Exception(NameException,DateException,IDDayStatus,IDSuperTypeEvent,idPrikaz)
VALUES ('день народного единства','2009-11-04',2,26,1)
-----------Заполнение Согласователя
go
EXEC AddSostavitel '2010-02-08 00:00:00.000',null,0,9,2 ---кадровик
go
EXEC AddSostavitel '2010-02-08 00:00:00.000',null,0,7,2 -----табельщик 7 отдела
go
EXEC AddSostavitel '2010-02-08 00:00:00.000',null,0,8,2 -----табельщик 5 отдела
go
EXEC AddSostavitel '2010-02-08 00:00:00.000',null,0,10,2 -----табельщик 6 отдела
go
EXEC AddSostavitel '2010-02-08 00:00:00.000',null,0,11,2 -----табельщик 4 отдела
go
EXEC AddSostavitel '2010-02-08 00:00:00.000',null,0,3,2 -----начальник 7 отдела
go
EXEC AddSostavitel '2010-02-08 00:00:00.000',null,0,2,2 -----начальник 5 отдела
go
EXEC AddSostavitel '2010-02-08 00:00:00.000',null,0,4,2 -----начальник 6 отдела
go
EXEC AddSostavitel '2010-02-08 00:00:00.000',null,0,1,2 -----начальник 4 отдела
-------------------***
------------ *** ИНДЕКСЫ *** ---------------------
go
create nonclustered index NindexAssertTabelSostavitel
ON ShemaTabel.AssertTabel (IDSostavitel ASC)
go
create nonclustered index NindexAssertTabelTabel
ON ShemaTabel.AssertTabel (IDTabel ASC)
------------------------------------------------
go
create nonclustered index NindexEmployeeEventFactStaff
ON ShemaTabel.EmployeeEvent (IDFactStaff ASC)
go
create nonclustered index NindexEmployeeEventSuperTypeEvent
ON ShemaTabel.EmployeeEvent (IDSuperTypeEvent ASC)
------------------------------------------------
go
create nonclustered index NindexExceptionDayStatus
ON ShemaTabel.Exception (IDDayStatus ASC)
go
create nonclustered index NindexExceptionSuperTypeEvent
ON ShemaTabel.Exception (IDSuperTypeEvent ASC)
go
create nonclustered index NindexExceptionPrikaz
ON ShemaTabel.Exception (IDPrikaz ASC)
-----------------------------------------------
go
create nonclustered index NindexSostavitelFactStaff
ON ShemaTabel.Sostavitel (IDFactStaff ASC)
go
create nonclustered index NindexSostavitelSostavitelType
ON ShemaTabel.Sostavitel (IDSostavitelType ASC)
-----------------------------------------------
go
create nonclustered index NindexSuperTypeEventDayStatus
ON ShemaTabel.SuperTypeEvent (IDDayStatus ASC)
----------------------------------------------
go
create nonclustered index NindexTabelDepartment
ON ShemaTabel.Tabel (IDDepartment ASC)
go
create nonclustered index NindexTabelSostavitel
ON ShemaTabel.Tabel (IDSostavitel ASC)
-----------------------------------------------
go
create nonclustered index NindexWorkSheduleEventSuperTypeEvent
ON ShemaTabel.WorkSheduleEvent (IDSuperTypeEvent ASC)
go
create nonclustered index NindexWorkSheduleEventRepeatRate
ON ShemaTabel.WorkSheduleEvent (IDRepeatRate ASC)
go
create nonclustered index NindexWorkSheduleEventShedule
ON ShemaTabel.WorkSheduleEvent (IDShedule ASC)
------------------------------------------------
go
create nonclustered index NindexZapisTabelTabel
ON ShemaTabel.ZapisTabel(IDTabel ASC)
go
create nonclustered index NindexZapisTabelFactStaff
ON ShemaTabel.ZapisTabel(IDFactStaff ASC)