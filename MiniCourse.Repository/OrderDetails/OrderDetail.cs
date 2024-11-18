using MiniCourse.Repository.Courses;
using MiniCourse.Repository.Orders;

namespace MiniCourse.Repository.OrderDetails
{
    public class OrderDetail
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public int CourseId { get; set; }
        public int Quantity { get; set; }
        public decimal TotalPrice { get; set; }

        public Order? Order { get; set; }
        public Course? Course { get; set; }
    }
}
