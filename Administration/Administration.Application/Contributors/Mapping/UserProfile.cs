using Administration.Application.Contributors.DTOs;
using Administration.Domain.DTOs;
using Administration.Domain.Entities;
using AutoMapper;

namespace Administration.Application.Contributors.Mapping
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<UserCreateRequestDto, User>()
                .ForMember(dest => dest.FatherId, opt => opt.MapFrom(src =>
                string.IsNullOrEmpty(src.FatherId) ? (Guid?)null : Guid.Parse(src.FatherId)));

            CreateMap<User, UserResponseDto>()
            .ForMember(dest => dest.Age, opt => opt.MapFrom(src =>
                src.Dob.HasValue
                    ? DateTime.Now.Year - src.Dob.Value.Year
                      - (DateTime.Now < src.Dob.Value.AddYears(DateTime.Now.Year - src.Dob.Value.Year) ? 1 : 0)
                    : 0
            ));
        }
    }

}
