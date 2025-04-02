// UserInterface.cs
public class UserInterface
{
    private ReadingListManager readingManager = new();
    private WishlistManager wishlistManager = new();
    private GoalTracker goalTracker = new();
    private JsonDataService jsonService = new();

    public void Run()
    {
        bool running = true;
        while (running)
        {
            Console.WriteLine("\n1. Add Physical Book\n2. Add Audio Book\n3. List Books\n4. Add Goal\n5. Show Goals\n6. Exit");
            Console.Write("Choose option: ");
            switch (Console.ReadLine())
            {
                case "1": AddPhysicalBook(); break;
                case "2": AddAudioBook(); break;
                case "3": readingManager.ListBooks(); break;
                case "4": AddGoal(); break;
                case "5": goalTracker.DisplayGoals(); break;
                case "6": running = false; break;
            }
        }
    }

    private void AddPhysicalBook()
    {
        Console.Write("Title: "); string title = Console.ReadLine();
        Console.Write("Author: "); string author = Console.ReadLine();
        Console.Write("Chapters: "); int chapters = int.Parse(Console.ReadLine());
        Console.Write("Pages: "); int pages = int.Parse(Console.ReadLine());

        var book = new PhysicalBook(title, author, chapters, pages);
        readingManager.AddBook(book);
    }

    private void AddAudioBook()
    {
        Console.Write("Title: "); string title = Console.ReadLine();
        Console.Write("Author: "); string author = Console.ReadLine();
        Console.Write("Chapters: "); int chapters = int.Parse(Console.ReadLine());
        Console.Write("Pages (equivalent): "); int pages = int.Parse(Console.ReadLine());
        Console.Write("Total Minutes: "); int minutes = int.Parse(Console.ReadLine());

        var book = new AudioBook(title, author, chapters, pages, minutes);
        readingManager.AddBook(book);
    }

    private void AddGoal()
    {
        Console.Write("Goal Type (Daily/Weekly): ");
        string type = Console.ReadLine();

        Console.Write("Target Amount: ");
        int target = int.Parse(Console.ReadLine());

        Console.Write("Modifier (e.g. 1.0 = normal, 0.5 = half credit): ");
        double modifier = double.Parse(Console.ReadLine());

        var goal = new Goal { Type = type, Target = target, Progress = 0, Modifier = modifier };
        goalTracker.AddGoal(goal);
    }
}