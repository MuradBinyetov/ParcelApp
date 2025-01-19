using AutoMapper;
using OrderService.Dtos;
using OrderService.Models;

namespace OrderService.Mapper
{
    public class OrderProfile : Profile
    {
        public OrderProfile()
        {
            CreateMap<Order, OrderDto>();
            CreateMap<OrderDto, Order>();
            CreateMap<CreateOrderDto,OrderDto>();
        }
    }
}
