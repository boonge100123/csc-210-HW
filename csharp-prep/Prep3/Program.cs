using System;
using System.Reflection.Metadata;
using System.Runtime.CompilerServices;

class Program
{
    static void Main(string[] args)
    {
        Random RandomGenerator = new Random();
        int number_to_guess = RandomGenerator.Next(1, 101);

        int user_guess = -1;
        while (user_guess != number_to_guess)
        {
            Console.Write("what is your guess?: \n");
            user_guess = int.Parse(Console.ReadLine());

            if(user_guess > number_to_guess)
            {
                Console.Write("your guess is too high: \n");
            }
            else if (user_guess < number_to_guess)
            {
                Console.Write("your guess is too low: \n");
            }
            else
            {
                Console.Write("good job you got it!");
            }
        }
    }
}