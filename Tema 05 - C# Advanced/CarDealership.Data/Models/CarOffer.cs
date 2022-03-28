
namespace CarDealership.Data.Models
{
    public class CarOffer
    {
        public int Id { get; set; }

        public string Make { get; set; }

        public string Model { get; set; }

        public int AvailableStock { get; set; }

        public decimal UnitPrice { get; set; }

        public ICollection<Order> Orders { get; set; }
    }
}
