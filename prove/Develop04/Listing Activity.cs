using System;
using System.Diagnostics;

class ListingActivity : UserInput
{
    private List<string> _prompts = new List<string>
    {
        "Who are people that you appreciate?",
        "What are your personal strengths?",
        "Who are people that you have helped this week?",
        "When have you felt the Holy Ghost this month?",
        "Who are some of your personal heroes?"
    };
    private Random _random = new Random();
    private string _ActivityName = "Listing Activity";
    private string _ActivityDescription = "This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area.";

    public void Run()
    {
        Menu menu = new Menu();
        DisplayStartMessage(_ActivityName, _ActivityDescription);

        var stopwatch = new Stopwatch();
        List<string> responses = new List<string>();
        Console.WriteLine($"\nYou have {_duration} seconds to list as many responses as you can. Press enter when you are done.");
        Console.Write("starting in . . .");
        menu.CountDownAnimation(5);
        stopwatch.Start();


        while (stopwatch.Elapsed.TotalSeconds < _duration)
        {
            string prompt = _prompts[_random.Next(_prompts.Count)];
            Console.WriteLine("\nPrompt: " + prompt);
            Console.WriteLine("\nPlease list your responses below:");

            string response = Console.ReadLine();
            if (!string.IsNullOrEmpty(response))
            {
                responses.Add(response);
            }

            Console.WriteLine($"You have {_duration - (int)stopwatch.Elapsed.TotalSeconds} seconds remaining.");
        }

        stopwatch.Stop();

        Console.WriteLine($"\nYou listed {responses.Count} items!");
        Console.WriteLine("Here are your responses:");
        foreach (var response in responses)
        {
            Console.WriteLine("- " + response);
        }
        stopwatch.Stop();
        DisplayEndMessage(_ActivityName);
    }
}
