namespace MiniCourse.WebUI.Users.ViewModels
{
    public record UserUpdateViewModel
    {
        public string UserName { get; set; } = default!;
        public string Email { get; set; } = default!;
        public string City { get; set; } = default!;

        public string UserID { get; set; } = default!;
    }
}
