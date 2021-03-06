USE [JungleDB]
GO
/****** Object:  StoredProcedure [dbo].[Populate_product_table]    Script Date: 9/5/2020 1:54:15 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

ALTER PROCEDURE [dbo].[Populate_product_table] 
AS 
  BEGIN 
      SET nocount ON; 

      DECLARE @rowCount    INT, 
              @recordCount INT; 
      DECLARE @Description NVARCHAR(max); 
      DECLARE @Cost DECIMAL(18, 2); 
      DECLARE @Price DECIMAL(18, 2); 
      DECLARE @SKU NVARCHAR(max); 
      DECLARE @Name NVARCHAR(50); 
      DECLARE @LargePhoto VARBINARY(max); 
      DECLARE @ThumbnailPhoto VARBINARY(max); 
      DECLARE @LargePhotoFileName NVARCHAR(50); 
      DECLARE @ThumbnailPhotoFileName NVARCHAR(50); 
	  DECLARE @ProductSubcategoryID int;

      CREATE TABLE #products 
        ( 
           rowid                  INT IDENTITY(1, 1), 
           description            NVARCHAR(max), 
           cost                   DECIMAL(18, 2), 
           price                  DECIMAL(18, 2), 
           sku                    NVARCHAR(max), 
           NAME                   NVARCHAR(50), 
           largephoto             VARBINARY(max), 
           thumbnailphoto         VARBINARY(max), 
           largephotofilename     NVARCHAR(50), 
           thumbnailphotofilename NVARCHAR(50) ,
		   productsubcategoryid	  INT
        ) 

      INSERT #products 
             (description, 
              cost, 
              price, 
              sku, 
              NAME, 
              largephoto, 
              thumbnailphoto, 
              largephotofilename, 
              thumbnailphotofilename,
			  productsubcategoryid) 
      SELECT p.NAME          AS Description, 
             p.standardcost  AS Cost, 
             p.listprice, 
             p.productnumber AS SKU, 
			 p.NAME,
             pp.largephoto, 
             pp.thumbnailphoto, 
             pp.largephotofilename,
             pp.thumbnailphotofilename,
			 p.productsubcategoryid
      FROM   [AdventureWorks2017].[Production].[productphoto] pp 
             JOIN [AdventureWorks2017].[Production].productproductphoto ppp 
               ON pp.productphotoid = ppp.productphotoid 
             JOIN [AdventureWorks2017].[Production].product p 
               ON ppp.productid = p.productid 
      WHERE  p.listprice IS NOT NULL 
             AND p.listprice > 0 

      SET @recordCount = @@ROWCOUNT 
      SET @rowCount = 1 

      WHILE @rowCount <= @recordCount 
        BEGIN 
            SELECT @Description = description, 
                   @Cost = cost, 
                   @Price = price, 
                   @SKU = sku, 
                   @Name = NAME, 
                   @LargePhoto = largephoto, 
                   @ThumbnailPhoto = thumbnailphoto, 
                   @LargePhotoFileName = largephotofilename, 
                   @ThumbnailPhotoFileName = thumbnailphotofilename,
				   @ProductSubcategoryId = productsubcategoryid
            FROM   #products 
            WHERE  rowid = @rowCount 

            INSERT product 
                   (description, 
                    cost, 
                    price, 
                    sku, 
                    NAME, 
                    largephoto, 
                    thumbnailphoto, 
					largephotofilename,
                    thumbnailphotofilename,
					productsubcategoryid)
            VALUES(@Description, 
                   @Cost, 
                   @Price, 
                   @SKU, 
                   @Name, 
                   @LargePhoto, 
                   @ThumbnailPhoto, 
                   @LargePhotoFileName,
				   @ThumbnailPhotoFileName,
				   @ProductSubcategoryID) 

            SET @rowCount = @rowCount + 1 
        END 

      DROP TABLE #products 
  END 

