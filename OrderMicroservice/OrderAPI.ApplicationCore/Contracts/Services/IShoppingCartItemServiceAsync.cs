namespace OrderAPI.ApplicationCore.Contracts.Services
{
    public interface IShoppingCartItemServiceAsync
    {
        Task<int> DeleteAsync(int id);
    }
}
