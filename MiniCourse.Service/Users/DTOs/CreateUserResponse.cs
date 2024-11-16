namespace MiniCourse.Service.Users.DTOs
{
    public record CreateUserResponse
    {
        public Guid UserId { get; set; }
        public string? UserName { get; set; }
    }
}
