using System;

class Program
{
    static void Main(string[] args)
    {
        // Get grade percentage from user
        Console.Write("What is your grade percentage? ");
        string userInput = Console.ReadLine();
        int gradePercentage = int.Parse(userInput);

        string letter = "";
        string sign = "";

        // Determine letter grade
        if (gradePercentage >= 90)
        {
            letter = "A";
        }
        else if (gradePercentage >= 80)
        {
            letter = "B";
        }
        else if (gradePercentage >= 70)
        {
            letter = "C";
        }
        else if (gradePercentage >= 60)
        {
            letter = "D";
        }
        else
        {
            letter = "F";
        }

        // Determine grade sign (stretch challenge)
        int lastDigit = gradePercentage % 10;
        
        if (letter != "F") // No + or - for F grades
        {
            if (lastDigit >= 7)
            {
                sign = "+";
            }
            else if (lastDigit < 3)
            {
                sign = "-";
            }
            else
            {
                sign = "";
            }
        }

        // Handle exceptional cases
        // No A+ grade
        if (letter == "A" && sign == "+")
        {
            sign = "";
        }
        
        // No F+ or F- grades
        if (letter == "F")
        {
            sign = "";
        }

        // Display the grade
        Console.WriteLine($"Your letter grade is: {letter}{sign}");

        // Determine if user passed and display appropriate message
        if (gradePercentage >= 70)
        {
            Console.WriteLine("Congratulations! You passed the course!");
        }
        else
        {
            Console.WriteLine("Don't give up! You'll do better next time!");
        }
    }
}