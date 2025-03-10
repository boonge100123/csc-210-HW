using System;
// this is the class that will hold the user's entry and the prompt and the date
// it will also have a method to format the entry for display
class UserEntryClass
{
    private string _entryPrompt;
    private string _userEntry;
    private DateTime _date;

    public UserEntryClass(string prompt, string userEntry)
    {
        _entryPrompt = prompt;
        _userEntry = userEntry;
        _date = DateTime.Now;
    }

    public string makeUserEntry()
    {
        return $"{_date:yyyy-MM-dd} - {_entryPrompt}\n{_userEntry}";
    }
    

}