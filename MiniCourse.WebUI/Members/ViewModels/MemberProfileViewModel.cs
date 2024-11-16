namespace MiniCourse.WebUI.Members.ViewModels
{
    public record MemberProfileViewModel
    {
        public string UserName { get; set; } = default!;
        public string Email { get; set; } = default!;
        public string City { get; set; } = default!;
    }
}
