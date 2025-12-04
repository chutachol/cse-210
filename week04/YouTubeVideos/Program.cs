using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("YouTube Video Analytics Program");
        Console.WriteLine("================================\n");
        
        // Create a list to store videos
        List<Video> videos = new List<Video>();
        
        // Create and populate Video 1
        Video video1 = new Video("C# Programming Tutorial for Beginners", "CodeMaster", 1200);
        
        // Create comments for video 1
        List<Comment> video1Comments = new List<Comment>
        {
            new Comment("John Doe", "Great tutorial! Learned a lot about classes."),
            new Comment("Jane Smith", "Could you make a video about inheritance?"),
            new Comment("Bob Johnson", "Very clear explanation, thank you!"),
            new Comment("Alice Brown", "This helped me with my homework assignment.")
        };
        
        video1.AddComments(video1Comments);
        videos.Add(video1);
        
        // Create and populate Video 2
        Video video2 = new Video("Learning Python in 30 Days", "PythonPro", 1800);
        
        List<Comment> video2Comments = new List<Comment>
        {
            new Comment("Charlie Wilson", "Python is my favorite language!"),
            new Comment("Diana Prince", "Day 15 and I'm loving it!"),
            new Comment("Ethan Hunt", "The data science section was amazing."),
            new Comment("Fiona Gallagher", "Wish there were more exercises.")
        };
        
        video2.AddComments(video2Comments);
        videos.Add(video2);
        
        // Create and populate Video 3
        Video video3 = new Video("Web Development Crash Course", "WebWizard", 2400);
        
        List<Comment> video3Comments = new List<Comment>
        {
            new Comment("George Miller", "HTML/CSS section was perfect for beginners."),
            new Comment("Hannah Baker", "The JavaScript part needs more examples."),
            new Comment("Ian Cooper", "Great overall introduction to web dev."),
            new Comment("Julia Roberts", "Loved the project at the end!")
        };
        
        video3.AddComments(video3Comments);
        videos.Add(video3);
        
        // Create and populate Video 4 (extra video to exceed requirements)
        Video video4 = new Video("Machine Learning Fundamentals", "AIExpert", 3600);
        
        List<Comment> video4Comments = new List<Comment>
        {
            new Comment("Kevin Lee", "Super comprehensive overview of ML!"),
            new Comment("Lisa Simpson", "The neural networks explanation was brilliant."),
            new Comment("Mike Ross", "Could use more code examples."),
            new Comment("Nancy Drew", "Perfect for someone starting in ML.")
        };
        
        video4.AddComments(video4Comments);
        videos.Add(video4);
        
        // Display all videos with their comments
        Console.WriteLine($"Total Videos in Database: {videos.Count}\n");
        
        foreach (Video video in videos)
        {
            video.DisplayVideoWithComments();
        }
        
        // Display some analytics
        DisplayVideoAnalytics(videos);
        
        Console.WriteLine("\nProgram execution complete. Press any key to exit...");
        Console.ReadKey();
    }
    
    static void DisplayVideoAnalytics(List<Video> videos)
    {
        Console.WriteLine("Video Analytics Summary");
        Console.WriteLine("=".PadRight(50, '='));
        
        int totalComments = 0;
        Video mostCommentedVideo = null;
        int maxComments = 0;
        
        foreach (Video video in videos)
        {
            int commentCount = video.GetNumberOfComments();
            totalComments += commentCount;
            
            if (commentCount > maxComments)
            {
                maxComments = commentCount;
                mostCommentedVideo = video;
            }
            
            Console.WriteLine($"{video.Title}: {commentCount} comments");
        }
        
        double averageComments = (double)totalComments / videos.Count;
        
        Console.WriteLine("\nSummary:");
        Console.WriteLine($"Total Videos: {videos.Count}");
        Console.WriteLine($"Total Comments: {totalComments}");
        Console.WriteLine($"Average Comments per Video: {averageComments:F1}");
        
        if (mostCommentedVideo != null)
        {
            Console.WriteLine($"Most Commented Video: {mostCommentedVideo.Title} ({maxComments} comments)");
        }
    }
}