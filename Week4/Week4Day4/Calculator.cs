using System;

class Calculator
{
    public int Add(int x, int y)
    {
        return x + y;
    }

    public int Subtract(int x,int y)
    {
        return x - y;
    }
}


class DemoCalculator
{
    static void Main()
    {
        Calculator c = new Calculator();

        // int num1 = 10;
        //int num2 = 20;

        Console.WriteLine("Enter Num1: " );
        int num1=Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("Enter Num2: ");
        int num2=Convert.ToInt32(Console.ReadLine());

        int addition=c.Add(num1 , num2);
        int subtraction = c.Subtract(num1, num2);


        Console.WriteLine("Addition = " + addition);
        Console.WriteLine("Subtraction = " + subtraction);
    }
}