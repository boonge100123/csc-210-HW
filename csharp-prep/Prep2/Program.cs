using System;

class Program
{
    // Marking determine_grade as static so Main() can call it
    static string DetermineGrade(float score)
    {
        if (score >= 90)
            return "A";
        else if (score >= 80)
            return "B";
        else if (score >= 70)
            return "C";
        else if (score >= 60)
            return "D";
        else
            return "F";
    }

    static void Main(string[] args)
    {
        Console.Write("What is your Grade?: ");
        
        // Error handling for invalid input
        if (float.TryParse(Console.ReadLine(), out float score))
        {
            string grade = DetermineGrade(score);
            Console.WriteLine("Your grade is: " + grade);
        }
        else
        {
            Console.WriteLine("Invalid input! Please enter a number.");
        }
    }
}
