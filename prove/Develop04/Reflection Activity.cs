using System;
using System.Diagnostics;
using Microsoft.VisualBasic;

class ReflectionActivity : UserInput
{
    private List<string> _initialQuestions = new List<string>
    {
        "Think of a time when you stood up for someone else.",
        "Think of a time when you did something really difficult.",
        "Think of a time when you helped someone in need.",
        "Think of a time when you did something truly selfless."
    };

    private List<string> _followUpQuestions = new List<string>
    {
        "Why was this experience meaningful to you?",
        "Have you ever done anything like this before?",
        "How did you get started?",
        "How did you feel when it was complete?",
        "What made this time different than other times when you were not as successful?",
        "What is your favorite thing about this experience?",
        "What could you learn from this experience that applies to other situations?",
        "What did you learn about yourself through this experience?",
        "How can you keep this experience in mind in the future?"
    };

    private Random _random = new Random();


    public void Run()
    {
        Menu menu = new Menu();
        DisplayStartMessage("Reflection Activity", "This activity will help you reflect on times in your life when you have shown strength and resilience. This will help you recognize the areas in your life where you are strong and how you can use those strengths to overcome challenges.");
        var stopwatch = new Stopwatch();
        stopwatch.Start();

        while (stopwatch.Elapsed.TotalSeconds < _duration)
        {
            string initialQuestion = _initialQuestions[_random.Next(_initialQuestions.Count)];
            Console.WriteLine(initialQuestion);
            menu.FirstLoadingAnimation(30);
            Console.WriteLine("\n \n");

            string followUpQuestion = _followUpQuestions[_random.Next(_followUpQuestions.Count)];
            Console.WriteLine(followUpQuestion);
            menu.FirstLoadingAnimation(30);
            Console.WriteLine("\n \n");
        }
    }
}