using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace DemoApps.Models;

public partial class Product
{
    public string? ProductId { get; set; }

    public string ProductName { get; set; } = null!;


    public string? CategoryId { get; set; }


    public decimal? UnitPrice { get; set; }

    public int? UnitsInStock { get; set; }

    [JsonIgnore]
    public Category? Category { get; set; }
}
