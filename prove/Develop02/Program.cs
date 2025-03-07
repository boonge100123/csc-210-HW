using System;

class Program
{
    static void Main()
    {
        NewPrompt promptGenerator = new NewPrompt();
        string randomPrompt = promptGenerator.GetRandomPrompt();
        Console.WriteLine("Your prompt: " + randomPrompt);
        Console.WriteLine("Please enter your journal entry: ");
        string userEntry = Console.ReadLine();

        UserEntryClass journalEntry = new UserEntryClass(randomPrompt, userEntry);

        Console.WriteLine("\nYour journal entry:");
        Console.WriteLine(journalEntry.makeUserEntry());
    }
}