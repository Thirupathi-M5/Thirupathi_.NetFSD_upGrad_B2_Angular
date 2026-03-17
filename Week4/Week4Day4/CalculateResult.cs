using System;


namespace Handson4
{
    internal class CalculateResult
    {
        static void CalResult(int m1, int m2, int m3, out int total, out double average)
        {
            total = m1 + m2 + m3;
            average = total / 3.0;
        }

        static void Main()
        {
            char choice;

            do
            {
                Console.Write("Enter Marks 1: ");
                int m1 = Convert.ToInt32(Console.ReadLine());

                Console.Write("Enter Marks 2: ");
                int m2 = Convert.ToInt32(Console.ReadLine());

                Console.Write("Enter Marks 3: ");
                int m3 = Convert.ToInt32(Console.ReadLine());

                if (m1 < 0 || m1 > 100 || m2 < 0 || m2 > 100 || m3 < 0 || m3 > 100)
                {
                    Console.WriteLine("Invalid marks! Enter values between 0 and 100.");
                    return;
                }

                int totalMarks;
                double averageMarks;

                CalResult(m1, m2, m3, out totalMarks, out averageMarks);

                Console.WriteLine("Total Marks = " + totalMarks);
                Console.WriteLine("Average Marks = " + averageMarks);

                if (averageMarks >= 40)
                    Console.WriteLine("Result: Pass");
                else
                    Console.WriteLine("Result: Fail");

                Console.Write("Do you want to enter another student? (y/n): ");
                choice = Convert.ToChar(Console.ReadLine());

            } while (choice == 'y' || choice == 'Y');
        }
    }
}
