namespace MiniCourse.WebUI.Users.DTOs
{
    public record UserCreateResponse
    {
        public Guid UserId { get; set; }
        public string? UserName { get; set; }
    }
}
