












--select * from [Department] where  [dateExit]>GETDATE()
--Представление со всеми текущими параметрами Department (DateBegin...) 
CREATE VIEW [dbo].[Department]
AS
SELECT  Dep.[id]
      ,DepartmentHistory.[DepartmentName]
      ,DepartmentHistory.[DepartmentSmallName]
      ,Dep.[idDepartmentType]
      ,DepartmentHistory.[idManagerDepartment]
      ,Dep.[KadrID]
      ,DepartmentHistory.DateBegin [dateCreate]
      ,Dep.[dateExit]
      ,Dep.[idManagerPlanStaff]
      ,DepartmentHistory.[idBeginPrikaz]
      ,Dep.[idEndPrikaz]
      ,Dep.[SeverKoeff]
      ,Dep.[RayonKoeff]
      ,Dep.[DepartmentGUID]
      ,idFundingCenter
	  ,Dep.DepartmentIndex
	  ,Dep.[DepPhoneNumber]
	  ,Dep.HasTimeSheet
	  , Dep.idOKVED,
	  DepartmentHistory.[Address],
	  DepartmentHistory.idRegionType
FROM         
	dbo.Dep inner JOIN
	 dbo.DepartmentHistory ON Dep.id=DepartmentHistory.idDepartment
		AND DepartmentHistory.DateBegin = 
			ISNULL((SELECT MAX(DepartmentHistory.DateBegin) FROM dbo.DepartmentHistory 
				WHERE DepartmentHistory.idDepartment=Dep.id AND
					DepartmentHistory.DateBegin<GETDATE()),DepartmentHistory.DateBegin)






















