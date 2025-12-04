using System;

class Program
{
    static void Main(string[] args)
    {
        /*
        EXCEEDING REQUIREMENTS - ENHANCEMENTS:
        
        1. LEVEL SYSTEM - Users level up every 1000 points with titles:
           - Level 1-4: Novice
           - Level 5-9: Apprentice
           - Level 10-14: Adept
           - Level 15-19: Expert
           - Level 20-29: Master
           - Level 30+: Legend
        
        2. VISUAL PROGRESS BAR - Shows progress to next level with █ characters
        
        3. ACHIEVEMENT SYSTEM - Unlocks special achievements:
           - "First Step" - Complete first goal
           - "Goal Getter" - Complete 5 goals (awards 100 bonus points)
           - "Master Achiever" - Complete 10 goals (awards 250 bonus points)
        
        4. BAD HABIT TRACKER - Negative goals where you lose points for bad habits
           (See BadHabitGoal.cs - this is a completely new goal type!)
        
        5. COLOR CODED OUTPUT - Different colors for different message types
           - Green for positive messages
           - Yellow for informational messages
           - Red for warnings
           - Cyan for achievements
        
        These enhancements make the program more engaging, provide better
        feedback, and add gamification elements that encourage continued use.
        */
        
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine("╔══════════════════════════════════════════╗");
        Console.WriteLine("║         ETERNAL QUEST PROGRAM            ║");
        Console.WriteLine("║       Your Journey to Greatness          ║");
        Console.WriteLine("╚══════════════════════════════════════════╝");
        Console.ResetColor();
        Console.WriteLine();
        
        GoalManager goalManager = new GoalManager();
        goalManager.Start();
    }
}