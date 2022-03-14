using CarDealershipRestApi.Models;
namespace CarDealershipRestApi.Repositories
{
    public interface ICarsRepository
    {
        List<Car> GetCarsList();
    }
}