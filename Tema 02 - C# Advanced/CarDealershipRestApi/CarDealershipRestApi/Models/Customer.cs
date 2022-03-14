using CarDealershipRestApi.Models;
namespace CarDealershipRestApi.Models
{
    public class Customer
    {
        public int CustomerId { get; set; }
        public string CustomerName { get; set; } = string.Empty;
        public List<Car> BoughtCars { get; set; } = new List<Car>();

    }
}
