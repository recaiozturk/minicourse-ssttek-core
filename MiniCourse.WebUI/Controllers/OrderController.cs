using Azure;
using Microsoft.AspNetCore.Mvc;
using MiniCourse.WebUI.Orders;

namespace MiniCourse.WebUI.Controllers
{
    public class OrderController(IOrderService orderService) : Controller
    {
        public async Task<IActionResult> Index()
        {
            var response = await orderService.GetOrdersByUserIdAsync();

            if (response.AnyError)
            {
                foreach (var error in response.Errors!)
                {
                    ModelState.AddModelError(string.Empty, error);
                    return View();
                }
            }
            return View(response.Data);
        }

        public IActionResult Success()
        {
            return View();
        }


    }
}
