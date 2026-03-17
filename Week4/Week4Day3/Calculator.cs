using System;
 class Calculator
{
    static void Main()
    {
        Console.Write("Enter First Number: ");
        int a= Convert.ToInt32 (Console.ReadLine());
       
        Console.Write("Enter Second Numbere: ");
        int b= Convert.ToInt32 (Console.ReadLine());

        Console.Write("Enter Operator (+, -, *, /): ");
        char op = Convert.ToChar(Console.ReadLine());

        double result = 0;

        switch (op)
        {
            case '+':
                result = a + b;
                Console.WriteLine("Result: " + result);
                break;

            case '-':
                result = a - b;
                Console.WriteLine("Result: " + result);
                break;

            case '*':
                result = a * b;
                Console.WriteLine("Result: " + result);
                break;

            case '/':
                result = a / b;
                Console.WriteLine("Result: " + result);
                break;

            Default:
                Console.WriteLine("Invalid Operator");
                break;
        }


    }
}