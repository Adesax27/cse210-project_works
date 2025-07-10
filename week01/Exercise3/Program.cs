using System;

public class Program
{
    public static void Main(string[] args)
    {
        string playAgain = "yes";

        while (playAgain.ToLower() == "yes")
        {
            // Core Requirement: Generate a random magic number between 1 and 100
            Random random = new Random();
            int magicNumber = random.Next(1, 101);

            int guess = -1;
            int guesses = 0;

            Console.WriteLine("I have chosen a magic number between 1 and 100. Try to guess it!");

            // Core Requirement: Add a loop that continues until the guess matches the magic number
            while (guess != magicNumber)
            {
                // Core Requirement: Ask the user for a guess
                Console.Write("What is your guess? ");
                string guessStr = Console.ReadLine();

                if (int.TryParse(guessStr, out guess))
                {
                    guesses++;

                    // Core Requirement: Determine if the guess is higher or lower
                    if (guess < magicNumber)
                    {
                        Console.WriteLine("Higher");
                    }
                    else if (guess > magicNumber)
                    {
                        Console.WriteLine("Lower");
                    }
                    else
                    {
                        Console.WriteLine($"You guessed it!");
                        // Stretch Challenge: Inform the user of the number of guesses
                        Console.WriteLine($"It took you {guesses} guesses.");
                    }
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter a whole number.");
                }
            }

            // Stretch Challenge: Ask the user if they want to play again
            Console.Write("Do you want to play again? (yes/no): ");
            playAgain = Console.ReadLine();
        }

        Console.WriteLine("Thank you for playing!");
    }
}