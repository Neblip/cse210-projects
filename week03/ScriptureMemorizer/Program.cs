using System;
using System.Collections.Generic;
using System.IO;

class Program
{
    static void Main()
    {
        List<Scripture> scriptures = ScriptureLoader.LoadFromFile("scriptures.txt");

        if (scriptures.Count == 0)
        {
            Console.WriteLine("No scriptures were loaded. Please check the scriptures.txt file format.");
            return;
        }

        Random random = new Random();
        Scripture scripture = scriptures[random.Next(scriptures.Count)];

        while (!scripture.AllWordsHidden())
        {
            Console.Clear();
            Console.WriteLine(scripture.GetDisplayText());
            Console.WriteLine("\nPress Enter to continue or type 'quit' to exit.");
            string input = Console.ReadLine();

            if (input.ToLower() == "quit")
                break;

            scripture.HideRandomWords(3);
        }

        Console.Clear();
        Console.WriteLine(scripture.GetDisplayText());
        Console.WriteLine("\nAll words are hidden. Program ended.");
    }
}

/*
Enhancement: 
- This program loads a list of scriptures from an external file (scriptures.txt).
- It randomly selects a scripture to present.
- This adds variety and reinforces memorization by providing different scriptures.
- At the end the program displays "All words are hidden. Program ended." to indicate completion.
*/
