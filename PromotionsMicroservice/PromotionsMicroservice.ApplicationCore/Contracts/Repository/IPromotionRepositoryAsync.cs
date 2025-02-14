using PromotionsMicroservice.ApplicationCore.Entities;

namespace PromotionsMicroservice.ApplicationCore.Contracts.Repository
{
    public interface IPromotionRepositoryAsync : IRepositoryAsync<Promotion>
    {
        Task<IEnumerable<Promotion>> GetPromotionByProductNameAsync(string name);
        Task<IEnumerable<Promotion>> GetActivePromotionsAsync();
    }
}
