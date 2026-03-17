using System;
using System.Collections.Generic;
using System.Linq;


namespace W5Handson1
{
    internal class StudentScoreDS
    {
        static void Main()
        {
            // Step 1: Store marks in array
            int[] marks = { 78, 85, 90, 67, 88 };

            int threshold = 80;

            // Step 2: Calculate Total using Sum() (like reduce)
            int totalMarks = marks.Sum();

            // Step 3: Calculate Average
            double averageMarks = marks.Average();

            // Step 4: Find Highest Score
            int highestScore = marks.Max();

            // Step 5: Filter students above threshold (like filter)
            var aboveThreshold = marks.Where(m => m > threshold).ToArray();

            int countAboveThreshold = aboveThreshold.Length;

            // Step 6: Using Dictionary (Map) for subject-wise highest marks
            Dictionary<string, int> subjectHighest = new Dictionary<string, int>();

            subjectHighest["Math"] = 90;
            subjectHighest["Science"] = 88;
            subjectHighest["English"] = 85;

            // Output
            Console.WriteLine("Total Marks: " + totalMarks);
            Console.WriteLine("Average Marks: " + averageMarks);
            Console.WriteLine("Students above " + threshold + ": " + countAboveThreshold);
            Console.WriteLine("Highest Score: " + highestScore);

            Console.WriteLine("\nSubject-wise Highest Marks:");
            foreach (var subject in subjectHighest)
            {
                Console.WriteLine(subject.Key + ": " + subject.Value);
            }
        }
    }
}
