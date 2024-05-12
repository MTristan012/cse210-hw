using System;
using System.Collections.Generic;

//Choose scriptures at random to present to the user.
class Program
{
    static void Main(string[] args)
    {
        List<Scripture> scriptures = new List<Scripture>();
        scriptures.Add(new Scripture(new Reference("John", 3, 16), "For God so loved the world, that he gave his only begotten Son, that whosoever believeth in him should not perish, but have everlasting life."));
        scriptures.Add(new Scripture(new Reference("Proverbs", 3, 5, 6), "Trust in the Lord with all thine heart; and lean not unto thine own understanding. In all thy ways acknowledge him, and he shall direct thy paths."));
        scriptures.Add(new Scripture(new Reference("1 Nephi", 3, 7), "And it came to pass that I, Nephi, said unto my father: I will go and do the things which the Lord hath commanded, for I know that the Lord giveth no commandments unto the children of men, save he shall prepare a way for them that they may accomplish the thing which he commandeth them."));
        scriptures.Add(new Scripture(new Reference("Doctrine and Covenants", 1, 5), "And they shall go forth and none shall stay them, for I the Lord have commanded them."));

        Random random = new Random();
        Scripture randomScripture = scriptures[random.Next(scriptures.Count)];

        DisplayScripture(randomScripture);

        Console.WriteLine("\nPress Enter to continue or type 'quit' to exit.");
        string input = Console.ReadLine();
        if (input.ToLower() == "quit")
            return;

        while (!randomScripture.IsCompletelyHidden())
        {
            randomScripture.HideRandomWords(1);
            Console.Clear();
            DisplayScripture(randomScripture);
            Console.WriteLine("\nPress Enter to continue or type 'quit' to exit.");
            input = Console.ReadLine();
            if (input.ToLower() == "quit")
                return;
        }

        Console.WriteLine("All words are hidden. Press Enter to exit.");
        Console.ReadLine();
    }

    static void DisplayScripture(Scripture scripture)
    {
        Console.Clear();
        Console.WriteLine(scripture.GetReference().GetDisplayText() + ":");
        foreach (Word word in scripture.GetWords())
        {
            Console.Write(word.GetDisplayText() + " ");
        }
    }
}