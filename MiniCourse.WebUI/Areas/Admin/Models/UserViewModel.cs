namespace MiniCourse.WebUI.Areas.Admin.Models
{
    public record UserViewModel
    {
        public string? Id { get; set; }
        public string? Name { get; set; }
        public string? Email { get; set; }
    }
}
