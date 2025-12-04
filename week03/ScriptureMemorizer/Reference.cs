using System;

public class Reference
{
    private string _book;
    private int _chapter;
    private int _startVerse;
    private int _endVerse;

    // Constructor for single verse
    public Reference(string book, int chapter, int verse)
    {
        _book = book;
        _chapter = chapter;
        _startVerse = verse;
        _endVerse = verse;
    }

    // Constructor for verse range
    public Reference(string book, int chapter, int startVerse, int endVerse)
    {
        _book = book;
        _chapter = chapter;
        _startVerse = startVerse;
        _endVerse = endVerse;
    }

    public string GetDisplayText()
    {
        if (_startVerse == _endVerse)
        {
            return $"{_book} {_chapter}:{_startVerse}";
        }
        else
        {
            return $"{_book} {_chapter}:{_startVerse}-{_endVerse}";
        }
    }

    // Check if it's a single verse or range
    public bool IsSingleVerse()
    {
        return _startVerse == _endVerse;
    }

    // Properties for testing/access if needed
    public string Book { get { return _book; } }
    public int Chapter { get { return _chapter; } }
    public int StartVerse { get { return _startVerse; } }
    public int EndVerse { get { return _endVerse; } }
}