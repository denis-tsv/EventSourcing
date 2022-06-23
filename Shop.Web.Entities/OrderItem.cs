﻿namespace Shop.Web.Entities;

public class OrderItem : Entity
{
    public int OrderId { get; set; }

    public int ProductId { get; set; }

    public int Quantity { get; set; }

    public Product Product { get; set; } = null!;

    public Order Order { get; set; } = null!;
}