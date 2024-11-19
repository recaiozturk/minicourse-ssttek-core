using MiniCourse.Repository.Courses;

namespace MiniCourse.Repository.Baskets
{
    public class BasketItem
    {
        public int Id { get; set; }
        public int BasketId { get; set; } 
        public Basket Basket { get; set; }
        public int CourseId { get; set; } 
        public Course Course { get; set; }
        public int Quantity { get; set; } 
        public decimal UnitPrice { get; set; } 
    }
}
