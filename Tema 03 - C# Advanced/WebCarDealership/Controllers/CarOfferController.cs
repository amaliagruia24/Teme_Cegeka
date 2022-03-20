using System.Threading.Tasks;
using CarDealership.Data;
using CarDealership.Data.Models;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebCarDealership;


namespace CarDealership.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CarOfferController : ControllerBase
    {
        private readonly DealershipDbContext _dbContext;
        
        public CarOfferController(DealershipDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var offers = await _dbContext.CarOffers.ToListAsync();
            return Ok(offers);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCarOffer(int id)
        {
            var carOffer = await _dbContext.CarOffers.FirstOrDefaultAsync(x => x.Id == id);
            if (carOffer == null)
            {
                return BadRequest("Car Offer doesn't exist.");
            }
            return Ok(carOffer);

        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CarOfferRequestModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var dbModel = new CarOffer
            {
                Make = model.Make,
                Model = model.Model,
                AvailableStock = model.AvailableStock,
                UnitPrice = model.UnitPrice
            };

            _dbContext.CarOffers.Add(dbModel);

            await _dbContext.SaveChangesAsync();
            return Created(Request.GetDisplayUrl(), dbModel);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var carOffer = await _dbContext.CarOffers.FirstOrDefaultAsync(x => x.Id == id);
            if (carOffer == null)
            {
                return BadRequest("Car Offer doesn't exist.");
            }

            _dbContext.CarOffers.Remove(carOffer);
            await _dbContext.SaveChangesAsync();

            var carOffers = _dbContext.CarOffers.ToList();
            return Ok(carOffers);
        }

        [HttpPut] 
        public async Task<IActionResult> Put([FromBody] CarOfferRequestModel model)
        {
            var carOffer = await _dbContext.CarOffers.FirstOrDefaultAsync(x => x.Make == model.Make 
            && x.Model == model.Model);

            if (carOffer == null)
            {
                return BadRequest("Car Offer doesn't exist.");
            }

            carOffer.Model = model.Model;
            carOffer.Make = model.Make;
            carOffer.AvailableStock = model.AvailableStock;

            await _dbContext.SaveChangesAsync();

            var carOffers = _dbContext.CarOffers.ToList();
            return Ok(carOffers);

        }

    }
}