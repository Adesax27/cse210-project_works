using System;
using System.Collections.Generic;

// Main program class to run the demonstration
public class Program
{
    public static void Main(string[] args)
    {
        // Create a list to hold all the video objects
        List<Video> videos = new List<Video>();

        // --- Video 1 ---
        Video video1 = new Video("C# Tutorial for Beginners", "Tech with J.Reading", 3600);
        video1.AddComment("Ademola", "This was so helpful, thank you!");
        video1.AddComment("Bob", "Great explanation of classes.");
        video1.AddComment("Charlie", "I finally understand loops!");
        videos.Add(video1);

        // --- Video 2 ---
        Video video2 = new Video("How to Bake Sourdough Bread", "Pro Home Cooks", 1250);
        video2.AddComment("Dana", "My starter finally worked because of this video.");
        video2.AddComment("Eli", "The crust on my bread was perfect.");
        video2.AddComment("Frank", "Can you do a video on rye bread next?");
        video2.AddComment("Grace", "Best recipe I've found online.");
        videos.Add(video2);

        // --- Video 3 ---
        Video video3 = new Video("1 Hour of Relaxing Piano Music", "Soothing Sounds", 3660);
        video3.AddComment("Heidi", "I listen to this while studying.");
        video3.AddComment("Ivan", "So peaceful and calming.");
        video3.AddComment("Judy", "Perfect for my yoga session.");
        videos.Add(video3);
        
        // --- Video 4 ---
        Video video4 = new Video("Nigeria ladies, Super Eagles", "Morocco", 5400);
        video4.AddComment("Commentator 1", "Nigeria claim tenth as they beat host-nation Morocco 3-2.");
        video4.AddComment("Commentor 2", "WOW! This match was played at Olympic Stadium in Rabat, Morocco.");
        video4.AddComment("Interviwer", "Awesome content as always by the Nigeria Super Women Eagles!");
        videos.Add(video4);

        // --- Display all videos and their comments ---
        Console.WriteLine("--- Displaying Video Information ---");
        Console.WriteLine();

        foreach (var video in videos)
        {
            // Display the core video details
            Console.WriteLine($"Title: {video.Title}");
            Console.WriteLine($"Author: {video.Author}");
            Console.WriteLine($"Length: {video.LengthInSeconds} seconds");
            Console.WriteLine($"Number of Comments: {video.GetNumberOfComments()}");
            
            // Display all the comments for the video
            Console.WriteLine("Comments:");
            if (video.GetNumberOfComments() > 0)
            {
                foreach (var comment in video.GetComments())
                {
                    Console.WriteLine($"  - {comment.CommenterName}: \"{comment.CommentText}\"");
                }
            }
            else
            {
                Console.WriteLine("  [No comments for this video]");
            }

            // Add a separator for readability between videos
            Console.WriteLine("------------------------------------------");
            Console.WriteLine();
        }
    }
}

/// <summary>
/// Represents a YouTube video, tracking its metadata and a list of comments.
/// </summary>
public class Video
{
    // Properties to store the video's core information
    public string Title { get; private set; }
    public string Author { get; private set; }
    public int LengthInSeconds { get; private set; }

    // A private list to hold all the Comment objects associated with this video.
    // This is an example of abstraction; the Program class doesn't know or care
    // that a List<T> is being used internally.
    private List<Comment> _comments;

    /// <summary>
    /// Constructor to create a new Video object.
    /// </summary>
    /// <param name="title">The title of the video.</param>
    /// <param name="author">The creator of the video.</param>
    /// <param name="lengthInSeconds">The length of the video in seconds.</param>
    public Video(string title, string author, int lengthInSeconds)
    {
        Title = title;
        Author = author;
        LengthInSeconds = lengthInSeconds;
        _comments = new List<Comment>(); // Initialize the list
    }

    /// <summary>
    /// Adds a new comment to the video's comment list.
    /// </summary>
    /// <param name="commenterName">The name of the person making the comment.</param>
    /// <param name="commentText">The text content of the comment.</param>
    public void AddComment(string commenterName, string commentText)
    {
        Comment newComment = new Comment(commenterName, commentText);
        _comments.Add(newComment);
    }

    /// <summary>
    /// Returns the total number of comments on the video.
    /// </summary>
    /// <returns>An integer representing the count of comments.</returns>
    public int GetNumberOfComments()
    {
        return _comments.Count;
    }


    /// <summary>
    /// Returns the list of comments for display purposes.
    /// </summary>
    /// <returns>A list of Comment objects.</returns>
    public List<Comment> GetComments()
    {
        return _comments;
    }
}

/// <summary>
/// Represents a single comment made on a video.
/// </summary>
public class Comment
{
    // Properties to store the comment's information
    public string CommenterName { get; private set; }
    public string CommentText { get; private set; }

    /// <summary>
    /// Constructor to create a new Comment object.
    /// </summary>
    /// <param name="commenterName">The name of the person making the comment.</param>
    /// <param name="commentText">The text content of the comment.</param>
    public Comment(string commenterName, string commentText)
    {
        CommenterName = commenterName;
        CommentText = commentText;
    }
}
