using System;

// A goal for breaking bad habits. Recording an event loses points.
public class NegativeGoal : Goal
{
    public NegativeGoal(string name, string description, int points) 
        : base(name, description, points)
    {
    }

    public override int RecordEvent()
    {
        // Returns a negative value to subtract from the score
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("A setback was recorded. Don't give up!");
        Console.ResetColor();
        return -_points;
    }

    public override bool IsComplete()
    {
        // Negative goals are never complete, they are ongoing efforts.
        return false;
    }

    public override string GetDetailsString()
    {
        // Using [-] to visually distinguish it as a negative goal
        return $"[-] {_shortName} ({_description})";
    }

    public override string GetStringRepresentation()
    {
        // Points are stored as positive but applied as negative
        return $"NegativeGoal||{_shortName}||{_description}||{_points}";
    }
}