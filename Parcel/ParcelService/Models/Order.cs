using OrderService.Dtos;

namespace OrderService.Models
{
    public class Order
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string UserId { get; set; }
        public string? CourierId { get; set; }
        public string Destination { get; set; }
        public OrderStatus Status { get; set; }
        public DateTime CreateDate { get; set; }
        public bool IsDeleted { get; set; }
    }
}
