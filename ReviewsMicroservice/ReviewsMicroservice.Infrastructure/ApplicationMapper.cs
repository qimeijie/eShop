using AutoMapper;
using ReviewsMicroservice.ApplicationCore.Entities;
using ReviewsMicroservice.ApplicationCore.Models;

namespace ReviewsMicroservice.Infrastructure
{
    public class ApplicationMapper : Profile
    {
        public ApplicationMapper()
        {
            CreateMap<Review, ReviewRequestModel>().ReverseMap();
            CreateMap<Review, ReviewResponseModel>().ReverseMap();
        }
    }
}
