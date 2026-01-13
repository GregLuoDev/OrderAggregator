using OrderAggregator.Models;
using System.Text.Json;

namespace OrderAggregator.Services;

public static class JSONParser
{
    public static List<Order> Parse(string filePath)
    {
        var basePath = AppContext.BaseDirectory;
        var projectRoot = Directory.GetParent(basePath)!.Parent!.Parent!.Parent!.FullName;

        var fullFilePath = Path.Combine(projectRoot, filePath);

        var json = File.ReadAllText(fullFilePath);

        using var doc = JsonDocument.Parse(json);

        var latestByOrderId = new Dictionary<string, Order>();

        foreach (var element in doc.RootElement.GetProperty("orders").EnumerateArray())
        {
            var order = JsonSerializer.Deserialize<Order>(element);
            if (order == null) continue;

            if (!latestByOrderId.TryGetValue(order.clientOrderId, out var existing) ||
            string.Compare(order.eventTime, existing.eventTime, StringComparison.Ordinal) > 0)
            {
                latestByOrderId[order.clientOrderId] = order;
            }
        }

        return latestByOrderId.Values.ToList();
    }
}
