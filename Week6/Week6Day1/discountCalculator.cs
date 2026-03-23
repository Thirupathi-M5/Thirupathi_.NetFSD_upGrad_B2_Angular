using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace W6handson1
{
    internal class discountCalculator
    {
        static void Main(string[] args)
        {
            Console.Write("Enter Product Name: ");
            string productName = Console.ReadLine();

            Console.Write("Enter Product Price: ");
            double price = Convert.ToDouble(Console.ReadLine());

            Console.Write("Enter Discount Percentage: ");
            double discount = Convert.ToDouble(Console.ReadLine());


            double finalPrice = price - (price * discount / 100);

            Console.WriteLine("\n----- BILL -----");
            Console.WriteLine($"Product: {productName}");
            Console.WriteLine($"Original Price: {price}");
            Console.WriteLine($"Discount: {discount}%");
            Console.WriteLine($"Final Price: {finalPrice}");
        }

    }
}
