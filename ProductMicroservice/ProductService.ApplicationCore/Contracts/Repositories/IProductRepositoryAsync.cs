using ProductMicroservice.ApplicationCore.Entities;

namespace ProductMicroservice.ApplicationCore.Contracts.Repositories
{
    public interface IProductRepositoryAsync : IRepositoryAsync<Product>
    {
        Task<IEnumerable<Product>> GetListProducts(int pageId, int pageSize, int? categoryId);
        Task<IEnumerable<Product>> GetProductByCategoryId(int categoryId);
        Task<IEnumerable<Product>> GetProductByProductName(string productName);
    }
}
