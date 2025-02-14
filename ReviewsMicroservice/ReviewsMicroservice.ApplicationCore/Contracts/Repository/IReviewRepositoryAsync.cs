using ReviewsMicroservice.ApplicationCore.Entities;

namespace ReviewsMicroservice.ApplicationCore.Contracts.Repository
{
    public interface IReviewRepositoryAsync
    {
        Task<IEnumerable<Review>> GetAllAsync();
        Task<int> InsertAsync(Review review);
        Task<int> UpdateAsync(Review review);
        Task<int> DeleteAsync(int id);
        Task<Review?> GetByIdAsync(int id);
        Task<IEnumerable<Review>> GetByUserIdAsync(string userId);
        Task<IEnumerable<Review>> GetByProductIdAsync(string productId);
        Task<IEnumerable<Review>> GetByYearAsync(int year);
        Task<int> ApproveReviewAsync(int id);
        Task<int> RejectReviewAsync(int id);

    }
}
