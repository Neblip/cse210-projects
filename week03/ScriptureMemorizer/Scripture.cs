using System;
using System.Collections.Generic;

public class Scripture
{
    private Reference _reference;
    private List<Word> _words;

    public Scripture(Reference reference, string text)
    {
        _reference = reference;
        _words = new List<Word>();
        foreach (string word in text.Split(' '))
        {
            _words.Add(new Word(word));
        }
    }

    public string GetDisplayText()
    {
        string verse = "";
        foreach (var word in _words)
        {
            verse += word.GetDisplay() + " ";
        }
        return $"{_reference}\n{verse.Trim()}";
    }

    public void HideRandomWords(int count)
    {
        Random rnd = new Random();
        int hidden = 0;
        List<int> indices = new List<int>();
        for (int i = 0; i < _words.Count; i++)
        {
            if (!_words[i].IsHidden())
                indices.Add(i);
        }

        while (hidden < count && indices.Count > 0)
        {
            int randomIndex = rnd.Next(indices.Count);
            _words[indices[randomIndex]].Hide();
            indices.RemoveAt(randomIndex);
            hidden++;
        }
    }

    public bool AllWordsHidden()
    {
        foreach (var word in _words)
        {
            if (!word.IsHidden())
                return false;
        }
        return true;
    }
}
