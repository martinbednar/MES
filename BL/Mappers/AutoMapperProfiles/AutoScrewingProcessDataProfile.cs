using AutoMapper;
using BL.DTOs;
using DAL.Models;

namespace BL.Mappers.AutoMapperProfiles
{
    public class AutoScrewingProcessDataProfile : Profile
    {
        public AutoScrewingProcessDataProfile()
        {
            CreateMap<AutoScrewingProcessData, AutoScrewingProcessDataDTO>();
        }
    }
}
