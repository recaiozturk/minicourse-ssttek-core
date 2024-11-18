using Microsoft.AspNetCore.Identity;
using MiniCourse.Repository.Orders;

namespace MiniCourse.Repository.Users
{
    public class AppUser:IdentityUser<Guid>
    {
        public string? City { get; set; }
        public string? Adress { get; set; }
        public List<Order>? Orders { get; set; }
    }
}
