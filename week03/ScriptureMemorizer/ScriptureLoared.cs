using System;
using System.Collections.Generic;
using System.IO;

public static class ScriptureLoader
{
    public static List<Scripture> LoadFromFile(string filename)
    {
        var scriptures = new List<Scripture>();

        if (!File.Exists(filename))
            return scriptures;

        var lines = File.ReadAllLines(filename);
        foreach (var line in lines)
        {
            if (string.IsNullOrWhiteSpace(line)) continue;

            var parts = line.Split('|');
            if (parts.Length != 2) continue;

            Reference reference = ParseReference(parts[0].Trim());
            if (reference != null)
                scriptures.Add(new Scripture(reference, parts[1].Trim()));
        }

        return scriptures;
    }

    private static Reference ParseReference(string refStr)
    {
        try
        {
            string[] parts = refStr.Split(' ');
            string book = parts[0];
            string[] chapterAndVerse = parts[1].Split(':');
            int chapter = int.Parse(chapterAndVerse[0]);

            if (chapterAndVerse[1].Contains("-"))
            {
                var verses = chapterAndVerse[1].Split('-');
                return new Reference(book, chapter, int.Parse(verses[0]), int.Parse(verses[1]));
            }
            else
            {
                return new Reference(book, chapter, int.Parse(chapterAndVerse[1]));
            }
        }
        catch
        {
            return null;
        }
    }
}
