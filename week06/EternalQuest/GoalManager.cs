using System;
using System.Collections.Generic;
using System.IO;

public class GoalManager
{
    private List<Goal> _goals;
    private int _score;
    
    public GoalManager()
    {
        _goals = new List<Goal>();
        _score = 0;
    }
    
    public void Start()
    {
        while (true)
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
                    Console.WriteLine("Goodbye! Keep working on your eternal quest!");
                    return;
                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;
            }
            
            Console.WriteLine("\nPress any key to continue...");
            Console.ReadKey();
            Console.Clear();
        }
    }
    
    public void DisplayPlayerInfo()
    {
        Console.WriteLine($"\n=== Eternal Quest ===");
        Console.WriteLine($"Current Score: {_score} points");
        
        // Level system (exceeding requirements)
        int level = _score / 1000 + 1;
        string title = GetTitleForLevel(level);
        Console.WriteLine($"Level: {level} ({title})");
        
        // Progress bar (exceeding requirements)
        int progress = _score % 1000;
        Console.Write($"Progress to next level: [");
        for (int i = 0; i < 20; i++)
        {
            if (i < progress / 50)
                Console.Write("█");
            else
                Console.Write(" ");
        }
        Console.WriteLine($"] {progress}/1000");
    }
    
    private string GetTitleForLevel(int level)
    {
        if (level < 5) return "Novice";
        else if (level < 10) return "Apprentice";
        else if (level < 15) return "Adept";
        else if (level < 20) return "Expert";
        else if (level < 30) return "Master";
        else return "Legend";
    }
    
    public void ListGoalNames()
    {
        Console.WriteLine("\nThe goals are:");
        for (int i = 0; i < _goals.Count; i++)
        {
            Console.WriteLine($"  {i + 1}. {_goals[i].GetShortName()}");
        }
    }
    
    public void ListGoalDetails()
    {
        if (_goals.Count == 0)
        {
            Console.WriteLine("\nNo goals yet. Create some goals to get started!");
            return;
        }
        
        Console.WriteLine("\nYour Goals:");
        for (int i = 0; i < _goals.Count; i++)
        {
            Console.WriteLine($"  {i + 1}. {_goals[i].GetDetailsString()}");
        }
    }
    
    public void CreateGoal()
    {
        Console.WriteLine("\nThe types of Goals are:");
        Console.WriteLine("  1. Simple Goal");
        Console.WriteLine("  2. Eternal Goal");
        Console.WriteLine("  3. Checklist Goal");
        Console.Write("Which type of goal would you like to create? ");
        
        string typeChoice = Console.ReadLine();
        
        Console.Write("What is the name of your goal? ");
        string name = Console.ReadLine();
        
        Console.Write("What is a short description of it? ");
        string description = Console.ReadLine();
        
        Console.Write("What is the amount of points associated with this goal? ");
        int points = int.Parse(Console.ReadLine());
        
        switch (typeChoice)
        {
            case "1":
                _goals.Add(new SimpleGoal(name, description, points));
                Console.WriteLine($"Simple goal '{name}' created!");
                break;
                
            case "2":
                _goals.Add(new EternalGoal(name, description, points));
                Console.WriteLine($"Eternal goal '{name}' created!");
                break;
                
            case "3":
                Console.Write("How many times does this goal need to be accomplished for a bonus? ");
                int target = int.Parse(Console.ReadLine());
                
                Console.Write("What is the bonus for accomplishing it that many times? ");
                int bonus = int.Parse(Console.ReadLine());
                
                _goals.Add(new ChecklistGoal(name, description, points, target, bonus));
                Console.WriteLine($"Checklist goal '{name}' created!");
                Console.WriteLine($"Complete this goal {target} times to earn a {bonus} point bonus!");
                break;
                
            default:
                Console.WriteLine("Invalid goal type.");
                break;
        }
    }
    
    public void RecordEvent()
    {
        if (_goals.Count == 0)
        {
            Console.WriteLine("\nNo goals to record. Create some goals first!");
            return;
        }
        
        ListGoalNames();
        Console.Write("Which goal did you accomplish? ");
        
        if (int.TryParse(Console.ReadLine(), out int goalNumber) && 
            goalNumber >= 1 && goalNumber <= _goals.Count)
        {
            Goal selectedGoal = _goals[goalNumber - 1];
            
            // Check if it's already complete (for SimpleGoal)
            if (selectedGoal is SimpleGoal simpleGoal && simpleGoal.IsComplete())
            {
                Console.WriteLine("This goal has already been completed!");
                return;
            }
            
            // Record the event
            selectedGoal.RecordEvent();
            
            // Update score
            _score += selectedGoal.GetPoints();
            
            // Add bonus for checklist goals if completed
            if (selectedGoal is ChecklistGoal checklistGoal && checklistGoal.IsComplete())
            {
                _score += checklistGoal.GetBonus();
            }
            
            // Check for achievements (exceeding requirements)
            CheckAchievements();
        }
        else
        {
            Console.WriteLine("Invalid goal number.");
        }
    }
    
    private void CheckAchievements()
    {
        // Achievement system (exceeding requirements)
        int completedGoals = _goals.Count(g => g.IsComplete());
        
        if (completedGoals == 1)
        {
            Console.WriteLine("\n Achievement Unlocked: First Step!");
            Console.WriteLine("You completed your first goal!");
        }
        else if (completedGoals == 5)
        {
            Console.WriteLine("\n Achievement Unlocked: Goal Getter!");
            Console.WriteLine("You've completed 5 goals!");
            _score += 100; // Bonus points for achievement
        }
        else if (completedGoals == 10)
        {
            Console.WriteLine("\n Achievement Unlocked: Master Achiever!");
            Console.WriteLine("You've completed 10 goals!");
            _score += 250; // Bonus points for achievement
        }
    }
    
    public void SaveGoals()
    {
        Console.Write("What is the filename for the goal file? ");
        string filename = Console.ReadLine();
        
        using (StreamWriter outputFile = new StreamWriter(filename))
        {
            // Save the score first
            outputFile.WriteLine($"Score:{_score}");
            
            // Save each goal
            foreach (Goal goal in _goals)
            {
                outputFile.WriteLine(goal.GetStringRepresentation());
            }
        }
        
        Console.WriteLine($"Goals saved to {filename}");
    }
    
    public void LoadGoals()
    {
        Console.Write("What is the filename for the goal file? ");
        string filename = Console.ReadLine();
        
        if (!File.Exists(filename))
        {
            Console.WriteLine("File not found.");
            return;
        }
        
        string[] lines = File.ReadAllLines(filename);
        
        // Clear current goals
        _goals.Clear();
        
        foreach (string line in lines)
        {
            string[] parts = line.Split(':');
            
            if (parts[0] == "Score")
            {
                _score = int.Parse(parts[1]);
            }
            else
            {
                string[] goalData = parts[1].Split(',');
                
                switch (parts[0])
                {
                    case "SimpleGoal":
                        bool isComplete = bool.Parse(goalData[3]);
                        _goals.Add(new SimpleGoal(goalData[0], goalData[1], 
                            int.Parse(goalData[2]), isComplete));
                        break;
                        
                    case "EternalGoal":
                        _goals.Add(new EternalGoal(goalData[0], goalData[1], 
                            int.Parse(goalData[2]), ""));
                        break;
                        
                    case "ChecklistGoal":
                        _goals.Add(new ChecklistGoal(goalData[0], goalData[1], 
                            int.Parse(goalData[2]), int.Parse(goalData[3]), 
                            int.Parse(goalData[4]), int.Parse(goalData[5])));
                        break;
                }
            }
        }
        
        Console.WriteLine($"Goals loaded from {filename}");
        Console.WriteLine($"Score restored: {_score} points");
    }
}