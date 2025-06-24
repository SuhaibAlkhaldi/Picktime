namespace Picktime.DTOs
{
    public class PointsSummaryDTO
    {
        public int AvailablePoints { get; set; }
        public int UsedPoints { get; set; }
        public int TotalEarned => AvailablePoints + UsedPoints;
    }
}
