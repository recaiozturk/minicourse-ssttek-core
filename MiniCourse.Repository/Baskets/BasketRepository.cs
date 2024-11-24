using Microsoft.EntityFrameworkCore;
using MiniCourse.Repository.Shared;

namespace MiniCourse.Repository.Baskets
{
    public class BasketRepository(AppDbContext context) : GenericRepository<Basket>(context), IBasketRepository
    {
        public async Task<Basket?> GetBasketByUserIdAsync(string userId)
        {
            return await context.Baskets
                .Include(b => b.Items) 
                .ThenInclude(bi => bi.Course)
                .FirstOrDefaultAsync(b => b.UserId == userId);
        }

        public async Task AddItemToBasketAsync(BasketItem basketItem)
        {
            await context.BasketItems.AddAsync(basketItem);
        }

        public async Task DeleteBasketAsync(int basketId)
        {
            var basket = await _context.Baskets
                .Include(b => b.Items)
                .FirstOrDefaultAsync(b => b.Id == basketId);

            if (basket == null)
                throw new InvalidOperationException("Sepet bulunamadı.");

            _context.BasketItems.RemoveRange(basket.Items);

            _context.Baskets.Remove(basket);
        }
    }
}
