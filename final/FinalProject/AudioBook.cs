// AudioBook.cs
public class AudioBook : Book
{
    private int minutesListened;
    private int totalMinutes;

    public AudioBook(string title, string author, int chapters, int pages, int totalMinutes)
        : base(title, author, chapters, pages, "Audio")
    {
        this.totalMinutes = totalMinutes;
    }

    public override void UpdateProgress()
    {
        Console.Write("Enter minutes listened: ");
        if (int.TryParse(Console.ReadLine(), out int minutes))
            minutesListened = minutes;
    }

    public override void DisplayDetails()
    {
        Console.WriteLine($"{Title} by {Author}, Format: Audio, Minutes Listened: {minutesListened}/{totalMinutes}");
    }
}