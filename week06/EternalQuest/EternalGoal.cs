using System;

// A goal that is never complete and can be recorded multiple times.
public class EternalGoal : Goal
{
    public EternalGoal(string name, string description, int points) 
        : base(name, description, points)
    {
    }

    public override int RecordEvent()
    {
        // Always awards points when recorded
        return _points;
    }

    public override bool IsComplete()
    {
        // An eternal goal is never "complete"
        return false;
    }

    public override string GetDetailsString()
    {
        return $"[ ] {_shortName} ({_description})";
    }

    public override string GetStringRepresentation()
    {
        return $"EternalGoal||{_shortName}||{_description}||{_points}";
    }
}