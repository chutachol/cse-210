using System;

class Program
{
    static void Main(string[] args)
    {
        // For generating random numbers
        Random random = new Random();
        bool playAgain = true;
        
        while (playAgain)
        {
            // Core Requirement 3: Generate random number from 1 to 100
            int magicNumber = random.Next(1, 101);
            int guessCount = 0;
            
            Console.WriteLine("Welcome to Guess My Number Game!");
            Console.WriteLine("I've picked a number between 1 and 100.");
            Console.WriteLine();

            int guess = -1;

            // Core Requirement 2: Loop until correct guess
            while (guess != magicNumber)
            {
                // Get user's guess
                Console.Write("What is your guess? ");
                string userInput = Console.ReadLine();
                
                // Validate input
                if (int.TryParse(userInput, out guess))
                {
                    guessCount++;
                    
                    // Core Requirement 1: Check if higher, lower, or correct
                    if (guess < magicNumber)
                    {
                        Console.WriteLine("Higher");
                    }
                    else if (guess > magicNumber)
                    {
                        Console.WriteLine("Lower");
                    }
                    else
                    {
                        Console.WriteLine("You guessed it!");
                    }
                }
                else
                {
                    Console.WriteLine("Please enter a valid number.");
                    guess = -1; // Reset guess to continue loop
                }
            }

            // Stretch Challenge 1: Display guess count
            Console.WriteLine($"It took you {guessCount} guesses!");

            // Stretch Challenge 2: Ask to play again
            Console.Write("Would you like to play again? (yes/no): ");
            string playAgainResponse = Console.ReadLine().ToLower();
            
            if (playAgainResponse != "yes")
            {
                playAgain = false;
                Console.WriteLine("Thanks for playing! Goodbye!");
            }
            else
            {
                Console.WriteLine(); // Add blank line for better separation between games
            }
        }
    }
}