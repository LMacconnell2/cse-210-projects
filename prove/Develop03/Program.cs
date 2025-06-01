using System;
using System.ComponentModel.Design;
using System.IO;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Text.Json;

class Program
{
    static ReferenceHandler referenceHandler;
    static ScriptureHandler scriptureHandler;
    static int difficulty = 1;

    static void Main(string[] args)
    {
        bool quit = false;
        string filePath = "";
        while (!quit)
        {
            Console.WriteLine("Welcome to the scripture memorizer!! ");
            Console.WriteLine("Select an option to begin the program! ");
            Console.WriteLine();
            Console.WriteLine("1) Open Scripture File. ");
            Console.WriteLine("2) Display Current Scripture. ");
            Console.WriteLine("3) Display Current scripture with hidden letters. ");
            Console.WriteLine("4) Set Memorizor Difficulty ");
            Console.WriteLine("5) Quit ");
            Console.WriteLine();
            string selection = Console.ReadLine();

            if (selection == "1")
            {
                Console.Write("Enter path to JSON file: ");
                filePath = Console.ReadLine();

                if (File.Exists(filePath))
                {
                    try
                    {
                        string json = File.ReadAllText(filePath);
                        ScriptureData data = JsonSerializer.Deserialize<ScriptureData>(json);

                        referenceHandler = new ReferenceHandler(data.Reference);
                        scriptureHandler = new ScriptureHandler(data.Verse);

                        Console.WriteLine("Scripture loaded successfully.");
                    }
                    catch (Exception err) //Everytime I chucked my code into ChatGPT to see what I did wrong, it recommended using a try/catch in the case that the file is not valid Json or is corrupted. 
                    {
                        Console.WriteLine("Error loading file: " + err.Message);
                    }
                }
                else
                {
                    Console.WriteLine("File does not exist.");
                }
            }
            else if (selection == "2")
            {
                if (referenceHandler != null && scriptureHandler != null) //ChatGPT recommended using these if/else statements to ensure the code does not break if someone attempts to do something if a file is not opened yet. 
                {
                    referenceHandler.DisplayReference();
                    scriptureHandler.DisplayVerse();
                }
                else
                {
                    Console.WriteLine("Please load a scripture file first.");
                }
            }
            else if (selection == "3")
            {
                if (referenceHandler != null && scriptureHandler != null)
                {
                    referenceHandler.DisplayReference();
                    scriptureHandler.DisplayHiddenVerse(difficulty);
                }
                else
                {
                    Console.WriteLine("Please load a scripture file first.");
                }
            }
            else if (selection == "4")
            {
                Console.WriteLine("Please select a difficulty level: ");
                Console.WriteLine("1) Hide every other letter. ");
                Console.WriteLine("2) Hide everything but the first letter. ");
                Console.WriteLine("3) Show only hyphens for every character in each word. ");
                int difficult = int.Parse(Console.ReadLine());
            }
            else if (selection == "5")
            {
                Console.WriteLine("Have a nice day!! ");
                quit = true;
            }
        }
    }
}

public class ScriptureData //This class is chatGPT generated. I could not for the life of me get this to work while 1) part of another clas, and 2)
{
    public string Reference { get; set; }
    public string Verse { get; set; }
}

class ReferenceHandler
{
    private string _reference;

    public ReferenceHandler(string reference)
    {
        _reference = reference;
    }

    public void DisplayReference()
    {
        Console.WriteLine($"Reference: {_reference}");
    }
}

class ScriptureHandler
{
    private string _verse;
    private List<string> _words;

    public ScriptureHandler(string verse)
    {
        _verse = verse;
        _words = new List<string>(_verse.Split(' '));
    }

    public void DisplayVerse()
    {
        Console.WriteLine(_verse);
    }

    public void DisplayHiddenVerse(int difficulty)
    {
        foreach (string word in _words)
        {
            WordHandler wordHandler = new WordHandler(word, difficulty); //This code iterates through each word in the original list and returns the hidden version
            Console.Write(wordHandler.GetHiddenWord() + " ");
        }
    }
}

class WordHandler
{
    private string _theWord; //Thought this variable name would be funny.
    private int _hideType;

    public WordHandler(string word, int hideType)
    {
        _theWord = word;
        _hideType = hideType;
    }

    public string GetHiddenWord()
    {
        switch (_hideType)
        {
            case 1: //Added the option to choose the difficulty. Does this count as extra stuff?
                return HideEveryOtherLetter();
            case 2: 
                return ShowOnlyFirstLetter();
            case 3: 
                return new string('-', _theWord.Length); //no need for a method on this one.
            default:
                return _theWord;
        }
    }

    private string HideEveryOtherLetter()
    {
        char[] chars = _theWord.ToCharArray();
        for (int i = 1; i < chars.Length; i += 2)
        {
            chars[i] = '-';
        }
        return new string(chars);
    }

    private string ShowOnlyFirstLetter()
    {
        if (_theWord.Length <= 1)
            return _theWord;
        return _theWord[0] + new string('-', _theWord.Length - 1);
    }
}
