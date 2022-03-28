using System.ComponentModel.DataAnnotations;


namespace CarDealership.Data.Models
{
    public class CarOfferRequestModel
    {
        [Required]
        public string Make { get; set; }

        [Required]
        public string Model { get; set; }

        [Required]
        [Range(0, 10000)]
        public int AvailableStock { get; set; }
    }
}
