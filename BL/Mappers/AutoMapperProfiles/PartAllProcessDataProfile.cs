using AutoMapper;
using BL.DTOs;
using DAL.Models;

namespace BL.Mappers.AutoMapperProfiles
{
    public class PartAllProcessDataProfile : Profile
    {
        public PartAllProcessDataProfile()
        {
            CreateMap<PartAllProcessData, PartAllProcessDataDTO>();
        }
    }
}
