using MiniCourse.Repository.Baskets;

namespace MiniCourse.WebUI.Baskets.DTOs
{
    public record BasketResponse
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public List<BasketItem> Items { get; set; } = new();
    }
}
