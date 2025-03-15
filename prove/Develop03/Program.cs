using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        ScriptureList scriptureList = new ScriptureList();
        Scripture scripture = null; // Declare it outside to be accessible in case "3"

        while (true)
        {
            Console.Clear();
            Console.WriteLine("Welcome to the Scripture memorization program!");
            Console.WriteLine("Please enter one of the following options to proceed:");
            Console.WriteLine(" 1. View List of Scripture Masteries available");
            Console.WriteLine(" 2. Enter your own scripture reference");
            Console.WriteLine(" 3. Proceed to the memorization tool");
            Console.WriteLine(" 4. Exit");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    Console.WriteLine("Select a book to view scriptures:");
                    Console.WriteLine("1. Book of Mormon");
                    Console.WriteLine("2. New Testament");
                    Console.WriteLine("3. Old Testament");
                    Console.WriteLine("4. Doctrine and Covenants");
                    Console.WriteLine("5. Return to Main Menu");

                    string bookChoice = Console.ReadLine();
                    List<Scripture> selectedScriptures = null;

                    switch (bookChoice)
                    {
                        case "1":
                            selectedScriptures = scriptureList.GetBookOfMormonScriptures();
                            break;
                        case "2":
                            selectedScriptures = scriptureList.GetNewTestamentScriptures();
                            break;
                        case "3":
                            selectedScriptures = scriptureList.GetOldTestamentScriptures();
                            break;
                        case "4":
                            selectedScriptures = scriptureList.GetDoctrineAndCovenantsScriptures();
                            break;
                        case "5":
                            continue;
                        default:
                            Console.WriteLine("Invalid choice. Returning to main menu.");
                            continue;
                    }

                    if (selectedScriptures != null && selectedScriptures.Count > 0)
                    {
                        Console.WriteLine("\nAvailable Scriptures:");
                        foreach (var scr in selectedScriptures)
                        {
                            Console.WriteLine($"{scr.GetReference()}: {scr.GetText()}");
                        }
                    }
                    else
                    {
                        Console.WriteLine("No scriptures available for the selected book.");
                    }
                    break;

                case "2":
                    Console.WriteLine("Please enter the Book of scripture:");
                    string book = Console.ReadLine();

                    Console.WriteLine("Please enter the chapter:");
                    if (!int.TryParse(Console.ReadLine(), out int chapter))
                    {
                        Console.WriteLine("Invalid chapter number. Please enter a valid integer.");
                        break;
                    }

                    Console.WriteLine("Please enter the starting verse:");
                    if (!int.TryParse(Console.ReadLine(), out int startVerse))
                    {
                        Console.WriteLine("Invalid verse number. Please enter a valid integer.");
                        break;
                    }

                    Console.WriteLine("Please enter the ending verse:");
                    if (!int.TryParse(Console.ReadLine(), out int endVerse))
                    {
                        Console.WriteLine("Invalid verse number. Please enter a valid integer.");
                        break;
                    }

                    Console.WriteLine("Please enter the text of the scripture:");
                    string text = Console.ReadLine();

                    scripture = new Scripture(book, chapter, startVerse, endVerse, text);
                    Console.WriteLine($"You entered: {scripture.GetReference()}: {scripture.GetText()}");
                    break;

                case "3":
                    Console.WriteLine("Please enter the number of words to remove:");
                    if (!int.TryParse(Console.ReadLine(), out int numberToRemove))
                    {
                        Console.WriteLine("Invalid number. Please enter a valid integer.");
                        break;
                    }

                    RemoveWords remover = new RemoveWords(scripture, numberToRemove);
                    string maskedText = remover.RemoveWordsFromText();
                    Console.WriteLine($"{scripture.GetReference()}: {maskedText}");
                    break;

                case "4":
                    Console.WriteLine("Thank you for using the Scripture memorization program. Goodbye!");
                    return;

                default:
                    Console.WriteLine("Invalid choice. Please enter a valid option.");
                    break;
            }

            Console.WriteLine("Press Enter to continue...");
            Console.ReadLine();
        }
    }
}
