
using CarDealershipRestApi.Models;
namespace CarDealershipRestApi.Repositories
{
    public class CustomersRepository : ICustomersRepository
    {
        List<Customer> customers = new List<Customer>
        {
            new Customer
            {
                CustomerId = 1,
                CustomerName = "Dragos Anca",
                BoughtCars = new List<Car>
                {
                    new Car
                    {
                        Id = 1,
                        CarModel = "Toyota",
                        Color = "Red",
                        Year = 2010,
                        Fuel = "Diesel"
                    }
                }
            },
            new Customer
            {
                CustomerId = 2,
                CustomerName = "Amalia Gruia",
                BoughtCars = new List<Car>()
            }
        };

        public List<Customer> GetCustomers()
        {
            return customers;
        }
    }
}
