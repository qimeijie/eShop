using AutoMapper;
using OrderAPI.ApplicationCore.Entities;
using OrderAPI.ApplicationCore.Models;

namespace OrderAPI.Infrastructure
{
    public class ApplicationMapper : Profile
    {
        public ApplicationMapper()
        {
            CreateMap<Address, CustomerAddressRequestModel>().ReverseMap();
            CreateMap<UserAddress, CustomerAddressRequestModel>().ReverseMap();
            CreateMap<Address, AddressResponseModel>().ReverseMap();
            CreateMap<UserAddress, UserAddressResponseModel>().ReverseMap();
            CreateMap<Customer, CustomerAddressResponseModel>().ReverseMap();

            CreateMap<OrderDetail, OrderDetailResponseModel>().ReverseMap();
            CreateMap<Order, OrderRequestModel>().ReverseMap();
            CreateMap<Order, OrderResponseModel>().ReverseMap();
            
            CreateMap<PaymentType, PaymentTypeResponseModel>().ReverseMap();
            CreateMap<PaymentMethod, PaymentResponseModel>().ReverseMap();

            CreateMap<ShoppingCartItem, ShoppingCartItemResponseModel>().ReverseMap();
            CreateMap<ShoppingCart, ShoppingCartRequestModel>().ReverseMap();
            CreateMap<ShoppingCart, ShoppingCartResponseModel>().ReverseMap();
           

        }
    }
}
