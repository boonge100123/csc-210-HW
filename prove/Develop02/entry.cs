using System;

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