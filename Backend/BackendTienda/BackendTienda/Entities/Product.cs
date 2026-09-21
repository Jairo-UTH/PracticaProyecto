using System;
using System.Collections.Generic;

namespace BackendTienda.Entities;

public partial class Product
{
    public int ProductId { get; set; }

    public int CategoryId { get; set; }

    public string Name { get; set; } = null!;

    public decimal Price { get; set; }

    public int StockQuantity { get; set; }

    public string? Image { get; set; }

    public DateTime CreatedAt { get; set; }

    public virtual Category Category { get; set; } = null!;

    public virtual ICollection<OrderDetail> OrderDetails { get; set; } = new List<OrderDetail>();
}
