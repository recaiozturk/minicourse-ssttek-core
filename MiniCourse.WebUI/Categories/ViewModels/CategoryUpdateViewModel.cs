namespace MiniCourse.WebUI.Categories.ViewModels
{
    public record CategoryUpdateViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; } = default!;
    }
}
