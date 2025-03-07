using System;

class Program
{
    static void Main()
    {
        void WriteInfoToFile(string journalName)
        {
            NewPrompt promptGenerator = new NewPrompt();
            string randomPrompt = promptGenerator.GetRandomPrompt();
            Console.WriteLine("Your prompt: " + randomPrompt);
            Console.WriteLine("Please enter your journal entry: ");
            string userEntry = Console.ReadLine();

            UserEntryClass userEntry1 = new UserEntryClass(randomPrompt, userEntry);
            string saveUserEntry = userEntry1.makeUserEntry();
            WriteOrReadToFile entryWriter = new WriteOrReadToFile(saveUserEntry, journalName);
            entryWriter.WriteToFile();
        }


        bool exit = false;
        while (exit != true)
        {
            Console.Clear();
            Console.WriteLine("========================================");
            Console.WriteLine("Welcome to the Journal Entry Program!");
            Console.WriteLine("Please select an option:");
            Console.WriteLine("1. Create a new journal");
            Console.WriteLine("2. write to an existing journal");
            Console.WriteLine("3. display a journal");
            Console.WriteLine("4. exit");
            Console.Write("Enter your selection: ");
            string userSelection = Console.ReadLine();

            if (userSelection == "1")
            {
                Console.WriteLine("========================================");
                Console.WriteLine("what would you like to name your journal?");
                string journalName = Console.ReadLine();
                journalName = journalName + ".txt";
                if (File.Exists(journalName))
                {
                    Console.WriteLine("========================================");
                    Console.WriteLine("The file already exists. Please choose a different name.");
                    Console.WriteLine("Press any key to continue...");
                    Console.ReadKey();
                }
                else
                {
                    Console.WriteLine("========================================");
                    WriteInfoToFile(journalName);
                    Console.WriteLine("Your entry has been saved!");
                    Console.WriteLine("Press any key to go back to the menue...");
                    Console.ReadKey();
                }
            }


            else if (userSelection == "2")
            {
                Console.WriteLine("========================================");
                Console.WriteLine("Please enter the name of the journal you would like to write to (donot add .txt): ");
                string journalName = Console.ReadLine();
                journalName = journalName + ".txt";

                if (File.Exists(journalName))
                {
                    WriteInfoToFile(journalName);
                }
                else
                {
                    Console.WriteLine("The file does not exist. Please create a new journal first.");
                    Console.WriteLine("Press any key to continue...");
                    Console.ReadKey();
                }
            }


            else if (userSelection == "3")
            {
                Console.WriteLine("Please enter the name of the journal you would like to display (donot add .txt): ");
                string journalName = Console.ReadLine();
                journalName = journalName + ".txt";

                if (File.Exists(journalName))
                {
                    WriteOrReadToFile requestFile = new WriteOrReadToFile("", journalName);
                    string fileContents = requestFile.GetFileContents(journalName);
                    Console.WriteLine($"{journalName}\n {fileContents}");
                    Console.WriteLine("\nPress any key to go back to the menue...");
                    Console.ReadKey();
                }

                else
                {
                    Console.WriteLine("The file does not exist. Please create a new journal first.");
                    Console.WriteLine("Press any key to continue...");
                    Console.ReadKey();
                }
            }


            else if (userSelection == "4")
            {
                exit = true;
                Console.WriteLine("Thank you for using the Journal Entry Program. Goodbye!");
                Console.WriteLine("========================================");
            }


            else
            {
                Console.WriteLine("Invalid selection. Please try again.");
                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();
            }
        }
    }
}
