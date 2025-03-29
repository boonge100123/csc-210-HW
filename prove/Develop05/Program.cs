using System;
using System.Diagnostics;

class Program
{
    static void Main(string[] args)
    {
        Menu menu = new Menu();
        menu.DisplayStartMessage();
        Console.WriteLine("Press any key to continue...");
        Console.ReadKey();

        while (true)
        {
            Console.Clear();
            menu.DisplayMenue();
            int choice = int.Parse(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    Console.Clear();
                    Console.WriteLine("Loading goals...");
                    Console.WriteLine("Press any key to continue...");
                    Console.ReadKey();
                    break;
                case 2:
                    Console.Clear();
                    Console.WriteLine("Listing goals...");
                    Console.WriteLine("Press any key to continue...");
                    Console.ReadKey();
                    break;
                case 3:
                    Console.Clear();
                    menu.DisplayGoalTypes();
                    int GoleTypeChoice = int.Parse(Console.ReadLine());
                    switch (GoleTypeChoice)
                    {
                        case 1:
                            menu.DesplayAndSaveSimpleGoal();
                            break;
                        case 2:
                            Console.WriteLine("Creating an Eternal Goal...");
                            // Here you would implement the logic to create an Eternal Goal
                            break;
                        case 3:
                            Console.WriteLine("Creating a Checklist Goal...");
                            // Here you would implement the logic to create a Checklist Goal
                            break;
                        case 4:
                            Console.WriteLine("Returning to Main Menu...");
                            break;
                        default:
                            Console.WriteLine("Invalid choice. Please select a valid goal type.");
                            break;
                    }
                    break;
                case 4:
                    Console.Clear();
                    Console.WriteLine("Marking goal as complete...");
                    Console.WriteLine("Press any key to continue...");
                    Console.ReadKey();
                    break;
                case 5:
                    Console.Clear();
                    Console.WriteLine("Viewing goals...");
                    Console.WriteLine("Press any key to continue...");
                    Console.ReadKey();
                    break;
                case 6:
                    menu.DisplayEndMessage();
                    return;
                default:
                    Console.WriteLine("Invalid choice. Please select a valid option.");
                    Console.WriteLine("Press any key to continue...");
                    Console.ReadKey();
                    break;
            }
        }

        // SimpleGole goal = new SimpleGole("Run a Marathon", "Complete a full marathon", 1000);
        // Console.WriteLine("Before completing:");
        // Console.WriteLine(goal.ToString());
        // int pointsEarned = goal.RecordPoints();
        // Console.WriteLine("\nAfter completing:");
        // Console.WriteLine(goal.ToString());
        // Console.WriteLine($"\nPoints earned: {pointsEarned}");
        // int extraPoints = goal.RecordPoints();
        // Console.WriteLine($"\nTrying to complete again...");
        // Console.WriteLine($"Extra points earned: {extraPoints}");
    }
}