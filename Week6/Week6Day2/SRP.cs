using System;
using System.Collections.Generic;

namespace Solids
{

    public class Student
    {
        public int StudentId { get; set; }
        public string StudentName { get; set; }
        public double Marks { get; set; }
    }


    public class StudentRepository
    {
        private List<Student> students = new List<Student>();

        public void AddStudent(Student student)
        {
            students.Add(student);
        }

        public List<Student> GetAllStudents()
        {
            return students;
        }
    }


    public class ReportGenerator
    {
        public void GenerateReport(List<Student> students)
        {
            Console.WriteLine("----- Student Report -----");

            foreach (var student in students)
            {
                string result = student.Marks >= 40 ? "Pass" : "Fail";

                Console.WriteLine($"ID: {student.StudentId}");
                Console.WriteLine($"Name: {student.StudentName}");
                Console.WriteLine($"Marks: {student.Marks}");
                Console.WriteLine($"Result: {result}");
                Console.WriteLine("------");
            }
        }
    }


    internal class SRP
    {
        public static void Main(string[] args)
        {

            StudentRepository repo = new StudentRepository();

            repo.AddStudent(new Student { StudentId = 1, StudentName = "Ranii", Marks = 90 });
            repo.AddStudent(new Student { StudentId = 2, StudentName = "Raju", Marks = 83 });
            repo.AddStudent(new Student { StudentId = 3, StudentName = "Sita", Marks = 95 });
            repo.AddStudent(new Student { StudentId = 3, StudentName = "Ram", Marks = 88 });

            ReportGenerator report = new ReportGenerator();
            report.GenerateReport(repo.GetAllStudents());

            Console.ReadLine();
        }
    }
}