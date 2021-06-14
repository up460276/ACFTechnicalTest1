using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACFTechnicalTest1
{
    class Program
    {
        static void Main(string[] args)
        {
            // The code provided will print ‘Hello World’ to the console.
            // Press Ctrl+F5 (or go to Debug > Start Without Debugging) to run your app.

            int guess = 0;
            int val = getRandom();
            int previousGuess = 0;
            List<int> guesses = new List<int>();
            Console.WriteLine("I have chosen a number between 1 and 100. Please guess it!");
            CheckIfInteger(Console.ReadLine(), out guess);

            if (checkCorrect(guess,val))
            {
                //guessed correctly first time
                //already printed out well done etc.
                return;
            }
            checkFirstGuess(guess,val);
            //add the first guess
            previousGuess = guess;
            while (guess != val)
            {

                //evaluate then get next guess
                Console.WriteLine("Please guess a number and press [Enter]!");

                CheckIfInteger(Console.ReadLine(), out guess);

                if (checkCorrect(guess, val))
                {
                    //guessed correctly
                    //already printed out well done etc.
                    return;
                }

                //it is not correct, update hot/cold
                doIt(guess, val, previousGuess);
                //update previous
                previousGuess = guess;
            }
        }

        public static int getRandom()
        {
            return new Random().Next(1, 100);
        }

        public static bool CheckIfInteger(string value, out int guess)
        {
            if (int.TryParse(value,out guess)){
                return true;
            }
            Console.WriteLine("Please enter an integer value!");
            CheckIfInteger(Console.ReadLine(),out guess);
            return true;
        }

        public static bool checkCorrect(int guess, int val)
        {
            if (guess == val)
            {
                Console.WriteLine("You are correct!");
                Console.ReadKey();
                return true;
            }
            return false;
        }

        public static void checkFirstGuess(int guess, int val)
        {
            //rules
            //within 10 = hot
            //outside =  cold
            if (workOutDistance(guess, val) < 10)
            {
                Console.WriteLine("Hot!");
            }
            else
            {
                Console.WriteLine("Cold!");
            }
        }

        public static int workOutDistance(int guess, int val)
        {
            int d = val - guess;
            return  d > 0 ? d : -d;
        }

        public static void doIt(int guess, int val, int previousGuess )
        {

            //workout distance
            int oldDistance = workOutDistance(previousGuess, val);
            int newDistance = workOutDistance(guess, val);
            //if next guess is closer, hotter else colder

            if (newDistance < oldDistance)
            {
                Console.WriteLine("Hotter!");
            }
            else
            {
                Console.WriteLine("Colder!");
            }
        }
    }
}
