// JsonDataService.cs
using System.Text.Json;

public class JsonDataService
{
    public void SaveData<T>(List<T> data, string filename)
    {
        string json = JsonSerializer.Serialize(data);
        File.WriteAllText(filename, json);
    }

    public List<T> LoadData<T>(string filename)
    {
        if (!File.Exists(filename)) return new List<T>();
        string json = File.ReadAllText(filename);
        return JsonSerializer.Deserialize<List<T>>(json);
    }
}