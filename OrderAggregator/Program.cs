using OrderAggregator.Services;

if (args.Length == 0)
{
    Console.WriteLine("Usage: dotnet run -- <input_file.json>");
    return;
}

var inputFile = args[0];

var orders = JSONParser.Parse(inputFile);

var sumByTicker = AggregationService.SumFilledByTicker(orders);
var largestByTicker = AggregationService.LargestFilledByTicker(orders);

var basePath = Path.Combine("Output", Path.GetFileNameWithoutExtension(inputFile));

CsvWriter.Write($"{basePath}_sum.csv", sumByTicker);
CsvWriter.Write($"{basePath}_largest.csv", largestByTicker);

Console.WriteLine("Order aggregation completed.");
Console.ReadLine();