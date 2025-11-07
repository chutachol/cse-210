using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        List<int> numbers = new List<int>();
        
        Console.WriteLine("Enter a list of numbers, type 0 when finished.");
        
        // Get numbers from user until they enter 0
        while (true)
        {
            Console.Write("Enter number: ");
            string userInput = Console.ReadLine();
            
            if (int.TryParse(userInput, out int number))
            {
                if (number == 0)
                {
                    break; // Stop when user enters 0
                }
                
                numbers.Add(number); // Add the number to the list
            }
            else
            {
                Console.WriteLine("Please enter a valid integer.");
            }
        }

        // Check if list is empty
        if (numbers.Count == 0)
        {
            Console.WriteLine("No numbers were entered.");
            return;
        }

        // Core Requirement 1: Compute the sum
        int sum = numbers.Sum();
        Console.WriteLine($"The sum is: {sum}");

        // Core Requirement 2: Compute the average
        double average = numbers.Average();
        Console.WriteLine($"The average is: {average}");

        // Core Requirement 3: Find the maximum number
        int max = numbers.Max();
        Console.WriteLine($"The largest number is: {max}");

        // Stretch Challenge 1: Find smallest positive number
        int smallestPositive = numbers
            .Where(n => n > 0) // Only positive numbers
            .DefaultIfEmpty(0)  // Handle case where no positive numbers exist
            .Min();
        
        if (smallestPositive > 0)
        {
            Console.WriteLine($"The smallest positive number is: {smallestPositive}");
        }
        else
        {
            Console.WriteLine("There are no positive numbers in the list.");
        }

        // Stretch Challenge 2: Sort and display the list
        List<int> sortedNumbers = numbers.OrderBy(n => n).ToList();
        Console.WriteLine("The sorted list is:");
        
        foreach (int number in sortedNumbers)
        {
            Console.WriteLine(number);
        }
    }
}