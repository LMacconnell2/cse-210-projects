using System;
using System.Collections.Generic;
using System.Globalization;

class Program
{
    static void Main(string[] args)
    {
        // // string valueInText = "42";
        // // int valueNumber = int.Parse(valueInText);
        // // Console.WriteLine(valueNumber);
        // // int x = 5;
        // // int y = 3;
        // // if (x > y)
        // // {
        // //     Console.WriteLine("X is greater than Y");
        // // }
        // // else
        // // {
        // //     Console.WriteLine("X is not greater than &.");
        // // }
        // // // Console.WriteLine(x);
        // // string school = "BYU-Idaho";
        // // if (school == "BYU-Idaho") 
        // // {
        // //     Console.WriteLine("This is the best college ever!");
        // // }
        // // Console.WriteLine($"I am studying at {school}");
        // // Console.Write("What is your favorite color? ");
        // // string color = Console.ReadLine();
        // // Console.WriteLine(color);

        // // if (color == "Blue")
        // // {
        // //     Console.WriteLine($"{color} is my favorite color too!");
        // // }
        // // else {
        // //     Console.WriteLine($"{color} is a disgusting color.");
        // // }

        // Console.Write("What is your grade percentage?");
        // string gradePercentString = Console.ReadLine();
        // int gradePercent = int.Parse(gradePercentString);
        // string letter = "";
        // bool failing = false;

        // if (gradePercent >= 90)
        // {
        //     letter = "A";
        // }
        // else if (gradePercent >= 80)
        // {
        //     letter = "B";
        // }
        // else if (gradePercent >= 70)
        // {
        //     letter = "C";
        // }
        // else if (gradePercent >= 60)
        // {
        //     letter = "D";
        //     failing = true;
        // }
        //         else if (gradePercent < 60)
        // {
        //     letter = "F";
        //     failing = true;
        // }

        // Console.WriteLine($"Your grade is: {letter} in this class");
        // if (failing)
        // {
        //     Console.WriteLine("You are currently failing this class.");
        // } 
        // double kphValue = 0;
        // Console.Write("Type your speed in kph: ");
        // kphValue = int.Parse(Console.ReadLine());
        // double mphValue = 0;
        // mphValue = kphValue*0.621371;


        // Console.WriteLine($"{kphValue} kph is {Math.Round(mphValue, 2)} miles per hour.");
        // if (kphValue > 200)
        // {
        //     Console.WriteLine("STOP SPEEDING!");
        // }
        // else
        // {
        //     Console.WriteLine("Thanks for obeying the law");
        // }

        // for (int i = 1; i <= 10; i++)
        // {
        //     Console.WriteLine($"The current number is {i}");
        // }

        // string response = "";
        // do
        // {
        // Console.Write("Do you want to continue? ");
        // response = Console.ReadLine();
        // } while (response == "yes");


        // List<int> guesses = new List<int>();
        // int luckyNumber;
        // int guessNumber;
        // int i = 0;
        // bool loop = true;
        // Console.WriteLine("This is a number guessing game. Please only use integers. ");
        // Console.Write("Choose a number to be the magic number. ");
        // luckyNumber = int.Parse(Console.ReadLine());

        // while (loop) 
        // {
        //     Console.Write("Guess a number: ");
        //     guessNumber = int.Parse(Console.ReadLine());
        //     guesses.Add(guessNumber);
        //     i += 1;
        //     if (guessNumber < luckyNumber)
        //     {
        //         Console.WriteLine("Too Low!");
        //     }
        //     else if (guessNumber > luckyNumber)
        //     {
        //         Console.WriteLine("Too High!");
        //     }
        //     else if (guessNumber == luckyNumber)
        //     {
        //         Console.WriteLine($"Congratulations! You found the correct answer of {luckyNumber} in {i} try(s). ");
        //         loop = false;
        //     }
        // }
        // Console.WriteLine("Your guesses were: ");
        // foreach (int guess in guesses)
        // {
        //     Console.Write($"{guess}. ");

        // }

        // DisplayWelcome();

    }


    // static void DisplayWelcome()
    // {
    //     Console.WriteLine("Welcome to the program! ");
    //     PromptUserName();

    // }

    // static void PromptUserName()
    // {   
    //     string userName = "";
    //     Console.Write("Please enter your name: ");
    //     userName = Console.ReadLine();
    //     PromptUserNumber(userName);
    // }

    // static void PromptUserNumber(string userName)
    // {
    //     int userNumber = 0;
    //     Console.Write("Please enter your favorite integer: ");
    //     userNumber = int.Parse(Console.ReadLine());
    //     SquareNumber(userNumber, userName);
    // }

    // static void SquareNumber(int userNumber, string userName)
    // {
    //     int squaredNumber;
    //     squaredNumber = userNumber * userNumber;
    //     DisplayResults(userName, squaredNumber);
    // }

    // static void DisplayResults(string userName, int squaredNumber)
    // {
    //     Console.WriteLine($"Hello {userName}, the square of your number is: {squaredNumber}");
    // }
}
class Person
{
    protected string _name;
    protected int _age;
    protected bool _isLeftHanded;
}
public class Student : Person
{
    private int _iNumber;
}