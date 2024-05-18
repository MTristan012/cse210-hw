using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;

public abstract class Activity
{
    protected string _name;
    protected string _description;
    protected int _duration;
    protected static Dictionary<string, int> _activityLog = new Dictionary<string, int>();

    public Activity(string name, string description)
    {
        _name = name;
        _description = description;
        if (!_activityLog.ContainsKey(name))
        {
            _activityLog[name] = 0;
        }
    }

    public void DisplayStartingMessage()
    {
        Console.Clear();
        Console.WriteLine($"Starting {_name} Activity");
        Console.WriteLine(_description);
        Console.Write("Enter the duration in seconds: ");
        _duration = int.Parse(Console.ReadLine());
        Console.WriteLine("Prepare to begin...");
        ShowSpinner(3);
    }

    public void DisplayEndingMessage()
    {
        Console.WriteLine("Good job!");
        ShowSpinner(2);
        Console.WriteLine($"You have completed the {_name} activity for {_duration} seconds.");
        ShowSpinner(2);
    }

    public void ShowSpinner(int seconds)
    {
        for (int i = 0; i < seconds; i++)
        {
            Console.Write("/");
            Thread.Sleep(250);
            Console.Write("\b-");
            Thread.Sleep(250);
            Console.Write("\b\\");
            Thread.Sleep(250);
            Console.Write("\b|");
            Thread.Sleep(250);
            Console.Write("\b");
        }
        Console.WriteLine();
    }

    public void ShowCountDown(int seconds)
    {
        for (int i = seconds; i > 0; i--)
        {
            Console.Write($"{i} ");
            Thread.Sleep(1000);
            Console.Write("\b\b\b");
        }
        Console.WriteLine();
    }

    public void LogActivity()
    {
        _activityLog[_name]++;
        SaveLog();
    }

    public static void SaveLog()
    {
        using (StreamWriter writer = new StreamWriter("activity_log.txt"))
        {
            foreach (var entry in _activityLog)
            {
                writer.WriteLine($"{entry.Key}:{entry.Value}");
            }
        }
    }

    public static void LoadLog()
    {
        if (File.Exists("activity_log.txt"))
        {
            using (StreamReader reader = new StreamReader("activity_log.txt"))
            {
                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine().Split(':');
                    _activityLog[line[0]] = int.Parse(line[1]);
                }
            }
        }
    }

    public abstract void Run();
}