namespace MiniCourse.WebUI.Users.DTOs
{
    public record UserResponse
    {
        public string? Id { get; set; }
        public string? Name { get; set; }
        public string? Email { get; set; }
    }
}
