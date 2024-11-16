namespace MiniCourse.WebUI.Users.ViewModels
{
    public record UserViewModel
    {
        public string? Id { get; set; }
        public string? Name { get; set; }
        public string? Email { get; set; }
        public string? City { get; set; }
    }
}
