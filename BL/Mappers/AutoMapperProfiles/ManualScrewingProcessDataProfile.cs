using AutoMapper;
using BL.DTOs;
using DAL.Models;

namespace BL.Mappers.AutoMapperProfiles
{
    public class ManualScrewingProcessDataProfile : Profile
    {
        public ManualScrewingProcessDataProfile()
        {
            CreateMap<ManualScrewingProcessData, ManualScrewingProcessDataDTO>();
        }
    }
}
