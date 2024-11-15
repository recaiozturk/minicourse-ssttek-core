namespace MiniCourse.Service.Auths.DTOs
{
    public record SignUpRequest
    {
        public string UserName { get; set; } = default!;
        public string Password { get; set; } = default!;
        public string RePassword { get; set; } = default!;
        public string Email { get; set; } = default!;
        public string City { get; set; } = default!;
    }
}
