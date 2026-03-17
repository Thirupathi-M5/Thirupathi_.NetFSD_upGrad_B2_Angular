using System;

namespace W5Handson1
{
    internal class Vehicle
    {
        public string Brand { get; set; }
        public double RentalRatePerDay { get; set; }

        public virtual double CalculateRental(int days)
        {
            return RentalRatePerDay * days;
        }
    }

    class Car : Vehicle
    {
        public override double CalculateRental(int days)
        {
            double total = RentalRatePerDay * days;
            return total + 500; // insurance charge
        }
    }

    class Bike : Vehicle
    {
        public override double CalculateRental(int days)
        {
            double total = RentalRatePerDay * days;
            return total - (total * 0.05); // 5% discount
        }
    }

    class Program2
    {
        static void Main()
        {
            Console.WriteLine("Enter Vehicle Type (Car/Bike): ");
            string type = Console.ReadLine();

            Console.Write("Enter Brand: ");
            string brand = Console.ReadLine();

            Console.Write("Enter Rental Rate Per Day: ");
            double rate = Convert.ToDouble(Console.ReadLine());

            Console.Write("Enter Number of Rental Days: ");
            int days = Convert.ToInt32(Console.ReadLine());

            if (days <= 0)
            {
                Console.WriteLine("Invalid number of days.");
                return;
            }

            Vehicle vehicle;

            if (type.ToLower() == "car")
            {
                vehicle = new Car();
            }
            else if (type.ToLower() == "bike")
            {
                vehicle = new Bike();
            }
            else
            {
                Console.WriteLine("Invalid vehicle type.");
                return;
            }

            vehicle.Brand = brand;
            vehicle.RentalRatePerDay = rate;

            double totalRental = vehicle.CalculateRental(days);

            Console.WriteLine("Total Rental = " + totalRental);
        }
    }
}
