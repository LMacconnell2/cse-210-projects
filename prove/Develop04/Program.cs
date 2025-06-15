using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;
using System.Threading;

class Program
{
    static void Main(string[] args)
    {
        bool _quit = false; // These variables are not used anywhere else in the program, therefor there is no need to declare them 
        // as part of the class. 
        string option;
        string selection;
        int duration = 30;

        while (!_quit)
        {
            bool _exit = false;
            Console.WriteLine("ZenMode Mindfulness. Choose an option to begin: ");
            Console.WriteLine("1) Breathing Activity ");
            Console.WriteLine("2) Reflection Activity ");
            Console.WriteLine("3) Listing Activity ");
            Console.WriteLine("4) Set Duration ");
            Console.WriteLine("5) Quit");
            option = Console.ReadLine();

            var breathing = new BreathingActivity(duration);
            var reflection = new ReflectionActivity(duration);
            var listing = new ListingActivity(duration);

            if (option == "1")
            {
                while (!_exit) //For "extra thingy" I created these sub menus to allow the user to view the description, instructions, run the activity or return to the main menu.
                {
                    Console.WriteLine("You have selected the Breathing Activity: ");
                    Console.WriteLine("1) Run Activity");
                    Console.WriteLine("2) View Activity Description");
                    Console.WriteLine("3) View Activity Instructions");
                    Console.WriteLine("4) Return to main menu");
                    selection = Console.ReadLine();

                    if (selection == "1")
                        breathing.RunActivity();
                    else if (selection == "2")
                        breathing.DisplayDescription();
                    else if (selection == "3")
                        breathing.DisplayInstructions();
                    else if (selection == "4")
                        _exit = true;
                    else
                    {
                        Console.WriteLine("Response invalid. Please try again. ");
                    }
                    Thread.Sleep(5000);
                    Console.Clear();
                }
            }
            else if (option == "2")
            {
                while (!_exit)
                {
                    Console.WriteLine("You have selected the Reflection Activity: ");
                    Console.WriteLine("1) Run Activity");
                    Console.WriteLine("2) View Activity Description");
                    Console.WriteLine("3) View Activity Instructions");
                    Console.WriteLine("4) Return to main menu");
                    selection = Console.ReadLine();

                    if (selection == "1")
                        reflection.RunActivity();
                    else if (selection == "2")
                        reflection.DisplayDescription();
                    else if (selection == "3")
                        reflection.DisplayInstructions();
                    else if (selection == "4")
                        _exit = true;
                    else
                    {
                        Console.WriteLine("Response invalid. Please try again. ");
                    }
                    Thread.Sleep(5000);
                    Console.Clear();
                }
            }
            else if (option == "3")
            {
                while (!_exit)
                {
                    Console.WriteLine("You have selected the Listing Activity: ");
                    Console.WriteLine("1) Run Activity");
                    Console.WriteLine("2) View Activity Description");
                    Console.WriteLine("3) View Activity Instructions");
                    Console.WriteLine("4) Return to main menu");
                    Console.WriteLine("5) Display Items Listed");
                    selection = Console.ReadLine();

                    if (selection == "1")
                        listing.RunActivity();
                    else if (selection == "2")
                        listing.DisplayDescription();
                    else if (selection == "3")
                        listing.DisplayInstructions();
                    else if (selection == "4")
                        _exit = true;
                    else if (selection == "5")
                        listing.DisplayItemsEntered();
                    else
                    {
                        Console.WriteLine("Response invalid. Please try again. ");
                    }
                    Thread.Sleep(5000);
                    Console.Clear();
                }
            }
            else if (option == "4")
            {
                Console.WriteLine("Write the amount of time (in seconds) that you will spend performing this activity: ");
                duration = int.Parse(Console.ReadLine());
            }
            else if (option == "5")
            {
                _quit = true;
            }
            else
            {
                Console.WriteLine("Response Invalid. Please try again: ");
                Thread.Sleep(2000);
            }

            Console.Clear();
        }
    }
}

class Activity
{
    protected int _duration; //chatGPT recommended making these fields protected as opposed to private. 
    protected string _messageStart;
    protected string _messageEnd;

    public Activity(int duration, string messageStart = "I'm sure you are going to do great!", string messageEnd = "Excellent job!!")
    {
        _duration = duration;
        _messageStart = messageStart;
        _messageEnd = messageEnd;
    }

    public void DisplayMessageStart(string messageStart)
    {
        Console.WriteLine("I'm sure you are going to do great!");
    }

    public void DisplayMessageEnd(string messageEnd)
    {
        Console.WriteLine("Excellent job!!");
    }

    public virtual void DisplayDescription()
    {
        Console.WriteLine("No description provided.");
}   

    public virtual void DisplayInstructions()
    {
        Console.WriteLine("No instructions provided.");
    }

    public virtual void DisplayAnimation(int milliseconds = 2000) //This animation function was created by chatGPT. NOT MY CODE!!
    {
        string[] spinner = { "|", "/", "-", "\\" };
        for (int i = 0; i < milliseconds / 200; i++)
        {
            Console.Write(spinner[i % spinner.Length]);
            Thread.Sleep(200);
            Console.Write("\b");
        }
    }

    public int GetDuration()
    {
        return _duration;
    }

    public void EndActivity()
    {
        Console.WriteLine("Activity complete.");
        DisplayAnimation(2000);
    }
}

class BreathingActivity : Activity
{
    private string _desc = "This activity will help you relax by walking your through breathing in and out slowly.";
    private string _instructions = "Breathe in for as many counts as directed. Hold the breath, then breathe out!";
    public BreathingActivity(int duration) : base(duration, "You're starting a breathing session.", "Great job finishing the session!") { }

    public void RunActivity()
    {
        DisplayMessageStart(_messageStart);
        Console.WriteLine("Prepare to begin...");
        DisplayAnimation(5000);

        Console.WriteLine($"Breathe in through your nose for {_duration * 0.4} seconds...");
        DisplayAnimation((int)(_duration * 0.4 * 1000));

        Console.WriteLine($"Hold the breath for {_duration * 0.2} seconds...");
        DisplayAnimation((int)(_duration * 0.2 * 1000));

        Console.WriteLine($"Exhale through your mouth for {_duration * 0.4} seconds...");
        DisplayAnimation((int)(_duration * 0.4 * 1000));
        EndActivity();
        DisplayMessageEnd(_messageEnd);
    }

    public override void DisplayDescription()
    {
        Console.WriteLine(_desc);
    }
    public override void DisplayInstructions()
    {
        Console.WriteLine(_instructions);
    }
}

class ReflectionActivity : Activity
{
    private string _desc = "This activity will help you think of a time when you displayed your strength and resilience. You will recognize the power you have and how you can use it in other aspects of your life. ";
    private string _instructions = "You will be shown a random prompt, then will be shown a sequence of questions concerning said experience. \nPonder on each question. Take your time. ";
    private List<string> _prompt = new List<string>
    {
    "Think of a time when you stood up for someone else.",
    "Think of a time when you did something really difficult.",
    "Think of a time when you helped someone in need.",
    "Think of a time when you did something truly selfless."
    };

    private List<string> _question = new List<string>
    {
    "Why was this experience meaningful to you?",
    "Have you ever done anything like this before?",
    "How did you get started?",
    "How did you feel when it was complete?",
    "What made this time different than other times when you were not as successful?",
    "What is your favorite thing about this experience?",
    "What could you learn from this experience that applies to other situations?",
    "What did you learn about yourself through this experience?",
    "How can you keep this experience in mind in the future?"
    };

    public ReflectionActivity(int duration) : base(duration, "You're starting a reflection session.", "Great job finishing the session!") { }

    public void RunActivity()
    {
        DisplayMessageStart(_messageStart);
        Console.WriteLine("The activity will start in 5 seconds");
        DisplayAnimation(5000);
        DisplayPrompt(ChooseRandomPrompt());

        foreach (string item in _question)
        {
            Console.WriteLine(item);
            DisplayAnimation((int)(_duration * 0.1 * 1000));
        }
        EndActivity();

        DisplayMessageEnd(_messageEnd);
    }

    public void DisplayPrompt(int index)
    {
        Console.WriteLine(_prompt[index]);
    }

    private static Random random = new Random();
    public int ChooseRandomPrompt()
    {
        return random.Next(0, 3);
    }
    
    public override void DisplayDescription()
    {
        Console.WriteLine(_desc);
    }
    public override void DisplayInstructions()
    {
        Console.WriteLine(_instructions);
    }
}

class ListingActivity : Activity
{
    private string _desc = "This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area. ";
    private string _instructions = "List things in accordance to the prompt. When typing in your responses, be sure to type them all at once before pressing enter.";
    private List<string> _prompt = new List<string>
    {
    "Who are people that you appreciate?",
    "What are personal strengths of yours?",
    "Who are people that you have helped this week?",
    "When have you felt the Holy Ghost this month?",
    "Who are some of your personal heroes?"
    };
    private int index;
    string _itemsEntered;

    public ListingActivity(int duration) : base(duration, "You're starting a listing session.", "Great job finishing the session!") { }

    public void RunActivity()
    {
        DisplayMessageStart(_messageStart);
        Console.WriteLine("The activity will start in 5 seconds. Grab a pencil and paper to begin listing. ");
        DisplayAnimation(5000);
        DisplayPrompt(ChooseRandomPrompt());
        DisplayAnimation(_duration * 1000);

        Console.WriteLine("Excellent job! Now enter in what you wrote down in your list: \n");
        _itemsEntered = Console.ReadLine();
        EndActivity();

        DisplayMessageEnd(_messageEnd);
    }

    public void DisplayPrompt(int index)
    {
        Console.WriteLine(_prompt[index]);
    }

    private static Random random = new Random();
    public int ChooseRandomPrompt()
    {
        return random.Next(0, 4);
    }

    public void DisplayItemsEntered()
    {
        Console.WriteLine(_itemsEntered);
    }
    
    public override void DisplayDescription()
    {
        Console.WriteLine(_desc);
    }
    public override void DisplayInstructions()
    {
        Console.WriteLine(_instructions);
    }
}