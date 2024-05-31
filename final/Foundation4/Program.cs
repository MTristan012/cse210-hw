class Program
{
    static void Main()
    {
        Activity running = new Running(new DateTime(2023, 5, 1), 30, 5);
        Activity cycling = new Cycling(new DateTime(2023, 5, 2), 60, 20);
        Activity swimming = new Swimming(new DateTime(2023, 5, 3), 45, 30);

        Console.WriteLine(running.GetSummary());
        Console.WriteLine(cycling.GetSummary());
        Console.WriteLine(swimming.GetSummary());
    }
}