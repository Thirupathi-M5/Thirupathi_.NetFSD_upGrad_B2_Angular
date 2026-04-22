using System;

namespace W5Handson1
{
    internal class Product
    {
    
        private double price;

        public string Name { get; set; }

        public double Price
        {
            get { return price; }
            set
            {
                if (value >= 0)
                    price = value;
                else
                    Console.WriteLine("Price cannot be negative");
            }
        }

        public virtual double CalculateDiscount()
        {
            return Price;
        }
    }

    class Electronics : Product
    {
        public override double CalculateDiscount()
        {
            return Price - (Price * 0.05);
        }
    }

    class Clothing : Product
    {
        public override double CalculateDiscount()
        {
            return Price - (Price * 0.15);
        }
    }

    class Program1
    {
        static void Main()
        {
            Product electronicProduct = new Electronics();
            electronicProduct.Name = "Laptop";
            electronicProduct.Price = 20000;

            double finalPrice = electronicProduct.CalculateDiscount();

            Console.WriteLine("Final Price after 5% discount = " + finalPrice);
        }
    }
}
