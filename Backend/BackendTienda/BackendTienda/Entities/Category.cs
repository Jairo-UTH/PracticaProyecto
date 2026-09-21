using System;
using System.Collections.Generic;

namespace BackendTienda.Entities;

public partial class Category
{
    public int CategoryId { get; set; }

    public string Icon { get; set; } = null!;

    public string Name { get; set; } = null!;

    public virtual ICollection<Product> Products { get; set; } = new List<Product>();
}
