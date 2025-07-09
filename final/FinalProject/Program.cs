using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text.Json;

class Program
{


    static void Main(string[] args)
    {
        bool quit = false;
        string selection = "";
        Console.WriteLine("Welcome to Task Tracker!! ");

        // Create each of the classes
        EventHandler eventHandler = new EventHandler();
        FileHandler fileHandler = new FileHandler();
        while (!quit)
        {
            Console.WriteLine();
            Console.WriteLine("Select an Option to Begin: ");
            Console.WriteLine("1) Display Current Events");
            Console.WriteLine("2) Create a New Event");
            Console.WriteLine("3) Update an Existing Event");
            Console.WriteLine("4) Remove an Event");
            Console.WriteLine("5) Save to file");
            Console.WriteLine("6) Open existing file.");
            selection = Console.ReadLine();
            if (selection == "1")
            {
                eventHandler.DisplayEvents();
            }
            else if (selection == "2")
            {
                eventHandler.NewEvent();
            }
            else if (selection == "3")
            {
                eventHandler.CompleteEvent();
            }
            else if (selection == "4")
            {
                eventHandler.RemoveEvent();
            }
            else if (selection == "5")
            {
                fileHandler.addToFile("string");
            }
            else if (selection == "6")
            {
                fileHandler.OpenFile("Example FilePath");
            }
            else
            {
                Console.WriteLine("Command not recognized, please try again. ");
            }
            Thread.Sleep(3000);
            Console.Clear();
        }
    }
}

class EventHandler
{
    public List<Event> _events { get; set; } = new List<Event>();

    public EventHandler()
    {
        Console.WriteLine("This is the EventHandler Constructor");
    }

    public void DisplayEvents()
    {
        Console.WriteLine("This is the DisplayEvents method");
    }

    public void NewEvent()
    {
        Console.WriteLine("Creating a New Event");
    }

    public void RemoveEvent()
    {
        Console.WriteLine("Removed an Event");
    }

    public void CompleteEvent()
    {
        Console.WriteLine("Completing an Event");
    }
}

class Event
{
    protected string eventName;
    protected string eventDescription;
    protected string eventType;
    protected bool repeatable;
    protected List<string> datesRepeated { get; set; } = new List<string>();

    public Event()
    {
        Console.WriteLine("Here is the event constructor!");
    }
    public void updateEvent()
    {
        Console.WriteLine("Selected Event has been updated");
    }

    public void RepeatEvent()
    {
        Console.WriteLine("Selected Event has been repeated");
    }

    public virtual void DisplayEvent()
    {
        Console.WriteLine("Displaying the default event");
        Console.WriteLine("How did you get here? ");
    }
}

class Reminder : Event
{
    private int _minutesToEvent;
    private int _priority;
    private int _minute;
    private int _hour;
    private int _year;

    public Reminder() : base()
    {
        Console.WriteLine("Here is the reminder constructor!");
    }

    public override void DisplayEvent()
    {
        Console.WriteLine("This displays the reminder event");
    }
}

class DueDate : Event
{
    private int _hourDue;
    private int _dayDue;
    private int _monthDue;
    private int _yearDue;
    private bool _completed;

    public DueDate() : base()
    {
        Console.WriteLine("HEre is the DueDate Constructor!");
    }

    public void DisplayDueDate()
    {
        Console.WriteLine("Your late for your date! Now she has to wait while finish your plate!");
    }

    public override void DisplayEvent()
    {
        Console.WriteLine("This displays the Due Date Event");
    }
}

class TimeBlock : Event
{
    private int _startHour;
    private int _endHour;
    private int _startMinute;
    private int _endMinute;
    private List<int> _date { get; set; } = new List<int>();
    private string _notes;
    public TimeBlock() : base()
    {
        Console.WriteLine("This is the TimeBlock constructor!");
    }

    public void DisplayNotes()
    {
        _notes = "This is a note I made in 10 seconds";
        Console.WriteLine(_notes);
    }
    public override void DisplayEvent()
    {
        Console.WriteLine("This is the DisplayEvent method for the TimeBlock class");
    }
}

class Appointment : TimeBlock
{
    private List<string> _persons { get; set; } = new List<string>();
    private string _address;

    public Appointment() : base()
    {
        Console.WriteLine("This is the constructor for the appointment class!");
    }

    public override void DisplayEvent()
    {
        Console.WriteLine("You have an appointment... now! GO GO GO!");
    }
}

class Class : TimeBlock
{
    private string _subject;
    private string _teacher;

    public Class() : base()
    {
        Console.WriteLine("This is the Class cosntructor!");
    }

    public override void DisplayEvent()
    {
        Console.WriteLine("Why did you decide to take this class?");
    }
}

class FileHandler
{
    private string _file;
    private string _filePath;

    public FileHandler() : base()
    {
        Console.WriteLine("This is the FileHandler constructor!");
    }

    public string OpenFile(string filePath)
    {
        return "File Opened";
    }

    public string addToFile(int day)
    {
        return "Reminder";
    }

    public string addToFile(string day)
    {
        return "DueDate";
    }

    public string addToFile(float day)
    {
        return "TimeBlock";
    }
}

