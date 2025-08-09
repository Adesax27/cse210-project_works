using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

// Manages all goals, user score, and file operations.
public class GoalManager
{
    private List<Goal> _goals;
    private int _score;

    public GoalManager()
    {
        _goals = new List<Goal>();
        _score = 0;
    }

    // Main loop for the user menu
    public void Start()
    {
        Console.WriteLine("Welcome to the Eternal Quest Program!");
        bool running = true;
        while (running)
        {
            DisplayPlayerInfo();

            Console.WriteLine("\nMenu Options:");
            Console.WriteLine("  1. Create New Goal");
            Console.WriteLine("  2. List Goals");
            Console.WriteLine("  3. Save Goals");
            Console.WriteLine("  4. Load Goals");
            Console.WriteLine("  5. Record Event");
            Console.WriteLine("  6. Quit");
            Console.Write("Select a choice from the menu: ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    CreateGoal();
                    break;
                case "2":
                    ListGoalDetails();
                    break;
                case "3":
                    SaveGoals();
                    break;
                case "4":
                    LoadGoals();
                    break;
                case "5":
                    RecordEvent();
                    break;
                case "6":
                    running = false;
                    Console.WriteLine("\nThank you for using the Eternal Quest Program. Keep striving!");
                    break;
                default:
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("\nInvalid option. Please try again.");
                    Console.ResetColor();
                    break;
            }
        }
    }

    // Displays the current score and level
    public void DisplayPlayerInfo()
    {
        // Creative addition: Leveling system
        int level = _score / 1000;
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine($"\nYou have {_score} points. (Level {level})");
        Console.ResetColor();
    }

    // Lists the details of all goals
    public void ListGoalDetails()
    {
        Console.WriteLine("\nYour Goals are:");
        if (_goals.Count == 0)
        {
            Console.WriteLine("You have not set any goals yet.");
            return;
        }
        for (int i = 0; i < _goals.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {_goals[i].GetDetailsString()}");
        }
    }

    // Prompts user for goal details and creates a new goal
    public void CreateGoal()
    {
        Console.WriteLine("\nThe types of Goals are:");
        Console.WriteLine("  1. Simple Goal (one-time completion)");
        Console.WriteLine("  2. Eternal Goal (never-ending)");
        Console.WriteLine("  3. Checklist Goal (complete a number of times)");
        Console.WriteLine("  4. Negative Goal (for breaking bad habits)");
        Console.Write("Which type of goal would you like to create? ");
        string type = Console.ReadLine();

        Console.Write("What is the name of your goal? ");
        string name = Console.ReadLine();
        Console.Write("What is a short description of it? ");
        string description = Console.ReadLine();
        Console.Write("What is the amount of points associated with this goal? ");
        int points = int.Parse(Console.ReadLine());

        switch (type)
        {
            case "1":
                _goals.Add(new SimpleGoal(name, description, points));
                break;
            case "2":
                _goals.Add(new EternalGoal(name, description, points));
                break;
            case "3":
                Console.Write("How many times does this goal need to be accomplished for a bonus? ");
                int target = int.Parse(Console.ReadLine());
                Console.Write("What is the bonus for accomplishing it that many times? ");
                int bonus = int.Parse(Console.ReadLine());
                _goals.Add(new ChecklistGoal(name, description, points, target, bonus));
                break;
            case "4":
                // For negative goals, we store points as a positive value but apply it negatively
                _goals.Add(new NegativeGoal(name, description, points));
                break;
            default:
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Invalid goal type.");
                Console.ResetColor();
                break;
        }
    }
    
    // Records an event for a chosen goal
    public void RecordEvent()
    {
        Console.WriteLine("\nWhich goal did you accomplish?");
        for (int i = 0; i < _goals.Count; i++)
        {
            Console.WriteLine($"  {i + 1}. {_goals[i].GetName()}");
        }
        Console.Write("Select a goal: ");
        if (int.TryParse(Console.ReadLine(), out int goalIndex) && goalIndex > 0 && goalIndex <= _goals.Count)
        {
            int pointsEarned = _goals[goalIndex - 1].RecordEvent();
            _score += pointsEarned;
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"\nCongratulations! You have earned {pointsEarned} points!");
            Console.ResetColor();
        }
        else
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Invalid selection.");
            Console.ResetColor();
        }
    }

    // Saves the current goals and score to a file
    public void SaveGoals()
    {
        Console.Write("\nWhat is the filename for the goal file? ");
        string filename = Console.ReadLine();

        using (StreamWriter outputFile = new StreamWriter(filename))
        {
            outputFile.WriteLine(_score);
            foreach (Goal goal in _goals)
            {
                outputFile.WriteLine(goal.GetStringRepresentation());
            }
        }
        Console.WriteLine("Saving... Goals saved successfully!");
    }

    // Loads goals and score from a file
    public void LoadGoals()
    {
        Console.Write("\nWhat is the filename for the goal file? ");
        string filename = Console.ReadLine();
        if (!File.Exists(filename))
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("File not found.");
            Console.ResetColor();
            return;
        }

        string[] lines = File.ReadAllLines(filename);
        _score = int.Parse(lines[0]);
        _goals.Clear(); // Clear existing goals before loading

        for (int i = 1; i < lines.Length; i++)
        {
            string[] parts = lines[i].Split("||");
            string type = parts[0];
            string name = parts[1];
            string description = parts[2];
            int points = int.Parse(parts[3]);

            Goal goal = null;
            if (type == "SimpleGoal")
            {
                bool isComplete = bool.Parse(parts[4]);
                goal = new SimpleGoal(name, description, points, isComplete);
            }
            else if (type == "EternalGoal")
            {
                goal = new EternalGoal(name, description, points);
            }
            else if (type == "ChecklistGoal")
            {
                int bonus = int.Parse(parts[4]);
                int target = int.Parse(parts[5]);
                int amountCompleted = int.Parse(parts[6]);
                goal = new ChecklistGoal(name, description, points, target, bonus, amountCompleted);
            }
            else if (type == "NegativeGoal")
            {
                 goal = new NegativeGoal(name, description, points);
            }
            
            if (goal != null)
            {
                _goals.Add(goal);
            }
        }
        Console.WriteLine("Loading... Goals loaded successfully!");
    }
}