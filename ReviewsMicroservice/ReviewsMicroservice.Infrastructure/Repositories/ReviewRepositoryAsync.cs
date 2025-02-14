using Microsoft.EntityFrameworkCore;
using ReviewsMicroservice.ApplicationCore.Contracts.Repository;
using ReviewsMicroservice.ApplicationCore.Entities;
using ReviewsMicroservice.Infrastructure.Data;

namespace ReviewsMicroservice.Infrastructure.Repositories
{
    public class ReviewRepositoryAsync : IReviewRepositoryAsync
    {
        private readonly ReviewDbContext reviewDbContext;

        public ReviewRepositoryAsync(ReviewDbContext reviewDbContext)
        {
            this.reviewDbContext = reviewDbContext;
        }
        public async Task<int> ApproveReviewAsync(int id)
        {
            var review = await reviewDbContext.Reviews.FindAsync(id);
            if (review == null)
                return await Task.FromResult(0);
            review.ReviewState = ReviewState.Approved;
            return await UpdateAsync(review);
        }

        public async Task<int> DeleteAsync(int id)
        {
            var review = await reviewDbContext.Reviews.FindAsync(id);
            if (review != null)
            {
                reviewDbContext.Reviews.Remove(review); 
            }
            return await reviewDbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<Review>> GetAllAsync()
        {
            return await reviewDbContext.Reviews.AsNoTracking().ToListAsync();
        }

        public async Task<Review?> GetByIdAsync(int id)
        {
            return await reviewDbContext.Reviews.FindAsync(id);
        }

        public async Task<IEnumerable<Review>> GetByProductIdAsync(string productId)
        {
            return await reviewDbContext.Reviews.AsNoTracking().Where(r => r.ProductId == productId).ToListAsync();
        }

        public async Task<IEnumerable<Review>> GetByUserIdAsync(string userId)
        {
            return await reviewDbContext.Reviews.AsNoTracking().Where(r => r.CustomerId == userId).ToListAsync();
        }

        public async Task<IEnumerable<Review>> GetByYearAsync(int year)
        {
            return await reviewDbContext.Reviews.AsNoTracking().Where(r => r.ReviewDate.Year == year).ToListAsync();
        }

        public async Task<int> InsertAsync(Review review)
        {
            await reviewDbContext.Reviews.AddAsync(review);
            return await reviewDbContext.SaveChangesAsync();
        }

        public async Task<int> RejectReviewAsync(int id)
        {
            var review = await reviewDbContext.Reviews.FindAsync(id);
            if (review == null)
                return await Task.FromResult(0);
            review.ReviewState = ReviewState.Rejected;
            return await UpdateAsync(review);
        }

        public async Task<int> UpdateAsync(Review review)
        {
            reviewDbContext.Entry(review).State = EntityState.Modified;
            return await reviewDbContext.SaveChangesAsync();
        }
    }
}
