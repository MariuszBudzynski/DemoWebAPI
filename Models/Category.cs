using System;
using System.Collections.Generic;

namespace DemoApps.Models;

public partial class Category
{
    public string? CategoryId { get; set; }

    public string CategoryName { get; set; } = null!;

    public string? Description { get; set; }

    IEnumerable<Product>? Products { get; set; }

}
