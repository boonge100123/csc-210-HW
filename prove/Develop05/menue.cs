using System;

class Menu
{
    public void DisplayMenue()
    {
        Console.WriteLine("welcome to the Goal setting program.");
        Console.WriteLine("Please select an option:");
        Console.WriteLine("1. load Goals");
        Console.WriteLine("2. List Goals");
        Console.WriteLine("3. Add Goal");
        Console.WriteLine("4. mark Goal as complete");
        Console.WriteLine("5. View Goals");
        Console.WriteLine("6. Exit");
        Console.WriteLine("Please select an option (1 - 6):");
    }

    public void DisplayGoalTypes()
    {
        Console.WriteLine("You have selected to add a goal.");
        Console.WriteLine("Please select the type of goal you want to make:");
        Console.WriteLine("1. Simple Goal");
        Console.WriteLine("2. Eternal Goal");
        Console.WriteLine("3. Checklist Goal");
        Console.WriteLine("4. Back to Main Menu");
        Console.WriteLine("Please select the type of goal you want to create (1 - 4):");
    }

    public void DesplayAndSaveSimpleGoal()
    {
        Console.WriteLine("Creating a Simple Goal...");
        Console.WriteLine("Please enter the name of the goal:");
        string name = Console.ReadLine();
        Console.WriteLine("Please enter the description of the goal:");
        string description = Console.ReadLine();
        Console.WriteLine("Please enter how many points you will earn for compleating the goal:");
        int points = int.Parse(Console.ReadLine());
        SimpleGole simpleGoal = new SimpleGole(name, description, points);
        Console.WriteLine($"Simple Goal created: {simpleGoal.ToString()}");
        simpleGoal.AddGoal(simpleGoal);
        Console.WriteLine("Would you like to save this goal? (yes/no)");
        string saveChoice = Console.ReadLine().ToLower();
        if (saveChoice == "yes")
        {
            simpleGoal.SaveGoals();
            Console.WriteLine("Goal saved successfully.");
        }
        else
        {
            Console.WriteLine("Goal not saved.");
        }
        Console.WriteLine("Press any key to continue...");
        Console.ReadKey();
    }
    public void DisplayStartMessage()
    {
        Console.WriteLine("Welcome to the Goal setting program.");
        Console.WriteLine("This program will help you set and track your goals.");
    }

    public void DisplayEndMessage()
    {
        Console.WriteLine("Thank you for using the Goal setting program.");
    }
}