namespace BL.DTOs
{
    public class PartAllProcessDataDTO
    {
        public required int Id { get; set; }
        public required string SerialNumber { get; set; }
        public required List<PressingProcessDataDTO> PressingProcessData { get; set; }
        public required List<PressingReworkProcessDataDTO> PressingReworkProcessData { get; set; }
        public required List<AutoScrewingProcessDataDTO> AutoScrewingProcessData { get; set; }
        public required List<NgAutoScrewingProcessDataDTO> NgAutoScrewingProcessData { get; set; }
        public required List<FitAndFunctionProcessDataDTO> FitAndFunctionProcessData { get; set; }
        public required List<ManualScrewingProcessDataDTO> ManualScrewingProcessData { get; set; }
        public required List<ConductivityProcessDataDTO> ConductivityProcessData { get; set; }
        public required List<ScanProcessDataDTO> ScanProcessData { get; set; }

    }
}
