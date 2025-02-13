using AutoMapper;
using OrderAPI.ApplicationCore.Contracts.Repositories;
using OrderAPI.ApplicationCore.Contracts.Services;
using OrderAPI.ApplicationCore.Entities;
using OrderAPI.ApplicationCore.Models;

namespace OrderAPI.Infrastructure.Services
{
    public class CustomerServiceAsync : ICustomerServiceAsync
    {
        private readonly IMapper mapper;
        private readonly ICustomerRepositoryAsync customerRepositoryAsync;
        private readonly IAddressRepositoryAsync addressRepositoryAsync;
        private readonly IUserAddressRepositoryAsync userAddressRepositoryAsync;

        public CustomerServiceAsync(IMapper mapper, ICustomerRepositoryAsync customerRepositoryAsync, IAddressRepositoryAsync addressRepositoryAsync, IUserAddressRepositoryAsync userAddressRepositoryAsync)
        {
            this.mapper = mapper;
            this.customerRepositoryAsync = customerRepositoryAsync;
            this.addressRepositoryAsync = addressRepositoryAsync;
            this.userAddressRepositoryAsync = userAddressRepositoryAsync;
        }
        public async Task<IEnumerable<CustomerAddressResponseModel>> GetCustomerAddressByUserIdAsync(int userId)
        {
            var customer = await customerRepositoryAsync.GetCustomerAddressByUserIdAsync(userId);
            return mapper.Map<IEnumerable<CustomerAddressResponseModel>>(customer);
        }

        public async Task<UserAddressResponseModel> SaveCustomerAddressAsync(CustomerAddressRequestModel customerAddressRequestModel)
        {
            var address = mapper.Map<Address>(customerAddressRequestModel);
            var addressId = (await addressRepositoryAsync.InsertAsync(address)).Id;
            var userAddress = new UserAddress()
            {
                AddressId = addressId,
                CustomerId = customerAddressRequestModel.CustomerId,
                IsDefaultAddress = customerAddressRequestModel.IsDefaultAddress
            };
            return mapper.Map<UserAddressResponseModel>(await userAddressRepositoryAsync.InsertAsync(userAddress));  
        }
    }
}
