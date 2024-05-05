using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

public class Journal
{
    public List<Entry> _entries;

    public Journal()
    {
        _entries = new List<Entry>();
    }

    public void AddEntry(Entry newEntry)
    {
        _entries.Add(newEntry);
    }

    public void DisplayAll()
    {
        if (_entries.Count == 0)
        {
            Console.WriteLine("No entries available.");
            return;
        }

        foreach (var entry in _entries)
        {
            Console.WriteLine($"Date: {entry._date}");
            Console.WriteLine($"Prompt: {entry._promptText}");
            Console.WriteLine($"Entry: {entry._entry}");
            Console.WriteLine($"Mood: {entry._mood}");
            Console.WriteLine();
        }
    }

    public void SaveToFile(string file, string format)
    {
        try
        {
            switch (format)
            {
                case "csv":
                    SaveToCsv($"{file}.{format}");
                    break;
                case "json":
                    SaveToJson($"{file}.{format}");
                    break;
                default:
                    Console.WriteLine("Invalid format. Please choose 'csv' or 'json'.");
                    break;
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error saving entries to file: {ex.Message}");
        }
    }

    private void SaveToCsv(string file)
    {
        using (StreamWriter writer = new StreamWriter(file))
        {
            foreach (var entry in _entries)
            {
                writer.WriteLine($"{entry._date},{entry._promptText},{entry._entry},{entry._mood}");
            }
        }

        Console.WriteLine("Entries saved to CSV file successfully.");
    }
    
    private void SaveToJson(string file)
    {
        var jsonEntries = new List<object>();

        foreach (var entry in _entries)
        {
            var jsonEntry = new
            {
                Date = entry._date,
                Prompt = entry._promptText,
                Entry = entry._entry,
                Mood = entry._mood
            };

            jsonEntries.Add(jsonEntry);
        }

        string jsonData = JsonSerializer.Serialize(jsonEntries, new JsonSerializerOptions { WriteIndented = true });

        File.WriteAllText(file, jsonData);

        Console.WriteLine("Entries saved to JSON file successfully.");
    }

    public void LoadFromFile(string file)
    {
        try
        {
            if (File.Exists(file))
            {
                _entries.Clear();

                using (StreamReader reader = new StreamReader(file))
                {
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {

                        if (string.IsNullOrWhiteSpace(line))
                        {
                            continue;
                        }

                        string[] parts = line.Split(',');
                        if (parts.Length == 4)
                        {
                            Entry entry = new Entry
                            {
                                _date = parts[0],
                                _promptText = parts[1],
                                _entry = parts[2],
                                _mood = parts[3]
                            };
                            _entries.Add(entry);
                        }
                    }
                }

                Console.WriteLine("Entries loaded from file successfully.");

                if (_entries.Count > 0)
                {
                    Console.WriteLine("Displaying loaded entries:");
                    DisplayAll();
                }
                else
                {
                    Console.WriteLine("No entries loaded.");
                }
            }
            else
            {
                Console.WriteLine("File not found.");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error loading entries from file: {ex.Message}");
        }
    }

}
