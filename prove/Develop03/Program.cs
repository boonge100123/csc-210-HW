using System;
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
            // Options for the user to choose from
            Console.Clear();
            Console.WriteLine("Welcome to the Scripture memorization program!");
            Console.WriteLine("Please enter one of the following options to proceed:");
            Console.WriteLine(" 1. View List of Scripture Masteries available");
            Console.WriteLine(" 2. Enter your own scripture reference to memorize");
            Console.WriteLine(" 3. Proceed to the memorization tool");
            Console.WriteLine(" 4. Exit");

            //user input for the menu choice
            Console.Write("Enter your choice (1-4): ");
            string choice = Console.ReadLine();

            // Process the user's choice using a switch statement
            switch (choice)
            {
                case "1":
                    // Display the lists of scripture masteries available for the user to choose from based on the diffrent standard works
                    Console.Clear();
                    Console.WriteLine("Select a book to view scriptures:");
                    Console.WriteLine("1. Book of Mormon");
                    Console.WriteLine("2. New Testament");
                    Console.WriteLine("3. Old Testament");
                    Console.WriteLine("4. Doctrine and Covenants");
                    Console.WriteLine("5. Return to Main Menu");

                    //user input for the book choice
                    Console.Write("Enter your choice (1-5): ");
                    string bookChoice = Console.ReadLine();

                    // switch statement to determine which book of scripture the user wants to view the mastery scriptures from
                    // this will call a list of scriptures from the ScriptureList class
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
                            // Return to main menu, do nothing and continue the loop
                            continue;
                        default:
                            // Handle invalid input and return the user to 
                            Console.WriteLine("Invalid choice. Press enter to continue...");
                            Console.ReadLine();
                            continue;
                    }

                    // Check if the selected scriptures list exsists and has info in it
                    if (selectedScriptures != null && selectedScriptures.Count > 0)
                    {
                        // Display the list of scriptures available for the user to choose from
                        Console.WriteLine("\nAvailable Scriptures:");
                        foreach (var scr in selectedScriptures)
                        {
                            // Display the scripture reference and a preview of the text (onaly the first 7 words)
                            Console.WriteLine($"{scr.GetReference()}: {string.Join(" ", scr.GetText().Split(' ').Take(7))}...");
                        }
                    }
                    // this is just to handle any errors that may occur if the list is empty or null
                    // this should not happen as the scriptureList class should always have info in it but just in case
                    //i guess you can call it idiot proffing... :)
                    else
                    {
                        Console.WriteLine("Something went wrong. No scriptures available for the selected book.");
                    }
                    break;

                case "2":
                    // Prompt the user to enter their own scripture reference to memorize
                    // this is the line that will get the book from them
                    Console.WriteLine("Please enter the Book of scripture:");
                    string book = Console.ReadLine();

                    // this is the line that will get the chapter from them
                    // this will also make sure the input is not a string or other invalid input
                    Console.WriteLine("Please enter the chapter:");
                    if (!int.TryParse(Console.ReadLine(), out int chapter))
                    {
                        // if the input is invalid, it will display an error message and return to the main menu
                        Console.WriteLine("Invalid chapter number. Please enter a valid integer.");
                        break;
                    }

                    // this is the line that will get the starting verse from them
                    // this will also make sure the input is not a string or other invalid input
                    Console.WriteLine("Please enter the starting verse:");
                    if (!int.TryParse(Console.ReadLine(), out int startVerse))
                    {
                        Console.WriteLine("Invalid verse number. Please enter a valid integer.");
                        break;
                    }

                    // this is the line that will get the ending verse from them
                    // this will also make sure the input is not a string or other invalid input
                    Console.WriteLine("Please enter the ending verse:");
                    Console.WriteLine("if it is the same as the starting verse, enter the same number. : ");
                    if (!int.TryParse(Console.ReadLine(), out int endVerse))
                    {
                        Console.WriteLine("Invalid verse number. Please enter a valid integer.");
                        break;
                    }

                    // this is the line that will get the text of the scripture from them
                    Console.WriteLine("Please enter the text of the scripture:");
                    string text = Console.ReadLine();

                    // Create a new Scripture object with the user's input
                    // it will also display it to the user
                    scripture = new Scripture(book, chapter, startVerse, endVerse, text);
                    Console.WriteLine($"You entered: {scripture.GetReference()}: {scripture.GetText()}");

                    //print out the instructions for the user to follow to use the memorization tool
                    Console.WriteLine("\nPress Enter to start removing words in batches of 3...");

                     // Set initial text to the scripture text
                    currentText = scripture.GetText();

                    // Start the loop to remove 3 words each time Enter is pressed
                    while (true)
                    {
                        // Clear the console and display the current text
                        Console.Clear();
                        //print out the whole text of the scripture to the user for the first iteration
                        // prompt the user to press enter to remove 3 words at a time
                        Console.WriteLine($"Current text: {currentText}");
                        Console.WriteLine("\nPress Enter to remove 3 more words, or any other key to return to the main menu.");

                        // this is the line that waits for the user to press enter
                        var key = Console.ReadKey();
                        if (key.Key == ConsoleKey.Enter)
                        {
                            // If Enter is pressed, remove 3 words from the text
                            int wordsRemaining = currentText.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Length;

                            // Remove the last set of 3 words, or fewer if there are less than 3 remaining
                            // this will check if there are less than 3 words remaining and remove them all if so
                            // there is a check to exit the loop if all the words have been removed
                            if (wordsRemaining <= 3)
                            {
                                // Remove the last 3 remaining words
                                RemoveWords remover = new RemoveWords(wordsRemaining); 
                                currentText = remover.RemoveWordsFromText(currentText);
                                Console.WriteLine("\nAll words have been removed.");
                                break;
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
                    // this is almost the same as case "1" but it will also display the scripture text to the user
                    // Prompt the user to select a book of scripture to view mastery scriptures from
                    // i was going to make this a function but i ran out of time and it was easier to just copy and paste the code
                    Console.Clear();
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
                    // Exit the program
                    Console.WriteLine("Thank you for using the Scripture memorization program. Goodbye!");
                    return;

                default:
                    // Handle invalid input and return the user to the main menu
                    Console.WriteLine("Invalid choice. Please enter a valid option.");
                    break;
            }

            Console.WriteLine("Press Enter to continue...");
            Console.ReadLine();
        }
    }
}
