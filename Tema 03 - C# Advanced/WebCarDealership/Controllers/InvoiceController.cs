using CarDealership.Data.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;
using System.Text;
using WebCarDealership.Requests;

namespace WebCarDealership.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InvoiceController : ControllerBase
    {

        private readonly DealershipDbContext _dbContext;

        public InvoiceController(DealershipDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpPost]
        public async Task<IActionResult> Post(int CustomerId)
        {
            var customer = _dbContext.Customers.FirstOrDefault(x => x.Id == CustomerId);

            if (customer == null)
            {
                return BadRequest("Customer doesn't exist. ");
            }

            decimal InvoiceAmount = 0;
            InvoiceRequest InvoiceRequest = new InvoiceRequest();

            foreach (Order order in _dbContext.Orders)
            {
                if (order.CustomerId == CustomerId)
                {
                    InvoiceAmount += order.OrderAmount;
                }
            }

            if (InvoiceAmount == 0)
            {
                return BadRequest("This customer doesn't have any orders yet.");
            }

            var dbModel = new Invoice
            {
                CustomerId = CustomerId,
                Amount = InvoiceAmount,
                InvoiceNumber = InvoiceRequest.GetInvoiceNumber(),
                Date = DateTime.UtcNow
            };

            _dbContext.Invoices.Add(dbModel);

            await _dbContext.SaveChangesAsync();

            return Created(Request.GetDisplayUrl(), dbModel);
        }
    }
}
