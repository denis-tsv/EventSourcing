﻿using MediatR;
using Shop.Web.UseCases.Orders.Dtos;

namespace Shop.Web.UseCases.Orders.Queries;

public class GetOrderQuery : IRequest<OrderDto>
{
    public Guid Id { get; init; }
}