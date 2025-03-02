using AuthenticationMicroservice.ApplicationCore.Entities;
using AuthenticationMicroservice.ApplicationCore.Models;
using AutoMapper;
using System.Linq;

namespace AuthenticationMicroservice.Infrastucture
{
    public class ApplicationMapper : Profile
    {
        public ApplicationMapper()
        {
            CreateMap<Role, RoleHttpResponse>().ReverseMap();
            CreateMap<User, UserHttpRequest>().ReverseMap();
            CreateMap<User, UserHttpResponse>().ForMember(
                    dest => dest.Roles,
                    opt => opt.MapFrom(src => src.UserRoles.Select(ur => ur.Role))
                ).ReverseMap();
        }
    }
}
