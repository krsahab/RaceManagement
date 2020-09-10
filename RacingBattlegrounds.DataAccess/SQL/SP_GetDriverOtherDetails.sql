-- ================================================
-- Template generated from Template Explorer using:
-- Create Procedure (New Menu).SQL
--
-- Use the Specify Values for Template Parameters 
-- command (Ctrl-Shift-M) to fill in the parameter 
-- values below.
--
-- This block of comments will not be included in
-- the definition of the procedure.
-- ================================================
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE SP_GetDriverOtherDetails
AS
BEGIN
WITH CTE AS
(
	select DriverId, 
	COUNT(RaceId) As RaceParticipated, 
	MAX(TopSpeed) As TopSpeed, 
	COUNT(case when IsWinner = 1 then RaceId end) As RaceWon
	from ParticipationDetailsView group by DriverId
)
Select CTE.DriverId, Drivers.Name, RaceParticipated, RaceWon, TopSpeed
From Drivers Left Join CTE on Drivers.Id = CTE.DriverId
END
GO
