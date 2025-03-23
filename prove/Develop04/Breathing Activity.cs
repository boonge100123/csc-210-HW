using System;
using System.Diagnostics;

class BreathingActivity : UserInput
{
    private string _ActivityName = "Breathing Activity";
    private string _ActivityDescription = "This activity will help you relax by walking you through breathing in and out slowly. Clear your mind and focus on your breathing.";
    public void Run()
    {
        Menu menu = new Menu();
        DisplayStartMessage(_ActivityName, _ActivityDescription);
        var stopwatch = new Stopwatch();
        stopwatch.Start();
        int breathInTime = 6;
        int breathOutTime = 2;

        while (stopwatch.Elapsed.TotalSeconds < _duration)
        {
            Console.Write("Breathing in...");
            menu.CountDownAnimation(breathInTime);
            Console.WriteLine();
            Thread.Sleep(1000);

            Console.Write("Now breath out...");
            menu.CountDownAnimation(breathOutTime);
            Console.WriteLine();
            Thread.Sleep(1000);
        }
        stopwatch.Stop();
        DisplayEndMessage(_ActivityName);
    }
}