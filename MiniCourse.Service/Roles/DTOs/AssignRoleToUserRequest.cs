namespace MiniCourse.Service.Roles.DTOs
{
    public record AssignRoleToUserRequest
    {
        public string Id { get; set; } = null!;
        public string Name { get; set; } = null!;
        public bool Exist { get; set; }
    }
}
