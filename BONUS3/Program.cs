using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BONUS3
{
    class Program
    {
        static void Main(string[] args)
        {
            Random randomNum = new Random();
            int target = 0, guess = 0, numGuesses = 0;
            string prompt = "Enter your guess: ", userAgain = "";
            bool win = false, playAgain = true, success = false;

            while (playAgain)
            {
                win = false;
                playAgain = true;
                success = false;
                numGuesses = 0;
                Console.Clear();

                Console.WriteLine("Welcome to the Guess a Number Game!");
                Console.WriteLine("+++++++++++++++++++++++++++++++++++");

                target = randomNum.Next(1, 100);

                Console.WriteLine("I'm thinking of a number between 1 and 100.");
                Console.WriteLine("Try to guess it.\n");

                while (guess != target)
                {
                    guess = GetIntWithinRange(prompt, 1, 100);
                    numGuesses++;
                    CheckGuess(guess, target, numGuesses);
                }

                WinningMessage(numGuesses);

                do
                {
                    Console.Write("\nWould you like to play again? (y/n): ");
                    userAgain = Console.ReadLine().ToLower();
                    if(userAgain == "y")
                    {
                        success = true;
                        playAgain = true;
                    }
                    else if ( userAgain == "n")
                    {
                        success = true;
                        playAgain = false;
                    }
                    else
                    {
                        Console.WriteLine("Please enter 'y' for yes and 'n' for no.");
                        success = false;
                    }                 
                } while (!success);
                

            }

            Console.WriteLine("\nThanks for playing!\n");

        }

        public static int GetIntWithinRange(string Prompt, int Min, int Max)
        {
            bool success = false;
            int userGuess = 0;
            
            while (!success)
            {
                Console.Write(Prompt);
                success = int.TryParse(Console.ReadLine(), out userGuess);
                if(!success || userGuess > 100 || userGuess < 1)
                {
                    Console.WriteLine("Please enter a number between 1 and 100.");
                    success = false;
                }                
            }

            return userGuess;
        }

        public static void CheckGuess(int userGuess, int gameTarget, int countGuesses)
        {
            if(userGuess == gameTarget)
            {
                Console.WriteLine($"\nCongratulations! You guessed in {countGuesses} tries.");
            }
            else if(userGuess + 10 <= gameTarget)
            {
                Console.WriteLine("Way too low!");
            }
            else if(userGuess - 10 >= gameTarget)
            {
                Console.WriteLine("Way too high!");
            }
            else if (userGuess  > gameTarget )
            {
                Console.WriteLine("Too high!");
            }
            else if(userGuess < gameTarget )
            {
                Console.WriteLine("Too low!");
            }
            return;
        }
        
        public static void WinningMessage(int countGuesses)
        {
            if(countGuesses == 1)
            {
                Console.WriteLine("You must be some kind of psychic!");
            }
            else if(countGuesses <= 3)
            {
                Console.WriteLine("The force is with you.");
            }
            else if (countGuesses <= 8)
            {
                Console.WriteLine("Not too shabby for a n00b!");
            }
            else
            {
                Console.WriteLine("Were you even trying?");
            }
        }
        
    }
}
