namespace RacingBattlegrounds.DataAccess.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class Add_InsertUpdate_Trigger : DbMigration
    {
        public override void Up()
        {
            Sql(@"CREATE TRIGGER tr_Participants_ForInsert
ON Participants
FOR INSERT
AS
BEGIN
	DECLARE @Id INT
	SELECT @Id=Id FROM inserted
	DECLARE @minCompletionTime INT
	SELECT @minCompletionTime=CompletionTime FROM Participants WHERE IsWinner = 1;
	DECLARE @currCompletionTime INT
	SELECT @currCompletionTime=CompletionTime FROM inserted
	IF (@currCompletionTime<=@minCompletionTime)
	BEGIN
		IF (@currCompletionTime<@minCompletionTime)
		BEGIN
			UPDATE participants 
			SET IsWinner = 0
			WHERE IsWinner=1;
		END
		UPDATE participants 
		SET IsWinner = 1
		WHERE Id=@Id;
	END
END");
            Sql(@"CREATE TRIGGER tr_Participants_ForUpdate
ON Participants
FOR UPDATE
AS
BEGIN
	DECLARE @Id INT
	SELECT @Id=Id FROM inserted
	DECLARE @minCompletionTime INT
	SELECT @minCompletionTime=CompletionTime FROM Participants WHERE IsWinner = 1;
	DECLARE @currCompletionTime INT
	SELECT @currCompletionTime=CompletionTime FROM inserted
	IF (@currCompletionTime<=@minCompletionTime)
	BEGIN
		IF (@currCompletionTime<@minCompletionTime)
		BEGIN
			UPDATE participants 
			SET IsWinner = 0
			WHERE IsWinner=1;
		END
		UPDATE participants 
		SET IsWinner = 1
		WHERE Id=@Id;
	END
END");
        }

        public override void Down()
        {
            Sql("DROP TRIGGER tr_Participants_ForInsert");
            Sql("DROP TRIGGER tr_Participants_ForUpdate");
        }
    }
}
