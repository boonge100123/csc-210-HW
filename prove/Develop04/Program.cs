using System;

class Program
{
    static void Main(string[] args)
    {

        while (true)
        {
            Console.Clear();
            Menu menu = new Menu();
            menu.DisplayMenue();
            Console.WriteLine("Please select an option (1-4):");
            int choice = int.Parse(Console.ReadLine());

            switch (choice)
            {
            case 1:
                Console.Clear();
                BreathingActivity breathingActivity = new BreathingActivity();
                breathingActivity.Run();
                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();
                break;
            case 2:
                Console.Clear();
                ReflectionActivity reflectionActivity = new ReflectionActivity();
                reflectionActivity.Run();
                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();
                break;
            case 3:
                Console.Clear();
                ListingActivity listingActivity = new ListingActivity();
                listingActivity.Run();
                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();
                break;
            case 4:
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