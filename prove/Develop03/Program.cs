using System;

class Program
{
    static void Main(string[] args)
    {
        Scripture scripture1 = new Scripture("John", 3, 16, "For God so loved the world, that he gave his only begotten Son, that whosoever believeth in him should not perish, but have everlasting life.");
        Scripture scripture2 = new Scripture("Genesis", 1, 1, "In the beginning God created the heaven and the earth.");
        Scripture scripture3 = new Scripture("Psalm", 23, 1, "The LORD is my shepherd; I shall not want.");

        Console.WriteLine(scripture1.GetReference());
        Console.WriteLine(scripture1.GetText());

        Console.WriteLine(scripture2.GetReference());
        Console.WriteLine(scripture2.GetText());

        Console.WriteLine(scripture3.GetReference());
        Console.WriteLine(scripture3.GetText());
    }
}