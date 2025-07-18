// Program.cs
using System;

public class Program
{
    public static void Main(string[] args)
    {
        Reference reference = new Reference("John", 3, 16);
        string scriptureText = "For God so loved the world, that he gave his only begotten Son, that whosoever believeth in him should not perish, but have everlasting life.";
        Scripture scripture = new Scripture(reference, scriptureText);

        Console.WriteLine("Welcome to the Scripture Memorizer!");
        Console.WriteLine("Press Enter to hide words, type 'quit' to exit.");

        while (!scripture.AreAllWordsHidden())
        {
            Console.Clear();
            Console.WriteLine(scripture.GetDisplayText());

            Console.Write("> ");
            string input = Console.ReadLine();

            if (input.ToLower() == "quit")
            {
                break;
            }
            else if (string.IsNullOrEmpty(input))
            {
                scripture.HideRandomWords(3); // Hide a few words at a time
            }
        }

        Console.Clear();
        Console.WriteLine(scripture.GetDisplayText());
        Console.WriteLine("Congratulations! All words are hidden.");
    }
}

// Showing Creativity and Exceeding Requirements:
// The HideRandomWords method in the Scripture class (in Scripture.cs) now attempts to only hide words that are not already hidden.
// It maintains a list of unhidden words and selects randomly from that list. This prevents the program from repeatedly hiding words that are already obscured.