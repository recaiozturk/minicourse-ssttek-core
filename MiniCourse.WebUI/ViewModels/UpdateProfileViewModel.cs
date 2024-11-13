namespace MiniCourse.WebUI.ViewModels
{
    public record UpdateProfileViewModel
    {
        public string UserName { get; set; } = default!;
        public string Email { get; set; } = default!;
        public string City { get; set; } = default!;
    }
}
