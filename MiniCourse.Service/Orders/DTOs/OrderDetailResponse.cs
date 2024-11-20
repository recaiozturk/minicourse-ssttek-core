namespace MiniCourse.Service.Orders.DTOs
{
    public record OrderDetailResponse
    {
        public int CourseId { get; set; }
        public int Quantity { get; set; } 
        public decimal UnitPrice { get; set; } 
    }
}
