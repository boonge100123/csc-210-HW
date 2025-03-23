using System;

class UserInput
{
    protected int _duration;

    public void DisplayStartMessage(string activityName, string activityDescription)
    {
        Menu menu = new Menu();
        Console.WriteLine($"Welcome to the {activityName}.");
        Console.WriteLine(activityDescription + "\n");
        Console.WriteLine("Please enter the length of how long you want this activity to last in seconds:");
        while (true)
        {
            if (int.TryParse(Console.ReadLine(), out int length))
            {
                _duration = length;
                break;
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter a number:");
            }
        }
        Console.Write("\nGet ready to begin...");
        menu.CountDownAnimation(5);

        
    }
}
