

namespace MiniCourse.Service.Baskets.DTOs
{
    public record AddBasketRequest
    {
        public int CourseId { get; set; }
        public int Quantity { get; set; }
        public string UserId { get; set; } = default!;
    }
}
