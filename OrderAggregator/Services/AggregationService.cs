using OrderAggregator.Models;

namespace OrderAggregator.Services;

public static class AggregationService
{
    public static Dictionary<string, int> SumFilledByTicker(IEnumerable<Order> orders)
    {
        var result = new Dictionary<string, int>();

        foreach (var order in orders)
        {
            result.TryGetValue(order.ticker, out var current);
            result[order.ticker] = current + order.filledQuantity;
        }

        return result
                    .Where(kvp => kvp.Value > 0)
                    .ToDictionary(kvp => kvp.Key, kvp => kvp.Value);
    }

    public static Dictionary<string, int> LargestFilledByTicker(IEnumerable<Order> orders)
    {
        var result = new Dictionary<string, int>();

        foreach (var order in orders)
        {
            result.TryGetValue(order.ticker, out var current);
            result[order.ticker] = Math.Max(current, order.filledQuantity);
        }

        return result 
                   .Where(kvp => kvp.Value > 0)
                   .ToDictionary(kvp => kvp.Key, kvp => kvp.Value);
    }
}

