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
            Console.WriteLine("\n-- Goal Tracker --");
            Console.WriteLine("1. Add Goal");
            Console.WriteLine("2. Show Goals");
            Console.WriteLine("3. Update Progress");
            Console.WriteLine("4. Edit Goal");
            Console.WriteLine("5. Delete Goal");
            Console.WriteLine("6. Back");
            Console.Write("Choose option: ");
            switch (Console.ReadLine())
            {
                case "1": Console.Clear(); AddGoal(); break;
                case "2": Console.Clear(); goalTracker.DisplayGoals(); Pause(); break;
                case "3": Console.Clear(); UpdateGoalProgress(); break;
                case "4": Console.Clear(); EditGoal(); break;
                case "5": Console.Clear(); DeleteGoal(); break;
                case "6": back = true; break;
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
        Console.WriteLine("-- Add a Goal --");

        Console.WriteLine("Choose Goal Frequency:");
        Console.WriteLine("1. Daily");
        Console.WriteLine("2. Weekly");
        Console.WriteLine("3. Monthly");
        Console.WriteLine("4. Yearly");
        Console.Write("Enter number (1–4): ");
        string type = Console.ReadLine() switch
        {
            "1" => "Daily",
            "2" => "Weekly",
            "3" => "Monthly",
            "4" => "Yearly",
            _ => "Daily" // fallback default
        };

        Console.WriteLine("Choose Unit:");
        Console.WriteLine("1. Pages");
        Console.WriteLine("2. Chapters");
        Console.WriteLine("3. Books");
        Console.WriteLine("4. Hours");
        Console.Write("Enter number (1–4): ");
        string unit = Console.ReadLine() switch
        {
            "1" => "Pages",
            "2" => "Chapters",
            "3" => "Books",
            "4" => "Hours",
            _ => "Pages"
        };

        Console.Write("Target Amount: ");
        int target = int.Parse(Console.ReadLine());

        var goal = new Goal
        {
            Type = type,
            Unit = unit,
            Target = target,
            Progress = 0
        };

        goalTracker.AddGoal(goal);
        jsonService.SaveData(goalTracker.GetAllGoals(), "goals.json");

        Console.WriteLine("Goal created and saved!");
        Pause();
    }


    private void UpdateGoalProgress()
    {
        var goals = goalTracker.GetAllGoals();
        if (goals.Count == 0)
        {
            Console.WriteLine("No goals found.");
            Pause();
            return;
        }

        for (int i = 0; i < goals.Count; i++)
            Console.WriteLine($"{i + 1}. {goals[i].Type} Goal - {goals[i].Unit} - {goals[i].GetProgressReport()}");

        Console.Write("Enter goal number to update: ");
        if (int.TryParse(Console.ReadLine(), out int choice) && choice >= 1 && choice <= goals.Count)
        {
            var goal = goals[choice - 1];
            Console.Write($"Enter amount of {goal.Unit} to add to progress: ");
            if (int.TryParse(Console.ReadLine(), out int amount))
            {
                goal.UpdateProgress(amount);
                jsonService.SaveData(goalTracker.GetAllGoals(), "goals.json");
                Console.WriteLine("Progress updated!");
            }
            else
            {
                Console.WriteLine("Invalid input.");
            }
        }
        else
        {
            Console.WriteLine("Invalid choice.");
        }

        Pause();
    }

    private void EditGoal()
    {
        var goals = goalTracker.GetAllGoals();
        if (goals.Count == 0)
        {
            Console.WriteLine("No goals found.");
            Pause();
            return;
        }
    
        for (int i = 0; i < goals.Count; i++)
            Console.WriteLine($"{i + 1}. {goals[i].Type} Goal - {goals[i].Unit} - {goals[i].GetProgressReport()}");
    
        Console.Write("Enter goal number to edit: ");
        if (int.TryParse(Console.ReadLine(), out int choice) && choice >= 1 && choice <= goals.Count)
        {
            var goal = goals[choice - 1];
    
            Console.WriteLine($"\nCurrent Type: {goal.Type}");
            Console.WriteLine("Choose new Goal Frequency or press Enter to keep current:");
            Console.WriteLine("1. Daily");
            Console.WriteLine("2. Weekly");
            Console.WriteLine("3. Monthly");
            Console.WriteLine("4. Yearly");
            Console.Write("Enter number (or just Enter to skip): ");
            string typeInput = Console.ReadLine();
            goal.Type = typeInput switch
            {
                "1" => "Daily",
                "2" => "Weekly",
                "3" => "Monthly",
                "4" => "Yearly",
                _ => goal.Type
            };
    
            Console.WriteLine($"\nCurrent Unit: {goal.Unit}");
            Console.WriteLine("Choose new Unit or press Enter to keep current:");
            Console.WriteLine("1. Pages");
            Console.WriteLine("2. Chapters");
            Console.WriteLine("3. Books");
            Console.WriteLine("4. Hours");
            Console.Write("Enter number (or just Enter to skip): ");
            string unitInput = Console.ReadLine();
            goal.Unit = unitInput switch
            {
                "1" => "Pages",
                "2" => "Chapters",
                "3" => "Books",
                "4" => "Hours",
                _ => goal.Unit
            };
    
            Console.Write($"New Target (current: {goal.Target}) or Enter to keep: ");
            string newTarget = Console.ReadLine();
            if (int.TryParse(newTarget, out int parsedTarget)) goal.Target = parsedTarget;
    
            jsonService.SaveData(goalTracker.GetAllGoals(), "goals.json");
            Console.WriteLine("Goal updated.");
        }
        else
        {
            Console.WriteLine("Invalid selection.");
        }
    
        Pause();
    }


    private void DeleteGoal()
    {
        var goals = goalTracker.GetAllGoals();
        if (goals.Count == 0)
        {
            Console.WriteLine("No goals to delete.");
            Pause();
            return;
        }

        for (int i = 0; i < goals.Count; i++)
            Console.WriteLine($"{i + 1}. {goals[i].Type} Goal - {goals[i].Unit} - {goals[i].GetProgressReport()}");

        Console.Write("Enter goal number to delete: ");
        if (int.TryParse(Console.ReadLine(), out int choice) && choice >= 1 && choice <= goals.Count)
        {
            goalTracker.RemoveGoalAt(choice - 1);
            jsonService.SaveData(goalTracker.GetAllGoals(), "goals.json");
            Console.WriteLine("Goal deleted.");
        }
        else
        {
            Console.WriteLine("Invalid choice.");
        }

        Pause();
    }


    private void Pause()
    {
        Console.WriteLine("\nPress Enter to continue...");
        Console.ReadLine();
    }
}
