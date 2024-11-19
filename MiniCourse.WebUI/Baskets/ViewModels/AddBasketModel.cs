namespace MiniCourse.WebUI.Baskets.ViewModels
{
    public record AddBasketModel
    {
        public int  CourseId { get; set; }
        public int Quantity { get; set; }
        public string UserId { get; set; } = default!;
    }
}
