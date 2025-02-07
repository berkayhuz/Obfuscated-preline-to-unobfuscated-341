using Newtonsoft.Json;

class RemoveCharacterKeys
{
    public static void Main(string[] args)
    {
        string inputJsonPath = "input.json";
        string outputJsonPath = "output.json";

        var classMapping = new Dictionary<string, string>();
        if (File.Exists(inputJsonPath))
        {
            classMapping = JsonConvert.DeserializeObject<Dictionary<string, string>>(File.ReadAllText(inputJsonPath));
        }

        RemoveEntriesWithCharacters(classMapping);

        string jsonResult = JsonConvert.SerializeObject(classMapping, Formatting.Indented);
        File.WriteAllText(outputJsonPath, jsonResult);
    }

    private static void RemoveEntriesWithCharacters(Dictionary<string, string> classMapping)
    {
        var keysToRemove = new List<string>();
        foreach (var entry in classMapping)
        {
            if (entry.Key.Length == 1)
            {
                keysToRemove.Add(entry.Key);
            }
        }

        foreach (var key in keysToRemove)
        {
            classMapping.Remove(key);
        }
    }
}
