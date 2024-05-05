using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

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
            Console.WriteLine();
        }
    }

    public void SaveToFile(string file)
    {
        try
        {
            using (StreamWriter writer = new StreamWriter(file))
            {
                foreach (var entry in _entries)
                {
                    writer.WriteLine($"{entry._date},{entry._promptText},{entry._entry}");
                }
            }

            Console.WriteLine("Entries saved to file successfully.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error saving entries to file: {ex.Message}");
        }
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
                        // Saltar líneas vacías
                        if (string.IsNullOrWhiteSpace(line))
                        {
                            continue;
                        }

                        string[] parts = line.Split(',');
                        if (parts.Length == 3)
                        {
                            Entry entry = new Entry
                            {
                                _date = parts[0],
                                _promptText = parts[1],
                                _entry = parts[2]
                            };
                            _entries.Add(entry);
                        }
                    }
                }

                Console.WriteLine("Entries loaded from file successfully.");
            }
            else
            {
                Console.WriteLine("File not found.");
            }

            Console.WriteLine("Displaying loaded entries:");
            DisplayAll();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error loading entries from file: {ex.Message}");
        }
    }

}
