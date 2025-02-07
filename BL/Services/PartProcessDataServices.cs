using AutoMapper;
using BL.DTOs;
using DAL.Data;
using DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace BL.Services
{
    public class PartProcessDataServices
    {
        private readonly IMapper _mapper;

        MyDbContext dbContext = new MyDbContext();

        public PartProcessDataServices(IMapper mapper)
        {
            _mapper = mapper;
        }

        public async Task<PartsProcessDataDTO> GetPartsProcessData(int pageNumber, int pageSize, DateTime? startedFrom, DateTime? startedTo, bool orderDescBySerialNumber = true)
        {
            if (startedFrom == null)
            {
                startedFrom = DateTime.MinValue;
            }
            if (startedTo == null)
            {
                startedTo = DateTime.MaxValue;
            }

            IQueryable<PartAllProcessData> partsAllProcessDataQueryable = dbContext.PartAllProcessData
                .Include(p => p.AutoScrewingProcessData)
                .Include(p => p.ConductivityProcessData)
                .Include(p => p.FitAndFunctionProcessData)
                    .ThenInclude(ff => ff.Measurements)
                .Include(p => p.ManualScrewingProcessData)
                .Include(p => p.NgAutoScrewingProcessData)
                .Include(p => p.PressingProcessData)
                .Include(p => p.PressingReworkProcessData)
                .Include(p => p.ScanProcessData)
                .Where(p =>
                    p.AutoScrewingProcessData.Any(pd => pd.DateTimeStarted >= startedFrom) ||
                    p.ConductivityProcessData.Any(pd => pd.DateTimeStarted >= startedFrom) ||
                    p.FitAndFunctionProcessData.Any(pd => pd.DateTimeStarted >= startedFrom) ||
                    p.ManualScrewingProcessData.Any(pd => pd.DateTimeStarted >= startedFrom) ||
                    p.NgAutoScrewingProcessData.Any(pd => pd.DateTime >= startedFrom) ||
                    p.PressingProcessData.Any(pd => pd.DateTimeStarted >= startedFrom) ||
                    p.PressingReworkProcessData.Any(pd => pd.DateTime >= startedFrom) ||
                    p.ScanProcessData.Any(pd => pd.DateTime >= startedFrom)
                )
                .Where(p =>
                    p.AutoScrewingProcessData.Any(pd => pd.DateTimeStarted <= startedTo) ||
                    p.ConductivityProcessData.Any(pd => pd.DateTimeStarted <= startedTo) ||
                    p.FitAndFunctionProcessData.Any(pd => pd.DateTimeStarted <= startedTo) ||
                    p.ManualScrewingProcessData.Any(pd => pd.DateTimeStarted <= startedTo) ||
                    p.NgAutoScrewingProcessData.Any(pd => pd.DateTime <= startedTo) ||
                    p.PressingProcessData.Any(pd => pd.DateTimeStarted <= startedTo) ||
                    p.PressingReworkProcessData.Any(pd => pd.DateTime >= startedFrom) ||
                    p.ScanProcessData.Any(pd => pd.DateTime <= startedTo)
                );

            if (orderDescBySerialNumber)
            {
                partsAllProcessDataQueryable = partsAllProcessDataQueryable.OrderByDescending(p => p.SerialNumber);
            }
            else
            {
                partsAllProcessDataQueryable = partsAllProcessDataQueryable.OrderBy(p => p.SerialNumber);
            }

            List<PartAllProcessData> partsAllProcessData = await partsAllProcessDataQueryable
                .Skip((pageNumber - 1) * pageSize).Take(pageSize)
                .ToListAsync();

            return new PartsProcessDataDTO()
            {
                PartsCount = partsAllProcessDataQueryable.Count(),
                PartsProcessData = _mapper.Map<List<PartAllProcessDataDTO>>(partsAllProcessData)
            };
        }

        public async Task<PartAllProcessDataDTO?> GetPartProcessData(string partId)
        {
            IQueryable<PartAllProcessData> partAllProcessDataQueryable = dbContext.PartAllProcessData
                .Include(p => p.AutoScrewingProcessData)
                .Include(p => p.ConductivityProcessData)
                .Include(p => p.FitAndFunctionProcessData)
                    .ThenInclude(ff => ff.Measurements)
                .Include(p => p.ManualScrewingProcessData)
                .Include(p => p.NgAutoScrewingProcessData)
                .Include(p => p.PressingProcessData)
                .Include(p => p.PressingReworkProcessData)
                .Include(p => p.ScanProcessData);


            PartAllProcessData? partAllProcessData = await partAllProcessDataQueryable
                .FirstOrDefaultAsync(p => p.Id.ToString() == partId);

            if (partAllProcessData == null)
            {
                partAllProcessData = await partAllProcessDataQueryable
                    .FirstOrDefaultAsync(p => p.SerialNumber == partId);

                if (partAllProcessData == null)
                {
                    partAllProcessData = await partAllProcessDataQueryable
                        .FirstOrDefaultAsync(p =>
                            (p.ScanProcessData.LastOrDefault() != null) &&
                            (p.ScanProcessData.OrderBy(s => s.Id).Last().PlantCode + p.ScanProcessData.OrderBy(s => s.Id).Last().FFF + p.ScanProcessData.OrderBy(s => s.Id).Last().SerialNumberProduct == partId));

                    if (partAllProcessData == null)
                    {
                        return null;
                    }
                    else
                    {
                        return _mapper.Map<PartAllProcessDataDTO>(partAllProcessData);
                    }
                }
                else
                {
                    return _mapper.Map<PartAllProcessDataDTO>(partAllProcessData);
                }
            }
            else
            {
                return _mapper.Map<PartAllProcessDataDTO>(partAllProcessData);
            }
        }
    }
}
