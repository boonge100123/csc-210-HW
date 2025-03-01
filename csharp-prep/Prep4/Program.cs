using System;

class Program
{
    static void Main(string[] args)
    {
        List<int> user_list = get_user_numbers();
        List<int> sorted_user_list = sort_user_list(user_list);
        int sum = sum_list(user_list);
        int larges_number = find_largest(user_list);
        int smallest_positive_number = find_smalest_positive_number(user_list);

        Console.Write($"The sum of all the numbers in the list is: {sum}\n");
        Console.Write($"The largest number in the list is: {larges_number}\n");
        Console.Write($"The smallest positive number in the list is: {smallest_positive_number}\n");

        foreach(int num in sorted_user_list)
        {
            Console.WriteLine(num);
        }
    }

    static List<int> get_user_numbers()
    {
        List<int> user_numbers = new List<int>();
        string user_input;

        Console.Write("Enter numbers (type 'done' to finish):");

        while (true)
        {
            Console.Write("Enter a Number (or done to stop):");
            user_input = Console.ReadLine();

            if (user_input.ToLower() == "done")
                break;

            if (int.TryParse(user_input, out int num))
            {
                user_numbers.Add(num);
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter a number."); 
            }
        }
        return user_numbers;
    }

    static List<int> sort_user_list(List<int> user_list)
    {
        user_list.Sort();
        return user_list;
    }

    static int sum_list(List<int> user_list)
    {
        int sum = 0;
        foreach (int num in user_list)
        {
            sum += num;
        }
    return sum;
    }

    static int find_largest(List<int> user_list)
    {
        int largest = 0;
        foreach (int num in user_list)
        {
            if(num > largest)
            {
                largest = num;
            }
        }
    return largest;
    }

    static int find_smalest_positive_number(List<int> user_list)
    {
        int smallest_positive_number = int.MaxValue;

        foreach(int num in user_list)
        {
            if(num > 0 && num < smallest_positive_number)
            {
                smallest_positive_number = num;
            }
        }
    return smallest_positive_number;
    }
}