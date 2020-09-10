namespace RacingBattlegrounds.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Cars",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 20),
                        EngineCapacity = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Drivers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 20),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Participants",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TopSpeed = c.Single(nullable: false),
                        CompletionTime = c.Int(nullable: false),
                        IsWinner = c.Boolean(nullable: false),
                        Car_Id = c.Int(nullable: false),
                        Driver_Id = c.Int(nullable: false),
                        Race_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Cars", t => t.Car_Id, cascadeDelete: true)
                .ForeignKey("dbo.Drivers", t => t.Driver_Id, cascadeDelete: true)
                .ForeignKey("dbo.Races", t => t.Race_Id, cascadeDelete: true)
                .Index(t => t.Car_Id)
                .Index(t => t.Driver_Id)
                .Index(t => t.Race_Id);
            
            CreateTable(
                "dbo.Races",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 20),
                        EngineCapacity = c.Int(nullable: false),
                        Track_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Tracks", t => t.Track_Id, cascadeDelete: true)
                .Index(t => t.Track_Id);
            
            CreateTable(
                "dbo.Tracks",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 20),
                        City = c.String(nullable: false, maxLength: 20),
                        Length = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Participants", "Race_Id", "dbo.Races");
            DropForeignKey("dbo.Races", "Track_Id", "dbo.Tracks");
            DropForeignKey("dbo.Participants", "Driver_Id", "dbo.Drivers");
            DropForeignKey("dbo.Participants", "Car_Id", "dbo.Cars");
            DropIndex("dbo.Races", new[] { "Track_Id" });
            DropIndex("dbo.Participants", new[] { "Race_Id" });
            DropIndex("dbo.Participants", new[] { "Driver_Id" });
            DropIndex("dbo.Participants", new[] { "Car_Id" });
            DropTable("dbo.Tracks");
            DropTable("dbo.Races");
            DropTable("dbo.Participants");
            DropTable("dbo.Drivers");
            DropTable("dbo.Cars");
        }
    }
}
