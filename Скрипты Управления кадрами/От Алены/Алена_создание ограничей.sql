--воинский учет
ALTER TABLE Employee ADD IDMilitaryRecord INT NULL
ALTER TABLE Employee ADD CONSTRAINT FK_MilitaryRecord FOREIGN KEY ([IDMilitaryRecord]) REFERENCES MilitaryRecord (ID);

--трудовая книжка 
ALTER TABLE Employee ADD IDEmploymentHistory INT NULL
ALTER TABLE Employee ADD CONSTRAINT FK_EmploymentHistory FOREIGN KEY ([IDEmploymentHistory]) REFERENCES EmploymentHistory (ID);

--степень владения языком
ALTER TABLE OK_EmployeeLang ADD IDLanguageLevel INT NULL
ALTER TABLE OK_EmployeeLang ADD CONSTRAINT FK_LanguageLevel FOREIGN KEY ([IDLanguageLevel]) REFERENCES LanguageLevel (ID);

ALTER TABLE OK_EmployeeLang ADD IDLanguageFK INT NULL
ALTER TABLE OK_EmployeeLang ADD CONSTRAINT FK_Language FOREIGN KEY ([IDLanguageFK]) REFERENCES OK_Language (idlanguage);

--соц проезд
ALTER TABLE SocialFare ADD CONSTRAINT FK_EmployeeSocialFare FOREIGN KEY ([idEmployee]) REFERENCES Employee (id);

--соц cтатус
ALTER TABLE OK_Social ADD idSocialStatusNew INT NULL
ALTER TABLE OK_Social ADD CONSTRAINT FK_SocialStatus FOREIGN KEY (idSocialStatusNew) REFERENCES OK_SocialStatus (idSocialStatus);

-- связь человека и факт стафф с подтвержд док-том
ALTER TABLE ConfirmDoc ADD CONSTRAINT FK_EmployeeCD FOREIGN KEY (idEmployee) REFERENCES Employee (id);
ALTER TABLE ConfirmDoc ADD CONSTRAINT FK_FactStaffCD FOREIGN KEY (FactStaffid) REFERENCES FactStaff (id);

--мат ответственность
ALTER TABLE FactStaff ADD idMaterialResp INT NULL
ALTER TABLE FactStaff ADD CONSTRAINT FK_MaterialResp FOREIGN KEY (idMaterialResp) REFERENCES MaterialResp (ID);

--факт стафф приказ
ALTER TABLE FactStaff_Prikaz ADD CONSTRAINT FK_Prikaz FOREIGN KEY (Prikazid) REFERENCES Prikaz (id);
ALTER TABLE FactStaff_Prikaz ADD CONSTRAINT FK_FactStaff FOREIGN KEY (FactStaffid) REFERENCES FactStaff (id);