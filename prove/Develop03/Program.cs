using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        ScriptureList scriptureList = new ScriptureList();
        Scripture scripture = null; // Declare it outside to be accessible in case "3"
        string currentText = string.Empty;
        List<Scripture> selectedScriptures = null;  // Declare it outside the switch for reusability

        while (true)
        {
            Console.Clear();
            Console.WriteLine("Welcome to the Scripture memorization program!");
            Console.WriteLine("Please enter one of the following options to proceed:");
            Console.WriteLine(" 1. View List of Scripture Masteries available");
            Console.WriteLine(" 2. Enter your own scripture reference to memorize");
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
                            Console.WriteLine($"{scr.GetReference()}: {string.Join(" ", scr.GetText().Split(' ').Take(7))}...");
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

                    Console.WriteLine("\nPress Enter to start removing words in batches of 3...");
                    currentText = scripture.GetText(); // Set initial text

                    // Start the loop to remove 3 words each time Enter is pressed
                    while (true)
                    {
                        Console.Clear();
                        Console.WriteLine($"Current text: {currentText}");
                        Console.WriteLine("\nPress Enter to remove 3 more words, or any other key to return to the main menu.");

                        var key = Console.ReadKey();
                        if (key.Key == ConsoleKey.Enter)
                        {
                            int wordsRemaining = currentText.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Length;

                            // Remove the last set of 3 words, or fewer if there are less than 3 remaining
                            if (wordsRemaining <= 3)
                            {
                                RemoveWords remover = new RemoveWords(wordsRemaining); // Remove the remaining words
                                currentText = remover.RemoveWordsFromText(currentText);
                                Console.WriteLine("\nAll words have been removed.");
                                break; // Exit the loop after removing the last words
                            }
                            else
                            {
                                RemoveWords remover = new RemoveWords(3); // Remove 3 words per press
                                currentText = remover.RemoveWordsFromText(currentText); // Remove 3 words
                            }
                        }
                        else
                        {
                            // User pressed any key other than Enter, return to main menu
                            break;
                        }
                    }
                    break;

                case "3":
                    Console.WriteLine("Select a book to view scriptures:");
                    Console.WriteLine("1. Book of Mormon");
                    Console.WriteLine("2. New Testament");
                    Console.WriteLine("3. Old Testament");
                    Console.WriteLine("4. Doctrine and Covenants");
                    Console.WriteLine("5. Return to Main Menu");

                    string bookChoice2 = Console.ReadLine();

                    switch (bookChoice2)
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
                        for (int i = 0; i < selectedScriptures.Count; i++)
                        {
                            Console.WriteLine($"{i + 1}. {selectedScriptures[i].GetReference()}: {string.Join(" ", selectedScriptures[i].GetText().Split(' ').Take(7))}...");
                        }

                        // Ask user to select a scripture
                        Console.WriteLine("\nEnter the number of the scripture you want to memorize:");
                        int scriptureChoice;
                        if (int.TryParse(Console.ReadLine(), out scriptureChoice) && scriptureChoice >= 1 && scriptureChoice <= selectedScriptures.Count)
                        {
                            // Get the selected scripture
                            scripture = selectedScriptures[scriptureChoice - 1];

                            // Display full text of the scripture
                            Console.WriteLine($"\nYou selected: {scripture.GetReference()}: {scripture.GetText()}");

                            // Start the word removal process
                            Console.WriteLine("\nPress Enter to start removing words in batches of 3...");
                            currentText = scripture.GetText(); // Set initial text

                            // Start the loop to remove 3 words each time Enter is pressed
                            while (true)
                            {
                                Console.Clear();
                                Console.WriteLine($"Current text: {currentText}");
                                Console.WriteLine("\nPress Enter to remove 3 more words, or any other key to return to the main menu.");

                                var key = Console.ReadKey();
                                if (key.Key == ConsoleKey.Enter)
                                {
                                    int wordsRemaining = currentText.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Length;

                                    // Remove the last set of 3 words, or fewer if there are less than 3 remaining
                                    if (wordsRemaining <= 3)
                                    {
                                        RemoveWords remover = new RemoveWords(wordsRemaining); // Remove the remaining words
                                        currentText = remover.RemoveWordsFromText(currentText);
                                        Console.WriteLine("\nAll words have been removed.");
                                        break; // Exit the loop after removing the last words
                                    }
                                    else
                                    {
                                        RemoveWords remover = new RemoveWords(3); // Remove 3 words per press
                                        currentText = remover.RemoveWordsFromText(currentText); // Remove 3 words
                                    }
                                }
                                else
                                {
                                    // User pressed any key other than Enter, return to main menu
                                    break;
                                }
                            }
                        }
                        else
                        {
                            Console.WriteLine("Invalid selection. Returning to main menu.");
                        }
                    }
                    else
                    {
                        Console.WriteLine("No scriptures available for the selected book.");
                    }
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
