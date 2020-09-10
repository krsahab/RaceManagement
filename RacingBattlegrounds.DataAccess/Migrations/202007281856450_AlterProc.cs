namespace RacingBattlegrounds.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AlterProc : DbMigration
    {
        public override void Up()
        {
            Sql(@"ALTER PROCEDURE [dbo].[SP_GetDriverOtherDetails]
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
END");
        }
        
        public override void Down()
        {
        }
    }
}
