using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection.PortableExecutable;
using System.Runtime.InteropServices;
using System.Text.Json;
using System.Diagnostics;

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
            eventHandler.DisplayTodayEvents();
            Console.WriteLine();
            Console.WriteLine("Select an Option to Begin: ");
            Console.WriteLine("1) Display Current Events");
            Console.WriteLine("2) Create a New Event");
            Console.WriteLine("3) Update an Existing Event");
            Console.WriteLine("4) Remove an Event");
            Console.WriteLine("5) Save to file");
            Console.WriteLine("6) Open existing file.");
            Console.WriteLine("7) Quit");
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
                Console.Write("Enter file path to save: ");
                string savePath = Console.ReadLine();
                FileHandler.SaveFile(savePath, eventHandler.Events);
            }
            else if (selection == "6")
            {
                Console.Write("Enter file path to open: ");
                string openPath = Console.ReadLine();
                eventHandler.Events = FileHandler.OpenFile(openPath);
            }
            else if (selection == "7")
            {
                FileHandler.FileCleanup();
                quit = true;
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
    public List<Event> Events { get; set; } = new List<Event>();

    public void DisplayEvents()
    {
        Console.Write("Select a Day to display: (MM-DD-YYYY): ");
        string date = Console.ReadLine();
        int count = 0;
        for (int i = 0; i < Events.Count; i++)
        {
            if (Events[i].Date.Contains(date))
            {
                Console.Write($"{++count}) ");
                Events[i].DisplayEvent();
            }
        }
        if (count == 0) Console.WriteLine("No events on this date.");
    }

    public void DisplayTodayEvents()
    {
    string today = DateTime.Now.ToString("MM-dd-yyyy");
    int count = 0;

    Console.WriteLine("Reminders and Due Dates Today:");

    foreach (var e in Events)
    {
        if (e.OccursOnDate(today) && e.IsReminderOrDueDate())
        {
            e.DisplayEvent();
            count++;
        }
    }
    if (count == 0)
    {
        Console.WriteLine("No events today.");
    }
    Console.WriteLine();
    }

    public void NewEvent()
    {
        Console.Write("Enter event type (Reminder, Due Date, Appointment, Class): ");
        string type = Console.ReadLine();
        Console.Write("Enter name: ");
        string name = Console.ReadLine();
        Console.Write("Enter description: ");
        string desc = Console.ReadLine();
        Console.Write("Enter date(s) (comma-separated): ");
        string date = Console.ReadLine();

        Event newEvent = type.ToLower() switch
        {
            "reminder" => new Reminder(name, desc, date),
            "due date" => new DueDate(name, desc, date),
            "appointment" => new Appointment(name, desc, date),
            "class" => new Class(name, desc, date),
            _ => new Event(name, desc, date)
        };

        Events.Add(newEvent);
        Console.WriteLine("Event added.");
    }

    public void RemoveEvent()
    {
        Console.Write("Enter event name to remove: ");
        string name = Console.ReadLine();
        Events.RemoveAll(e => e.EventName.Equals(name, StringComparison.OrdinalIgnoreCase));
        Console.WriteLine("Event removed.");
    }

    public void CompleteEvent()
    {
        Console.Write("Enter event name to mark complete: ");
        string name = Console.ReadLine();
        var ev = Events.Find(e => e.EventName.Equals(name, StringComparison.OrdinalIgnoreCase));
        if (ev != null)
        {
            ev.Completed = true;
            Console.WriteLine("Event marked as complete.");
        }
        else Console.WriteLine("Event not found.");
    }
}

class Event
{
    public string EventType { get; set; }
    public string EventName { get; set; }
    public string EventDescription { get; set; }
    public string Date { get; set; }
    public bool Completed { get; set; }
    public bool Repeatable { get; set; }

    public Event() { }

    public Event(string name, string desc, string date)
    {
        EventName = name;
        EventDescription = desc;
        Date = date;
        Completed = false;
        Repeatable = date.Contains(",");
    }

    public virtual void DisplayEvent()
    {
        Console.WriteLine($"{EventType}: {EventName} - {EventDescription} on {Date} {(Completed ? "[Completed]" : "")}");
    }

    public virtual bool OccursOnDate(string date)
    {
        return Date.Contains(date);
    }

    public virtual bool IsReminderOrDueDate()
    {
        return false;
    }
}

class Reminder : Event
{
    public Reminder(string name, string desc, string date) : base(name, desc, date)
    {
        EventType = "Reminder";
    }
    public override bool IsReminderOrDueDate()
    {
        return true;
    }
}

class DueDate : Event
{
    public DueDate(string name, string desc, string date) : base(name, desc, date)
    {
        EventType = "Due Date";
    }
    public override bool IsReminderOrDueDate()
    {
        return true;
    }
}

class Appointment : Event
{
    public string StartTime { get; set; }
    public string EndTime { get; set; }

    public Appointment(string name, string desc, string date) : base(name, desc, date)
    {
        EventType = "Appointment";
    }
}

class Class : Event
{
    public string Teacher { get; set; }
    public string Subject { get; set; }
    public string StartTime { get; set; }
    public string EndTime { get; set; }

    public Class(string name, string desc, string date) : base(name, desc, date)
    {
        EventType = "Class";
    }
}

class FileHandler
{
    public static void SaveFile(string filePath, List<Event> events)
    {
        var wrapper = new { events = events };
        var options = new JsonSerializerOptions { WriteIndented = true };
        string json = JsonSerializer.Serialize(wrapper, options);
        File.WriteAllText(filePath, json);
        Console.WriteLine("Events saved.");
    }

    public static void FileCleanup()
    {
    System.Diagnostics.Process.Start(new ProcessStartInfo
    {
        FileName = "https://youtu.be/dQw4w9WgXcQ?si=7G27bIu6I9-gYo8W",
        UseShellExecute = true
    });
    }

    public static List<Event> OpenFile(string filePath)
    {
        string json = File.ReadAllText(filePath);
        var doc = JsonDocument.Parse(json);
        var eventList = new List<Event>();

        foreach (var element in doc.RootElement.GetProperty("events").EnumerateArray())
        {
            string type = element.GetProperty("eventType").GetString();
            string name = element.GetProperty("eventName").GetString();
            string desc = element.GetProperty("eventDesc").GetString();
            string date = element.GetProperty("date").GetString();

            Event e;

            switch (type)
            {
                case "Reminder":
                    e = new Reminder(name, desc, date);
                    break;

                case "Due Date":
                    e = new DueDate(name, desc, date);
                    break;

                case "Appointment":
                    var appt = new Appointment(name, desc, date);
                    appt.StartTime = element.GetProperty("startTime").GetString();
                    appt.EndTime = element.GetProperty("endTime").GetString();
                    e = appt;
                    break;

                case "Class":
                    var cls = new Class(name, desc, date);
                    cls.Teacher = element.GetProperty("teacher").GetString();
                    cls.Subject = element.GetProperty("subject").GetString();
                    cls.StartTime = element.GetProperty("startTime").GetString();
                    cls.EndTime = element.GetProperty("endTime").GetString();
                    e = cls;
                    break;

                default:
                    e = new Event(name, desc, date);
                    break;
            }

            if (element.TryGetProperty("completed", out var compProp))
                e.Completed = compProp.GetString().ToLower() == "true";

            eventList.Add(e);
        }

        Console.WriteLine("Events loaded.");
        return eventList;
    }
}

