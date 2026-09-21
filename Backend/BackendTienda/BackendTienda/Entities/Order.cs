using System;
using System.Collections.Generic;

namespace BackendTienda.Entities;

public partial class Order
{
    public int OrderId { get; set; }

    public decimal TotalAmount { get; set; }

    public DateTime OrderDate { get; set; }

    public virtual ICollection<OrderDetail> OrderDetails { get; set; } = new List<OrderDetail>();
}
