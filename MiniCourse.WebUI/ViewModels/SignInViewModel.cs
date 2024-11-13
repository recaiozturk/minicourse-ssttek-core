namespace MiniCourse.WebUI.ViewModels
{
    public record SignInViewModel
    {
        public string Email { get; set; } = default!;
        public string Password { get; set; } = default!;
    }
}
