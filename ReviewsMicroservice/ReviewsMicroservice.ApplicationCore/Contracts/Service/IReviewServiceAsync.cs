using ReviewsMicroservice.ApplicationCore.Models;

namespace ReviewsMicroservice.ApplicationCore.Contracts.Service
{
    public interface IReviewServiceAsync
    {
        Task<IEnumerable<ReviewResponseModel>> GetAllAsync();
        Task<int> InsertAsync(ReviewRequestModel review);
        Task<int> UpdateAsync(ReviewRequestModel review);
        Task<int> DeleteAsync(int id);
        Task<ReviewResponseModel?> GetByIdAsync(int id);
        Task<IEnumerable<ReviewResponseModel>> GetByUserIdAsync(string userId);
        Task<IEnumerable<ReviewResponseModel>> GetByProductIdAsync(string productId);
        Task<IEnumerable<ReviewResponseModel>> GetByYearAsync(int year);
        Task<int> ApproveReviewAsync(int id);
        Task<int> RejectReviewAsync(int id);
    }
}
