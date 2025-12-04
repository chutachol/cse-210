using System;

public class EternalGoal : Goal
{
    // Constructor
    public EternalGoal(string name, string description, int points) 
        : base(name, description, points)
    {
    }
    
    // Constructor for loading from file
    public EternalGoal(string name, string description, int points, string extra)
        : base(name, description, points)
    {
        // Extra parameter is unused for EternalGoal, but needed for consistency
    }
    
    public override void RecordEvent()
    {
        Console.WriteLine($"Congratulations! You earned {_points} points!");
    }
    
    public override bool IsComplete()
    {
        // Eternal goals are never complete
        return false;
    }
    
    public override string GetDetailsString()
    {
        return base.GetDetailsString();
    }
    
    public override string GetStringRepresentation()
    {
        return $"EternalGoal:{_shortName},{_description},{_points}";
    }
}