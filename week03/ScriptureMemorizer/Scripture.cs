using System;
using System.Collections.Generic;

public class Scripture
{
    private Reference _reference;
    private List<Word> _words;
    private List<Word> _originalWords;

    public Scripture(Reference reference, string text)
    {
        _reference = reference;
        _words = new List<Word>();
        _originalWords = new List<Word>();
        
        // Split the text into words and create Word objects
        string[] wordArray = text.Split(' ', StringSplitOptions.RemoveEmptyEntries);
        foreach (string word in wordArray)
        {
            Word wordObj = new Word(word);
            _words.Add(wordObj);
            // Store original words for creativity feature
            Word originalWord = new Word(word);
            _originalWords.Add(originalWord);
        }
    }

    public void HideRandomWords(int numberToHide)
    {
        Random random = new Random();
        int wordsHidden = 0;
        
        // Keep trying to hide words until we've hidden the requested number
        // or all words are hidden
        while (wordsHidden < numberToHide && !IsCompletelyHidden())
        {
            int index = random.Next(0, _words.Count);
            
            // Only hide words that aren't already hidden
            if (!_words[index].IsHidden())
            {
                _words[index].Hide();
                wordsHidden++;
            }
        }
    }

    public string GetDisplayText()
    {
        string displayText = _reference.GetDisplayText() + " ";
        
        foreach (Word word in _words)
        {
            displayText += word.GetDisplayText() + " ";
        }
        
        return displayText.Trim();
    }

    public bool IsCompletelyHidden()
    {
        foreach (Word word in _words)
        {
            if (!word.IsHidden())
            {
                return false;
            }
        }
        return true;
    }

    // CREATIVITY: Method to show a hint (reveal one random hidden word)
    public void ShowHint()
    {
        List<int> hiddenIndices = new List<int>();
        
        // Find all hidden words
        for (int i = 0; i < _words.Count; i++)
        {
            if (_words[i].IsHidden())
            {
                hiddenIndices.Add(i);
            }
        }
        
        // If there are hidden words, reveal one
        if (hiddenIndices.Count > 0)
        {
            Random random = new Random();
            int randomIndex = hiddenIndices[random.Next(0, hiddenIndices.Count)];
            _words[randomIndex] = new Word(_originalWords[randomIndex].Text);
        }
    }

    // CREATIVITY: Method to get the original scripture text
    public string GetOriginalText()
    {
        string originalText = _reference.GetDisplayText() + " ";
        
        foreach (Word word in _originalWords)
        {
            originalText += word.Text + " ";
        }
        
        return originalText.Trim();
    }

    // Property for access if needed
    public Reference Reference { get { return _reference; } }
}