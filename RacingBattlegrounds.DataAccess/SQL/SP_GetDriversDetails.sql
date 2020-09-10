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
CREATE PROCEDURE SP_GetDriverDetails
AS
BEGIN
WITH CTE AS
(
	SELECT
	DriverId, CarName, TrackName, EngineCapacity, IsWinner, COUNT(RaceId) AS MyCount
	FROM dbo.ParticipationDetailsView
	GROUP BY
	GROUPING SETS
	(
		(DriverId, IsWinner, CarName),
		(DriverId, IsWinner, EngineCapacity),
		(DriverId, IsWinner, TrackName)
	)
),
CTEMax AS
(
	SELECT
	DriverId,
	MAX(CASE WHEN IsWinner = 1 AND CarName IS NOT NULL THEN MyCount END) AS MaxCarWin,
	MAX(CASE WHEN IsWinner = 1 AND EngineCapacity IS NOT NULL THEN MyCount END) AS MaxCategoryWin,
	MAX(CASE WHEN IsWinner = 1 AND TrackName IS NOT NULL THEN MyCount END) AS MaxTrackWin,
	MAX(CASE WHEN IsWinner = 0 AND CarName IS NOT NULL THEN MyCount END) AS MaxCarLose,
	MAX(CASE WHEN IsWinner = 0 AND EngineCapacity IS NOT NULL THEN MyCount END) AS MaxCategoryLose,
	MAX(CASE WHEN IsWinner = 0 AND TrackName IS NOT NULL THEN MyCount END) AS MaxTrackLose
	FROM CTE
	GROUP BY DriverId
),
MostWinLose AS
(
	SELECT
	CTE.DriverId,
	STRING_AGG((CASE WHEN IsWinner = 1 AND CarName IS NOT NULL AND CTE.MyCount = CTEMax.MaxCarWin THEN CarName END), ', ') AS CarWithMostWin,
	STRING_AGG((CASE WHEN IsWinner = 1 AND EngineCapacity IS NOT NULL AND CTE.MyCount = CTEMax.MaxCategoryWin THEN EngineCapacity END), ', ') AS CategoryWithMostWin,
	STRING_AGG((CASE WHEN IsWinner = 1 AND TrackName IS NOT NULL AND CTE.MyCount = CTEMax.MaxTrackWin THEN TrackName END), ', ') AS TrackWithMostWin,
	STRING_AGG((CASE WHEN IsWinner = 0 AND CarName IS NOT NULL AND CTE.MyCount = CTEMax.MaxCarLose THEN CarName END), ', ') AS CarWithMostLose,
	STRING_AGG((CASE WHEN IsWinner = 0 AND EngineCapacity IS NOT NULL AND CTE.MyCount = CTEMax.MaxCategoryLose THEN EngineCapacity END), ', ') AS CategoryWithMostLose,
	STRING_AGG((CASE WHEN IsWinner = 0 AND TrackName IS NOT NULL AND CTE.MyCount = CTEMax.MaxTrackLose THEN TrackName END), ', ') AS TrackWithMostLose
	FROM CTE INNER JOIN  CTEMax
	ON CTE.DriverId = CTEMax.DriverId
	GROUP BY CTE.DriverId
),
Participations As
(
	select DriverId, 
	COUNT(RaceId) As RaceParticipated, 
	MAX(TopSpeed) As TopSpeed, 
	COUNT(case when IsWinner = 1 then RaceId end) As RaceWon
	from ParticipationDetailsView group by DriverId
)
select 
D.Name, p.RaceParticipated, p.RaceWon, p.TopSpeed,
ISNULL(M.CarWithMostWin,'Not Available') As CarWithMostWin, ISNUll(M.CategoryWithMostWin,'Not Available') As CategoryWithMostWin, 
ISNULL(M.TrackWithMostWin, 'Not Available')As TrackWithMostWin, ISNULL(M.CarWithMostLose, 'Not Available') As CarWithMostLose, 
ISNULL(M.CategoryWithMostLose,'NotAvailable')As CategoryWithMostLose, ISNULL(M.TrackWithMostLose,'Not Available')As TrackWithMostLose
FROM MostWinLose M FULL OUTER JOIN Participations P on M.DriverId = p.DriverId
RIGHT JOIN Drivers D on D.Id = P.DriverId;
END
GO
