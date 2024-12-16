using AutoMapper;
using BL.DTOs;
using DAL.Models;

namespace BL.Mappers.AutoMapperProfiles
{
    public class PressingReworkProcessDataProfile : Profile
    {
        public PressingReworkProcessDataProfile()
        {
            CreateMap<PressingReworkProcessData, PressingReworkProcessDataDTO>();
        }
    }
}
