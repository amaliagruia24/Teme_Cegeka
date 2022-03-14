using CarDealershipRestApi.Models;
namespace CarDealershipRestApi.Repositories
{
    public interface ICustomersRepository
    {
        List<Customer> GetCustomers();
    }
}
