namespace Picktime.DTOs
{
    public class GetProviderOutputDTO
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Logo { get; set; }
        public TimeOnly AverageTime { get; set; }
        public TimeOnly ActualServedServiceTime { get; set; }

        public int CategoryId { get; set; }
    }
}
