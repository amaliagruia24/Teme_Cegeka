using System;
using System.Collections.Generic;
using System.Text;

namespace RentalCars
{
    class RentalCarsIasi : RentalCars
    {
        public RentalCarsIasi(string name) : base(name)
        {
        }

        public override void ApplyDiscount(Rental rental, ref double amount)
        {
            if (rental.Customer.FrequentRenterPoints >= Constants.MinimumDaysForDiscount)
            {
                amount = amount * 0.95;
            }
        }

        public override double GetAmountFromCustomer(Rental rental)
        {
            double thisAmount = 0;

            // determines the amount for each line
            switch (rental.Car.PriceCode)
            {
                case PriceCode.Regular:
                    Regular regular = new Regular(Constants.RegularPricePerDayIasi,
                        Constants.RegularPricePerExtraDay, Constants.RegularMaximumDays);
                    thisAmount = regular.CaculateAmount(rental.DaysRented);
                    break;

                case PriceCode.Premium:
                    Premium premium = new Premium(Constants.PremiumPricePerDay);
                    thisAmount = premium.CaculateAmount(rental.DaysRented);
                    break;

                case PriceCode.Mini:
                    Mini mini = new Mini(Constants.MiniPricePerDay,
                        Constants.MiniPricePerExtraDay, Constants.MiniMaximumDays);
                    thisAmount = mini.CaculateAmount(rental.DaysRented);
                    break;
            }
            return thisAmount;
        }

        public override void IncreaseRenterPoints(Rental rental)
        {
            var frequentRenterPoints = 0;

            frequentRenterPoints = 1;
            if (rental.Car.PriceCode == PriceCode.Premium
                && rental.DaysRented > 1)
                frequentRenterPoints++;

            rental.Customer.FrequentRenterPoints += frequentRenterPoints;
        }

        public override string Statement()
        {
            double totalAmount = 0;

            var response = "Rental Record for " + Name + "\n";
            response += "------------------------------\n";

            foreach (var each in _rentals)
            {
                double thisAmount = 0;

                thisAmount = GetAmountFromCustomer(each);

                ApplyDiscount(each, ref thisAmount);

                IncreaseRenterPoints(each);

                response += each.Customer.Name + "\t" + each.Car.Model + "\t" + each.DaysRented + "d \t" + thisAmount + " EUR\n";
                totalAmount += thisAmount;
            }
            response += "------------------------------\n";
            response += "Total revenue " + totalAmount + " EUR\n";

            return response;
        }
    }
}
