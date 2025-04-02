// UserInterface.cs
public class UserInterface
{
    private ReadingListManager readingManager = new();
    private WishlistManager wishlistManager = new();
    private GoalTracker goalTracker = new();
    private JsonDataService jsonService = new();
    private PersonalLibraryManager personalLibraryManager = new();

    public void Run()
    {
        bool running = true;
        while (running)
        {
            Console.WriteLine("\n1. Go to Personal Library\n2. Go to Reading and Goal Progress\n3. Exit");
            Console.Write("Choose option: ");
            switch (Console.ReadLine())
            {
                case "1": PersonalLibraryMenu(); break;
                case "2": ReadingGoalMenu(); break;
                case "3": running = false; break;
            }
        }
    }

    private void PersonalLibraryMenu()
    {
        bool back = false;
        while (!back)
        {
            Console.WriteLine("\n-- Personal Library --\n1. Add Book\n2. List Books\n3. Show Library Summary\n4. Back");
            Console.Write("Choose option: ");
            switch (Console.ReadLine())
            {
                case "1": AddPersonalBook(); break;
                case "2": personalLibraryManager.ListBooks(); break;
                case "3":
                    Console.WriteLine($"Total Books Owned: {personalLibraryManager.GetBookCount()}");
                    Console.WriteLine($"Total Value: ${personalLibraryManager.GetTotalValue():F2}");
                    break;
                case "4": back = true; break;
            }
        }
    }

    private void ReadingGoalMenu()
    {
        bool back = false;
        while (!back)
        {
            Console.WriteLine("\n-- Reading & Goal Progress --\n1. Add Goal\n2. Show Goals\n3. Back");
            Console.Write("Choose option: ");
            switch (Console.ReadLine())
            {
                case "1": AddGoal(); break;
                case "2": goalTracker.DisplayGoals(); break;
                case "3": back = true; break;
            }
        }
    }

    private void AddPersonalBook()
    {
        Console.Write("Title: ");
        string title = Console.ReadLine();
        Console.Write("Author: ");
        string author = Console.ReadLine();
        Console.Write("Price: $");
        decimal price = decimal.Parse(Console.ReadLine());

        var book = new PersonalBook { Title = title, Author = author, Price = price };
        personalLibraryManager.AddBook(book);
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