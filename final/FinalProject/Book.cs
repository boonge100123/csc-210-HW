// Book.cs
public abstract class Book
{
    public string Title { get; private set; }
    public string Author { get; private set; }
    public int ChapterCount { get; private set; }
    public int PageCount { get; private set; }
    public string Format { get; private set; }
    public int Rating { get; set; }

    protected Book(string title, string author, int chapters, int pages, string format)
    {
        Title = title;
        Author = author;
        ChapterCount = chapters;
        PageCount = pages;
        Format = format;
    }

    public abstract void UpdateProgress();
    public abstract void DisplayDetails();
}