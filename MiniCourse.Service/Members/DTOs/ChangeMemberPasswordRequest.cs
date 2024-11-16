namespace MiniCourse.Service.Members.DTOs
{
    public class ChangeMemberPasswordRequest
    {
        public string UserId { get; set; } = default!;
        public string OldPassword { get; set; } = default!;
        public string Password { get; set; } = default!;
        public string RePassword { get; set; } = default!;
    }
}
