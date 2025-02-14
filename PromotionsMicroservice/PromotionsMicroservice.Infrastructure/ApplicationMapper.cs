using AutoMapper;
using PromotionsMicroservice.ApplicationCore.Entities;
using PromotionsMicroservice.ApplicationCore.Models;

namespace PromotionsMicroservice.Infrastructure
{
    public class ApplicationMapper : Profile
    {
        public ApplicationMapper()
        {
            CreateMap<Promotion, PromotionRequestModel>().ReverseMap();
            CreateMap<Promotion, PromotionResponseModel>().ReverseMap();
        }
    }
}
