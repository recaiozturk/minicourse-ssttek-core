namespace MiniCourse.WebUI.Orders.DTOs
{
    public class OrderDetailResponse
    {
        public int CourseId { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
    }
}
