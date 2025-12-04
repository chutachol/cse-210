using System;

public abstract class Goal
{
    protected string _shortName;
    protected string _description;
    protected int _points;
    
    // Constructor
    public Goal(string name, string description, int points)
    {
        _shortName = name;
        _description = description;
        _points = points;
    }
    
    // Abstract methods that must be implemented by derived classes
    public abstract void RecordEvent();
    public abstract bool IsComplete();
    
    // Virtual method that can be overridden if needed
    public virtual string GetDetailsString()
    {
        string checkbox = IsComplete() ? "[X]" : "[ ]";
        return $"{checkbox} {_shortName} ({_description})";
    }
    
    // Abstract method for saving/loading
    public abstract string GetStringRepresentation();
    
    // Getter for points (useful for recording events)
    public int GetPoints()
    {
        return _points;
    }
    
    // Getter for name
    public string GetShortName()
    {
        return _shortName;
    }
}