// W05 Project: Mindfulness Program
// Author: Ademola Samuel Okunjoyo
// CSE 210 - C#
//
// --- EXCEEDING REQUIREMENTS ---
// To exceed the requirements, I implemented a feature in the Reflection Activity
// to ensure that no random question is repeated until all questions from the list have been shown at least once
// in a single session. This is achieved by creating a temporary copy of the question list,
// drawing questions from it, and removing them after they are displayed. If the temporary list
// becomes empty, it is refilled from the master list, allowing the cycle to start over if the
// activity duration is long enough.

class Program
{
    static void Main(string[] args)
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("Menu Options:");
            Console.WriteLine("  1. Start Breathing Activity");
            Console.WriteLine("  2. Start Reflection Activity");
            Console.WriteLine("  3. Start Listing Activity");
            Console.WriteLine("  4. Quit");
            Console.Write("Select a choice from the menu: ");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    BreathingActivity breathing = new BreathingActivity();
                    breathing.StartActivity();
                    break;
                case "2":
                    ReflectionActivity reflection = new ReflectionActivity();
                    reflection.StartActivity();
                    break;
                case "3":
                    ListingActivity listing = new ListingActivity();
                    listing.StartActivity();
                    break;
                case "4":
                    Console.WriteLine("Thank you for using the Mindfulness App. Goodbye! 👋");
                    return;
                default:
                    Console.WriteLine("Invalid choice. Please select a number from 1 to 4.");
                    Thread.Sleep(2000);
                    break;
            }
        }
    }
}