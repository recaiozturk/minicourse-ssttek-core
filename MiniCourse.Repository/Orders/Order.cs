using MiniCourse.Repository.Baskets;
using MiniCourse.Repository.OrderDetails;

namespace MiniCourse.Repository.Orders
{
    public class Order
    {
        public int Id { get; set; }
        public Guid UserId { get; set; } 
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
        public int OrderStatus { get; set; }
        public List<OrderDetail> OrderDetails { get; set; } = default!;
        public decimal TotalAmount { get; set; } 
        public int? BasketId { get; set; } 
        public Basket? Basket { get; set; } 
    }
}
