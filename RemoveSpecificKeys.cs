using Newtonsoft.Json;

class RemoveSpecificKeys
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

        RemoveEntriesBasedOnConditions(classMapping);

        string jsonResult = JsonConvert.SerializeObject(classMapping, Formatting.Indented);
        File.WriteAllText(outputJsonPath, jsonResult);
    }

    private static void RemoveEntriesBasedOnConditions(Dictionary<string, string> classMapping)
    {
        var keysToRemove = new List<string>();
        foreach (var entry in classMapping)
        {
            if (entry.Key.Length == 5 ||
                entry.Key.Contains("::before") ||
                entry.Key.Contains("::after") ||
                entry.Key == entry.Value ||
                entry.Key.Contains("group-focus:") ||
                entry.Key.Contains(":focus") ||
                entry.Key.Contains("hover:") ||
                entry.Key.Contains("focus:") ||
                entry.Key.Contains("checked:") ||
                entry.Key.Contains(":checked") ||
                entry.Key.Contains(":hover") ||
                entry.Key.Contains(":disabled") ||
                entry.Key.Contains("::-moz-placeholder"))
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
