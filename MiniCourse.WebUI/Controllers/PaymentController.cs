using Azure;
using Microsoft.AspNetCore.Mvc;
using MiniCourse.WebUI.Orders;
using MiniCourse.WebUI.Payments;
using MiniCourse.WebUI.Payments.ViewModels;

namespace MiniCourse.WebUI.Controllers
{
    public class PaymentController(IOrderService orderService,IPaymentService paymentService) : Controller
    {
        public async Task<IActionResult> PaymentPage()
        {
            var result = await orderService.CreateOrderAsync();

            if (result.AnyError)
                return RedirectToAction(nameof(Index), "Basket");

            //burda payment sayfasıan baska model de gidebilir
            ViewBag.OrderId = result.Data.OrderId;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> PaymentPage(PaymentViewModel model)
        {
            var response = await paymentService.ProcessPaymentAsync(model);

            if (response.AnyError)
            {
                foreach (var error in response.Errors!)
                {
                    ModelState.AddModelError(string.Empty, error);
                }

                return View(model);
            }



            //burda payment sayfasıan baska model de gidebilir

            //siparis basarili sayfasina gitsin
            return RedirectToAction("Success", "Order");
        }
    }
}
