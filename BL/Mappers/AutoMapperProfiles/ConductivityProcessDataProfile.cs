using AutoMapper;
using BL.DTOs;
using DAL.Models;

namespace BL.Mappers.AutoMapperProfiles
{
    public class ConductivityProcessDataProfile : Profile
    {
        public ConductivityProcessDataProfile()
        {
            CreateMap<ConductivityProcessData, ConductivityProcessDataDTO>();
        }
    }
}
