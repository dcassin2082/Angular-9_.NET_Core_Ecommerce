USE [JungleDB]
GO
/****** Object:  StoredProcedure [dbo].[Update_product_description]    Script Date: 9/5/2020 1:56:19 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

ALTER PROCEDURE [dbo].[Update_product_description] @name NVARCHAR(50) 
AS 
  BEGIN 
      SET nocount ON; 

      UPDATE product 
      SET    description = (SELECT pd.description 
                            FROM   [AdventureWorks2017].[Production].[product] p 
                                   JOIN 
                           [AdventureWorks2017].[Production].[productmodel] pm 
                                     ON p.productmodelid = pm.productmodelid 
                                   JOIN 
  [AdventureWorks2017].[Production].[productmodelproductdescriptionculture] 
  pc 
            ON pm.productmodelid = pc.productmodelid 
          JOIN [AdventureWorks2017].[Production].[productdescription] pd 
            ON pc.productdescriptionid = pd.productdescriptionid 
   WHERE  p.NAME = @name 
          AND pc.cultureid = 'en') 
      WHERE  NAME = @name 
  END 

