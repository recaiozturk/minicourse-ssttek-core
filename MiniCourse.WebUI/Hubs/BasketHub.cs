using Microsoft.AspNetCore.SignalR;

namespace MiniCourse.WebUI.Hubs
{
    public class BasketHub: Hub
    {
        // İstemcileri belirli bir metot ile güncelleyebilirsiniz
        public async Task UpdateBasketItemCount(string userId, int itemCount)
        {
            await Clients.User(userId).SendAsync("ReceiveBasketItemCount", itemCount);
        }
    }
}
