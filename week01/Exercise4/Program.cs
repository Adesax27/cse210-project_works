using System;
using System.Collections.Generic;
using System.Linq;

public class Program
{
    public static void Main(string[] args)
    {
        List<int> numbers = new List<int>();
        Console.WriteLine("Enter a list of numbers, type 0 when finished.");

        int inputNumber;
        do
        {
            Console.Write("Enter number: ");
            string input = Console.ReadLine();
            if (int.TryParse(input, out inputNumber) && inputNumber != 0)
            {
                numbers.Add(inputNumber);
            }
            else if (inputNumber != 0)
            {
                Console.WriteLine("Invalid input. Please enter a whole number.");
            }
        } while (inputNumber != 0);

        // Core Requirements
        if (numbers.Count > 0)
        {
            int sum = numbers.Sum();
            Console.WriteLine($"The sum is: {sum}");

            double average = (double)sum / numbers.Count;
            Console.WriteLine($"The average is: {average}");

            int maxNumber = numbers.Max();
            Console.WriteLine($"The largest number is: {maxNumber}");

            // Stretch Challenges
            int smallestPositive = numbers.Where(n => n > 0).DefaultIfEmpty(0).Min();
            if (smallestPositive > 0)
            {
                Console.WriteLine($"The smallest positive number is: {smallestPositive}");
            }

            numbers.Sort();
            Console.WriteLine("The sorted list is:");
            foreach (int number in numbers)
            {
                Console.WriteLine(number);
            }
        }
        else
        {
            Console.WriteLine("No numbers were entered.");
        }
    }
}