using System;

namespace Solids
{

    public interface IDiscountStrategy
    {
        double CalculateDiscount(double amount);
    }


    public class RegularCustomerDiscount : IDiscountStrategy
    {
        public double CalculateDiscount(double amount)
        {
            return amount * 0.05;
        }
    }


    public class PremiumCustomerDiscount : IDiscountStrategy
    {
        public double CalculateDiscount(double amount)
        {
            return amount * 0.10;
        }
    }


    public class VipCustomerDiscount : IDiscountStrategy
    {
        public double CalculateDiscount(double amount)
        {
            return amount * 0.20;
        }
    }


    public class DiscountCalculator
    {
        public double GetFinalPrice(double amount, IDiscountStrategy strategy)
        {
            double discount = strategy.CalculateDiscount(amount);
            return amount - discount;
        }
    }

    //  Main Class
    internal class OCP
    {
        public static void Main(string[] args)
        {
            DiscountCalculator calculator = new DiscountCalculator();

            double amount = 1000;

            IDiscountStrategy regular = new RegularCustomerDiscount();
            IDiscountStrategy premium = new PremiumCustomerDiscount();
            IDiscountStrategy vip = new VipCustomerDiscount();

            Console.WriteLine("Regular Final Price: " + calculator.GetFinalPrice(amount, regular));
            Console.WriteLine("Premium Final Price: " + calculator.GetFinalPrice(amount, premium));
            Console.WriteLine("VIP Final Price: " + calculator.GetFinalPrice(amount, vip));

            Console.ReadLine();
        }
    }
}