using System;

class Scripture
{
    private string _text;
    private ScriptureReference _reference;

    public Scripture(string book, int chapter, int startVerse, int endVerse, string text)
    {
        _text = text;
        _reference = new ScriptureReference(book, chapter, startVerse, endVerse);
    }

    public Scripture(string book, int chapter, int verse, string text)
    {
        _text = text;
        _reference = new ScriptureReference(book, chapter, verse);

    }

}
