using Microsoft.AspNetCore.Mvc;
using MiniCourse.WebUI.Baskets;

namespace MiniCourse.WebUI.ViewComponents
{
    public class BasketCountViewComponent(IBasketService basketService): ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync(string userId)
        {

            var basketRequest = await basketService.GetBasketByUserIdAsync();

            int basketCount = 0;

            if(basketRequest.AnyError)
                return View(basketCount);
            basketCount = basketRequest.Data.Items.Count();

            // Sayıyı View ile dön
            return View(basketCount);
        }
    }
}
