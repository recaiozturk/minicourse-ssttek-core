namespace MiniCourse.WebUI.Baskets.ViewModels
{
    public record BasketDetailViewModel
    {
        public List<BasketItemViewModel> Items { get; set; } = new List<BasketItemViewModel>();
        public decimal TotalPrice { get; set; }
    }
}
