// PersonalLibraryManager.cs
public class PersonalLibraryManager
{
    private List<PersonalBook> personalLibrary = new();

    public void AddBook(PersonalBook book) => personalLibrary.Add(book);
    public void ListBooks()
    {
        foreach (var book in personalLibrary)
            Console.WriteLine($"{book.Title} by {book.Author} - ${book.Price:F2}");
    }

    public decimal GetTotalValue() => personalLibrary.Sum(b => b.Price);
    public int GetBookCount() => personalLibrary.Count;
}