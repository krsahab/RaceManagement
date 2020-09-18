namespace RacingBattlegrounds.DataAccess.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class _202009121717577_Add_InsertUpdate_Trigger : DbMigration
    {
        public override void Up()
        {
            Sql(@"CREATE OR ALTER TRIGGER tr_Participants_ForInsert
ON Participants
FOR INSERT
AS
BEGIN
	UPDATE Participants
	SET IsWinner = 
	CASE
	WHEN CompletionTime = (SELECT MIN(CompletionTime) FROM Participants WHERE Race_Id = (SELECT Race_Id FROM inserted)) THEN 1
	ELSE 0
	END
	WHERE Race_Id = (SELECT Race_Id FROM inserted)
END");
            Sql(@"CREATE OR ALTER TRIGGER tr_Participants_ForUpdate
ON Participants
FOR UPDATE
AS
BEGIN
	UPDATE Participants
	SET IsWinner = 
	CASE
	WHEN CompletionTime = (SELECT MIN(CompletionTime) FROM Participants WHERE Race_Id = (SELECT Race_Id FROM inserted)) THEN 1
	ELSE 0
	END
	WHERE Race_Id = (SELECT Race_Id FROM inserted)
END");
        }

        public override void Down()
        {
            Sql("DROP TRIGGER tr_Participants_ForInsert");
            Sql("DROP TRIGGER tr_Participants_ForUpdate");
        }
    }
}
