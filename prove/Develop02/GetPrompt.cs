using System;
// this class will hold the list of prompts and will have a method to get a random prompt from the list
// it is what will handall chosing a random prompt for the user to write about
class NewPrompt
{
    private List<string> _promptList;

    public NewPrompt()
    {
        _promptList = new List<string>{
            "Who was the most interesting person I interacted with today?",
            "What was the best part of my day?",
            "How did I see the hand of the Lord in my life today?",
            "What was the strongest emotion I felt today?",
            "If I had one thing I could do over today, what would it be?"
        };
    }

    public string GetRandomPrompt()
    {
        Random random = new Random();
        int index = random.Next(_promptList.Count);
        return _promptList[index];
    }
}