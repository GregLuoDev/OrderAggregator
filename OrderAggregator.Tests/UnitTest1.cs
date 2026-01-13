using OrderAggregator.Models;
using OrderAggregator.Services;

namespace OrderAggregator.Tests;

public class UnitTest1
{
    [Fact]
    public void SumFilledByTicker_ReturnsCorrectSum()
    {
        var orders = new List<Order>
        {
            new() {
                eventTime= "20251112-01:24:23:102",
                clientOrderId= "aaaaaa",
                ticker= "BHP AU Equity",
                quantity=100,
                filledQuantity = 100
            },
             new() {
                eventTime= "20251112-01:24:23:103",
                clientOrderId= "bbbbbb",
                ticker= "BHP AU Equity",
                quantity=100,
                filledQuantity = 10
            }
        };

        var result = AggregationService.SumFilledByTicker(orders);

        Assert.Equal(110, result["BHP AU Equity"]);
    }


    [Fact]
    public void LargestFillByTicker_ReturnsCorrectValue()
    {
        var orders = new List<Order>
        {
            new() {
                eventTime= "20251112-01:24:23:101",
                clientOrderId= "aaaaaa",
                ticker= "BHP AU Equity",
                quantity=100,
                filledQuantity = 50
            },
            new() {
                eventTime= "20251112-01:24:23:102",
                clientOrderId= "aaaaaa",
                ticker= "BHP AU Equity",
                quantity=100,
                filledQuantity = 100
            },
             new() {
                eventTime= "20251112-01:24:23:103",
                clientOrderId= "bbbbbb",
                ticker= "BHP AU Equity",
                quantity=100,
                filledQuantity = 10
            }
        };

        var result = AggregationService.LargestFilledByTicker(orders);

        Assert.Equal(100, result["BHP AU Equity"]);
    }
}