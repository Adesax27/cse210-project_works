using System; // Journal.cs

using System.Collections.Generic;
using System.IO;
using System.Linq;

public class Journal
{
    public List<Entry> _entries = new List<Entry>();

    public void AddEntry(string prompt, string response)
    {
        Entry newEntry = new Entry(DateTime.Now, prompt, response);
        _entries.Add(newEntry);
    }

    public void DisplayJournal()
    {
        if (_entries.Count == 0)
        {
            Console.WriteLine("Your journal is currently empty.");
            Console.WriteLine();
            return;
        }

        Console.WriteLine("--- Journal Entries ---");
        foreach (Entry entry in _entries)
        {
            entry.Display();
        }
        Console.WriteLine("--- End of Journal ---");
        Console.WriteLine();
    }

    public void SaveJournalToFile(string filename)
    {
        try
        {
            using (StreamWriter writer = new StreamWriter(filename))
            {
                foreach (Entry entry in _entries)
                {
                    writer.WriteLine($"{entry.Date.ToBinary()}");
                    writer.WriteLine(entry.Prompt);
                    writer.WriteLine(entry.Response);
                }
            }
            Console.WriteLine($"Journal saved to: {filename}");
            Console.WriteLine();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error saving journal to file: {ex.Message}");
            Console.WriteLine();
        }
    }

    public void LoadJournalFromFile(string filename)
    {
        _entries.Clear();
        try
        {
            if (File.Exists(filename))
            {
                using (StreamReader reader = new StreamReader(filename))
                {
                    while (!reader.EndOfStream)
                    {
                        if (long.TryParse(reader.ReadLine(), out long dateBinary))
                        {
                            DateTime date = DateTime.FromBinary(dateBinary);
                            string prompt = reader.ReadLine();
                            string response = reader.ReadLine();
                            Entry entry = new Entry(date, prompt, response);
                            _entries.Add(entry);
                        }
                        else
                        {
                            Console.WriteLine("Error reading date from file. Skipping entry.");
                        }
                    }
                }
                Console.WriteLine($"Journal loaded from: {filename}");
                Console.WriteLine();
            }
            else
            {
                Console.WriteLine($"File not found: {filename}");
                Console.WriteLine();
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error loading journal from file: {ex.Message}");
            Console.WriteLine();
        }
    }
}