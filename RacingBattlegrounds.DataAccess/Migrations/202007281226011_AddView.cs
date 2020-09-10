namespace RacingBattlegrounds.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddView : DbMigration
    {
        public override void Up()
        {
            Sql(@"create view dbo.ParticipationDetailsView as
SELECT dbo.Participants.Driver_Id AS DriverId, dbo.Drivers.Name AS DriverName, 
dbo.Participants.Car_Id AS CarId, dbo.Cars.Name AS CarName, dbo.Tracks.Id AS TrackId, dbo.Tracks.Name AS TrackName, 
dbo.Participants.Race_Id AS RaceId, dbo.Races.EngineCapacity, dbo.Participants.TopSpeed, dbo.Participants.IsWinner
FROM dbo.Participants INNER JOIN dbo.Drivers ON dbo.Participants.Driver_Id = dbo.Drivers.Id 
INNER JOIN dbo.Cars ON dbo.Cars.Id = dbo.Participants.Car_Id 
INNER JOIN dbo.Races ON dbo.Races.Id = dbo.Participants.Race_Id 
INNER JOIN dbo.Tracks ON dbo.Races.Track_Id = dbo.Tracks.Id");
        }
        
        public override void Down()
        {
            Sql("DROP VIEW dbo.ParticipationDetailsView");
        }
    }
}
