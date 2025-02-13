using ProductMicroservice.ApplicationCore.Entities;

namespace ProductMicroservice.ApplicationCore.Contracts.Repositories
{
    public interface ICategoryRepositoryAsync : IRepositoryAsync<ProductCategory>
    {
        Task<IEnumerable<ProductCategory>> GetCategoryByParentCategoryId(int parentCategoryId);
    }
}
