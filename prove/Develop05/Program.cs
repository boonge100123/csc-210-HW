using System;

class Program
{
    static void Main(string[] args)
    {
        string filePath = "goals.csv";
        FileHandler fileHandler = new FileHandler(filePath);
        Menu menu = new Menu(fileHandler);

        menu.DisplayStartMessage();

        bool exit = false;
        while (!exit)
        {
            Console.Clear();
            Console.WriteLine($"Score: {fileHandler.GetScore()}");
            Console.WriteLine("1. Load/Create Goals\n2. List Goals\n3. Add Goal\n4. Record Event\n5. Save\n6. Remove Goal\n7. Exit");

            switch (Console.ReadLine())
            {
                case "1":
                    Console.Write("File name (without extension): ");
                    filePath = Console.ReadLine() + ".csv";
                    fileHandler.SetFilePath(filePath);
                    Console.WriteLine("1. Load\n2. New");
                    if (Console.ReadLine() == "1") fileHandler.LoadGoals();
                    break;
                case "2":
                    fileHandler.ListGoals();
                    Console.WriteLine("Press any key to continue...");
                    Console.ReadKey();
                    break;
                case "3":
                    menu.DisplayGoalTypes();
                    switch (Console.ReadLine())
                    {
                        case "1": menu.DisplayAndSaveSimpleGoal(); break;
                        case "2": menu.DisplayAndSaveEternalGoal(); break;
                        case "3": menu.DisplayAndSaveChecklistGoal(); break;
                    }
                    break;
                case "4":
                    fileHandler.ListGoals();
                    Console.Write("Goal number to record: ");
                    fileHandler.RecordGoalEvent(int.Parse(Console.ReadLine()) - 1);
                    break;
                case "5": fileHandler.SaveGoals(); break;
                case "6":
                    fileHandler.ListGoals();
                    Console.Write("Enter the number of the goal to remove: ");
                    if (int.TryParse(Console.ReadLine(), out int removeIndex))
                    {
                        fileHandler.RemoveGoal(removeIndex - 1);
                    }
                    else
                    {
                        Console.WriteLine("Invalid input.");
                        Console.WriteLine("Press any key to continue...");
                        Console.ReadKey();
                    }
                    break;

                case "7":
                    exit = true;
                    break;

            }
        }
    }
}
