using DAL.Data;
using DAL.Models;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace BL.Services
{
    internal class PartServices
    {
        MyDbContext dbContext = new MyDbContext();

        internal PartAllProcessData GetPart(string serialNumber)
        {
            PartAllProcessData? partAllProcessData = dbContext.PartAllProcessData.OrderBy(p => p.Id).LastOrDefault(p => p.SerialNumber == serialNumber);

            if (partAllProcessData == null)
            {
                EntityEntry<PartAllProcessData> newPartAllProcessData = dbContext.PartAllProcessData.Add(
                    new PartAllProcessData()
                    {
                        SerialNumber = serialNumber,
                        AutoScrewingProcessData = new List<AutoScrewingProcessData>(),
                        ConductivityProcessData = new List<ConductivityProcessData>(),
                        FitAndFunctionProcessData = new List<FitAndFunctionProcessData>(),
                        ManualScrewingProcessData = new List<ManualScrewingProcessData>(),
                        NgAutoScrewingProcessData = new List<NgAutoScrewingProcessData>(),
                        PressingProcessData = new List<PressingProcessData>(),
                        PressingReworkProcessData = new List<PressingReworkProcessData>(),
                        ScanProcessData = new List<ScanProcessData>()
                    }
                );
                dbContext.SaveChanges();
                return newPartAllProcessData.Entity;
            }
            else
            {
                return partAllProcessData;
            }
        }
    }
}
