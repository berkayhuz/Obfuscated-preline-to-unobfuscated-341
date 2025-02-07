using Newtonsoft.Json;

class RemoveSameKeyValuePairs
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

        RemoveEntriesWithSameKeyValue(classMapping);

        string jsonResult = JsonConvert.SerializeObject(classMapping, Formatting.Indented);
        File.WriteAllText(outputJsonPath, jsonResult);
    }

    private static void RemoveEntriesWithSameKeyValue(Dictionary<string, string> classMapping)
    {
        var keysToRemove = new List<string>();
        foreach (var entry in classMapping)
        {
            if (entry.Key == entry.Value)
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
