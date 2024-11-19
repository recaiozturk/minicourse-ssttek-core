using Microsoft.EntityFrameworkCore;
using MiniCourse.Repository.Shared;

namespace MiniCourse.Repository.Baskets
{
    public class BasketRepository(AppDbContext context) : GenericRepository<Basket>(context), IBasketRepository
    {
        public async Task<Basket?> GetBasketByUserIdAsync(string userId)
        {
            return await context.Baskets
                .Include(b => b.Items) // BasketItem'ları dahil ediyoruz
                .ThenInclude(bi => bi.Course) // Course bilgilerini de yüklüyoruz
                .FirstOrDefaultAsync(b => b.UserId == userId);
        }

        public async Task AddItemToBasketAsync(BasketItem basketItem)
        {
            await context.BasketItems.AddAsync(basketItem);
        }
    }
}
