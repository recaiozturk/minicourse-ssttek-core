namespace MiniCourse.Service.Baskets.DTOs
{
    public record BasketDetailResponse
    {
        public List<BasketItemResponse> Items { get; set; } = new List<BasketItemResponse>();
        public decimal TotalPrice { get; set; }
    }
}
