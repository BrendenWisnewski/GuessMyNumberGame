using System;
using System.Collections.Generic;
using System.Linq;

//Worked along with Jonathan Gomez and Bradley

namespace GuessMyNumberGame
{
    class Program
    {
        public static int[] list = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
        public static int[] bigList = Enumerable.Range(1, 1000).ToArray();
        public static int[] hundredList = Enumerable.Range(1, 100).ToArray();


        public static int Bisection(int[] input)
        {
            int startPoint = input[0];
            int endPoint = input[input.Length - 1];
            int result = 0;
            bool gotIt = false;
            try
            {


                Console.WriteLine($"Choose a number between 1 and {input.Length}");
                int userInput = Int32.Parse(Console.ReadLine());
                if(userInput < 1 || userInput > input.Length)
                {
                    throw new ArgumentOutOfRangeException();
                }
                

                while (gotIt == false)
                {
                    int middle = (startPoint + endPoint) / 2;
                    Console.WriteLine($"Start number is {startPoint} middle number is {middle} end number is {endPoint}");

                    if (middle == userInput)
                    {
                        result += middle;
                        Console.WriteLine($"found your {userInput}");
                        gotIt = true;
                    }
                    else if (middle < userInput) startPoint = middle;
                    else if (middle > userInput) endPoint = middle;
                }
            }
            catch(ArgumentOutOfRangeException ex)
            {
                Console.WriteLine(ex.Message);
                Bisection(input);
            }

                return result;
            
           
        }

        static public Random rand = new Random();
        public static int ComputerGuess(int[] input)
        {
            int computer = rand.Next(1, input.Length+1);

            int startPoint = input[0];
            int endPoint = input[input.Length - 1];
            int result = 0;
            bool gotIt = false;
            Console.WriteLine($"Welcome to you versus the computer, the number range is between 1 and {input.Length}");
            try
            {
                while (gotIt == false)
                {
                    int middle = (startPoint + endPoint) / 2;
                    Console.WriteLine("Guess a new number");
                    int ourGuess = Int32.Parse(Console.ReadLine());
                    if(ourGuess < 1 || ourGuess > input.Length)
                    {
                        throw new ArgumentOutOfRangeException();
                    }

                    if (ourGuess == computer)
                    {
                        result += computer;
                        Console.WriteLine($"found the number {computer}");
                        gotIt = true;
                    }
                    else if (ourGuess < computer)
                    {
                        startPoint = middle;
                        Console.WriteLine("Guess Higher");
                    }
                    else if (ourGuess > computer)
                    {
                        Console.WriteLine("Guess lower");
                        endPoint = middle;
                    }
                }
            }
            catch(ArgumentOutOfRangeException ex)
            {
                Console.WriteLine(ex.Message);
                ComputerGuess(input);
            }

            return result;
        }

        public static int HumanGuess(int[] input)
        {
            
            
            int startPoint = input[0];
            int endPoint = input[input.Length - 1];
            int result = 0;
            bool gotIt = false;
            Console.WriteLine("Try to stump the computer!");
            try
            {
                Console.WriteLine($"Choose a number between 1 and {input.Length}");
                int ourNum = Int32.Parse(Console.ReadLine());
                if (ourNum < 1 || ourNum > input.Length)
                {
                    throw new ArgumentOutOfRangeException();
                }
                while (gotIt == false)
                {
                    int middle = (startPoint + endPoint) / 2;
                    int computerNum = rand.Next(startPoint, endPoint);


                    if (ourNum == computerNum)
                    {
                        result += middle;
                        Console.WriteLine($"found your number: {ourNum}");
                        gotIt = true;
                    }
                    else
                    {
                        Console.WriteLine($"Did I get the number {computerNum}?\n1. Go higher\n2. Go lower ");
                        int userInput = Int32.Parse(Console.ReadLine());

                        if (userInput == 1)
                        {
                            Console.WriteLine("Guessing higher...");
                            startPoint = computerNum;
                        }
                        else if (userInput == 2)
                        {
                            Console.WriteLine("Guessing lower...");
                            endPoint = computerNum;
                        }
                    }
                }
            }
            catch(ArgumentOutOfRangeException ex)
            {
                Console.WriteLine(ex.Message);
                HumanGuess(input);
            }
            return result;
        }

        static public void ChooseGame()
        {
            Console.WriteLine("Welcome to the Guess My Number Game!");
            Console.WriteLine("\nWhat game do you want to play? (Choose a number)");
            Console.WriteLine("1. See the Bisection Algorithm in action");
            Console.WriteLine("2. Try to guess the computers number");
            Console.WriteLine("3. Computer attempts to guess your number");

            try
            {
                int user = Int32.Parse(Console.ReadLine());
               if(user < 1 || user > 3)
                {
                    throw new ArgumentOutOfRangeException();
                }
                switch (user)
                {
                    case 1:
                        Bisection(list);
                        break;
                    case 2:
                        ComputerGuess(bigList);
                        break;
                    case 3:
                        HumanGuess(hundredList);
                        break;
                }
            }
            catch(ArgumentOutOfRangeException ex)
            {
                Console.WriteLine(ex.Message);
                ChooseGame();
            }
        }
        static void Main(string[] args)
        {
            bool playAgain = true;

            while(playAgain == true)
            {
                ChooseGame();

                Console.WriteLine("Play again? \nType yes or no");
                string answer = Console.ReadLine().ToLower();
                if (answer == "yes") playAgain = true;
                else playAgain = false;
                Console.Clear();
            }
           
            

           
        }
    }
}
