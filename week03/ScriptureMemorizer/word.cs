public class Word
{
    private string _text;
    private bool _isHidden;

    public Word(string text)
    {
        _text = text;
        _isHidden = false;
    }

    public void Hide()
    {
        _isHidden = true;
    }

    public void Show()
    {
        _isHidden = false;
    }

    public bool IsHidden()
    {
        return _isHidden;
    }

    public string GetDisplayText()
    {
        if (_isHidden)
        {
            // Return underscores equal to the length of the word
            return new string('_', _text.Length);
        }
        else
        {
            return _text;
        }
    }

    // Property for access if needed
    public string Text { get { return _text; } }
}