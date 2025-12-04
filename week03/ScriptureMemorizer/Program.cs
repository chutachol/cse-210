using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("=== Scripture Memorizer Program ===\n");
        
        // CREATIVITY: Scripture Library - Multiple scriptures to choose from
        List<Scripture> scriptureLibrary = CreateScriptureLibrary();
        
        // Let user select a scripture or get a random one
        Scripture selectedScripture = SelectScripture(scriptureLibrary);
        
        // Main program loop
        RunMemorizer(selectedScripture);
        
        Console.WriteLine("\nProgram ended. Good job memorizing!");
    }

    static List<Scripture> CreateScriptureLibrary()
    {
        // CREATIVITY: Create multiple scriptures
        List<Scripture> library = new List<Scripture>();
        
        // Scripture 1: John 3:16
        Reference ref1 = new Reference("John", 3, 16);
        string text1 = "For God so loved the world that he gave his one and only Son, that whoever believes in him shall not perish but have eternal life.";
        library.Add(new Scripture(ref1, text1));
        
        // Scripture 2: Proverbs 3:5-6
        Reference ref2 = new Reference("Proverbs", 3, 5, 6);
        string text2 = "Trust in the Lord with all your heart and lean not on your own understanding; in all your ways submit to him, and he will make your paths straight.";
        library.Add(new Scripture(ref2, text2));
        
        // Scripture 3: Philippians 4:13
        Reference ref3 = new Reference("Philippians", 4, 13);
        string text3 = "I can do all this through him who gives me strength.";
        library.Add(new Scripture(ref3, text3));
        
        // Scripture 4: 1 Nephi 3:7
        Reference ref4 = new Reference("1 Nephi", 3, 7);
        string text4 = "And it came to pass that I, Nephi, said unto my father: I will go and do the things which the Lord hath commanded, for I know that the Lord giveth no commandments unto the children of men, save he shall prepare a way for them that they may accomplish the thing which he commandeth them.";
        library.Add(new Scripture(ref4, text4));
        
        // Scripture 5: Matthew 11:28-30
        Reference ref5 = new Reference("Matthew", 11, 28, 30);
        string text5 = "Come unto me, all ye that labour and are heavy laden, and I will give you rest. Take my yoke upon you, and learn of me; for I am meek and lowly in heart: and ye shall find rest unto your souls. For my yoke is easy, and my burden is light.";
        library.Add(new Scripture(ref5, text5));
        
        return library;
    }

    static Scripture SelectScripture(List<Scripture> library)
    {
        Console.WriteLine("Scripture Library:");
        Console.WriteLine("==================");
        
        for (int i = 0; i < library.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {library[i].Reference.GetDisplayText()}");
        }
        
        Console.WriteLine($"\nEnter a number (1-{library.Count}) to select a scripture,");
        Console.WriteLine("or press Enter for a random scripture:");
        
        string input = Console.ReadLine();
        
        if (string.IsNullOrWhiteSpace(input))
        {
            // Random selection
            Random random = new Random();
            int index = random.Next(0, library.Count);
            Console.WriteLine($"\nSelected: {library[index].Reference.GetDisplayText()}");
            return library[index];
        }
        else if (int.TryParse(input, out int choice) && choice >= 1 && choice <= library.Count)
        {
            Console.WriteLine($"\nSelected: {library[choice - 1].Reference.GetDisplayText()}");
            return library[choice - 1];
        }
        else
        {
            Console.WriteLine("\nInvalid selection. Choosing a random scripture...");
            Random random = new Random();
            int index = random.Next(0, library.Count);
            Console.WriteLine($"Selected: {library[index].Reference.GetDisplayText()}");
            return library[index];
        }
    }

    static void RunMemorizer(Scripture scripture)
    {
        // CREATIVITY: Display original scripture first for reference
        Console.WriteLine("\nOriginal Scripture:");
        Console.WriteLine("===================");
        Console.WriteLine(scripture.GetOriginalText());
        Console.WriteLine("\nPress Enter to begin memorization...");
        Console.ReadLine();
        Console.Clear();
        
        string userInput = "";
        int wordsToHidePerRound = 3; // Number of words to hide each time
        
        while (userInput.ToLower() != "quit" && !scripture.IsCompletelyHidden())
        {
            // Display current scripture
            Console.WriteLine(scripture.GetDisplayText());
            
            // Display options
            Console.WriteLine("\n" + new string('=', 50));
            Console.WriteLine("Options:");
            Console.WriteLine("  - Press Enter to hide more words");
            Console.WriteLine("  - Type 'hint' to reveal one hidden word");
            Console.WriteLine("  - Type 'show' to see the full scripture again");
            Console.WriteLine("  - Type 'quit' to end the program");
            Console.WriteLine(new string('=', 50));
            
            if (!scripture.IsCompletelyHidden())
            {
                Console.Write("\nYour choice: ");
                userInput = Console.ReadLine();
                
                if (userInput.ToLower() == "quit")
                {
                    break;
                }
                else if (userInput.ToLower() == "hint")
                {
                    // CREATIVITY: Hint feature
                    scripture.ShowHint();
                    Console.Clear();
                    Console.WriteLine("Hint applied! One word has been revealed.\n");
                }
                else if (userInput.ToLower() == "show")
                {
                    // CREATIVITY: Show full scripture again
                    Console.Clear();
                    Console.WriteLine("Full Scripture:");
                    Console.WriteLine("================");
                    Console.WriteLine(scripture.GetOriginalText());
                    Console.WriteLine("\nPress Enter to continue memorizing...");
                    Console.ReadLine();
                    Console.Clear();
                }
                else
                {
                    // Hide more words and continue
                    scripture.HideRandomWords(wordsToHidePerRound);
                    Console.Clear();
                }
            }
        }
        
        // Final display
        Console.Clear();
        if (scripture.IsCompletelyHidden())
        {
            Console.WriteLine("Congratulations! You've memorized the entire scripture!\n");
            Console.WriteLine(scripture.GetDisplayText());
        }
    }
}

/*
CREATIVITY AND EXCEEDING REQUIREMENTS:
=======================================
I have implemented several features that go beyond the core requirements:

1. SCRIPTURE LIBRARY:
   - Created a library of 5 different scriptures
   - User can select a specific scripture or get a random one
   - Includes both single verses and verse ranges

2. HINT SYSTEM:
   - Users can type "hint" to reveal one hidden word
   - Helpful for when users get stuck during memorization
   - Only reveals words that are currently hidden

3. SHOW FULL SCRIPTURE:
   - Users can type "show" to see the complete scripture again
   - Useful for refreshing memory during practice
   - Returns to memorization mode after viewing

4. ENHANCED USER INTERFACE:
   - Clear menu with available options
   - Progress indicators
   - Better formatting and visual separation

5. MULTIPLE SCRIPTURES:
   - Program includes scriptures from both Bible and Book of Mormon
   - Demonstrates handling different reference formats
   - Easy to add more scriptures to the library

6. ORIGINAL TEXT PRESERVATION:
   - Stores original words separately for hint functionality
   - Can display original scripture at any time

These features make the program more practical for actual scripture memorization,
providing tools that real users would find helpful in their memorization practice.
*/