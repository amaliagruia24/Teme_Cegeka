using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using CarDealershipRestApi.Models;
using CarDealershipRestApi.Repositories;

namespace CarDealershipRestApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarController : ControllerBase
    {
        ICarsRepository carsRepository;
        
        public CarController(ICarsRepository carsRepository)
        {
            this.carsRepository = carsRepository;
        }
        
        [HttpGet]
        public async Task<ActionResult<List<Car>>> Get()
        {
            return Ok(carsRepository.GetCarsList());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Car>> Get(int id)
        {
            var car = this.carsRepository.GetCarsList().Find(c => c.Id == id);
            if (car == null)
            {
                return BadRequest("Car not found.");
            }
            return Ok(car);
        }

        [HttpPost]
        public async Task<ActionResult<List<Car>>> AddCar(Car car)
        {
            this.carsRepository.GetCarsList().Add(car);
            return Ok(this.carsRepository.GetCarsList());
        }

        [HttpPut]
        public async Task<ActionResult<List<Car>>> UpdateCar(Car request)
        {
            var car = this.carsRepository.GetCarsList().Find(c => c.Id == request.Id);
            if (car == null)
            {
                return BadRequest("Car not found.");
            }

            car.CarModel = request.CarModel;
            car.Color = request.Color;
            car.Year = request.Year;
            car.Fuel = request.Fuel;

            return Ok(this.carsRepository.GetCarsList());

        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<Car>>> Delete(int id)
        {
            var car = this.carsRepository.GetCarsList().Find(c => c.Id == id);
            if (car == null)
            {
                return BadRequest("Car not found.");
            }
            this.carsRepository.GetCarsList().Remove(car);
            return Ok(carsRepository.GetCarsList());
        }


    }
}
