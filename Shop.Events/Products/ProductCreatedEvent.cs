﻿namespace Shop.Events.Products;

public class ProductCreatedEvent : Event
{
    public Guid Id { get; set; }
    public string Name { get; set; } = null!;
    public decimal Price { get; set; }
}