using System;

public class Program
{
    public static void Main(string[] args)
    {
        Console.Write("Enter your grade percentage: ");
        string gradePercentageStr = Console.ReadLine();

        if (int.TryParse(gradePercentageStr, out int gradePercentage))
        {
            string letter = "";

            if (gradePercentage >= 90)
            {
                letter = "A";
            }
            else if (gradePercentage >= 80)
            {
                letter = "B";
            }
            else if (gradePercentage >= 70)
            {
                letter = "C";
            }
            else if (gradePercentage >= 60)
            {
                letter = "D";
            }
            else
            {
                letter = "F";
            }

            Console.WriteLine($"Your letter grade is: {letter}");

            if (gradePercentage >= 70)
            {
                Console.WriteLine("Congratulations! You passed the course.");
            }
            else
            {
                Console.WriteLine("Hang in there! You'll get it next time.");
            }

            // Stretch Challenge
            string sign = "";
            if (letter != "F")
            {
                int lastDigit = gradePercentage % 10;
                if (lastDigit >= 7 && gradePercentage < 90)
                {
                    sign = "+";
                }
                else if (lastDigit < 3 && gradePercentage >= 60)
                {
                    sign = "-";
                }
            }
            else
            {
                sign = ""; // No sign for F
            }

            if (letter == "A" && gradePercentage >= 97)
            {
                sign = ""; // No A+
            }

            Console.WriteLine($"Your final grade is: {letter}{sign}");
        }
        else
        {
            Console.WriteLine("Invalid input. Please enter a valid grade percentage (a whole number).");
        }
    }
}