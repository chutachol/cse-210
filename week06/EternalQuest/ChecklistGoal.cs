using System;

public class ChecklistGoal : Goal
{
    private int _amountCompleted;
    private int _target;
    private int _bonus;
    
    // Constructor for creating new goals
    public ChecklistGoal(string name, string description, int points, int target, int bonus) 
        : base(name, description, points)
    {
        _amountCompleted = 0;
        _target = target;
        _bonus = bonus;
    }
    
    // Constructor for loading from file
    public ChecklistGoal(string name, string description, int points, int amountCompleted, int target, int bonus)
        : base(name, description, points)
    {
        _amountCompleted = amountCompleted;
        _target = target;
        _bonus = bonus;
    }
    
    public override void RecordEvent()
    {
        _amountCompleted++;
        
        if (_amountCompleted >= _target)
        {
            int totalPoints = _points + _bonus;
            Console.WriteLine($"Congratulations! You earned {_points} points!");
            Console.WriteLine($"Bonus! You earned {_bonus} extra points for completing the goal!");
            Console.WriteLine($"Total points earned: {totalPoints}");
        }
        else
        {
            Console.WriteLine($"Congratulations! You earned {_points} points!");
            Console.WriteLine($"You have now completed {_amountCompleted}/{_target} times.");
        }
    }
    
    public override bool IsComplete()
    {
        return _amountCompleted >= _target;
    }
    
    public override string GetDetailsString()
    {
        string baseString = base.GetDetailsString();
        return $"{baseString} -- Currently completed: {_amountCompleted}/{_target}";
    }
    
    public override string GetStringRepresentation()
    {
        return $"ChecklistGoal:{_shortName},{_description},{_points},{_amountCompleted},{_target},{_bonus}";
    }
    
    // Additional method specific to ChecklistGoal
    public int GetBonus()
    {
        return _bonus;
    }
}