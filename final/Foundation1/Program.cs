using System;

class Program
{
    static void Main()
    {
        List<Video> videos = new List<Video>();

        Video video1 = new Video("¡Celebración por los 200,000 Subs con Age of Empires II!", "3GB", 7200);
        video1.AddComment(new Comment("Jabalí", "Great video!"));
        video1.AddComment(new Comment("Rinku", "Very Funny!"));
        video1.AddComment(new Comment("senki_c", "Thanks for sharing!"));
        videos.Add(video1);

        Video video2 = new Video("Dead Cells: Return to Castlevania DLC - Launch Trailer", "Motion Twin", 101);
        video2.AddComment(new Comment("Koon Edu", "I loved it!"));
        video2.AddComment(new Comment("Old Jenkins", "I Want it!"));
        videos.Add(video2);

        Video video3 = new Video("polnalyubvi & Attaque de panique — Дикий Райский Сад (live)", "polnalyubvi", 268);
        video3.AddComment(new Comment("Wololo", "Awesome!"));
        video3.AddComment(new Comment("Davincho", "Incredible, I've never heard any song like this before."));
        videos.Add(video3);

        foreach (var video in videos)
        {
            Console.WriteLine($"Title: {video.GetTitle()}");
            Console.WriteLine($"Author: {video.GetAuthor()}");
            Console.WriteLine($"Length: {video.GetLength()} seconds");
            Console.WriteLine($"Number of comments: {video.GetNumberOfComments()}");

            foreach (var comment in video.GetComments())
            {
                Console.WriteLine($"Comment by {comment.GetName()}: {comment.GetText()}");
            }

            Console.WriteLine();
        }
    }
}