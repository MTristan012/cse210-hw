using System;
using System.Collections.Generic;
using System.Linq;
class Program
{
    static void Main(string[] args)
    {
        
        List<int> numbers = [];
        int sum = 0;

        Console.WriteLine("Enter a list of numbers, type 0 when finished.");
        Console.WriteLine("Enter number:");
        int number = int.Parse(Console.ReadLine());
        numbers.Add(number);

        while (number != 0)
        {
            Console.WriteLine("Enter number:");
            number = int.Parse(Console.ReadLine());
            if (number != 0)
            {
                numbers.Add(number);
            }
        }

        foreach (int n in numbers)
        {
            sum += n;
        }
        Console.WriteLine($"The sum is: {sum}");

        int length = numbers.Count;
        double avg = (double)sum / length;
        Console.WriteLine($"The average is: {avg}");

        int max = numbers.Max();
        Console.WriteLine($"The largest number is: {max}");

        var positiveNumbers = numbers.Where(n => n > 0);
        int min = positiveNumbers.Min();
        Console.WriteLine($"The smallest positive number is: {min}");

        Console.WriteLine($"The sorted list is:");
        numbers.Sort();
        foreach (int n in numbers){
            Console.WriteLine(n);
        }

    }
}