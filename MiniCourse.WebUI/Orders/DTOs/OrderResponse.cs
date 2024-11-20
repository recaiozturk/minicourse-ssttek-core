namespace MiniCourse.WebUI.Orders.DTOs
{
    public class OrderResponse
    {
        public int OrderId { get; set; }
        public decimal TotalPrice { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
        public int OrderStatus { get; set; }
        public List<OrderDetailResponse> OrderDetails { get; set; }
    }
}
