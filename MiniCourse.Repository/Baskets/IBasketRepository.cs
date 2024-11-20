using MiniCourse.Repository.Shared;

namespace MiniCourse.Repository.Baskets
{
    public interface IBasketRepository : IGenericRepository<Basket>
    {
        Task<Basket?> GetBasketByUserIdAsync(string userId);
        Task AddItemToBasketAsync(BasketItem basketItem);
        Task DeleteBasketAsync(int basketId);
    }
}
