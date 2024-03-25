using API.Models;
using AutoMapper;
using Domain.Models;

namespace APITests.Mappers.Configurations
{
    public class LoginMapperConfigurations : Profile
    {
        public LoginMapperConfigurations()
        {
            CreateMap<UserInfoResponse, UserInfoModel>();
        }
    }
}
