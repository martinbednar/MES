using AutoMapper;
using BL.DTOs;
using DAL.Models;

namespace BL.Mappers.AutoMapperProfiles
{
    public class ScanProcessDataProfile : Profile
    {
        public ScanProcessDataProfile()
        {
            CreateMap<ScanProcessData, ScanProcessDataDTO>();
        }
    }
}
