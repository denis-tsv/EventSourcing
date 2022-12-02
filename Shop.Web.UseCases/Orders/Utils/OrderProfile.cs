using AutoMapper;
using Shop.Models;
using Shop.Web.UseCases.Orders.Dtos;

namespace Shop.Web.UseCases.Orders.Utils;

public class OrderProfile : Profile
{
    public OrderProfile()
    {
        CreateMap<OrderModel, OrderDto>();
    }
}