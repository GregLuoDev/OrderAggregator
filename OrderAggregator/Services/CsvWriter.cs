namespace OrderAggregator.Services;

public static class CsvWriter
{
    public static void Write(string filePath, Dictionary<string, int> data)
    {
        var basePath = AppContext.BaseDirectory;
        var projectRoot = Directory.GetParent(basePath)!.Parent!.Parent!.Parent!.FullName;
        var fullFilePath = Path.Combine(projectRoot, filePath);

        var lines = data.Select(kvp => $"{kvp.Key}, {kvp.Value}");
        File.WriteAllLines(fullFilePath, lines);
    }
}