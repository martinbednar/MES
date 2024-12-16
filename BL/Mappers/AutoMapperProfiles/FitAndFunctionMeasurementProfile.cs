using AutoMapper;
using BL.DTOs;
using DAL.Models;

namespace BL.Mappers.AutoMapperProfiles
{
    public class FitAndFunctionMeasurementProfile : Profile
    {
        public FitAndFunctionMeasurementProfile()
        {
            CreateMap<FitAndFunctionMeasurement, FitAndFunctionMeasurementDTO>();
        }
    }
}
