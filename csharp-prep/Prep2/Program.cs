using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Insert your score here:");
        int score = int.Parse(Console.ReadLine());

        string grade = "";
        string sign = "";
        float scoreSign = 0;
        string message = "";

        if (score >= 90) 
        {
            grade = "A";
        }
        else if (score < 90 && score >= 80)
        {
            grade = "B";
        }
        else if (score < 80 && score >= 70)
        {
            grade = "C";
        }
        else if (score < 70 && score >= 60)
        {
            grade = "D";
        }
        else
        {
            grade = "F";
        }

        
        if (score < 93 && score >= 60)
        {
            scoreSign = score % 10;
            if (scoreSign >= 7)
            {
                sign = "+";
            }
            else if (scoreSign < 3)
            {
                sign = "-";
            }
            else
            {
                sign = "";
            }
        }

        if (score >= 70)
        {
            message = "Congratulation you Pass!";
        }
        else{
            message = "You Shall not Pass";
        }
        
        Console.WriteLine($"Your grade is {grade}{sign} {message}");
    }
}