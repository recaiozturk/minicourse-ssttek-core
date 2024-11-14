using Microsoft.AspNetCore.Mvc;

namespace MiniCourse.WebUI.Controllers
{
    public class PaymentController : Controller
    {
        public IActionResult PaymentPage()
        {
            return View();
        }
    }
}
