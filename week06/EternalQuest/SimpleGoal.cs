using System;

public class SimpleGoal : Goal
{
    private bool _isComplete;
    
    // Constructor for creating new goals
    public SimpleGoal(string name, string description, int points) 
        : base(name, description, points)
    {
        _isComplete = false;
    }
    
    // Constructor for loading from file
    public SimpleGoal(string name, string description, int points, bool isComplete)
        : base(name, description, points)
    {
        _isComplete = isComplete;
    }
    
    public override void RecordEvent()
    {
        _isComplete = true;
        Console.WriteLine($"Congratulations! You earned {_points} points!");
    }
    
    public override bool IsComplete()
    {
        return _isComplete;
    }
    
    public override string GetDetailsString()
    {
        return base.GetDetailsString();
    }
    
    public override string GetStringRepresentation()
    {
        return $"SimpleGoal:{_shortName},{_description},{_points},{_isComplete}";
    }
}