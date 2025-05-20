using System;

class Program
{
    static void Main(string[] args)
    {
        List<int> numbers = new List<int>();
        Console.WriteLine("Enter a list of numbers, type 0 when finished.");
        int userInput = 1;
        while (userInput != 0)
        {
            Console.Write("Enter number: ");
            userInput = int.Parse(Console.ReadLine());
            if (userInput != 0)
            {
                numbers.Add(userInput);
            }
        }

        Console.WriteLine($"The sum is: {numbers.Sum()}");
        Console.WriteLine($"The average is: {numbers.Average()}");
        Console.WriteLine($"The larguest number is: {numbers.Max()}");
        bool found = false;
        numbers.Sort();
        foreach (int number in numbers)
        {
            if (number > 0 && number % 2 == 0)
            {
                Console.WriteLine($"The smallest positive number is: {number}");
                found = true;
                break;
            }
        }
        foreach (int number in numbers)
        {
            Console.WriteLine(number);
        }
    }
}