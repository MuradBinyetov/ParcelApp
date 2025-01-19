using OrderService.Dtos;
using OrderService.Models;

namespace OrderService.Services.Abstract
{
    public interface IOrderService
    { 
        public Task<OrderDto> CreateOrderAsync(OrderDto dto);
        public Task<OrderDto> UpdateOrderDestination(int  id, string destination);
        public Task<OrderDto> GetOrderByIdAsync(int id);
        public Task CancelParcel(int id);
        public Task<List<OrderDto>> GetAllOrdersByUser(string userId);
        public Task<List<OrderDto>> GetAllOrdersByCourierId(string courierId);
        public Task<OrderDto> UpdateOrderStatus(int id, OrderStatus status);
        public Task<List<OrderDto>> GetAllOrdersAsync();
        public Task<OrderDto> AssignOrderToCourier(int id, string courierId);
        public Task<OrderDto> ChangeOrderStatusByCourier(int orderId, OrderStatus status, string userId);
        public Task<List<OrderDto>> GetAllOrdersByCourier(string courierId);
        //catdirilmani izlemek methodu 
        //kuryerlerin siyahisini izlemek


    }
}
