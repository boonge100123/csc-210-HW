using System;
using System.Diagnostics;

class Program
{
    static void Main(string[] args)
    {
        while (true)
        {
            Console.WriteLine("Welcome to the Scripture memorization program!");
            Console.WriteLine("Please enter one of the following options to proceed:");
            Console.WriteLine(" 1. Veiw List of scripture Masteries available");
            Console.WriteLine(" 2. Enter your own scripture reference");
            Console.WriteLine(" 3. Procied to the memorization tool");
            Console.WriteLine(" 4. Exit");

            string choice = Console.ReadLine();
            
            switch (choice)
            {
                case "1":
                    break;

                case "2":
                    Console.WriteLine("Please enter the Book of scripture:");
                    string book = Console.ReadLine();
                    Console.WriteLine("Please enter the chapter:");
                    int chapter = int.Parse(Console.ReadLine());
                    Console.WriteLine("Please enter the starting verse:");
                    int startVerse = int.Parse(Console.ReadLine());
                    Console.WriteLine("Please enter the ending verse:");
                    int endVerse = int.Parse(Console.ReadLine());
                    Console.WriteLine("Please enter the text of the scripture:");
                    string text = Console.ReadLine();

                    Scripture scripture = new Scripture(book, chapter, startVerse, endVerse, text);
                    Console.WriteLine($"You entered: {scripture.GetReference()}: {scripture.GetText()}");
                    
                    break;

                case "3":
                    break;

                case "4":
                    Console.WriteLine("Thank you for using the Scripture memorization program. Goodbye!");
                    return;

                default:
                    Console.WriteLine("Invalid choice. Please enter a valid option.");
                    break;
    }
}

        // string maskedText = remover.RemoveWordsFromText();
        // Console.WriteLine($"{scripture.GetReference()}: {maskedText}");
    }
}