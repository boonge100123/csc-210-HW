// PhysicalBook.cs
public class PhysicalBook : Book
{
    private int pagesRead;
    public PhysicalBook(string title, string author, int chapters, int pages)
        : base(title, author, chapters, pages, "Physical") { }

    public override void UpdateProgress()
    {
        Console.Write("Enter pages read: ");
        if (int.TryParse(Console.ReadLine(), out int read))
            pagesRead = read;
    }

    public override void DisplayDetails()
    {
        Console.WriteLine($"{Title} by {Author}, Format: Physical, Pages Read: {pagesRead}");
    }
}