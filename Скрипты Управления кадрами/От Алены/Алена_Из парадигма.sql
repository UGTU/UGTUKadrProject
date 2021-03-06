--CREATE TABLE LanguageLevel (ID int IDENTITY NOT NULL, Name varchar(255) NOT NULL UNIQUE, PRIMARY KEY (ID));
--CREATE TABLE MilitaryRecord (ID int IDENTITY NOT NULL, VUS int NOT NULL, Comissariat varchar(255) NOT NULL, Otmetka bit NOT NULL, [ID MilitaryProfile] int NOT NULL, [ID MilitaryRank] int NOT NULL, [ID ReservCathegory] int NOT NULL, [ID MilitaryVal] int NOT NULL, [ID TypeMilitaryRecord] int NOT NULL, PRIMARY KEY (ID));
--CREATE TABLE ReservCathegory (ID int IDENTITY NOT NULL, ReservCat varchar(255) NOT NULL UNIQUE, PRIMARY KEY (ID));
--CREATE TABLE MilitaryProfile (ID int IDENTITY NOT NULL, MilitaryProf varchar(255) NOT NULL UNIQUE, PRIMARY KEY (ID));
--CREATE TABLE MilitaryVal (ID int IDENTITY NOT NULL, MilitaryVal varchar(255) NOT NULL UNIQUE, PRIMARY KEY (ID));
--CREATE TABLE MilitaryRank (ID int IDENTITY NOT NULL, MilitaryRank varchar(255) NOT NULL UNIQUE, PRIMARY KEY (ID));
--CREATE TABLE TypeMilitaryRecord (ID int IDENTITY NOT NULL, TypeMilitaryRec varchar(255) NOT NULL UNIQUE, PRIMARY KEY (ID));
--CREATE TABLE EmploymentHistory (ID int IDENTITY NOT NULL, Number varchar(255) NOT NULL, Seria varchar(255) NOT NULL, DateIs date NOT NULL, PRIMARY KEY (ID));
--CREATE TABLE Standing (ID int IDENTITY NOT NULL, DateBegSt date NOT NULL, DateEndSt date NOT NULL, WorkPlace varchar(max) NULL, Post varchar(255) NULL, [ID TypeRegion] int NOT NULL, [ID TypeStanding] int NOT NULL, [ID EmploymentHistory] int NOT NULL, PRIMARY KEY (ID));
--CREATE TABLE TypeStanding (ID int IDENTITY NOT NULL, NameTypeStanding varchar(255) NOT NULL UNIQUE, PRIMARY KEY (ID));
--CREATE TABLE TypeRegion (ID int IDENTITY NOT NULL, NameRegion varchar(255) NOT NULL UNIQUE, PRIMARY KEY (ID));
--CREATE TABLE ConfirmDoc (ID int NOT NULL, [ID VidConfirmDoc] int NOT NULL, Seria varchar(10) NULL, Number int NULL, FactStaffid int NULL, IssuedDate date NULL, idEmployee int NULL, PRIMARY KEY (ID));
--CREATE TABLE VidConfirmDoc (ID int IDENTITY NOT NULL, NameVidConfirmDoc varchar(max) NOT NULL, [ID TypeConfirmDoc] int NOT NULL, PRIMARY KEY (ID));
--CREATE TABLE TypeConfirmDoc (ID int IDENTITY NOT NULL, NameTypeConfirmDoc varchar(255) NOT NULL UNIQUE, PRIMARY KEY (ID));
--CREATE TABLE ProfTraining (ID int NOT NULL, NameEducAgency varchar(max) NOT NULL, [ID Specialty] int NULL, [ID TypeProfTraining] int NULL, [ID FactStaff_Prikaz] int NULL, PRIMARY KEY (ID));
--CREATE TABLE Specialty (ID int IDENTITY NOT NULL, NameSpecilaty varchar(max) NOT NULL, PRIMARY KEY (ID));
--CREATE TABLE TypeProfTraining (ID int IDENTITY NOT NULL, NameTypeProfTraining varchar(max) NOT NULL , PRIMARY KEY (ID));
--CREATE TABLE Validation (ID int NOT NULL, Resolution varchar(max) NOT NULL, [ID FactStaff_Prikaz] int NULL, PRIMARY KEY (ID));
--CREATE TABLE BusinessMission (ID int IDENTITY NOT NULL, [ID FactStaff_Prikaz] int NULL, PRIMARY KEY (ID));
--CREATE TABLE PlaceMission ([ID TypeRegion] int NOT NULL, [ID BusinessMission] int NOT NULL, DayMission int NOT NULL, DayTravel int NOT NULL, PRIMARY KEY ([ID TypeRegion], [ID BusinessMission]));
--CREATE TABLE Honor (ID int NOT NULL, [ID NameHonor] int NOT NULL, [ID FactStaff_Prikaz] int NULL, PRIMARY KEY (ID));
--CREATE TABLE NameHonor (ID int IDENTITY NOT NULL, NameHonor varchar(255) NOT NULL , PRIMARY KEY (ID));
--CREATE TABLE MaterialResp (ID int IDENTITY NOT NULL, PaymentMat money NOT NULL, [ID FactStaff_Prikaz] int NULL, PRIMARY KEY (ID));
--CREATE TABLE SocialFare (ID int IDENTITY NOT NULL, DateBeg date NOT NULL, DateEnd date NOT NULL, idEmployee int NOT NULL, PRIMARY KEY (ID));
--CREATE TABLE FactStaff_Prikaz (ID int IDENTITY NOT NULL, Prikazid int NOT NULL, DateBeg date NULL, DateEnd date NULL, [ID FactStaff_Prikaz] int NOT NULL, FactStaffid int NOT NULL, PRIMARY KEY (ID));

--ALTER TABLE MilitaryRecord ADD CONSTRAINT FK_MilitaryProfile FOREIGN KEY ([ID MilitaryProfile]) REFERENCES MilitaryProfile (ID);
--ALTER TABLE MilitaryRecord ADD CONSTRAINT FK_MilitaryRank FOREIGN KEY ([ID MilitaryRank]) REFERENCES MilitaryRank (ID);
--ALTER TABLE MilitaryRecord ADD CONSTRAINT FK_ReservCathegory FOREIGN KEY ([ID ReservCathegory]) REFERENCES ReservCathegory (ID);
--ALTER TABLE MilitaryRecord ADD CONSTRAINT FK_MilitaryVal FOREIGN KEY ([ID MilitaryVal]) REFERENCES MilitaryVal (ID);
--ALTER TABLE MilitaryRecord ADD CONSTRAINT FK_TypeMilitaryRec FOREIGN KEY ([ID TypeMilitaryRecord]) REFERENCES TypeMilitaryRecord (ID);
--ALTER TABLE Standing ADD CONSTRAINT FK_TypeRegionStanding FOREIGN KEY ([ID TypeRegion]) REFERENCES TypeRegion (ID);
--ALTER TABLE VidConfirmDoc ADD CONSTRAINT FK_TypeConfirmDoc FOREIGN KEY ([ID TypeConfirmDoc]) REFERENCES TypeConfirmDoc (ID);
--ALTER TABLE ConfirmDoc ADD CONSTRAINT FK_VidConfirmDoc FOREIGN KEY ([ID VidConfirmDoc]) REFERENCES VidConfirmDoc (ID);
--ALTER TABLE ProfTraining ADD CONSTRAINT FK_Specialty FOREIGN KEY ([ID Specialty]) REFERENCES Specialty (ID);
--ALTER TABLE ProfTraining ADD CONSTRAINT FK_TypeProfTraining FOREIGN KEY ([ID TypeProfTraining]) REFERENCES TypeProfTraining (ID);
--ALTER TABLE PlaceMission ADD CONSTRAINT FK_TypeRegionBM FOREIGN KEY ([ID TypeRegion]) REFERENCES TypeRegion (ID);
--ALTER TABLE PlaceMission ADD CONSTRAINT FK_BusinessMission FOREIGN KEY ([ID BusinessMission]) REFERENCES BusinessMission (ID);
--ALTER TABLE Honor ADD CONSTRAINT FK_NameHonor FOREIGN KEY ([ID NameHonor]) REFERENCES NameHonor (ID);
--ALTER TABLE Standing ADD CONSTRAINT FK_TypeStanding FOREIGN KEY ([ID TypeStanding]) REFERENCES TypeStanding (ID);
--ALTER TABLE Standing ADD CONSTRAINT FK_Standing FOREIGN KEY ([ID EmploymentHistory]) REFERENCES EmploymentHistory (ID);
--ALTER TABLE Validation ADD CONSTRAINT FK_ValidationCD FOREIGN KEY (ID) REFERENCES ConfirmDoc (ID);
--ALTER TABLE ProfTraining ADD CONSTRAINT FK_ProfTrainingCD FOREIGN KEY (ID) REFERENCES ConfirmDoc (ID);
--ALTER TABLE BusinessMission ADD CONSTRAINT FK_BusinessMissionPrikaz FOREIGN KEY ([ID FactStaff_Prikaz]) REFERENCES FactStaff_Prikaz (ID);
--ALTER TABLE Honor ADD CONSTRAINT FK_HonorPrikaz FOREIGN KEY ([ID FactStaff_Prikaz]) REFERENCES FactStaff_Prikaz (ID);
--ALTER TABLE MaterialResp ADD CONSTRAINT FK_MaterialRespPrikaz FOREIGN KEY ([ID FactStaff_Prikaz]) REFERENCES FactStaff_Prikaz (ID);
--ALTER TABLE Validation ADD CONSTRAINT FK_ValidationPrikaz FOREIGN KEY ([ID FactStaff_Prikaz]) REFERENCES FactStaff_Prikaz (ID);
--ALTER TABLE ProfTraining ADD CONSTRAINT FK_ProfTrainigPrikaz FOREIGN KEY ([ID FactStaff_Prikaz]) REFERENCES FactStaff_Prikaz (ID);
--ALTER TABLE FactStaff_Prikaz ADD CONSTRAINT FKFactStaff_302864 FOREIGN KEY ([ID FactStaff_Prikaz]) REFERENCES FactStaff_Prikaz (ID);
--ALTER TABLE Honor ADD CONSTRAINT FK_HonorCD FOREIGN KEY (ID) REFERENCES ConfirmDoc (ID);
