namespace MiniCourse.Service.Baskets.DTOs
{
    public record BasketItemResponse
    {
        public int CourseId { get; set; }
        public string CourseName { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal TotalPrice => Quantity * UnitPrice;
    }
}
