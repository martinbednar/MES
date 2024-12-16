using AutoMapper;
using BL.DTOs;
using DAL.Models;

namespace BL.Mappers.AutoMapperProfiles
{
    public class PressingProcessDataProfile : Profile
    {
        public PressingProcessDataProfile()
        {
            CreateMap<PressingProcessData, PressingProcessDataDTO>();
        }
    }
}
