using AutoMapper;
using BL.DTOs;
using DAL.Models;

namespace BL.Mappers.AutoMapperProfiles
{
    public class FitAndFunctionProcessDataProfile : Profile
    {
        public FitAndFunctionProcessDataProfile()
        {
            CreateMap<FitAndFunctionProcessData, FitAndFunctionProcessDataDTO>();
        }
    }
}
