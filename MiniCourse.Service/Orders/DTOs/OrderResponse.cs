namespace MiniCourse.Service.Orders.DTOs
{
    public record OrderResponse
    {
        public int OrderId { get; set; } 
        public decimal TotalPrice { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
        public int OrderStatus { get; set; }
        public string? OrderStatusStr { get; set; }
        public List<OrderDetailResponse> OrderDetails { get; set; }
    }
}