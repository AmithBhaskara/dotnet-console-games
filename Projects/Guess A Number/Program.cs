using System;

class GuessingGame
{
    static void Main()
    {
        Random random = new Random();
        int value = 0;
        int input = 0;
        string inputString;
        int maxRange = 0;
        int maxGuesses = 0;

        // Ask the player to select the range
        Console.WriteLine("Select the range for the game:");
        Console.WriteLine("1. 1-100 (5 guesses)");
        Console.WriteLine("2. 1-200 (7 guesses)");
        Console.WriteLine("3. 1-300 (9 guesses)");
        Console.Write("Enter your choice (1-3): ");
        string rangeChoice = Console.ReadLine() ?? "";

        // Determine the range and maximum guesses based on the player's choice
        switch (rangeChoice)
        {
            case "1":
                maxRange = 100;
                maxGuesses = 5;
                break;
            case "2":
                maxRange = 200;
                maxGuesses = 7;
                break;
            case "3":
                maxRange = 300;
                maxGuesses = 9;
                break;
            default:
                Console.WriteLine("Invalid choice. Defaulting to 1-100 with 5 guesses.");
                maxRange = 100;
                maxGuesses = 5;
                break;
        }

        // Generate a random value within the selected range
        value = random.Next(1, maxRange + 1);

        // Start the guessing game
        for (int attempts = 1; attempts <= maxGuesses; attempts++)
        {
            Console.Write($"Guess a number (1-{maxRange}): ");
            inputString = Console.ReadLine() ?? "";

            // Check if the input can be parsed to an integer
            if (int.TryParse(inputString, out input))
            {
                int difference = Math.Abs(input - value);

                if (input == value)
                {
                    Console.WriteLine("You guessed it!");
                    break;
                }
                else if (input < value)
                {
                    Console.WriteLine($"Incorrect. Too Low ({GetHint(difference)})");
                }
                else
                {
                    Console.WriteLine($"Incorrect. Too High ({GetHint(difference)})");
                }
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter a number between 1 and " + maxRange + ".");
            }

            Console.WriteLine($"Guesses remaining: {maxGuesses - attempts}");
        }

        Console.WriteLine($"Game over! The correct number was {value}.");
        Console.Write("Press any key to exit...");
        Console.ReadKey(true);
    }

    static string GetHint(int difference)
    {
        if (difference > 25)
        {
            return "Cold";
        }
        else if (difference >= 15 && difference <= 25)
        {
            return "Warm";
        }
        else if (difference >= 5 && difference < 15)
        {
            return "Hot";
        }
        else if (difference >= 1 && difference < 5)
        {
            return "Super Hot";
        }
		else
		{
			return "";
		}
    }
}
