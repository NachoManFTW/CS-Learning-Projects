using System;
using System.Collections.Generic;

namespace NumberGuessingGame
{
    class Program
    {
        public static void Main()
        {
            int randomNumber = 0;
            int guess = 0;
            RandomNumberGenerator(ref randomNumber);
            Console.WriteLine("Random Number Generator");
            Console.WriteLine("Guess a number between 0 and 20");

            while (true)
            {
                Console.Write("\n\nYour Guess: ");
                try
                {
                    guess = Convert.ToInt32(Console.ReadLine());
                }
                catch (Exception)
                {
                    Console.Error.WriteLine("ERROR: Invalid Input");
                }

                HigherOrLower(ref randomNumber, ref guess);


                if (guess == randomNumber)
                    break;
            }
            Console.WriteLine("You Won!!!");
            Console.WriteLine("Exiting...");
        }
    
        static void RandomNumberGenerator(ref int randomNumber)
        {
            Random random = new Random();
            randomNumber = random.Next(21);
        }

        static void HigherOrLower(ref int randomNumber, ref int guess)
        {
            if (randomNumber > guess)
                Console.WriteLine("Higher");
            else if (randomNumber < guess)
                Console.WriteLine("Lower");
        }
    }
}
