namespace MiniCourse.Service.Roles.DTOs
{
    public record UpdateRoleRequest
    {
        public string Id { get; set; } = null!;
        public string Name { get; set; } = null!;
    }
}
