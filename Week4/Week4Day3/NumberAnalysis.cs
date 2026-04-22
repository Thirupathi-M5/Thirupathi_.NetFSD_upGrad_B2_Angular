using System;
class NumberAnalysis
{
    public static void Main()
    {
        Console.WriteLine("Enter Number");
        int n= Convert.ToInt32(Console.ReadLine());

        int evenCount = 0;
        int oddCount = 0;
        int sum = 0;

        for(int i = 0; i <= n; i++)
        {
            sum = sum + i;
            if (i % 2 == 0)
            {
                evenCount++;
            }
            else
            {
                oddCount++;
            }

        }

        Console.WriteLine("Even Count : " + evenCount);
        Console.WriteLine("Odd Count : " + oddCount);
        Console.WriteLine("Sum : " + sum);
    }
}