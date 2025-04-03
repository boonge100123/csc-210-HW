public class UserInterface
{
    private ReadingListManager readingManager = new();
    private WishlistManager wishlistManager = new();
    private GoalTracker goalTracker = new();
    private JsonDataService jsonService = new();
    private PersonalLibraryManager personalLibraryManager = new();

    private const string personalLibraryFile = "personal_library.json";
    private const string wishlistFile = "wishlist.json";
    private const string goalsFile = "goals.json";

    public void Run()
    {
        personalLibraryManager.LoadLibrary(jsonService.LoadData<PersonalBook>(personalLibraryFile));
        wishlistManager.LoadWishlist(jsonService.LoadData<WishlistItem>(wishlistFile));
        goalTracker.LoadGoals(jsonService.LoadData<Goal>(goalsFile));

        bool running = true;
        while (running)
        {
            Console.Clear();
            Console.WriteLine("-- Main Menu --");
            Console.WriteLine("1. Personal Library");
            Console.WriteLine("2. Goal Tracker");
            Console.WriteLine("3. Wishlist Manager");
            Console.WriteLine("4. Exit");
            Console.Write("Choose option: ");

            switch (Console.ReadLine())
            {
                case "1": PersonalLibraryMenu(); break;
                case "2": GoalTrackerMenu(); break;
                case "3": WishlistMenu(); break;
                case "4":
                    jsonService.SaveData(personalLibraryManager.GetAllBooks(), personalLibraryFile);
                    jsonService.SaveData(wishlistManager.GetWishlistItems(), wishlistFile);
                    jsonService.SaveData(goalTracker.GetAllGoals(), goalsFile);
                    running = false;
                    break;
            }
        }
    }

    private void PersonalLibraryMenu()
    {
        bool back = false;
        while (!back)
        {
            Console.Clear();
            Console.WriteLine("\n-- Personal Library --");
            Console.WriteLine("1. Add Book");
            Console.WriteLine("2. List Books");
            Console.WriteLine("3. Show Library Summary");
            Console.WriteLine("4. Remove Book");
            Console.WriteLine("5. Edit Book");
            Console.WriteLine("6. Back");
            Console.Write("Choose option: ");
            switch (Console.ReadLine())
            {
                case "1": Console.Clear(); AddPersonalBook(); break;
                case "2": Console.Clear(); personalLibraryManager.ListBooks(); Pause(); break;
                case "3":
                    Console.Clear();
                    Console.WriteLine($"Total Books Owned: {personalLibraryManager.GetBookCount()}");
                    Console.WriteLine($"Total Value: ${personalLibraryManager.GetTotalValue():F2}");
                    Pause();
                    break;
                case "4": Console.Clear(); RemovePersonalBook(); break;
                case "5": Console.Clear(); EditPersonalBook(); break;
                case "6": back = true; break;
            }
        }
    }

    private void GoalTrackerMenu()
    {
        bool back = false;
        while (!back)
        {
            Console.Clear();
            Console.WriteLine("\n-- Goal Tracker --\n1. Add Goal\n2. Show Goals\n3. Back");
            Console.Write("Choose option: ");
            switch (Console.ReadLine())
            {
                case "1": Console.Clear(); AddGoal(); break;
                case "2": Console.Clear(); goalTracker.DisplayGoals(); Pause(); break;
                case "3": back = true; break;
            }
        }
    }

    private void WishlistMenu()
    {
        bool back = false;
        while (!back)
        {
            Console.Clear();
            Console.WriteLine("-- Wishlist Manager --");
            Console.WriteLine("1. View Wishlist");
            Console.WriteLine("2. Add to Wishlist");
            Console.WriteLine("3. Remove from Wishlist");
            Console.WriteLine("4. Move Item to Personal Library");
            Console.WriteLine("5. Back");
            Console.Write("Choose option: ");

            switch (Console.ReadLine())
            {
                case "1": ViewWishlist(); break;
                case "2": AddToWishlist(); break;
                case "3": RemoveFromWishlist(); break;
                case "4": MoveToPersonalLibrary(); break;
                case "5": back = true; break;
            }
        }
    }

    private void ViewWishlist()
    {
        Console.Clear();
        Console.WriteLine("\n-- Wishlist --");
        var items = wishlistManager.GetWishlistItems();
        if (items.Count == 0)
        {
            Console.WriteLine("No items in wishlist.");
        }
        else
        {
            foreach (var item in items)
                Console.WriteLine($"{item.Title} by {item.Author} - ${item.Price:F2}");

            Console.WriteLine($"\nTotal Wishlist Value: ${wishlistManager.GetTotalCost():F2}");
        }
        Pause();
    }

    private void AddToWishlist()
    {
        Console.Clear();
        Console.WriteLine("-- Add Book to Wishlist --");

        Console.Write("Title: ");
        string title = Console.ReadLine();

        Console.Write("Author: ");
        string author = Console.ReadLine();

        Console.Write("Price: $");
        if (decimal.TryParse(Console.ReadLine(), out decimal price))
        {
            var item = new WishlistItem { Title = title, Author = author, Price = price };
            wishlistManager.AddItem(item);
            jsonService.SaveData(wishlistManager.GetWishlistItems(), wishlistFile);
            Console.WriteLine("\nBook added to wishlist!");
        }
        else
        {
            Console.WriteLine("Invalid price. Book not added.");
        }

        Pause();
    }

    private void RemoveFromWishlist()
    {
        var items = wishlistManager.GetWishlistItems();
        if (items.Count == 0)
        {
            Console.WriteLine("Wishlist is empty.");
            Pause();
            return;
        }

        for (int i = 0; i < items.Count; i++)
            Console.WriteLine($"{i + 1}. {items[i].Title} by {items[i].Author} - ${items[i].Price:F2}");

        Console.Write("Enter number to remove: ");
        if (int.TryParse(Console.ReadLine(), out int choice) && choice >= 1 && choice <= items.Count)
        {
            wishlistManager.RemoveItem(items[choice - 1]);
            jsonService.SaveData(wishlistManager.GetWishlistItems(), wishlistFile);
            Console.WriteLine("Item removed.");
        }
        else
        {
            Console.WriteLine("Invalid choice.");
        }
        Pause();
    }

    private void MoveToPersonalLibrary()
    {
        var items = wishlistManager.GetWishlistItems();
        if (items.Count == 0)
        {
            Console.WriteLine("Wishlist is empty.");
            Pause();
            return;
        }

        for (int i = 0; i < items.Count; i++)
            Console.WriteLine($"{i + 1}. {items[i].Title} by {items[i].Author} - ${items[i].Price:F2}");

        Console.Write("Enter number to move to library: ");
        if (int.TryParse(Console.ReadLine(), out int choice) && choice >= 1 && choice <= items.Count)
        {
            var selected = items[choice - 1];
            wishlistManager.RemoveItem(selected);
            jsonService.SaveData(wishlistManager.GetWishlistItems(), wishlistFile);

            var personalBook = new PersonalBook
            {
                Title = selected.Title,
                Author = selected.Author,
                Price = selected.Price
            };

            personalLibraryManager.AddBook(personalBook);
            Console.WriteLine("Book moved to personal library.");
        }
        else
        {
            Console.WriteLine("Invalid choice.");
        }
        Pause();
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

    private void RemovePersonalBook()
    {
        var books = personalLibraryManager.GetAllBooks();
        if (books.Count == 0)
        {
            Console.WriteLine("No books in library.");
            Pause();
            return;
        }

    

        for (int i = 0; i < books.Count; i++)
            Console.WriteLine($"{i + 1}. {books[i].Title} by {books[i].Author} - ${books[i].Price:F2}");

        Console.Write("Enter number of book to remove: ");
        if (int.TryParse(Console.ReadLine(), out int choice) && choice >= 1 && choice <= books.Count)
        {
            personalLibraryManager.RemoveBookAt(choice - 1);
            Console.WriteLine("Book removed.");
        }
        else
        {
            Console.WriteLine("Invalid selection.");
        }

        Pause();
    }

    private void EditPersonalBook()
    {
        var books = personalLibraryManager.GetAllBooks();
        if (books.Count == 0)
        {
            Console.WriteLine("No books in library.");
            Pause();
            return;
        }
    
        for (int i = 0; i < books.Count; i++)
            Console.WriteLine($"{i + 1}. {books[i].Title} by {books[i].Author} - ${books[i].Price:F2}");
    
        Console.Write("Enter number of book to edit: ");
        if (int.TryParse(Console.ReadLine(), out int choice) && choice >= 1 && choice <= books.Count)
        {
            var book = books[choice - 1];
    
            Console.Write($"New Title (leave blank to keep '{book.Title}'): ");
            string newTitle = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(newTitle)) book.Title = newTitle;
    
            Console.Write($"New Author (leave blank to keep '{book.Author}'): ");
            string newAuthor = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(newAuthor)) book.Author = newAuthor;
    
            Console.Write($"New Price (leave blank to keep ${book.Price:F2}): ");
            string newPriceInput = Console.ReadLine();
            if (decimal.TryParse(newPriceInput, out decimal newPrice)) book.Price = newPrice;
    
            Console.WriteLine("Book updated.");
        }
        else
        {
            Console.WriteLine("Invalid selection.");
        }
    
        Pause();
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
        jsonService.SaveData(goalTracker.GetAllGoals(), goalsFile);
        Console.WriteLine("Goal added and saved!");
        Pause();
    }

    private void Pause()
    {
        Console.WriteLine("\nPress Enter to continue...");
        Console.ReadLine();
    }
}
