using System;

public class Entry
{
    private Journal _journal;

    public string _date;
    public string _promptText;
    public string _entry;
    public string _mood;

    public Entry(Journal journal)
    {
        _journal = journal;
        _date = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
    }

    public Entry()
    {
    }

    public void Display(PromptGenerator promptGenerator)
    {
        Console.WriteLine("Welcome");
        Console.WriteLine("Choose an Option:");
        Console.WriteLine("1) Write a record");
        Console.WriteLine("2) Display all the records");
        Console.WriteLine("3) Load a record file");
        Console.WriteLine("4) Save the records in a file");
        Console.WriteLine("5) Exit");
        int option = int.Parse(Console.ReadLine());
        switch (option)
        {
            case 1:
                string promptText = promptGenerator.GetRandomPrompt();
                Console.WriteLine($"Q: {promptText}");
                Console.Write("A: ");
                string entryText = Console.ReadLine();

                Console.Write("How do you feel?: ");
                string mood = Console.ReadLine();

                Entry newEntry = new Entry(_journal);
                newEntry._promptText = promptText;
                newEntry._entry = entryText;
                newEntry._mood = mood;

                _journal.AddEntry(newEntry);
                break;
            case 2:
                _journal.DisplayAll();
                break;
            case 3:
                Console.Write("Enter the file name to load: ");
                string fileName = Console.ReadLine();
                _journal.LoadFromFile(fileName);
                break;
            case 4:
                Console.WriteLine("Enter the format to save (csv): ");
                string formatToSave = Console.ReadLine().ToLower();
                Console.Write("Enter the file name to save: ");
                string fileNameToSave = Console.ReadLine();
                _journal.SaveToFile(fileNameToSave, formatToSave);
                break;
            case 5:
                Console.WriteLine("Be Safe, Friend. Don't you dare go Hollow");
                Environment.Exit(0);
                break;
            default:
                Console.WriteLine("Invalid option. Please choose a valid option.");
                break;
        }
    }
}