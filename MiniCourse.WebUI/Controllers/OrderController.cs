using Microsoft.AspNetCore.Mvc;
using MiniCourse.WebUI.Orders;

namespace MiniCourse.WebUI.Controllers
{
    public class OrderController(IOrderService orderService) : Controller
    {
        public IActionResult Index()
        {
            //burdayiz my orders tarafı yapılacak
            return View();
        }
    }
}
