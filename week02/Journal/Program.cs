using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("=== PERSONAL JOURNAL PROGRAM ===\n");
        Console.WriteLine("Welcome to your personal journal!");
        Console.WriteLine("This program helps you maintain a consistent journaling habit.\n");
        
        Journal journal = new Journal();
        bool running = true;
        
        while (running)
        {
            DisplayMenu();
            string choice = Console.ReadLine();
            
            switch (choice)
            {
                case "1":
                    WriteNewEntry(journal);
                    break;
                    
                case "2":
                    journal.DisplayAll();
                    break;
                    
                case "3":
                    SaveJournal(journal);
                    break;
                    
                case "4":
                    LoadJournal(journal);
                    break;
                    
                case "5":
                    // CREATIVITY: Display statistics
                    journal.DisplayStatistics();
                    break;
                    
                case "6":
                    // CREATIVITY: Search entries
                    SearchJournal(journal);
                    break;
                    
                case "7":
                    // CREATIVITY: Display writing tips
                    DisplayWritingTips();
                    break;
                    
                case "8":
                    Console.WriteLine("\nThank you for journaling today!");
                    Console.WriteLine("Remember: Consistency is more important than perfection.");
                    running = false;
                    break;
                    
                default:
                    Console.WriteLine("\nInvalid option. Please choose 1-8.");
                    break;
            }
            
            if (running && choice != "1")
            {
                Console.WriteLine("\nPress Enter to continue...");
                Console.ReadLine();
                Console.Clear();
            }
        }
    }

    static void DisplayMenu()
    {
        Console.WriteLine("========== MAIN MENU ==========");
        Console.WriteLine("1. Write a new entry");
        Console.WriteLine("2. Display all entries");
        Console.WriteLine("3. Save journal to file");
        Console.WriteLine("4. Load journal from file");
        Console.WriteLine("5. View journal statistics");
        Console.WriteLine("6. Search entries");
        Console.WriteLine("7. Get writing inspiration");
        Console.WriteLine("8. Exit");
        Console.WriteLine("===============================");
        Console.Write("Choose an option (1-8): ");
    }

    static void WriteNewEntry(Journal journal)
    {
        Console.Clear();
        Console.WriteLine("=== WRITE NEW ENTRY ===\n");
        
        // Get random prompt
        string prompt = journal.GetRandomPrompt();
        Console.WriteLine($"Today's Prompt: {prompt}\n");
        
        // CREATIVITY: Optional mood tracking
        Console.WriteLine("Would you like to track your mood today? (y/n)");
        string trackMood = Console.ReadLine().ToLower();
        string mood = "";
        
        if (trackMood == "y" || trackMood == "yes")
        {
            string randomMood = journal.GetRandomMood();
            Console.WriteLine($"\nSuggested moods: {string.Join(", ", new string[] {"Happy", "Content", "Peaceful", "Excited", "Neutral", "Tired"})}");
            Console.WriteLine($"Random suggestion: {randomMood}");
            Console.Write("Enter your mood (or press Enter for suggestion): ");
            mood = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(mood))
            {
                mood = randomMood;
            }
        }
        
        // CREATIVITY: Optional daily rating
        int rating = 0;
        Console.WriteLine("\nWould you like to rate your day? (1-10, or 0 to skip)");
        Console.Write("Daily rating: ");
        if (int.TryParse(Console.ReadLine(), out int inputRating) && inputRating >= 0 && inputRating <= 10)
        {
            rating = inputRating;
        }
        
        // Get entry text
        Console.WriteLine("\nStart writing your entry (type 'END' on a new line to finish):");
        Console.WriteLine("--------------------------------------------------------------");
        
        string entryText = "";
        string line;
        while (true)
        {
            line = Console.ReadLine();
            if (line?.ToUpper() == "END")
                break;
            entryText += line + "\n";
        }
        
        // Remove trailing newline
        if (entryText.EndsWith("\n"))
            entryText = entryText.Substring(0, entryText.Length - 1);
        
        // Add entry to journal
        if (!string.IsNullOrWhiteSpace(entryText))
        {
            journal.AddEntry(prompt, entryText, mood, rating);
            Console.WriteLine($"\n✓ Entry saved successfully!");
            Console.WriteLine($"Total entries in journal: {journal.EntryCount}");
        }
        else
        {
            Console.WriteLine("\n✗ Entry was empty. Not saved.");
        }
        
        Console.WriteLine("\nPress Enter to return to menu...");
        Console.ReadLine();
        Console.Clear();
    }

    static void SaveJournal(Journal journal)
    {
        Console.Clear();
        Console.WriteLine("=== SAVE JOURNAL ===\n");
        
        if (journal.EntryCount == 0)
        {
            Console.WriteLine("No entries to save. Write some entries first!");
            return;
        }
        
        Console.WriteLine($"You have {journal.EntryCount} entries to save.");
        Console.Write("Enter filename (default: journal.csv): ");
        string filename = Console.ReadLine();
        
        if (string.IsNullOrWhiteSpace(filename))
        {
            filename = "journal.csv";
        }
        
        journal.SaveToFile(filename);
    }

    static void LoadJournal(Journal journal)
    {
        Console.Clear();
        Console.WriteLine("=== LOAD JOURNAL ===\n");
        
        Console.WriteLine("Warning: Loading a journal will replace your current entries.");
        Console.Write("Do you want to continue? (y/n): ");
        string confirm = Console.ReadLine().ToLower();
        
        if (confirm != "y" && confirm != "yes")
        {
            Console.WriteLine("Load cancelled.");
            return;
        }
        
        Console.Write("\nEnter filename to load: ");
        string filename = Console.ReadLine();
        
        if (string.IsNullOrWhiteSpace(filename))
        {
            Console.WriteLine("No filename provided.");
            return;
        }
        
        journal.LoadFromFile(filename);
    }

    // CREATIVITY: Search functionality
    static void SearchJournal(Journal journal)
    {
        Console.Clear();
        Console.WriteLine("=== SEARCH JOURNAL ===\n");
        
        if (journal.EntryCount == 0)
        {
            Console.WriteLine("No entries to search. Load or write some entries first!");
            return;
        }
        
        Console.Write("Enter search keyword: ");
        string keyword = Console.ReadLine();
        
        if (!string.IsNullOrWhiteSpace(keyword))
        {
            journal.SearchEntries(keyword);
        }
        else
        {
            Console.WriteLine("No keyword entered.");
        }
    }

    // CREATIVITY: Writing tips for inspiration
    static void DisplayWritingTips()
    {
        Console.Clear();
        Console.WriteLine("=== WRITING INSPIRATION ===\n");
        
        string[] tips = {
            "1. Don't worry about grammar or spelling - just write!",
            "2. Set a timer for 5-10 minutes and write without stopping",
            "3. Write about something small that made you smile today",
            "4. Describe a conversation you had in detail",
            "5. Write a letter to your future self",
            "6. List 3 things you're grateful for today",
            "7. Describe your surroundings using all 5 senses",
            "8. Write about a problem you're facing from different perspectives",
            "9. Record a dream you remember",
            "10. Write about what you'd do if you had an extra hour today"
        };
        
        foreach (string tip in tips)
        {
            Console.WriteLine(tip);
        }
        
        Console.WriteLine("\nRemember: The goal is consistency, not perfection!");
        Console.WriteLine("Even a few sentences each day adds up over time.");
    }
}

/*
CREATIVITY AND EXCEEDING REQUIREMENTS:
=======================================
I have implemented several features that go beyond the core requirements:

1. ENHANCED ENTRY TRACKING:
   - Added mood tracking with predefined mood options
   - Added daily rating system (1-10 scale)
   - Both mood and rating are optional

2. CSV FILE HANDLING:
   - Proper CSV format with header row
   - Handles quotes and commas within text fields
   - Automatic .csv extension addition
   - Proper escaping/unescaping of quotes for CSV compatibility

3. SEARCH FUNCTIONALITY:
   - Search entries by keyword
   - Searches across entry text, prompts, and moods
   - Displays search results with context

4. JOURNAL STATISTICS:
   - Shows total entry count
   - Displays entries per month
   - Calculates average daily rating
   - Shows most common moods
   - Helps users track their journaling habits over time

5. WRITING INSPIRATION:
   - Menu option with writing tips and prompts
   - Encourages consistent journaling
   - Provides creative writing suggestions

6. IMPROVED USER EXPERIENCE:
   - Random mood suggestions
   - Entry count displayed
   - Clear confirmation messages
   - Better error handling
   - More intuitive menu system

7. ADDITIONAL PROMPTS:
   - Added 10 extra prompts beyond the required 5
   - Prompts focus on gratitude, learning, kindness, health, and goals

8. DATA VALIDATION:
   - Proper input validation for ratings
   - File existence checks
   - Error handling for file operations

These features address common barriers to journaling by making it more engaging,
providing insights into journaling habits, and offering tools to find and reflect
on past entries. The CSV format ensures compatibility with spreadsheet programs
like Excel, making it easy to analyze journal data outside the program.
*/