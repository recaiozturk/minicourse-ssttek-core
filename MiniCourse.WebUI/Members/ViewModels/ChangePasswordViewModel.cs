namespace MiniCourse.WebUI.Members.ViewModels
{
    public record ChangePasswordViewModel
    {
        public string UserId { get; set; } = default!;
        public string OldPassword { get; set; } = default!;
        public string Password { get; set; } = default!;
        public string RePassword { get; set; } = default!;
    }
}
