using AutoMapper;
using Microsoft.EntityFrameworkCore;
using OrderService.Data;
using OrderService.Dtos;
using OrderService.Models;
using OrderService.Services.Abstract;

namespace OrderService.Services.Concrete
{
    public class OrderService : IOrderService
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public OrderService(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<OrderDto> AssignOrderToCourier(int id, string courierId)
        {
            var order = await GetOrderByIdAsync(id);
            order.CourierId = courierId;
            await _context.SaveChangesAsync();
            var orderDto =  _mapper.Map<OrderDto>(order);
            return orderDto;
        }

        public async Task CancelParcel(int id)
        {
            var order = await GetOrderByIdAsync(id);
            order.UserId = null;
            order.IsDeleted = true;
            order.Status = OrderStatus.Cancel;
            await _context.SaveChangesAsync();
        }

        public async Task<OrderDto> CreateOrderAsync(OrderDto dto)
        {
            var order = _mapper.Map<Order>(dto);
            order.CreateDate = DateTime.Now;
            order.IsDeleted = false;
            order.Status = OrderStatus.Active;
            _context.Orders.Add(order);
            await _context.SaveChangesAsync();
            var orderDto = _mapper.Map<OrderDto>(order);
            return orderDto;
        } 

        public async Task<List<OrderDto>> GetAllOrdersAsync()
        {
            var orders = await _context.Orders.ToListAsync();
            var ordersDto = _mapper.Map<List<OrderDto>>(orders);
            return ordersDto;
        }

        public async Task<List<OrderDto>> GetAllOrdersByUser(string userId)
        {
            var orders = await _context.Orders.Where(o=>o.UserId == userId).ToListAsync();
            var ordersDto = _mapper.Map<List<OrderDto>>(orders);
            return ordersDto;
        }

        public async Task<List<OrderDto>> GetAllOrdersByCourierId(string courierId)
        {
            var orders = await _context.Orders.Where(o => o.CourierId == courierId).ToListAsync();
            var ordersDto = _mapper.Map<List<OrderDto>>(orders);
            return ordersDto;
        }

        public async Task<OrderDto> GetOrderByIdAsync(int id)
        {
            var order = await _context.Orders.FirstOrDefaultAsync(o => o.Id == id);
            var orderDto = _mapper.Map<OrderDto>(order);
            return orderDto;

        }

        public async Task<OrderDto> UpdateOrderDestination(int id, string destination)
        {
            var order = await GetOrderByIdAsync(id);
            order.Destination = destination;
            await _context.SaveChangesAsync();
            var orderDto = _mapper.Map<OrderDto>(order);
            return orderDto; 
        }

        public async Task<OrderDto> UpdateOrderStatus(int id, OrderStatus status)
        {
            var order = await GetOrderByIdAsync(id);
            order.Status = status;
            await _context.SaveChangesAsync();
            var orderDto = _mapper.Map<OrderDto>(order);
            return orderDto; 
        }

        public async Task<OrderDto> ChangeOrderStatusByCourier(int orderId,OrderStatus status, string userId)
        {
            var order = await GetOrderByIdAsync(orderId);
            order.Status = status;
            await _context.SaveChangesAsync();
            var orderDto = _mapper.Map<OrderDto>(order);
            return orderDto; 
        }

        public async Task<List<OrderDto>> GetAllOrdersByCourier(string courierId)
        {
            var orders = await _context.Orders.Where(o => o.CourierId == courierId).ToListAsync();
            var ordersDto = _mapper.Map<List<OrderDto>>(orders);
            return ordersDto;
        }
    }
}
