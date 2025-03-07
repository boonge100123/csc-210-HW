using System;

// this class will handle writing to a file and reading from a file
// it can write a new entry to a new file or append to an existing file
// it can also read the contents of a file and return it back to main to be displayed
class WriteOrReadToFile
{
    private string _entry;
    private string _fileName;

    public WriteOrReadToFile(string entry, string fileName)
    {
        _entry = entry;
        _fileName = fileName;
    }

    public void WriteToFile()
    {
        using (StreamWriter writer = new StreamWriter(_fileName, true))
        {
            writer.WriteLine(_entry);
        }
    }

    public string GetFileContents(string fileName)
    {
        if (File.Exists(fileName))
        {
            return File.ReadAllText(fileName);
        }
        else
        {
            return "The file does not exist or hasn't been opened. Please provide a valid file name.";
        }
    }
}
