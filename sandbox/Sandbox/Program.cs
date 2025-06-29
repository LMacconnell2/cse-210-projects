// using System;
// using System.Collections.Generic;
// using System.Globalization;

// class Program
// {
//     static void Main(string[] args)
//     {
//         // // string valueInText = "42";
//         // // int valueNumber = int.Parse(valueInText);
//         // // Console.WriteLine(valueNumber);
//         // // int x = 5;
//         // // int y = 3;
//         // // if (x > y)
//         // // {
//         // //     Console.WriteLine("X is greater than Y");
//         // // }
//         // // else
//         // // {
//         // //     Console.WriteLine("X is not greater than &.");
//         // // }
//         // // // Console.WriteLine(x);
//         // // string school = "BYU-Idaho";
//         // // if (school == "BYU-Idaho") 
//         // // {
//         // //     Console.WriteLine("This is the best college ever!");
//         // // }
//         // // Console.WriteLine($"I am studying at {school}");
//         // // Console.Write("What is your favorite color? ");
//         // // string color = Console.ReadLine();
//         // // Console.WriteLine(color);

//         // // if (color == "Blue")
//         // // {
//         // //     Console.WriteLine($"{color} is my favorite color too!");
//         // // }
//         // // else {
//         // //     Console.WriteLine($"{color} is a disgusting color.");
//         // // }

//         // Console.Write("What is your grade percentage?");
//         // string gradePercentString = Console.ReadLine();
//         // int gradePercent = int.Parse(gradePercentString);
//         // string letter = "";
//         // bool failing = false;

//         // if (gradePercent >= 90)
//         // {
//         //     letter = "A";
//         // }
//         // else if (gradePercent >= 80)
//         // {
//         //     letter = "B";
//         // }
//         // else if (gradePercent >= 70)
//         // {
//         //     letter = "C";
//         // }
//         // else if (gradePercent >= 60)
//         // {
//         //     letter = "D";
//         //     failing = true;
//         // }
//         //         else if (gradePercent < 60)
//         // {
//         //     letter = "F";
//         //     failing = true;
//         // }

//         // Console.WriteLine($"Your grade is: {letter} in this class");
//         // if (failing)
//         // {
//         //     Console.WriteLine("You are currently failing this class.");
//         // } 
//         // double kphValue = 0;
//         // Console.Write("Type your speed in kph: ");
//         // kphValue = int.Parse(Console.ReadLine());
//         // double mphValue = 0;
//         // mphValue = kphValue*0.621371;


//         // Console.WriteLine($"{kphValue} kph is {Math.Round(mphValue, 2)} miles per hour.");
//         // if (kphValue > 200)
//         // {
//         //     Console.WriteLine("STOP SPEEDING!");
//         // }
//         // else
//         // {
//         //     Console.WriteLine("Thanks for obeying the law");
//         // }

//         // for (int i = 1; i <= 10; i++)
//         // {
//         //     Console.WriteLine($"The current number is {i}");
//         // }

//         // string response = "";
//         // do
//         // {
//         // Console.Write("Do you want to continue? ");
//         // response = Console.ReadLine();
//         // } while (response == "yes");


//         // List<int> guesses = new List<int>();
//         // int luckyNumber;
//         // int guessNumber;
//         // int i = 0;
//         // bool loop = true;
//         // Console.WriteLine("This is a number guessing game. Please only use integers. ");
//         // Console.Write("Choose a number to be the magic number. ");
//         // luckyNumber = int.Parse(Console.ReadLine());

//         // while (loop) 
//         // {
//         //     Console.Write("Guess a number: ");
//         //     guessNumber = int.Parse(Console.ReadLine());
//         //     guesses.Add(guessNumber);
//         //     i += 1;
//         //     if (guessNumber < luckyNumber)
//         //     {
//         //         Console.WriteLine("Too Low!");
//         //     }
//         //     else if (guessNumber > luckyNumber)
//         //     {
//         //         Console.WriteLine("Too High!");
//         //     }
//         //     else if (guessNumber == luckyNumber)
//         //     {
//         //         Console.WriteLine($"Congratulations! You found the correct answer of {luckyNumber} in {i} try(s). ");
//         //         loop = false;
//         //     }
//         // }
//         // Console.WriteLine("Your guesses were: ");
//         // foreach (int guess in guesses)
//         // {
//         //     Console.Write($"{guess}. ");

//         // }

//         // DisplayWelcome();

//     }


//     // static void DisplayWelcome()
//     // {
//     //     Console.WriteLine("Welcome to the program! ");
//     //     PromptUserName();

//     // }

//     // static void PromptUserName()
//     // {   
//     //     string userName = "";
//     //     Console.Write("Please enter your name: ");
//     //     userName = Console.ReadLine();
//     //     PromptUserNumber(userName);
//     // }

//     // static void PromptUserNumber(string userName)
//     // {
//     //     int userNumber = 0;
//     //     Console.Write("Please enter your favorite integer: ");
//     //     userNumber = int.Parse(Console.ReadLine());
//     //     SquareNumber(userNumber, userName);
//     // }

//     // static void SquareNumber(int userNumber, string userName)
//     // {
//     //     int squaredNumber;
//     //     squaredNumber = userNumber * userNumber;
//     //     DisplayResults(userName, squaredNumber);
//     // }

//     // static void DisplayResults(string userName, int squaredNumber)
//     // {
//     //     Console.WriteLine($"Hello {userName}, the square of your number is: {squaredNumber}");
//     // }
// }
// class Person
// {
//     protected string _name;
//     protected int _age;
//     protected bool _isLeftHanded;
// }
// public class Student : Person
// {
//     private int _iNumber;
// }

using System;
using System.Collections.Generic;

class LibraryItem
{
    private string _name;
    private string _description;
    private int _id;
    private int _totalItems;
    private int _numberCheckedOut;

    public LibraryItem(string name, string description, int id, int totalItems, int numberCheckedOut)
    {
        _name = name;
        _description = description;
        _id = id;
        _totalItems = totalItems;
        _numberCheckedOut = numberCheckedOut;
    }

    public int GetTotalItems()
    {
        return _totalItems;
    }

    public void CheckOut()
    {
        if (_numberCheckedOut < _totalItems)
        {
            _numberCheckedOut++;
        }
        else
        {
            Console.WriteLine($"{_name} is not available for checkout.");
        }
    }

    public void CheckIn()
    {
        if (_numberCheckedOut > 0)
        {
            _numberCheckedOut--;
        }
    }

    public void Display()
    {
        Console.WriteLine($"ID: {_id}, Name: {_name}, Description: {_description}, Total: {_totalItems}, Checked Out: {_numberCheckedOut}");
    }
}

class Book : LibraryItem
{
    private int _numberOfPages;
    private string _author;

    public int NumberOfPages { get { return _numberOfPages; } }
    public string Author { get { return _author; } }

    public Book(string name, string description, int id, int totalItems, int numberCheckedOut, int numberOfPages, string author)
        : base(name, description, id, totalItems, numberCheckedOut)
    {
        _numberOfPages = numberOfPages;
        _author = author;
    }

    public void DisplayBook()
    {
        base.Display();
        Console.WriteLine($"Author: {_author}, Pages: {_numberOfPages}");
    }
}

class AudioBook : LibraryItem
{
    private double _duration;
    private string _author;
    private List<string> _cast;

    public double Duration { get { return _duration; } }
    public string Author { get { return _author; } }
    public List<string> Cast { get { return _cast; } }

    public AudioBook(string name, string description, int id, int totalItems, int numberCheckedOut, double duration, string author, List<string> cast)
        : base(name, description, id, totalItems, numberCheckedOut)
    {
        _duration = duration;
        _author = author;
        _cast = cast;
    }

    public void DisplayAudioBook()
    {
        base.Display();
        Console.WriteLine($"Author: {_author}, Duration: {_duration} hrs, Cast: {string.Join(", ", _cast)}");
    }
}

class Map : LibraryItem
{
    private string _location;
    private string _size;

    public string Location { get { return _location; } }
    public string Size { get { return _size; } }

    public Map(string name, string description, int id, int totalItems, int numberCheckedOut, string location, string size)
        : base(name, description, id, totalItems, numberCheckedOut)
    {
        _location = location;
        _size = size;
    }

    public void DisplayMap()
    {
        base.Display();
        Console.WriteLine($"Location: {_location}, Size: {_size}");
    }
}

class DVD : LibraryItem
{
    private string _producer;

    public string Producer { get { return _producer; } }

    public DVD(string name, string description, int id, int totalItems, int numberCheckedOut, string producer)
        : base(name, description, id, totalItems, numberCheckedOut)
    {
        _producer = producer;
    }

    public void DisplayDVD()
    {
        base.Display();
        Console.WriteLine($"Producer: {_producer}");
    }
}

class Program
{
    static void Main()
    {
        List<Book> books = new List<Book>
        {
            new Book("C# Basics", "Intro to C#", 1, 5, 1, 300, "Jane Doe"),
            new Book("Advanced C#", "Deep dive into C#", 2, 3, 0, 450, "John Sharp"),
            new Book("OOP Concepts", "Understanding Object-Oriented Programming", 3, 4, 2, 280, "Sarah Codewell")
        };

        List<AudioBook> audioBooks = new List<AudioBook>
        {
            new AudioBook("The Great Audio Adventure", "An exciting journey", 4, 3, 2, 2.5, "John Smith", new List<string> { "Alice", "Bob" }),
            new AudioBook("C# Audio Course", "Learn by listening", 5, 2, 1, 3.0, "Emily Syntax", new List<string> { "Tom", "Nina" }),
            new AudioBook("History of Computing", "A spoken documentary", 6, 1, 0, 1.5, "Alan Retrospect", new List<string> { "Dr. Tech", "Narrator Joe" })
        };

        List<Map> maps = new List<Map>
        {
            new Map("World Map", "Geographical map", 7, 2, 0, "Global", "Large"),
            new Map("City Transit Map", "Map of public transportation routes", 8, 5, 1, "Metroville", "Medium")
        };

        List<DVD> dvds = new List<DVD>
        {
            new DVD("C# Movie", "Learn C# visually", 9, 4, 1, "Tech Films"),
            new DVD("Design Patterns Explained", "Understand design patterns visually", 10, 3, 0, "CodeMedia"),
            new DVD("Introduction to Databases", "Database basics for beginners", 11, 2, 1, "LearnIt Studios")
        };

        foreach (var book in books)
        {
            book.DisplayBook();
        }

        foreach (var audio in audioBooks)
        {
            audio.DisplayAudioBook();
        }

        foreach (var map in maps)
        {
            map.DisplayMap();
        }

        foreach (var dvd in dvds)
        {
            dvd.DisplayDVD();
        }

        int totalItems = 0;
        foreach (var book in books)
        {
            totalItems += book.GetTotalItems();
        }
        foreach (var audio in audioBooks)
        {
            totalItems += audio.GetTotalItems();
        }
        foreach (var map in maps)
        {
            totalItems += map.GetTotalItems();
        }
        foreach (var dvd in dvds)
        {
            totalItems += dvd.GetTotalItems();
        }

        Console.WriteLine($"\nTotal Library Items: {totalItems}");
    }
}
