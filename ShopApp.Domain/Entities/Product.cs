using System;
using System.Collections.Generic;
using System.Text;

namespace ShopApp.Domain.Entities;

public class Product
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public decimal Price { get; set; }
}
