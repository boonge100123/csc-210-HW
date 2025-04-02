// ReadingListManager.cs
public class ReadingListManager
{
    private List<Book> readingList = new();

    public void AddBook(Book book) => readingList.Add(book);
    public void RemoveBook(Book book) => readingList.Remove(book);
    public void ListBooks()
    {
        foreach (var book in readingList)
            book.DisplayDetails();
    }
}
