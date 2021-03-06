USE [XomeEntity.Models.XomeDBContext]
GO
/****** Object:  StoredProcedure [dbo].[SP_RaceDetails]    Script Date: 7/28/2020 7:44:17 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Kumar Sahab>
-- Create date: <7/28/25020,,>
-- Description:	<Get Race Details,,>
-- =============================================
ALTER PROCEDURE [dbo].[SP_RaceDetails] 
AS
BEGIN
	select T.City, T.Name As TrackName, T.Length, R.EngineCapacity, C.Name As CarName, D.Name As DriverName, p.TopSpeed, p.CompletionTime
	from Races R inner Join Tracks T on R.Track_Id = T.Id
	inner Join Participants P on P.IsWinner = 1 AND p.Race_Id = R.Id
	inner join Drivers D on D.Id = P.Driver_Id
	inner Join Cars C on C.Id = p.Car_Id
	Order by p.TopSpeed desc
END
