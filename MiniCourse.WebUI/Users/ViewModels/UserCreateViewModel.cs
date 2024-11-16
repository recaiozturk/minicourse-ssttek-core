namespace MiniCourse.WebUI.Users.ViewModels
{
    public record UserCreateViewModel
    {
        public string UserName { get; set; } = default!;
        public string Email { get; set; } = default!;
        public string Password { get; set; } = default!;
        public string City { get; set; } = default!;
    }
}
