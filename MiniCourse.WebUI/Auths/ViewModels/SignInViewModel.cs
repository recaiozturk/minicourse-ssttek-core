namespace MiniCourse.WebUI.Auths.ViewModels
{
    public record SignInViewModel
    {
        public string Email { get; set; } = default!;
        public string Password { get; set; } = default!;
        public bool RememberMe { get; set; }
    }
}
