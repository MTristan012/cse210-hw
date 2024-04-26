using System;

class Program
{
    static void Main(string[] args)
    {
        DisplayWelcome();
        string name = PromptUsaerName();
        int numer = PromptUserNumber();
        int sqr = SquareNumber(numer);
        DisplayResult(sqr, name);
    }
    static void DisplayWelcome(){
        Console.WriteLine("Welcome to the Program!");
    }
    static string PromptUsaerName(){
        Console.WriteLine("Please enter your name:");
        string name = Console.ReadLine();
        return name;
    }
    static int PromptUserNumber(){
        Console.WriteLine("Please enter your favorite number:");
        int number = int.Parse(Console.ReadLine());
        return number;
    }
    static int SquareNumber(int number){
        return _ = number * number;
    }
    static void DisplayResult(int number, string name){
        Console.WriteLine($"{name}, the square of your number is {number}");
    }
}