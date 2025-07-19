// Scripture.cs
using System;
using System.Collections.Generic;
using System.Linq;

public class Scripture
{
    private Reference _reference;
    private List<Word> _words = new List<Word>();
    private Random _random = new Random();

    public Scripture(Reference reference, string text)
    {
        _reference = reference;
        string[] splitWords = text.Split(' ');
        foreach (string word in splitWords)
        {
            _words.Add(new Word(word));
        }
    }

    public void HideRandomWords(int numberOfWordsToHide)
    {
        List<Word> unhiddenWords = _words.Where(word => !word.IsHidden()).ToList();
        if (unhiddenWords.Count == 0)
        {
            return; // All words are hidden
        }

        for (int i = 0; i < numberOfWordsToHide; i++)
        {
            if (unhiddenWords.Count > 0)
            {
                int randomIndex = _random.Next(unhiddenWords.Count);
                Word wordToHide = unhiddenWords[randomIndex];
                wordToHide.Hide();
                unhiddenWords.RemoveAt(randomIndex); // Ensure we don't hide the same word again in this batch (for stretch)
            }
        }
    }

    public string GetDisplayText()
    {
        string displayText = _reference.GetDisplayText() + "\n";
        foreach (Word word in _words)
        {
            displayText += word.GetDisplayText() + " ";
        }
        return displayText.TrimEnd();
    }

    public bool AreAllWordsHidden()
    {
        return _words.All(word => word.IsHidden());
    }
}