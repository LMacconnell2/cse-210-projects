using System;

class Program
{
    static void Main(string[] args)
    {
        // string valueInText = "42";
        // int valueNumber = int.Parse(valueInText);
        // Console.WriteLine(valueNumber);
        // int x = 5;
        // int y = 3;
        // if (x > y)
        // {
        //     Console.WriteLine("X is greater than Y");
        // }
        // else
        // {
        //     Console.WriteLine("X is not greater than &.");
        // }
        // // Console.WriteLine(x);
        // string school = "BYU-Idaho";
        // if (school == "BYU-Idaho") 
        // {
        //     Console.WriteLine("This is the best college ever!");
        // }
        // Console.WriteLine($"I am studying at {school}");
        // Console.Write("What is your favorite color? ");
        // string color = Console.ReadLine();
        // Console.WriteLine(color);

        // if (color == "Blue")
        // {
        //     Console.WriteLine($"{color} is my favorite color too!");
        // }
        // else {
        //     Console.WriteLine($"{color} is a disgusting color.");
        // }

        Console.Write("What is your grade percentage?");
        string gradePercentString = Console.ReadLine();
        int gradePercent = int.Parse(gradePercentString);
        string letter = "";
        bool failing = false;

        if (gradePercent >= 90)
        {
            letter = "A";
        }
        else if (gradePercent >= 80)
        {
            letter = "B";
        }
        else if (gradePercent >= 70)
        {
            letter = "C";
        }
        else if (gradePercent >= 60)
        {
            letter = "D";
            failing = true;
        }
                else if (gradePercent < 60)
        {
            letter = "F";
            failing = true;
        }

        Console.WriteLine($"Your grade is: {letter} in this class");
        if (failing)
        {
            Console.WriteLine("You are currently failing this class.");
        } 
    }
}