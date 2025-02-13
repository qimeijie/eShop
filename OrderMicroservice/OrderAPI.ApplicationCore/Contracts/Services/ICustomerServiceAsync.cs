using OrderAPI.ApplicationCore.Entities;
using OrderAPI.ApplicationCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderAPI.ApplicationCore.Contracts.Services
{
    public interface ICustomerServiceAsync
    {
        Task<IEnumerable<CustomerAddressResponseModel>> GetCustomerAddressByUserIdAsync(int userId);
        Task<UserAddressResponseModel> SaveCustomerAddressAsync(CustomerAddressRequestModel customerAddressRequestModel);
    }
}
