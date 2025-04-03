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

    public void LoadLibrary(List<PersonalBook> books)
    {
        personalLibrary = books ?? new List<PersonalBook>();
    }

    public void RemoveBookAt(int index)
    {
        if (index >= 0 && index < personalLibrary.Count)
            personalLibrary.RemoveAt(index);
    }

public List<PersonalBook> GetAllBooks() => personalLibrary;
    public decimal GetTotalValue() => personalLibrary.Sum(b => b.Price);
    public int GetBookCount() => personalLibrary.Count;
}