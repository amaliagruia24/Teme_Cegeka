using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using CarDealershipRestApi.Models;
using CarDealershipRestApi.Repositories;

namespace CarDealershipRestApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        ICustomersRepository customersRepository;
        ICarsRepository carsRepository;

        public CustomerController(ICustomersRepository customersRepository, ICarsRepository carsRepository)
        {
            this.customersRepository = customersRepository;
            this.carsRepository = carsRepository;
        }

        [HttpGet]
        public async Task<ActionResult<List<Customer>>> Get()
        {
            return Ok(customersRepository.GetCustomers());
        }

        [HttpGet("Filtered")] 
        public async Task<ActionResult<Dictionary<string, List<Car>>>> GetFilteredCustomers(string carModel) 
        {
            Dictionary<string, List<Car>> result = new Dictionary<string, List<Car>>();
            foreach (Customer customer in customersRepository.GetCustomers())
            {
                List<Car> associatedCars = new List<Car>();
                foreach (Car car in customer.BoughtCars)
                {
                    if (car.CarModel == carModel)
                    {
                        if (result.ContainsKey(customer.CustomerName))
                        {
                            result[customer.CustomerName].Add(car);
                        } else
                        {
                            associatedCars.Add(car);
                        }
                    }
                }
                if (associatedCars.Count > 0)
                {
                    result[customer.CustomerName] = associatedCars;
                }
                
            }

            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<List<Customer>>> buyCar(int customerId, string carModel)
        {
            Car car = carsRepository.GetCarsList().Find(c => c.CarModel.Equals(carModel));
            if (car == null)
            {
                return BadRequest("Car not found.");
            }
            foreach (Customer customer in customersRepository.GetCustomers())
            {
                if (customer.CustomerId == customerId)
                {
                    customer.BoughtCars.Add(car);
                }
            }
            return Ok(customersRepository.GetCustomers());
        }

    }
}

