using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Handson4
{
    internal class AvgMarks
    {
        class Student
        {
            public double CalculateAverage(int m1, int m2, int m3)
            {
                double avg = (m1 + m2 + m3) / 3.0;
                return avg;
            }
        }


        class StudentMarks
        {
            static void Main()
            {
                Console.WriteLine("Enter Marks1: ");
                int m1 = Convert.ToInt32(Console.ReadLine());

                Console.WriteLine("Enter Marks2: ");
                int m2 = Convert.ToInt32(Console.ReadLine());

                Console.WriteLine("Enter Marks3: ");
                int m3 = Convert.ToInt32(Console.ReadLine());


                Student s = new Student();

                double avg = s.CalculateAverage(m1, m2, m3);

                string grade;

                if (avg >= 80)
                    grade = "A";

                else if (avg >= 60 && avg < 80)
                    grade = "B";
                else if (avg >= 40 && avg < 60)
                    grade = "C";
                else
                    grade = "Fail";

                Console.WriteLine("Average =" + avg);
                Console.WriteLine("Grade = " + grade);
            }
        }

    }
}
