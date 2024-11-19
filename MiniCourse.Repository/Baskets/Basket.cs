using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniCourse.Repository.Baskets
{
    public class Basket
    {
        public int Id { get; set; } 
        public string UserId { get; set; } 
        public List<BasketItem> Items { get; set; } = new();
        public DateTime CreatedDate { get; set; } = DateTime.Now; 
    }
}
