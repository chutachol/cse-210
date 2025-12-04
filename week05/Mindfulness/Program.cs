using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        /* 
        EXCEEDING REQUIREMENTS:
        
        1. Added activity statistics tracking - keeps track of how many times each activity is performed
        2. Implemented a session history that shows at the end of each session
        3. Added a progress bar for the breathing activity that visually shows breathing cycle
        4. Added input validation for menu selection and duration input
        5. Implemented a more sophisticated spinner animation
        6. Added color coding for different activities to improve user experience
        7. Prevent duplicate prompts/questions in reflecting activity until all have been shown
        8. Added a congratulatory message when user completes all 3 activities in one session
        
        These enhancements make the program more user-friendly, engaging, and provide
        better feedback to the user about their mindfulness practice.
        */
        
        Dictionary<string, int> activityStats = new Dictionary<string, int>
        {
            {"Breathing", 0},
            {"Reflecting", 0},
            {"Listing", 0}
        };
        
        List<string> completedActivities = new List<string>();
        
        Console.WriteLine("Welcome to the Mindfulness Program!");
        Console.WriteLine();
        
        while (true)
        {
            DisplayMenu();
            string choice = GetValidMenuChoice();
            
            if (choice == "4")
            {
                break;
            }
            
            Console.Clear();
            
            switch (choice)
            {
                case "1":
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    BreathingActivity breathing = new BreathingActivity();
                    breathing.Run();
                    activityStats["Breathing"]++;
                    if (!completedActivities.Contains("Breathing"))
                        completedActivities.Add("Breathing");
                    Console.ResetColor();
                    break;
                    
                case "2":
                    Console.ForegroundColor = ConsoleColor.Green;
                    ReflectingActivity reflecting = new ReflectingActivity();
                    reflecting.Run();
                    activityStats["Reflecting"]++;
                    if (!completedActivities.Contains("Reflecting"))
                        completedActivities.Add("Reflecting");
                    Console.ResetColor();
                    break;
                    
                case "3":
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    ListingActivity listing = new ListingActivity();
                    listing.Run();
                    activityStats["Listing"]++;
                    if (!completedActivities.Contains("Listing"))
                        completedActivities.Add("Listing");
                    Console.ResetColor();
                    break;
            }
            
            DisplaySessionSummary(activityStats);
            
            // Congratulate if all activities completed
            if (completedActivities.Count == 3)
            {
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.WriteLine();
                Console.WriteLine(" CONGRATULATIONS! You've completed all 3 mindfulness activities in this session! 🎉");
                Console.WriteLine("Take a moment to appreciate your commitment to mindfulness.");
                Console.ResetColor();
                Console.WriteLine();
                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();
                completedActivities.Clear(); // Reset for next session
            }
        }
        
        DisplayFinalStatistics(activityStats);
        Console.WriteLine("Thank you for practicing mindfulness with us today!");
    }
    
    static void DisplayMenu()
    {
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.White;
        Console.WriteLine("Menu Options:");
        Console.WriteLine("  1. Start breathing activity");
        Console.WriteLine("  2. Start reflecting activity");
        Console.WriteLine("  3. Start listing activity");
        Console.WriteLine("  4. Quit");
        Console.ResetColor();
        Console.Write("Select a choice from the menu: ");
    }
    
    static string GetValidMenuChoice()
    {
        while (true)
        {
            string choice = Console.ReadLine();
            if (choice == "1" || choice == "2" || choice == "3" || choice == "4")
            {
                return choice;
            }
            Console.Write("Invalid choice. Please enter 1, 2, 3, or 4: ");
        }
    }
    
    static void DisplaySessionSummary(Dictionary<string, int> stats)
    {
        Console.WriteLine();
        Console.WriteLine("═══════════════════════════════════════════");
        Console.WriteLine("            SESSION SUMMARY");
        Console.WriteLine("═══════════════════════════════════════════");
        Console.WriteLine($"Breathing activities completed: {stats["Breathing"]}");
        Console.WriteLine($"Reflecting activities completed: {stats["Reflecting"]}");
        Console.WriteLine($"Listing activities completed: {stats["Listing"]}");
        Console.WriteLine("═══════════════════════════════════════════");
        Console.WriteLine();
        Console.WriteLine("Press any key to return to the menu...");
        Console.ReadKey();
    }
    
    static void DisplayFinalStatistics(Dictionary<string, int> stats)
    {
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine("╔══════════════════════════════════════════╗");
        Console.WriteLine("║          MINDFULNESS STATISTICS          ║");
        Console.WriteLine("╠══════════════════════════════════════════╣");
        Console.WriteLine($"║  Breathing Activities: {stats["Breathing"],3}             ║");
        Console.WriteLine($"║  Reflecting Activities: {stats["Reflecting"],2}             ║");
        Console.WriteLine($"║  Listing Activities: {stats["Listing"],4}             ║");
        Console.WriteLine("╠══════════════════════════════════════════╣");
        int total = stats["Breathing"] + stats["Reflecting"] + stats["Listing"];
        Console.WriteLine($"║  TOTAL SESSIONS: {total,7}            ║");
        Console.WriteLine("╚══════════════════════════════════════════╝");
        Console.ResetColor();
        Console.WriteLine();
    }
}