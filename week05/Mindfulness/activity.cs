public abstract class Activity
{
    protected string _name;
    protected string _description;
    protected int _duration;

    // Abstract method to be implemented by each derived class
    public abstract void Run();

    // Orchestrates the standard flow of an activity
    public void StartActivity()
    {
        DisplayStartingMessage();
        Run();
        DisplayEndingMessage();
    }

    // Displays the initial welcome message and prompts for duration
    private void DisplayStartingMessage()
    {
        Console.Clear();
        Console.WriteLine($"Welcome to the {_name}.");
        Console.WriteLine($"\n{_description}");
        Console.Write("\nHow long, in seconds, would you like for your session? ");
        _duration = int.Parse(Console.ReadLine());

        Console.Clear();
        Console.WriteLine("Get ready...");
        ShowSpinner(5);
    }

    // Displays the concluding message
    private void DisplayEndingMessage()
    {
        Console.WriteLine("\nWell done!! 👍");
        ShowSpinner(3);
        Console.WriteLine($"\nYou have completed another {_duration} seconds of the {_name}.");
        ShowSpinner(5);
    }

    // Shows a spinner animation for a specified duration
    protected void ShowSpinner(int seconds)
    {
        List<string> animationStrings = new List<string> { "|", "/", "-", "\\" };
        DateTime endTime = DateTime.Now.AddSeconds(seconds);
        int i = 0;

        while (DateTime.Now < endTime)
        {
            string s = animationStrings[i];
            Console.Write(s);
            Thread.Sleep(250);
            Console.Write("\b \b"); // Erase the character

            i++;
            if (i >= animationStrings.Count)
            {
                i = 0;
            }
        }
    }

    // Shows a countdown timer for a specified duration
    protected void ShowCountDown(int seconds)
    {
        for (int i = seconds; i > 0; i--)
        {
            Console.Write(i);
            Thread.Sleep(1000);
            Console.Write("\b \b"); // Erase the number
        }
    }
}