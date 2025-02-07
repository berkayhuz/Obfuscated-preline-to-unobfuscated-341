using HtmlAgilityPack;
using Newtonsoft.Json;

class ClassRenamer
{
    static void Main(string[] args)
    {
        string htmlFilePath = "input.html";
        string jsonFilePath = "classMapping.json";
        string outputHtmlFilePath = "output.html";

        var htmlDoc = new HtmlDocument();
        htmlDoc.Load(htmlFilePath);

        var classMapping = JsonConvert.DeserializeObject<Dictionary<string, string>>(File.ReadAllText(jsonFilePath));

        var reversedClassMapping = new Dictionary<string, string>();
        foreach (var kvp in classMapping)
        {
            reversedClassMapping[kvp.Value] = kvp.Key;
        }

        RemoveComments(htmlDoc.DocumentNode);

        RenameClasses(htmlDoc.DocumentNode, reversedClassMapping);

        htmlDoc.Save(outputHtmlFilePath);

    }

    static void RenameClasses(HtmlNode node, Dictionary<string, string> classMapping)
    {
        if (node.NodeType == HtmlNodeType.Element)
        {
            if (node.Attributes["class"] != null)
            {
                var classNames = node.Attributes["class"].Value.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                for (int i = 0; i < classNames.Length; i++)
                {
                    if (classMapping.ContainsKey(classNames[i]))
                    {
                        classNames[i] = classMapping[classNames[i]];
                    }
                }
                node.Attributes["class"].Value = string.Join(' ', classNames);
            }
        }

        foreach (HtmlNode child in node.ChildNodes)
        {
            RenameClasses(child, classMapping);
        }
    }

    static void RemoveComments(HtmlNode node)
    {
        for (int i = node.ChildNodes.Count - 1; i >= 0; i--)
        {
            HtmlNode child = node.ChildNodes[i];
            if (child.NodeType == HtmlNodeType.Comment)
            {
                node.ChildNodes.Remove(child);
            }
            else
            {
                RemoveComments(child);
            }
        }
    }
}
