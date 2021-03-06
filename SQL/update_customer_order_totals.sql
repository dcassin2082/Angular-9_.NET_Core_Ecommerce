USE [JungleDB]
GO
/****** Object:  StoredProcedure [dbo].[Update_customer_order_totals]    Script Date: 9/5/2020 1:55:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

ALTER PROCEDURE [dbo].[Update_customer_order_totals] 
	@orderId INT 
AS 
  BEGIN 
      SET nocount ON; 

      UPDATE customerorder 
      SET    ordersubtotal = (SELECT Sum(linetotal) 
                              FROM   orderitem 
                              WHERE  orderid = @orderId) 
      WHERE  orderid = @orderId 

      UPDATE customerorder 
      SET    tax = (SELECT ordersubtotal * 0.08 
                    WHERE  orderid = @orderId) 
      WHERE  orderid = @orderId 

      UPDATE customerorder 
      SET    ordertotal = (SELECT ordersubtotal + tax + shippingcharge 
                           WHERE  orderid = @orderId) 
      WHERE  orderid = @orderId 
  END 

