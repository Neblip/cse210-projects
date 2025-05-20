using System;

class Program
{
    static void Main(string[] args)
    {
        string playAgain = "y";
        while (playAgain == "y")
        {
            int count = 0;
            Random randomGenerator = new Random();
            int magicNumber = randomGenerator.Next(1, 101);
            bool isGuessed = false;
            do
            {
                count++;
                Console.Write("What is your guess? ");
                int guess = int.Parse(Console.ReadLine());
                if (guess == magicNumber)
                {
                    Console.WriteLine("You gessed it!");
                    Console.WriteLine($"You guessed the magic number {magicNumber} in {count} tries.");
                    isGuessed = true;
                }
                else if (guess < magicNumber)
                {
                    Console.WriteLine("Lower!");
                }
                else if (guess > magicNumber)
                {
                    Console.WriteLine("Higher!");
                }
            } while (isGuessed == false);
            Console.Write("Do you want to play again? (y/n) ");
            playAgain = Console.ReadLine().ToLower();
        }
        Console.Write("Thank you for playing!");
        
    }
}