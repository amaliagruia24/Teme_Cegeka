using CarDealership.Data.Models;

namespace CarDealership.Data
{
    public interface IRepository
    {
        Task<CarOffer> GetCarOfferById(int id);
        void AddOrder(Order order);
        Task<int> SaveChanges();
    }
}
