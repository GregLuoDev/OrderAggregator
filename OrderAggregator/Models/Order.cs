using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderAggregator.Models;

public class Order
{
    public string eventTime { get; set; } = string.Empty;
    public string clientOrderId { get; set; } = string.Empty;
    public string ticker { get; set; } = string.Empty;
    public int quantity { get; set; }
    public int filledQuantity { get; set; }
}
