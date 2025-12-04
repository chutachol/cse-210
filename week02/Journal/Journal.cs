using System;
using System.Collections.Generic;
using System.IO;

public class Journal
{
    private List<Entry> _entries;
    private List<string> _prompts;
    private List<string> _moods; // CREATIVITY: List of possible moods

    public Journal()
    {
        _entries = new List<Entry>();
        InitializePrompts();
        InitializeMoods(); // CREATIVITY: Initialize mood options
    }

    private void InitializePrompts()
    {
        _prompts = new List<string>
        {
            "Who was the most interesting person I interacted with today?",
            "What was the best part of my day?",
            "How did I see the hand of the Lord in my life today?",
            "What was the strongest emotion I felt today?",
            "If I had one thing I could do over today, what would it be?",
            // CREATIVITY: Additional prompts
            "What new thing did I learn today?",
            "What made me laugh today?",
            "What act of kindness did I perform or witness today?",
            "What am I grateful for today?",
            "What challenge did I overcome today?",
            "What did I do today to take care of my physical health?",
            "What book, article, or podcast impacted me today?",
            "What creative work did I do today?",
            "How did I show love to someone today?",
            "What goal did I make progress on today?"
        };
    }

    // CREATIVITY: Initialize mood options
    private void InitializeMoods()
    {
        _moods = new List<string>
        {
            "Happy", "Content", "Peaceful", "Excited", "Hopeful",
            "Neutral", "Reflective", "Tired", "Stressed", "Anxious",
            "Sad", "Frustrated", "Angry", "Overwhelmed", "Motivated"
        };
    }

    // Add a new entry
    public void AddEntry(string prompt, string response, string mood = "", int rating = 0)
    {
        string date = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
        Entry newEntry = new Entry(date, prompt, response, mood, rating);
        _entries.Add(newEntry);
    }

    // Display all entries
    public void DisplayAll()
    {
        if (_entries.Count == 0)
        {
            Console.WriteLine("No entries found. Start by writing a new entry!");
            return;
        }

        Console.WriteLine("\n=== YOUR JOURNAL ENTRIES ===\n");
        
        // CREATIVITY: Show entry count
        Console.WriteLine($"Total entries: {_entries.Count}\n");
        
        for (int i = 0; i < _entries.Count; i++)
        {
            Console.WriteLine($"Entry #{i + 1}:");
            _entries[i].Display();
            if (i < _entries.Count - 1)
            {
                Console.WriteLine("---");
            }
        }
    }

    // Get a random prompt
    public string GetRandomPrompt()
    {
        Random random = new Random();
        int index = random.Next(0, _prompts.Count);
        return _prompts[index];
    }

    // CREATIVITY: Get a random mood suggestion
    public string GetRandomMood()
    {
        Random random = new Random();
        int index = random.Next(0, _moods.Count);
        return _moods[index];
    }

    // Save to CSV file
    public void SaveToFile(string filename)
    {
        try
        {
            // CREATIVITY: Ensure .csv extension
            if (!filename.EndsWith(".csv"))
            {
                filename += ".csv";
            }

            using (StreamWriter writer = new StreamWriter(filename))
            {
                // Write CSV header
                writer.WriteLine("Date,Prompt,Entry,Mood,Rating");
                
                foreach (Entry entry in _entries)
                {
                    writer.WriteLine(entry.GetFileString());
                }
            }
            
            Console.WriteLine($"\n✓ Journal saved successfully to '{filename}'");
            Console.WriteLine($"Total entries saved: {_entries.Count}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"\n✗ Error saving file: {ex.Message}");
        }
    }

    // Load from CSV file
    public void LoadFromFile(string filename)
    {
        try
        {
            if (!File.Exists(filename))
            {
                Console.WriteLine($"\n✗ File '{filename}' not found.");
                return;
            }

            // Clear current entries
            _entries.Clear();
            
            string[] lines = File.ReadAllLines(filename);
            
            // Skip header row if it exists
            int startIndex = (lines.Length > 0 && lines[0].StartsWith("Date,Prompt")) ? 1 : 0;
            
            int loadedCount = 0;
            for (int i = startIndex; i < lines.Length; i++)
            {
                string line = lines[i];
                if (string.IsNullOrWhiteSpace(line))
                    continue;
                
                try
                {
                    // Parse CSV line
                    string[] parts = ParseCSVLine(line);
                    
                    if (parts.Length >= 3)
                    {
                        string date = UnescapeQuotes(parts[0]);
                        string prompt = UnescapeQuotes(parts[1]);
                        string entryText = UnescapeQuotes(parts[2]);
                        string mood = parts.Length > 3 ? UnescapeQuotes(parts[3]) : "";
                        int rating = parts.Length > 4 && int.TryParse(parts[4], out int r) ? r : 0;
                        
                        Entry loadedEntry = new Entry(date, prompt, entryText, mood, rating);
                        _entries.Add(loadedEntry);
                        loadedCount++;
                    }
                }
                catch
                {
                    Console.WriteLine($"Warning: Could not parse line {i + 1}");
                }
            }
            
            Console.WriteLine($"\n✓ Journal loaded successfully from '{filename}'");
            Console.WriteLine($"Entries loaded: {loadedCount}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"\n✗ Error loading file: {ex.Message}");
        }
    }

    // Helper method to parse CSV line
    private string[] ParseCSVLine(string line)
    {
        List<string> parts = new List<string>();
        bool inQuotes = false;
        string currentPart = "";
        
        for (int i = 0; i < line.Length; i++)
        {
            char c = line[i];
            
            if (c == '"')
            {
                // Handle escaped quotes
                if (i + 1 < line.Length && line[i + 1] == '"')
                {
                    currentPart += '"';
                    i++;
                }
                else
                {
                    inQuotes = !inQuotes;
                }
            }
            else if (c == ',' && !inQuotes)
            {
                parts.Add(currentPart);
                currentPart = "";
            }
            else
            {
                currentPart += c;
            }
        }
        
        parts.Add(currentPart);
        return parts.ToArray();
    }

    // Helper method to unescape quotes
    private string UnescapeQuotes(string text)
    {
        return text.Replace("\"\"", "\"");
    }

    // CREATIVITY: Get journal statistics
    public void DisplayStatistics()
    {
        if (_entries.Count == 0)
        {
            Console.WriteLine("No entries to analyze.");
            return;
        }

        Console.WriteLine("\n=== JOURNAL STATISTICS ===\n");
        Console.WriteLine($"Total entries: {_entries.Count}");
        
        // Count entries by month
        var entriesByMonth = new Dictionary<string, int>();
        foreach (var entry in _entries)
        {
            if (DateTime.TryParse(entry.Date, out DateTime date))
            {
                string monthKey = date.ToString("yyyy-MM");
                if (entriesByMonth.ContainsKey(monthKey))
                    entriesByMonth[monthKey]++;
                else
                    entriesByMonth[monthKey] = 1;
            }
        }
        
        Console.WriteLine("\nEntries per month:");
        foreach (var kvp in entriesByMonth)
        {
            Console.WriteLine($"  {kvp.Key}: {kvp.Value} entries");
        }
        
        // Average rating if available
        int totalRating = 0;
        int ratedEntries = 0;
        foreach (var entry in _entries)
        {
            if (entry.Rating > 0)
            {
                totalRating += entry.Rating;
                ratedEntries++;
            }
        }
        
        if (ratedEntries > 0)
        {
            double averageRating = (double)totalRating / ratedEntries;
            Console.WriteLine($"\nAverage daily rating: {averageRating:F1}/10");
        }
        
        // Most common moods
        var moodCounts = new Dictionary<string, int>();
        foreach (var entry in _entries)
        {
            if (!string.IsNullOrEmpty(entry.Mood))
            {
                if (moodCounts.ContainsKey(entry.Mood))
                    moodCounts[entry.Mood]++;
                else
                    moodCounts[entry.Mood] = 1;
            }
        }
        
        if (moodCounts.Count > 0)
        {
            Console.WriteLine("\nMost common moods:");
            var sortedMoods = moodCounts.OrderByDescending(x => x.Value).Take(5);
            foreach (var kvp in sortedMoods)
            {
                Console.WriteLine($"  {kvp.Key}: {kvp.Value} times");
            }
        }
    }

    // CREATIVITY: Search entries
    public void SearchEntries(string keyword)
    {
        var results = _entries.Where(e => 
            e.EntryText.IndexOf(keyword, StringComparison.OrdinalIgnoreCase) >= 0 ||
            e.PromptText.IndexOf(keyword, StringComparison.OrdinalIgnoreCase) >= 0 ||
            e.Mood.IndexOf(keyword, StringComparison.OrdinalIgnoreCase) >= 0).ToList();
        
        if (results.Count == 0)
        {
            Console.WriteLine($"\nNo entries found containing '{keyword}'");
            return;
        }
        
        Console.WriteLine($"\n=== SEARCH RESULTS FOR '{keyword}' ===\n");
        Console.WriteLine($"Found {results.Count} entries:\n");
        
        for (int i = 0; i < results.Count; i++)
        {
            Console.WriteLine($"Result #{i + 1}:");
            results[i].Display();
            if (i < results.Count - 1)
            {
                Console.WriteLine("---");
            }
        }
    }

    // Property for entry count
    public int EntryCount { get { return _entries.Count; } }
}