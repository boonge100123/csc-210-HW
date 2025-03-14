using System;

class RemoveWords
{
    private int _NumberToRemove;
    private Scripture _scripture;
    private Random _random = new Random();

    public RemoveWords(Scripture scripture, int numberToRemove)
    {
        _NumberToRemove = numberToRemove;
        _scripture = scripture;
    }

    public string RemoveWordsFromText()
    {
        string text = _scripture.GetText();
        string[] words = text.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

        if (_NumberToRemove > words.Length)
        {
            _NumberToRemove = words.Length;
        }

        HashSet<int> selectedIndices = new HashSet<int>();
        while (selectedIndices.Count < _NumberToRemove)
        {
            selectedIndices.Add(_random.Next(words.Length));
        }

        foreach (int index in selectedIndices)
        {
            words[index] = new string('_', words[index].Length);
        }

        return string.Join(" ", words);
    }
}
