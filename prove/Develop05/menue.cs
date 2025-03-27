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