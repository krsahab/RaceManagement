namespace RacingBattlegrounds.BusinessLayer.DTO
{
    public class ParticipantDTO
    {
        public int Id { get; set; }
        public int Driver_Id { get; set; }
        public int Race_Id { get; set; }
        public int Car_Id { get; set; }
        public float TopSpeed { get; set; }
        public int CompletionTime { get; set; }
        public bool IsWinner { get; set; }
    }
}
