using Microsoft.AspNetCore.Mvc;
using MiniCourse.WebUI.Baskets;

namespace MiniCourse.WebUI.ViewComponents
{
    public class BasketCountViewComponent(IBasketService basketService): ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync(string userId)
        {

            // Kullanıcıya ait sepeti al
            var basketRequest = await basketService.GetBasketByUserIdAsync();

            int basketCount = 0;

            if(basketRequest.AnyError)
                return View(basketCount);

            // Sepetteki toplam ürün sayısını hesapla
            /*basketCount = basketRequest.Data?.Items.Sum(item => item.Quantity) ?? 0*/;
            basketCount = basketRequest.Data.Items.Count();

            // Sayıyı View ile dön
            return View(basketCount);
        }
    }
}
