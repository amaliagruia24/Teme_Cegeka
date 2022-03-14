using CarDealershipRestApi.Models;

namespace CarDealershipRestApi.Repositories
{
    public class CarsRepository : ICarsRepository
    {
        List<Car> cars = new List<Car>
        {
            new Car {
                Id = 1,
                CarModel = "Toyota",
                Color = "Red",
                Year = 2010,
                Fuel = "Diesel"
            },
            new Car {
                Id = 2,
                CarModel = "BMW",
                Color = "White",
                Year = 2016,
                Fuel = "Diesel"
            },
            new Car {
                Id = 3,
                CarModel = "Ford",
                Color = "White",
                Year = 2015,
                Fuel = "Gasoline"
            },
            new Car {
                Id = 4,
                CarModel = "Ford",
                Color = "Red",
                Year = 2018,
                Fuel = "Electricity"
            },
            new Car {
                Id = 5,
                CarModel = "Peugeot",
                Color = "Black",
                Year = 2010,
                Fuel = "Diesel"
            }
        };

        public List<Car> GetCarsList()
        {
            return cars;
        }

    }
}
