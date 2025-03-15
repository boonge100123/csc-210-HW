using System;
using System.Collections.Generic;
using System.Linq;

class RemoveWords
{
    private int _NumberToRemove;
    private Random _random = new Random();

    public RemoveWords(int numberToRemove)
    {
        _NumberToRemove = Math.Max(0, numberToRemove); // Ensure non-negative
    }

    public string RemoveWordsFromText(string currentText)
    {
        string[] words = currentText.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

        // Find indices of visible words (words not completely replaced by underscores)
        List<int> visibleWordIndices = new List<int>();
        for (int i = 0; i < words.Length; i++)
        {
            if (!words[i].All(c => c == '_')) // If the word is not already hidden
            {
                visibleWordIndices.Add(i);
            }
        }

        if (visibleWordIndices.Count == 0)
        {
            return currentText; // No more words to remove
        }

        int wordsToHide = Math.Min(_NumberToRemove, visibleWordIndices.Count);

        // Shuffle indices and take the first `wordsToHide` elements
        for (int i = visibleWordIndices.Count - 1; i > 0; i--)
        {
            int j = _random.Next(i + 1);
            (visibleWordIndices[i], visibleWordIndices[j]) = (visibleWordIndices[j], visibleWordIndices[i]);
        }

        for (int i = 0; i < wordsToHide; i++)
        {
            int index = visibleWordIndices[i];
            words[index] = new string('_', words[index].Length);
        }

        return string.Join(" ", words);
    }
}
