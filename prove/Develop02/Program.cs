using System;
using System.IO;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        FileHandler fileHandler = new FileHandler();
        JournalHandler journalHandler = new JournalHandler();
        EntryHandler entryHandler = new EntryHandler();

        string _currentFile = "";

        while (true)
        {
            Console.WriteLine("\nWelcome to the ezJournal! Select an option to begin:");
            Console.WriteLine("1) Open File");
            Console.WriteLine("2) Save File");
            Console.WriteLine("3) New Entry");
            Console.WriteLine("4) See Random Prompt");
            Console.WriteLine("5) Display Entries");
            Console.WriteLine("6) Exit");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    journalHandler.LoadFile(fileHandler);
                    break;
                case "2":
                    fileHandler.SaveFile();
                    break;
                case "3":
                    string newEntry = entryHandler.NewEntry();
                    journalHandler.AddEntry(newEntry);
                    fileHandler.SetFile(journalHandler.GetFileContents());
                    break;
                case "4":
                    entryHandler.ChooseRandomPrompt();
                    break;
                case "5":
                    journalHandler.DisplayEntries();
                    break;
                case "6":
                    Console.WriteLine("Goodbye!");
                    return;
                default:
                    Console.WriteLine("Invalid option. Try again.");
                    break;
            }
        }
    }
}

//Classes are typically in another file. (For this project I left them all in one, in the future I will separate them out. )
class FileHandler
{
    public string _file;

    //private string _fileContent = OpenFile();

    public string OpenFile()
    //Ask the user for a path and then save the content of that file into _file.
    {
        Console.Write("Please type the filepath of your file: ");
        string filePath = Console.ReadLine();
        //using try/catch so that if something goes wrong, it doesnt break the whole program. It will tell the user if the file does not exist.
        //NOTE: The path is RELATIVE to the .cs file.
        try
        {
            _file = File.ReadAllText(filePath);
            return _file;
        }
        catch
        {
            Console.WriteLine($"{filePath} could not be found.");
            return string.Empty;
        }
    }

    public void SaveFile()
    // saves the current file to a given filepath.
    {
        Console.Write("Please type a path to save this file to (.txt files only): ");
        string filePath = Console.ReadLine();
        //using try/catch so that if something goes wrong, it doesnt break the whole program. 
        try
        {
            File.WriteAllText(filePath, _file);
            Console.WriteLine("File Saved");
        }
        catch
        {
            Console.WriteLine("File not saved, please try again.");
        }
    }
    
    public void SetFile(string content) // ChatGPT recommended putting this in a separate method, but I don't quite understand why yet. 
    {
        _file = content;
    }
}

class JournalHandler
{
    private string _currentFile = "";
    private List<string> _entryList = new List<string>();

    public void LoadFile(FileHandler fileHandler)
    {
        _currentFile = fileHandler.OpenFile(); //references the FileHandler Class to grab the return value of OpenFile.
        string[] entryListRaw = _currentFile.Split("#/"); //Split the entries on #/
        _entryList.Clear(); //remove anything in the current list, then replace it with the contents of the opened file. 

        foreach (string entry in entryListRaw)
        {
            _entryList.Add(entry.Trim()); //trim up any whitespace. 
        }
    }

    public void DisplayEntries()
    {
        Console.WriteLine("Journal Entries:");
        foreach (string entry in _entryList)
        {
            Console.WriteLine("- " + entry);
        }
    }

    public void AddEntry(string entry)
    {
        _entryList.Add(entry);
        Console.WriteLine("Entry added.");
    }

    public string GetFileContents()
    {
        return string.Join("#/", _entryList); // I am using '#/' to separate entries. 
    }
}

class EntryHandler
{
    public string _time = "";

    List<string> _prompts = new List<string> //just a list of random prompts. Probably should have added more. 
    {
        "What was your favorite thing about the day?",
        "What is your favorite thing about your significant other?",
        "When did you wake up this morning?"
    };

public string NewEntry()
{
    Console.WriteLine("Begin typing your new entry. Start and end it with #/:");
    string _currentEntry = Console.ReadLine();
    
    // Adds the current date and formats nicely
    return $"[{GetCurrentDate()}] {_currentEntry}"; //Cant imagine a world without string literals.
}

    public string GetCurrentDate() //I want the current date!!!!!
    {
        return DateTime.Now.ToString("yyyy-MM-dd HH:mm");
    }

    public void ChooseRandomPrompt()
    {
        Random random = new Random();
        int randomIndex = random.Next(0, _prompts.Count); //.Count allows me the make the prompt list as long or short as I want!
        Console.WriteLine("Prompt: " + _prompts[randomIndex]);
    }
}