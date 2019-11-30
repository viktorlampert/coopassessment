using System;
using System.Collections.Generic;

namespace GuessTheFood
{
    class Program
    {
        List<String> Foods = new List<String>();
        static void Main(string[] args)
        {
            Program p = new Program();
            p.Foods.AddRange(new string[] { "Pizza", "Pasta", "Salmon","Steak","Miso"});
            p.DisplayOptions();
            p.GuessingGame();

        }

        void DisplayOptions()
        {
            Console.WriteLine("Welcome to guess the food!");
            Console.WriteLine("Your Options:");
            int count = 1;
            foreach (string food in Foods)
            {
                Console.WriteLine($"{count}: {food}");
                count++;
            }
        }

        void GuessingGame()
        {
            Random random = new Random();
            int randNum = random.Next(Foods.Count + 1);
            int attempt = 0;
            while ((3 - attempt) != 0)
            {
                Console.WriteLine("Guess the food item:");
                int userGuess = Convert.ToInt32(Console.ReadLine());
                if (userGuess != randNum)
                {
                    attempt += 1;
                    Console.WriteLine($"Unfortunately that is incorrect, you have {3 - attempt} attempt(s) left!");
                    
                }
                else
                {
                    Console.WriteLine("Congratulations that was the correct answer!");
                    break;
                }

               
            }
        }




    }

}
