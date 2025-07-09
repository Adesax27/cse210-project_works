using System;

public class Program
{
    public static void DisplayWelcome()
    {
        Console.WriteLine("Welcome to the program!");
    }

    public static string PromptUserName()
    {
        Console.Write("Please enter your name: ");
        return Console.ReadLine();
    }

    public static int PromptUserNumber()
    {
        Console.Write("Please enter your favorite number: ");
        string input = Console.ReadLine();
        if (int.TryParse(input, out int number))
        {
            return number;
        }
        else
        {
            Console.WriteLine("Invalid input. Please enter a whole number.");
            return PromptUserNumber(); // Recursive call to ask again
        }
    }

    public static int SquareNumber(int number)
    {
        return number * number;
    }

    public static void DisplayResult(string name, int squaredNumber)
    {
        Console.WriteLine($"{name}, the square of your number is {squaredNumber}");
    }

    public static void Main(string[] args)
    {
        DisplayWelcome();
        string userName = PromptUserName();
        int favoriteNumber = PromptUserNumber();
        int squaredNumber = SquareNumber(favoriteNumber);
        DisplayResult(userName, squaredNumber);
    }
}