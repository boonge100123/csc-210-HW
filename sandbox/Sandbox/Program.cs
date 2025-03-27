using System;
class Program
{
// static void runspiner()
// {
//     int counter = 0;
//     while (counter < 10)
//     {
//         Console.Write(".");
//         Thread.Sleep(1000);
//         Console.Write(".");
//         Thread.Sleep(1000);
//         Console.Write(".");
//         Thread.Sleep(1000);
//         Console.Write("\b\b\b");
//         Console.Write("   ");
//         Console.Write("\b\b\b");
//         Thread.Sleep(1000);

//         counter++;
//     }
// }


    static void Main(string[] args)
    {
        // Console.WriteLine("Hello World!");
        // runspiner();

        List<int> numbers = new List<int>{ 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
        List<int> evenNumbers = numbers.Where(n => n % 2 == 0).ToList();
        List<int> oddNumbers = numbers.Where(n => n % 2 != 0).ToList();

        foreach (int x in evenNumbers)
        {
            Console.WriteLine(x);
        }

        foreach (int x in oddNumbers)
        {
            Console.WriteLine(x);
        }
    }
}