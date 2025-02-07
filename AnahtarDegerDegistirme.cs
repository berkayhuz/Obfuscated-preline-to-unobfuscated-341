using Newtonsoft.Json.Linq;

class AnahtarDegerDegistirme
{
    static void Main()
    {
        string inputFilePath = "input.json";
        string json = File.ReadAllText(inputFilePath);

        JObject jsonObject = JObject.Parse(json);

        JObject swappedObject = SwapKeysAndValues(jsonObject);

        string outputFilePath = "output.json";
        File.WriteAllText(outputFilePath, swappedObject.ToString());

    }

    static JObject SwapKeysAndValues(JObject jsonObject)
    {
        JObject swappedObject = new JObject();

        foreach (var property in jsonObject.Properties())
        {
            swappedObject[property.Value.ToString()] = property.Name;
        }

        return swappedObject;
    }
}
