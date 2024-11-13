namespace MiniCourse.WebUI.ViewModels
{
    public record ChangePasswordViewModel
    {
        public string OldPassword { get; set; } = default!;
        public string Password { get; set; } = default!;
        public string RePassword { get; set; } = default!;
    }
}
