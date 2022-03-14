namespace CarDealershipRestApi.Models
{
    public class Car
    {
        public int Id { get; set; }
        public string CarModel { get; set; } = string.Empty;
        public string Color { get; set; } = string.Empty;
        public int Year { get; set; }
        public string Fuel { get; set; } = string.Empty;

    }
}
