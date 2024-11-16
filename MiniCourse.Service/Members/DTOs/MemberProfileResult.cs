
namespace MiniCourse.Service.Members.DTOs
{
    public record MemberProfileResult
    {
        public string UserName { get; set; } = default!;
        public string Email { get; set; } = default!;
        public string City { get; set; } = default!;
    }
}
