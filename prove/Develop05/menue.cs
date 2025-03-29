using System;

class Menu
{
    private FileHandler _fileHandler;

    public Menu(FileHandler fileHandler)
    {
        _fileHandler = fileHandler;
    }

    public void DisplayStartMessage()
    {
        Console.WriteLine("Welcome to the Goal setting program.");
        Console.WriteLine("Press any key to continue...");
        Console.ReadKey();
    }

    public void DisplayGoalTypes()
    {
        Console.WriteLine("Choose goal type:");
        Console.WriteLine("1. Simple Goal");
        Console.WriteLine("2. Eternal Goal");
        Console.WriteLine("3. Checklist Goal");
        Console.WriteLine("4. Back");
    }

    public void DisplayAndSaveSimpleGoal()
    {
        Console.Write("Name: "); string name = Console.ReadLine();
        Console.Write("Description: "); string desc = Console.ReadLine();
        Console.Write("Points: "); int points = int.Parse(Console.ReadLine());
        _fileHandler.AddGoal(new SimpleGoal(name, desc, points));
        Console.WriteLine("Press any key to continue...");
        Console.ReadKey();
    }

    public void DisplayAndSaveEternalGoal()
    {
        Console.Write("Name: "); string name = Console.ReadLine();
        Console.Write("Description: "); string desc = Console.ReadLine();
        Console.Write("Points: "); int points = int.Parse(Console.ReadLine());
        _fileHandler.AddGoal(new EternalGoal(name, desc, points));
        Console.WriteLine("Press any key to continue...");
        Console.ReadKey();
    }

    public void DisplayAndSaveChecklistGoal()
    {
        Console.Write("Name: "); string name = Console.ReadLine();
        Console.Write("Description: "); string desc = Console.ReadLine();
        Console.Write("Points: "); int points = int.Parse(Console.ReadLine());
        Console.Write("Target Count: "); int count = int.Parse(Console.ReadLine());
        Console.Write("Bonus: "); int bonus = int.Parse(Console.ReadLine());
        _fileHandler.AddGoal(new ChecklistGoal(name, desc, points, count, bonus));
        Console.WriteLine("Press any key to continue...");
        Console.ReadKey();
    }
}