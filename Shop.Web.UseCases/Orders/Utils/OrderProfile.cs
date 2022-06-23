using AutoMapper;
using Shop.Web.Entities;
using Shop.Web.UseCases.Orders.Dtos;

namespace Shop.Web.UseCases.Orders.Utils;

public class OrderProfile : Profile
{
    public OrderProfile()
    {
        CreateMap<Order, OrderDto>();

        CreateMap<UpdateOrderDto, Order>();
        CreateMap<CreateOrderDto, Order>();

        CreateMap<OrderItem, OrderItemDto>().ReverseMap();
    }
}