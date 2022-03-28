using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using CarDealership.Data;
using CarDealership.Data.Models;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.EntityFrameworkCore;
using WebCarDealership;
using WebCarDealership.Requests;

namespace WebCarDealership.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly DealershipDbContext _dbContext;

        public CustomerController(DealershipDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            _dbContext.Customers.Include(c => c.Orders);

            var customers = await _dbContext.Customers.ToListAsync();
            
            return Ok(customers);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CustomerRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var dbModel = new Customer
            {
                Name = request.Name,
                Email = request.Email
            };

            _dbContext.Customers.Add(dbModel);

            await _dbContext.SaveChangesAsync();
            return Created(Request.GetDisplayUrl(), dbModel);
        }
        

    }
}
