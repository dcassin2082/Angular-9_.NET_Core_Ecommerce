USE [JungleDB]
GO
/****** Object:  StoredProcedure [dbo].[Update_product_photos]    Script Date: 9/5/2020 1:56:52 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

ALTER PROCEDURE [dbo].[Update_product_photos] @name NVARCHAR(50) 
AS 
  BEGIN 
      SET nocount ON; 

      UPDATE product 
      SET    ThumbnailPhoto = (SELECT ThumbnailPhoto 
                       FROM   [AdventureWorks2017].[Production].[product] 
                       WHERE  NAME = @name), 
             ThumbnailPhotoFileName = (SELECT ThumbnailPhotoFileName 
                     FROM   [AdventureWorks2017].[Production].[product] 
                     WHERE  NAME = @name), 
             LargePhoto = (SELECT LargePhoto 
                                      FROM 
             [AdventureWorks2017].[Production].[product]
                                      WHERE  NAME = @name), 
             LargePhotoFileName = (SELECT LargePhotoFileName 
                                    FROM 
             [AdventureWorks2017].[Production].[product] 
                                    WHERE  NAME = @name) 
      WHERE  NAME = @name 
  END 