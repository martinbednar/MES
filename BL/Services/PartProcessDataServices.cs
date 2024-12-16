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

        public async Task<List<PartAllProcessDataDTO>> GetPartsProcessData(int pageNumber, int pageSize, DateTime? startedFrom, DateTime? startedTo)
        {
            if (startedFrom == null)
            {
                startedFrom = DateTime.MinValue;
            }
            if (startedTo == null)
            {
                startedTo = DateTime.MaxValue;
            }

            List<PartAllProcessData> partsAllProcessData = await dbContext.PartAllProcessData
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
                )
                .Skip((pageNumber - 1) * pageSize).Take(pageSize)
                .ToListAsync();

            return _mapper.Map<List<PartAllProcessDataDTO>>(partsAllProcessData);
        }

        public async Task<PartAllProcessDataDTO?> GetPartProcessData(int partId)
        {
            PartAllProcessData? partAllProcessData = await dbContext.PartAllProcessData
                .Include(p => p.AutoScrewingProcessData)
                .Include(p => p.ConductivityProcessData)
                .Include(p => p.FitAndFunctionProcessData)
                    .ThenInclude(ff => ff.Measurements)
                .Include(p => p.ManualScrewingProcessData)
                .Include(p => p.NgAutoScrewingProcessData)
                .Include(p => p.PressingProcessData)
                .Include(p => p.PressingReworkProcessData)
                .Include(p => p.ScanProcessData)
                .FirstOrDefaultAsync(p => p.Id == partId);

            if (partAllProcessData == null)
            {
                return null;
            }
            else
            {
                return _mapper.Map<PartAllProcessDataDTO>(partAllProcessData);
            }
        }
    }
}
