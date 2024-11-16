namespace MiniCourse.WebUI.Members.ViewModels
{
    public record MemberProfileUpdateViewModel
    {
        public string UserId { get; set; } = default!;
        public string UserName { get; set; } = default!;
        public string Email { get; set; } = default!;
        public string City { get; set; } = default!;
    }
}
