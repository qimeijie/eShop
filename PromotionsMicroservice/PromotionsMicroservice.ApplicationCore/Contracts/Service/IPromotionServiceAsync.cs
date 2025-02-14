using PromotionsMicroservice.ApplicationCore.Models;

namespace PromotionsMicroservice.ApplicationCore.Contracts.Service
{
    public interface IPromotionServiceAsync
    {
        Task<IEnumerable<PromotionResponseModel>> GetAllAsync();
        Task<PromotionResponseModel> GetByIdAsync(int id);
        Task<PromotionResponseModel> InsertAsync(PromotionRequestModel promotionRequestModel);
        Task<PromotionResponseModel> UpdateAsync(PromotionRequestModel promotionRequestModel);
        Task<int> DeleteAsync(int id);
        Task<IEnumerable<PromotionResponseModel>> GetPromotionByProductNameAsync(string productName);
        Task<IEnumerable<PromotionResponseModel>> GetActivePromotionsAsync();
    }
}
