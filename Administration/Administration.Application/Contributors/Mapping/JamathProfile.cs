using Administration.Application.Jamaths.DTOs;
using Administration.Domain.Entities;
using AutoMapper;

namespace Administration.Application.Contributors.Mapping
{
    public class JamathProfile : Profile
    {
        public JamathProfile()
        {
            CreateMap<Jamathperiod, JamathDto>();
            CreateMap<JamathDto, Jamathperiod>();
        }
    }
}
