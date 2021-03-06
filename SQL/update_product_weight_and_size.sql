USE [JungleDB]
GO
/****** Object:  StoredProcedure [dbo].[Update_product_weight_and_size]    Script Date: 9/5/2020 1:57:10 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

ALTER PROCEDURE [dbo].[Update_product_weight_and_size] @name NVARCHAR(50) 
AS 
  BEGIN 
      SET nocount ON; 

      UPDATE product 
      SET    weight = (SELECT weight 
                       FROM   [AdventureWorks2017].[Production].[product] 
                       WHERE  NAME = @name), 
             size = (SELECT size 
                     FROM   [AdventureWorks2017].[Production].[product] 
                     WHERE  NAME = @name), 
             weightunitmeasurecode = (SELECT weightunitmeasurecode 
                                      FROM 
             [AdventureWorks2017].[Production].[product] 
                                      WHERE  NAME = @name), 
             sizeunitmeasurecode = (SELECT sizeunitmeasurecode 
                                    FROM 
             [AdventureWorks2017].[Production].[product] 
                                    WHERE  NAME = @name) 
      WHERE  NAME = @name 
  END 