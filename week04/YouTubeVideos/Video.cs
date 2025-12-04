using System;
using System.Collections.Generic;

public class Video
{
    private string _title;
    private string _author;
    private int _length; // Length in seconds
    private List<Comment> _comments;

    public Video(string title, string author, int length)
    {
        _title = title;
        _author = author;
        _length = length;
        _comments = new List<Comment>();
    }

    // Method to add a comment
    public void AddComment(Comment comment)
    {
        _comments.Add(comment);
    }

    // Method to add multiple comments
    public void AddComments(List<Comment> comments)
    {
        _comments.AddRange(comments);
    }

    // Method to return the number of comments
    public int GetNumberOfComments()
    {
        return _comments.Count;
    }

    // Method to get video details
    public string GetVideoDetails()
    {
        return $"Title: {_title}\nAuthor: {_author}\nLength: {_length} seconds\nNumber of Comments: {GetNumberOfComments()}";
    }

    // Method to get all comments
    public List<Comment> GetComments()
    {
        return new List<Comment>(_comments); // Return a copy to maintain encapsulation
    }

    // Method to display video with all comments
    public void DisplayVideoWithComments()
    {
        Console.WriteLine("=".PadRight(50, '='));
        Console.WriteLine(GetVideoDetails());
        Console.WriteLine("\nComments:");
        Console.WriteLine("-".PadRight(50, '-'));
        
        if (_comments.Count == 0)
        {
            Console.WriteLine("No comments yet.");
        }
        else
        {
            foreach (Comment comment in _comments)
            {
                Console.WriteLine(comment.GetCommentDetails());
            }
        }
        Console.WriteLine("=".PadRight(50, '='));
        Console.WriteLine();
    }

    // Properties for access if needed
    public string Title { get { return _title; } }
    public string Author { get { return _author; } }
    public int Length { get { return _length; } }
}