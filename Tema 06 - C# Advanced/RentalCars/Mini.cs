using System;
using System.Collections.Generic;
using System.Text;

namespace RentalCars
{
    public class Mini
    {
        public int PricePerDay;
        public int PricePerExtraDay;
        public int MaximumDays;

        public Mini(int PricePerDay, int PricePerExtraDay, int MaximumDays)
        {
            this.PricePerDay = PricePerDay;
            this.PricePerExtraDay = PricePerExtraDay;
            this.MaximumDays = MaximumDays;
        }
        public int CaculateAmount(int rentedDays)
        {
            int amount = 0;
            if (rentedDays <= MaximumDays)
            {
                amount += PricePerDay * rentedDays;
            }
            else
            {
                amount += PricePerDay * MaximumDays;
                int remainedDays = rentedDays - MaximumDays;
                amount += PricePerExtraDay * remainedDays;
            }
            return amount;
        }
    }
}
