namespace RacingBattlegrounds.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddDriverOtherDetailsSP : DbMigration
    {
        public override void Up()
        {
            Sql(@"CREATE PROCEDURE SP_GetDriverOtherDetails
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
From CTE Inner Join Drivers on Drivers.Id = CTE.DriverId
END");
        }
        
        public override void Down()
        {
            Sql(@"DROP PROCEDURE SP_GetDriverOtherDetails");
        }
    }
}
