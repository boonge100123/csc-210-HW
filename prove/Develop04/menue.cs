using System;
using System.Diagnostics;

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

    public void FirstLoadingAnimation(int durationInSeconds)
    {
        Console.Write("pondering ");
        Stopwatch stopwatch = new Stopwatch();
        stopwatch.Start();
    
        while (stopwatch.Elapsed.TotalSeconds < durationInSeconds)
        {
            for (int i = 0; i < 3 && stopwatch.Elapsed.TotalSeconds < durationInSeconds; i++)
            {
                Thread.Sleep(300);
                Console.Write(".");
            }
            Thread.Sleep(300);
            Console.Write("\b\b\b   \b\b\b");
        }
    
        stopwatch.Stop();
        Console.WriteLine("\nLoading complete!");
    }


    public void SecondLoadingAnimation(int durationInSeconds)
{
    Console.Write("Loading ");
    char[] spinnerChars = { '|', '/', '-', '\\' };
    var stopwatch = new Stopwatch();
    stopwatch.Start();

    int index = 0;
    while (stopwatch.Elapsed.TotalSeconds < durationInSeconds)
    {
        Console.Write(spinnerChars[index]);
        Thread.Sleep(200);
        Console.Write("\b");
        index = (index + 1) % spinnerChars.Length;
    }

    stopwatch.Stop();
    Console.WriteLine("\nLoading complete!");
}

    public void CountDownAnimation(int durationInSeconds)
    {
        for (int i = durationInSeconds; i > 0; i--)
        {
            Console.Write($"{i} ");  // Print the number on the same line
            Thread.Sleep(1000);
            Console.Write("\b\b"); // Move the cursor back to overwrite the number
        }
    }
}