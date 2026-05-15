using AutoMapper;
using IdentityService.DTOs.Request;
using IdentityService.Models;

namespace ActivityService.Automapper
{
    public class IdentityMapper : Profile
    {
        public IdentityMapper() {
             
            CreateMap<RegistrationRequest, User>();
        }
    }
}
