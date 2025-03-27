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
            Console.WriteLine("Please select an option (1 - 6):");
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
                    Console.WriteLine("Adding goal...");
                    Console.WriteLine("Press any key to continue...");
                    Console.ReadKey();
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
    }
}