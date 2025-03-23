using System;
using System.Diagnostics;

class BreathingActivity : UserInput
{
    public void Run()
    {
        Menu menu = new Menu();
        DisplayStartMessage("Breathing Activity", "This activity will help you relax by walking you through breathing in and out slowly. Clear your mind and focus on your breathing.");
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
    }
}