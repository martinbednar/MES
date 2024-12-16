using AutoMapper;
using BL.DTOs;
using DAL.Models;

namespace BL.Mappers.AutoMapperProfiles
{
    public class NgAutoScrewingProcessDataProfile : Profile
    {
        public NgAutoScrewingProcessDataProfile()
        {
            CreateMap<NgAutoScrewingProcessData, NgAutoScrewingProcessDataDTO>();
        }
    }
}
