using System;

namespace Solids
{

    public abstract class Shape
    {
        public abstract double CalculateArea();
    }


    public class Rectangle : Shape
    {
        public double Length { get; set; }
        public double Width { get; set; }

        public override double CalculateArea()
        {
            return Length * Width;
        }
    }


    public class Circle : Shape
    {
        public double Radius { get; set; }

        public override double CalculateArea()
        {
            return Math.PI * Radius * Radius;
        }
    }

    public class AreaCalculator
    {
        public void PrintArea(Shape shape)
        {
            Console.WriteLine("Area: " + shape.CalculateArea());
        }
    }

    // Main Class
    internal class LSP
    {
        public static void Main(string[] args)
        {
            AreaCalculator calculator = new AreaCalculator();


            Shape rect = new Rectangle { Length = 20, Width = 10 };
            calculator.PrintArea(rect);

            Shape circle = new Circle { Radius = 7 };
            calculator.PrintArea(circle);

            Console.ReadLine();
        }
    }
}