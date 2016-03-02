USE [Kadr]
GO
SELECT TOP 1000 [idFactStaff]
      ,[idReplacedFactStaff]
      ,[idReplacementReason]
      ,[DateEnd]
  FROM [Kadr].[dbo].[FactStaffReplacement]
  where [idFactStaff]=17776


  insert into [dbo].[FactStaffReplacement]([idFactStaff]
      ,[idReplacedFactStaff]
      ,[idReplacementReason]
      ,[DateEnd])
values (21871,8872,6,null)


INSERT INTO [dbo].[FactStaffReplacement]
           ([idFactStaff]
           ,[idReplacedFactStaff]
           ,[idReplacementReason]
           )
     VALUES
           (20569, 17016, 6)
GO

update [dbo].[FactStaff]
set [IsReplacement]=1
where id=21871






