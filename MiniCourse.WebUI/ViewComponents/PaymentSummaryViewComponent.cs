using Microsoft.AspNetCore.Mvc;
using MiniCourse.WebUI.Baskets;
using MiniCourse.WebUI.Baskets.DTOs;
using MiniCourse.WebUI.Baskets.ViewModels;

namespace MiniCourse.WebUI.ViewComponents
{
    public class PaymentSummaryViewComponent(IBasketService basketService):ViewComponent
   
    {
        public async Task<IViewComponentResult> InvokeAsync(string userId)
        {

            var basketRequest = await basketService.GetBasketDetailAsync();

            var basketSummeryModal = new BasketDetailViewModel();

            if (basketRequest.AnyError)
                return View(basketSummeryModal);

            basketSummeryModal = basketRequest.Data;

            return View(basketSummeryModal);
        }
    }
}
