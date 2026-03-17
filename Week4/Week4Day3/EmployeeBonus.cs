using System;

class EmployeeBonus
{
    public static void Main()
    {
        Console.Write("Enter Name: ");
        string name = Console.ReadLine();

        Console.Write("Enter Salary: ");
        double salary = Convert.ToDouble(Console.ReadLine());

        Console.Write("Enter Experience (years): ");
        int experience = Convert.ToInt32(Console.ReadLine());

        double BonusPercent;
         if(experience < 2)
        {
            BonusPercent = 0.05;
        }
        else if(experience>= 2 && experience<=5) {
            BonusPercent = 0.10;
    }
        else
        {
            BonusPercent = 0.15;
        }

        double Bonus = salary * BonusPercent;
        double finalsalary = salary + Bonus;

        Console.WriteLine("Employee: " + name);
        Console.WriteLine("Bonus: " + Bonus);
        Console.WriteLine("Final Salary: " + finalsalary);
    }

}