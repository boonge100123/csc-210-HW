using System;
class Program
{
static void runspiner()
{
    int counter = 0;
    while (counter < 10)
    {
        Console.Write(".");
        Thread.Sleep(1000);
        Console.Write(".");
        Thread.Sleep(1000);
        Console.Write(".");
        Thread.Sleep(1000);
        Console.Write("\b\b\b");
        Console.Write("   ");
        Console.Write("\b\b\b");
        Thread.Sleep(1000);

        counter++;
    }
}


    static void Main(string[] args)
    {
        Console.WriteLine("Hello World!");
        runspiner();
    }
}