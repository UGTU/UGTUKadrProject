USE [Kadr]
GO

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
where id=20569


