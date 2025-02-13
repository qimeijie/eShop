using ProductMicroservice.ApplicationCore.Entities;

namespace ProductMicroservice.ApplicationCore.Contracts.Repositories
{
    public interface ICategoryVariationRepositoryAsync : IRepositoryAsync<CategoryVariation>
    {
        Task<IEnumerable<CategoryVariation>> GetCategoryVariationByCategoryId(int categoryId);
    }
}
