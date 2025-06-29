using System;
using System.Collections.Generic;
using System.Text.Json;
//NGL I crashed out when writing this. Twice.
class Program
{
    static void Main(string[] args)
    {
        bool quit = false;
        string _selection = "";
        var goalHandler = new GoalHandler();
        var fileHandler = new FileHandler("goals.json");

        while (!quit)
        {
            int score = fileHandler.GetCurrentScore();
            Console.WriteLine("Welcome to the Goal Organizer! ");
            Console.WriteLine($"Current Score: {score}");
            Console.WriteLine("1) Create a new goal");
            Console.WriteLine("2) Remove a goal"); //This is what im doing for extra flare. 
            Console.WriteLine("3) View goals");
            Console.WriteLine("4) Update Goal");
            Console.WriteLine("5) Save current progress");
            Console.WriteLine("6) Load progress from file.");
            Console.WriteLine("7) Exit");
            Console.Write("Select an option to begin: ");
            _selection = Console.ReadLine();
            if (_selection == "1")
            {
                goalHandler.NewGoal();
            }
            else if (_selection == "2")
            {
                goalHandler.RemoveGoal();
            }
            else if (_selection == "3")
            {
                goalHandler.DisplayGoals();
                Console.WriteLine("Press Enter to continue...");
                Console.ReadLine();
            }
            else if (_selection == "4")
            {
                goalHandler.UpdateGoal(fileHandler);
            }
            else if (_selection == "5")
            {
                fileHandler.SaveFile(goalHandler.Goals);
            }
            else if (_selection == "6")
            {
                goalHandler.Goals = fileHandler.LoadFile();
            }
            else if (_selection == "7")
            {
                quit = true;
            }
            else
            {
                Console.WriteLine("Invalid input. Please try again");
            }
            DisplayAnimation(3);
            Console.Clear();
        }
    }

    static void DisplayAnimation(int time)
    {
        for (int i = 0; i < time; i++)
        {
            Console.Write(". ");
            Thread.Sleep(500);
        }
        Console.WriteLine();
    }
}

class GoalHandler
{
    public List<Goal> Goals { get; set; } = new List<Goal>();

    public void DisplayGoals()
    {
        for (int i = 0; i < Goals.Count; i++)
        {
            Console.Write($"{i + 1}) ");
            Goals[i].Display();
        }
    }

    public void NewGoal()
    {
        Console.WriteLine("Select goal type: 1) Simple 2) Eternal 3) Checklist");
        string type = Console.ReadLine();
        Console.Write("Goal Name: ");
        string name = Console.ReadLine();
        Console.Write("Description: ");
        string desc = Console.ReadLine();
        Console.Write("Points: ");
        int points = int.Parse(Console.ReadLine());

        Goal newGoal = null;
        switch (type)
        {
            case "1":
                newGoal = new SimpleGoal(name, desc, points);
                break;
            case "2":
                newGoal = new EternalGoal(name, desc, points);
                break;
            case "3":
                Console.Write("Times to Complete: ");
                int toComplete = int.Parse(Console.ReadLine());
                newGoal = new ChecklistGoal(name, desc, points, toComplete);
                break;
            default:
                Console.WriteLine("Invalid goal type selected.");
                break;
        };

        if (newGoal != null) Goals.Add(newGoal);
    }

    public void RemoveGoal()
    {
        DisplayGoals();
        Console.Write("Enter goal number to remove: ");
        if (int.TryParse(Console.ReadLine(), out int index) && index > 0 && index <= Goals.Count)
        {
            Goals.RemoveAt(index - 1);
        }
        else
        {
            Console.WriteLine("Invalid index. Please Try Again.");
        }
    }

    public void UpdateGoal(FileHandler fileHandler)
    {
        DisplayGoals();
        Console.Write("Enter goal number to update: ");
        if (int.TryParse(Console.ReadLine(), out int select) && select > 0 && select <= Goals.Count)
        {
            int pointsEarned = Goals[select - 1].UpdateGoal();
            fileHandler.UpdateScore(pointsEarned);
        }
        else
        {
            Console.WriteLine("Invalid index.");
        }
    }
}

abstract class Goal
{
    protected string GoalName { get; set; }
    protected string GoalDesc { get; set; }
    protected int GoalPoints { get; set; }
    protected string GoalType { get; set; }
    protected int GoalID { get; set; }

    protected Goal(string name, string desc, int points)
    {
        GoalName = name;
        GoalDesc = desc;
        GoalPoints = points;
    }

    public abstract int UpdateGoal();
    public abstract Dictionary<string, object> AddToFile();

    public virtual void Display()
    {
        Console.WriteLine($"{GoalName} - {GoalDesc}");
    }
}

class SimpleGoal : Goal
{
    private bool _goalCompleted = false;

    public SimpleGoal(string name, string desc, int points) : base(name, desc, points)
    {
        GoalType = "Simple";
    }

    public override int UpdateGoal()
    {
        _goalCompleted = true;
        Console.WriteLine($"{GoalName} marked as completed.");
        return GoalPoints;
    }

    public override Dictionary<string, object> AddToFile()
    {
        return new Dictionary<string, object>
        {
            ["GoalType"] = GoalType,
            ["GoalName"] = GoalName,
            ["GoalDesc"] = GoalDesc,
            ["GoalPoints"] = GoalPoints,
            ["GoalCompleted"] = _goalCompleted
        };
    }
}

class EternalGoal : Goal
{
    private int _timesCompleted = 0;

    public EternalGoal(string name, string desc, int points) : base(name, desc, points)
    {
        GoalType = "Eternal";
    }

    public override int UpdateGoal()
    {
        _timesCompleted++;
        Console.WriteLine($"{GoalName} updated. Total completions: {_timesCompleted}");
        return GoalPoints;
    }

    public override Dictionary<string, object> AddToFile()
    {
        return new Dictionary<string, object>
        {
            ["GoalType"] = GoalType,
            ["GoalName"] = GoalName,
            ["GoalDesc"] = GoalDesc,
            ["GoalPoints"] = GoalPoints,
            ["TimesCompleted"] = _timesCompleted
        };
    }
}

class ChecklistGoal : Goal
{
    private int _timesCompleted = 0;
    private int _timesToComplete;
    private bool _goalCompleted = false;

    public ChecklistGoal(string name, string desc, int points, int toComplete) : base(name, desc, points)
    {
        GoalType = "Checklist";
        _timesToComplete = toComplete;
    }

    public override int UpdateGoal()
    {
        _timesCompleted++;
        if (_timesCompleted >= _timesToComplete)
        {
            _goalCompleted = true;
            Console.WriteLine($"{GoalName} fully completed!");
        }
        else
        {
            Console.WriteLine($"{GoalName} progress: {_timesCompleted}/{_timesToComplete}");
        }
        return GoalPoints;
    }

    public override Dictionary<string, object> AddToFile()
    {
        return new Dictionary<string, object>
        {
            ["GoalType"] = GoalType,
            ["GoalName"] = GoalName,
            ["GoalDesc"] = GoalDesc,
            ["GoalPoints"] = GoalPoints,
            ["TimesCompleted"] = _timesCompleted,
            ["TimesToComplete"] = _timesToComplete,
            ["GoalCompleted"] = _goalCompleted
        };
    }
}

class FileHandler
{
    private string _filePath;
    private int _score;

    public FileHandler(string filePath)
    {
        _filePath = filePath;
    }

    public void SaveFile(List<Goal> goals)
    {
        var goalData = new List<Dictionary<string, object>>();
        foreach (var goal in goals)
        {
            goalData.Add(goal.AddToFile());
        }
        var saveObj = new { score = _score, goals = goalData };
        string json = JsonSerializer.Serialize(saveObj, new JsonSerializerOptions { WriteIndented = true }); //I like WriteIndented :) Makes things look nice.
        File.WriteAllText(_filePath, json);
        Console.WriteLine("Progress saved.");
    }

    public List<Goal> LoadFile()
    //GhaptGPT assisted greatly in creating this method. Like I said. I crashed out. I had a clear idea in mind for the JSON file, but it 
    //simple was not working. I said "uncle" and asked ChatpGPT for help. 
    {
        var goals = new List<Goal>();
        if (!File.Exists(_filePath)) return goals;

        string json = File.ReadAllText(_filePath);
        var doc = JsonSerializer.Deserialize<JsonElement>(json);
        _score = doc.GetProperty("score").GetInt32();

        foreach (var g in doc.GetProperty("goals").EnumerateArray())
        {
            string type = g.GetProperty("GoalType").GetString();
            string name = g.GetProperty("GoalName").GetString();
            string desc = g.GetProperty("GoalDesc").GetString();
            int points = g.GetProperty("GoalPoints").GetInt32();

            switch (type)
            {
                case "Simple":
                    var simple = new SimpleGoal(name, desc, points);
                    break;
                case "Eternal":
                    var eternal = new EternalGoal(name, desc, points);
                    eternal.UpdateGoal(); // Optionally set completions
                    break;
                case "Checklist":
                    int toComplete = g.GetProperty("TimesToComplete").GetInt32();
                    var checklist = new ChecklistGoal(name, desc, points, toComplete);
                    break;
            }
        }
        Console.WriteLine("Progress loaded.");
        return goals;
    }

    public int GetCurrentScore() => _score;
    public void UpdateScore(int points)
    {
        _score += points;
    }
}


