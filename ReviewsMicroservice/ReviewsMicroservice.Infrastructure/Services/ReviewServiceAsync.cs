using AutoMapper;
using ReviewsMicroservice.ApplicationCore.Contracts.Repository;
using ReviewsMicroservice.ApplicationCore.Contracts.Service;
using ReviewsMicroservice.ApplicationCore.Entities;
using ReviewsMicroservice.ApplicationCore.Models;

namespace ReviewsMicroservice.Infrastructure.Services
{
    public class ReviewServiceAsync : IReviewServiceAsync
    {
        private readonly IMapper mapper;
        private readonly IReviewRepositoryAsync reviewRepositoryAsync;

        public ReviewServiceAsync(IMapper mapper, IReviewRepositoryAsync reviewRepositoryAsync)
        {
            this.mapper = mapper;
            this.reviewRepositoryAsync = reviewRepositoryAsync;
        }
        public Task<int> ApproveReviewAsync(int id)
        {
            return reviewRepositoryAsync.ApproveReviewAsync(id);
        }

        public Task<int> DeleteAsync(int id)
        {
            return reviewRepositoryAsync.DeleteAsync(id);
        }

        public async Task<IEnumerable<ReviewResponseModel>> GetAllAsync()
        {
            return mapper.Map<IEnumerable<ReviewResponseModel>>(await reviewRepositoryAsync.GetAllAsync());
        }

        public async Task<ReviewResponseModel?> GetByIdAsync(int id)
        {
            return mapper.Map<ReviewResponseModel>(await reviewRepositoryAsync.GetByIdAsync(id));
        }

        public async Task<IEnumerable<ReviewResponseModel>> GetByProductIdAsync(string productId)
        {
            return mapper.Map<IEnumerable<ReviewResponseModel>>(await reviewRepositoryAsync.GetByProductIdAsync(productId));
        }

        public async Task<IEnumerable<ReviewResponseModel>> GetByUserIdAsync(string userId)
        {
            return mapper.Map<IEnumerable<ReviewResponseModel>>(await reviewRepositoryAsync.GetByUserIdAsync(userId));
        }

        public async Task<IEnumerable<ReviewResponseModel>> GetByYearAsync(int year)
        {
            return mapper.Map<IEnumerable<ReviewResponseModel>>(await reviewRepositoryAsync.GetByYearAsync(year));
        }

        public Task<int> InsertAsync(ReviewRequestModel review)
        {
            return reviewRepositoryAsync.InsertAsync(mapper.Map<Review>(review));
        }

        public Task<int> RejectReviewAsync(int id)
        {
            return reviewRepositoryAsync.RejectReviewAsync(id);
        }

        public Task<int> UpdateAsync(ReviewRequestModel review)
        {
            return reviewRepositoryAsync.UpdateAsync(mapper.Map<Review>(review));
        }
    }
}
