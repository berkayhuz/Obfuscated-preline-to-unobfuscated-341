using Newtonsoft.Json.Linq;

class jsoncifttemizleme
{
    static void Main()
    {
        string jsonFilePath = "input.json";
        string jsonString = File.ReadAllText(jsonFilePath);

        JObject jsonObject = JObject.Parse(jsonString);

        RemoveDuplicateKeysWithSameValue(jsonObject);

        string updatedJsonString = jsonObject.ToString();
        string outputFilePath = "output.json";
        File.WriteAllText(outputFilePath, updatedJsonString);
    }

    static void RemoveDuplicateKeysWithSameValue(JObject jsonObject)
    {
        HashSet<string> encounteredValues = new HashSet<string>();
        var propertiesToRemove = new List<JProperty>();

        foreach (var property in jsonObject.Properties())
        {
            string value = property.Value.ToString();

            if (!encounteredValues.Contains(value))
            {
                encounteredValues.Add(value);
            }
            else
            {
                propertiesToRemove.Add(property);
            }
        }

        foreach (var property in propertiesToRemove)
        {
            property.Remove();
        }
    }
}
