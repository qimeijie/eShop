using AutoMapper;
using ProductMicroservice.ApplicationCore.Entities;
using ProductMicroservice.ApplicationCore.Models;

namespace ProductMicroservice.Infrastructure
{
    public class ApplicationMapper : Profile
    {
        public ApplicationMapper()
        {
            CreateMap<Product, ProductRequestModel>().ReverseMap();
            CreateMap<Product, ProductResponseModel>().ReverseMap();
            CreateMap<CategoryVariation, CategoryVariationRequestModel>().ReverseMap();
            CreateMap<CategoryVariation, CategoryVariationResponseModel>().ReverseMap();
            CreateMap<ProductCategory, ProductCategoryRequestModel>().ReverseMap();
            CreateMap<ProductCategory, ProductCategoryResponseModel>().ReverseMap();
            CreateMap<ProductVariationValue, ProductVariationValueRequestModel>().ReverseMap();
            CreateMap<ProductVariationValue, ProductVariationValueResponseModel>().ReverseMap();
            CreateMap<VariationValue, VariationValueRequestModel>().ReverseMap();
            CreateMap<VariationValue, VariationValueResponseModel>().ReverseMap();
        }
    }
}
