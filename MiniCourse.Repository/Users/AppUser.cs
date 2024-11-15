using Microsoft.AspNetCore.Identity;

namespace MiniCourse.Repository.Users
{
    public class AppUser:IdentityUser<Guid>
    {
        public string? City { get; set; }
        public string? Adress { get; set; }
    }
}
