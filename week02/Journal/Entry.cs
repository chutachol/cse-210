using System;

public class Entry
{
    private string _date;
    private string _promptText;
    private string _entryText;
    private string _mood; // CREATIVITY: Added mood tracking
    private int _rating; // CREATIVITY: Added daily rating (1-10)

    // Constructor for creating new entries
    public Entry(string date, string promptText, string entryText, string mood = "", int rating = 0)
    {
        _date = date;
        _promptText = promptText;
        _entryText = entryText;
        _mood = mood;
        _rating = rating;
    }

    // Display the entry
    public void Display()
    {
        Console.WriteLine($"Date: {_date}");
        Console.WriteLine($"Prompt: {_promptText}");
        Console.WriteLine($"Entry: {_entryText}");
        
        // CREATIVITY: Display mood and rating if they exist
        if (!string.IsNullOrEmpty(_mood))
        {
            Console.WriteLine($"Mood: {_mood}");
        }
        
        if (_rating > 0)
        {
            Console.WriteLine($"Daily Rating: {_rating}/10");
        }
        
        Console.WriteLine();
    }

    // Format for file storage
    public string GetFileString()
    {
        // CREATIVITY: Using CSV format with proper escaping
        return $"\"{EscapeQuotes(_date)}\",\"{EscapeQuotes(_promptText)}\",\"{EscapeQuotes(_entryText)}\",\"{EscapeQuotes(_mood)}\",{_rating}";
    }

    // Helper method to escape quotes for CSV
    private string EscapeQuotes(string text)
    {
        return text.Replace("\"", "\"\"");
    }

    // Properties for access
    public string Date { get { return _date; } }
    public string PromptText { get { return _promptText; } }
    public string EntryText { get { return _entryText; } }
    public string Mood { get { return _mood; } }
    public int Rating { get { return _rating; } }
}