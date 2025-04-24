using System;

class Program
{
    static void Main(string[] args)
    {
        // int x = 5;
        // Console.WriteLine(x);
        Console.Write("What is your favorite color? ");
        string color = Console.ReadLine();
        Console.WriteLine(color);

        if (color == "Blue")
        {
            Console.WriteLine($"{color} is my favorite color too!");
        }
        else {
            Console.WriteLine($"{color} is a disgusting color.");
        }
    }
}