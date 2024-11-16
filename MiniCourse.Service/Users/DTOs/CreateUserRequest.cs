namespace MiniCourse.Service.Users.DTOs
{
    public record CreateUserRequest(string UserName, string Email, string Password, string City);
}
