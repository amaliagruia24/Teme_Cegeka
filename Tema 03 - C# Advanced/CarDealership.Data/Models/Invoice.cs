using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealership.Data.Models
{
    public class Invoice
    {
        public int Id { get; set; }

        public int CustomerId { get; set; }
        public Customer Customer { get; set; }

        [StringLength(450)]
        public string InvoiceNumber { get; set; }

        public DateTime Date { get; set; }

        public decimal Amount { get; set; }

        public ICollection<Order> Orders { get; set; }
    }
}
