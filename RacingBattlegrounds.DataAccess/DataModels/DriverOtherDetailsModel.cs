namespace RacingBattlegrounds.DataAccess.DataModels
{
    public class DriverOtherDetailsModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int? RaceParticipated { get; set; }
        public int? RaceWon { get; set; }
        public float? TopSpeed { get; set; }
    }
}
