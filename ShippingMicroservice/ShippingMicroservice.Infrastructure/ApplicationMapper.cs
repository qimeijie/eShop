using AutoMapper;
using ShippingMicroservice.ApplicationCore.Entities;
using ShippingMicroservice.ApplicationCore.Models;

namespace ShippingMicroservice.Infrastructure
{
    public class ApplicationMapper : Profile
    {
        public ApplicationMapper()
        {
            CreateMap<Region, RegionResponseModel>().ReverseMap();
            CreateMap<ShipperRegion, ShipperRegionResponseModel>().ReverseMap();
            CreateMap<Shipper, ShipperResponseModel>().ReverseMap();
            CreateMap<Shipper, ShipperRequestModel>().ReverseMap();
        }
    }
}
