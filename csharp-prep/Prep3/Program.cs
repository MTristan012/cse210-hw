using System;

class Program
{
    static void Main(string[] args)
    {
        Random rnd = new Random();
        int rNumb = rnd.Next(0, 101);
        string  play = "yes";

        Console.WriteLine("What is the magic number?");
        Console.WriteLine("What is your guess?");
        int guess = int.Parse(Console.ReadLine());

        while (play == "yes")
        {
            while (rNumb != guess)
            {
                if (rNumb > guess)
                {
                    Console.WriteLine("Lower");
                }
                else
                {
                    Console.WriteLine("Higher");
                }

                Console.WriteLine("What is your guess?");
                guess = int.Parse(Console.ReadLine());
            }
            Console.WriteLine("You guessed it!");
            Console.WriteLine("You want to coninue playing? (yes/no)");
            play = Console.ReadLine();
            rNumb = rnd.Next(0, 101);
            Console.WriteLine("What is your guess?");
            guess = int.Parse(Console.ReadLine());
        }
    }
}