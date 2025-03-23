using System;

class Menu
{
    private int _time;
    private DateTime _date;
    private string _displayObject;

    public Menu(int time)
    {
        _time = time;
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
        for (int i = 0; i < 3; i++)
        {
            Thread.Sleep(300); // slower, smoother timing
            Console.Write(".");
        }
        Thread.Sleep(300);
        // Clear the dots by overwriting with spaces and returning the cursor
        Console.Write("\b\b\b   \b\b\b");
        counter++;
    }
    Console.WriteLine("\nLoading complete!");
}


    public void SecondLoadingAnimation()
    {
        Console.Write("Loading      ");
        int counter = 0;
        while (counter < 10)
        {
            Thread.Sleep(1000);
            Console.Write("|");
            Thread.Sleep(1000);
            Console.Write("\b");
            Console.Write("/");
            Thread.Sleep(1000);
            Console.Write("\b");
            Console.Write("-");
            Thread.Sleep(1000);
            Console.Write("\b");
            Console.Write("\\");
            Thread.Sleep(1000);
            Console.Write("\b");
        }
    }

    public void CountDownAnimation()
{
    Console.Write("Loading ");
    int counter = 10;
    while (counter > 0)
    {
        Console.Write($"{counter}  ");
        Thread.Sleep(1000);
        Console.Write("\rLoading ");
        counter--;
    }
    Console.WriteLine("\rLoading complete!");
}
}