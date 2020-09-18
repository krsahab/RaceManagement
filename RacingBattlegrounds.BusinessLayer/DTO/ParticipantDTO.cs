namespace RacingBattlegrounds.BusinessLayer.DTO
{
    public class ParticipantDTO
    {
        public int Id { get; set; }
        public int DriverId { get; set; }
        public string DriverName { get; set; }
        public int RaceId { get; set; }
        public string RaceName { get; set; }
        public int CarId { get; set; }
        public string CarName { get; set; }
        public float TopSpeed { get; set; }
        public int CompletionTime { get; set; }
        public bool IsWinner { get; set; }
    }
}
