// Program.cs
using System;
using System.Collections.Generic;
using System.Linq;

public class Program
{
    public static void Main(string[] args)
    {
        Journal journal = new Journal();
        List<string> prompts = new List<string>()
        {
            "Who was the most interesting person I interacted with today?",
            "What was the best part of my day?",
            "How did I see the hand of the Lord in my life today?",
            "What was the strongest emotion I felt today?",
            "If I had one thing I could do over today, what would it be?",
            "What am I grateful for today?",
            "What did I learn new today?",
            "What is a goal I worked on today?"
        };

        string choice = "";
        while (choice != "5")
        {
            Console.WriteLine("Welcome to the Journal Program!");
            Console.WriteLine("Please select one of the following choices:");
            Console.WriteLine("1. Write a new entry");
            Console.WriteLine("2. Display the journal");
            Console.WriteLine("3. Save the journal to a file");
            Console.WriteLine("4. Load the journal from a file");
            Console.WriteLine("5. Quit");
            Console.Write("Enter your choice: ");

            choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    Console.WriteLine();
                    Random random = new Random();
                    int promptIndex = random.Next(prompts.Count);
                    string prompt = prompts[promptIndex];
                    Console.WriteLine($"Today's prompt is: {prompt}");
                    Console.Write("> ");
                    string response = Console.ReadLine();
                    journal.AddEntry(prompt, response);
                    Console.WriteLine("Entry added.");
                    Console.WriteLine();
                    break;
                case "2":
                    Console.WriteLine();
                    journal.DisplayJournal();
                    break;
                case "3":
                    Console.WriteLine();
                    Console.Write("Enter the filename to save to (e.g., journal.txt): ");
                    string saveFilename = Console.ReadLine();
                    journal.SaveJournalToFile(saveFilename);
                    break;
                case "4":
                    Console.WriteLine();
                    Console.Write("Enter the filename to load from (e.g., journal.txt): ");
                    string loadFilename = Console.ReadLine();
                    journal.LoadJournalFromFile(loadFilename);
                    break;
                case "5":
                    Console.WriteLine();
                    Console.WriteLine("Thank you for using the Journal Program!");
                    break;
                default:
                    Console.WriteLine();
                    Console.WriteLine("Invalid choice. Please enter a number from 1 to 5.");
                    Console.WriteLine();
                    break;
            }
        }
    }
}

// Showing Creativity and Exceeding Requirements:
// The program saves the journal entries to a text file. Each entry is stored with its date (converted to binary for accurate saving and loading), the prompt, and the response.
// This ensures that the date is preserved correctly when loading the journal back into the program.