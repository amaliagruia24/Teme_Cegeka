using System;
using System.Collections.Generic;
using System.Text;

namespace RentalCars
{
    public class Premium
    {
        public int PricePerDay;

        public Premium(int PricePerDay)
        {
            this.PricePerDay = PricePerDay;
        }

        public int CaculateAmount(int rentedDays)
        {
            int amount = 0;
            amount += rentedDays * PricePerDay;
            return amount;
        }
    }
}
