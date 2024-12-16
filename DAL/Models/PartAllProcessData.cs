namespace DAL.Models
{
    public class PartAllProcessData
    {
        public int Id { get; set; }
        public required string SerialNumber { get; set; }
        public required ICollection<PressingProcessData> PressingProcessData { get; set; }
        public required ICollection<PressingReworkProcessData> PressingReworkProcessData { get; set; }
        public required ICollection<AutoScrewingProcessData> AutoScrewingProcessData { get; set; }
        public required ICollection<NgAutoScrewingProcessData> NgAutoScrewingProcessData { get; set; }
        public required ICollection<FitAndFunctionProcessData> FitAndFunctionProcessData { get; set; }
        public required ICollection<ManualScrewingProcessData> ManualScrewingProcessData { get; set; }
        public required ICollection<ConductivityProcessData> ConductivityProcessData { get; set; }
        public required ICollection<ScanProcessData> ScanProcessData { get; set; }
    }
}
