USE [JungleDB]
GO
/****** Object:  StoredProcedure [dbo].[Update_order_item]    Script Date: 9/5/2020 1:55:52 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
ALTER PROCEDURE [dbo].[Update_order_item]
	@productId int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
		update orderitem set description=
		(select name from product where productid=@productId)
		where productid=@productId
END
