using System;

class Menu
{
    private int _time;
    private DateTime _date;
    private string _displayObject;

    public Menu()
    {
        _time = 0;
        _date = DateTime.Now;
        _displayObject = "";
    }

    public void DisplayMenue()
    {
        Console.WriteLine("welcome to the Mindfulness Program.");
        Console.WriteLine("Please select an option:");
        Console.WriteLine("1. Breathing Activity");
        Console.WriteLine("2. Reflection Activity");
        Console.WriteLine("3. Listing Activity");
        Console.WriteLine("4. Exit");
    }

    public void DisplayEndMessage()
    {
        Console.WriteLine("Thank you for using the Mindfulness Program.");
    }

    public void FirstLoadingAnimation()
    {
        Console.Write("Loading");
        int counter = 0;
        while (counter < 10)
        {
            Thread.Sleep(1000);
            Console.Write(".    ");
            Thread.Sleep(1000);
            Console.Write(".    ");
            Thread.Sleep(1000);
            Console.Write(".");
            Thread.Sleep(1000);
            Console.Write("\b\b\b\b\b\b\b\b\b\b\b");
            Console.Write("           ");
            Console.Write("\b\b\b\b\b\b\b\b\b\b\b");
            counter++;
        }
    }
}