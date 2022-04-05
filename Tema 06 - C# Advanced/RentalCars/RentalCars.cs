using System;
using System.Collections.Generic;

namespace RentalCars
{
    abstract class RentalCars
    {
        public readonly List<Rental> _rentals = new List<Rental>();

        public RentalCars(string name)
        {
            Name = name;
        }

        public string Name { get; }

        public void AddRental(Rental rental)
        {
            _rentals.Add(rental);
            rental.Customer.AddRental(rental);
        }

        public abstract string Statement();

        public abstract void IncreaseRenterPoints(Rental rental);

        public abstract void ApplyDiscount(Rental rental, ref double amount);

        public abstract double GetAmountFromCustomer(Rental rental);
       
    }
}