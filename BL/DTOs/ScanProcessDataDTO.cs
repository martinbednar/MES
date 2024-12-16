namespace BL.DTOs
{
    public class ScanProcessDataDTO
    {
        public required int Id { get; set; }
        public required string SerialNumber { get; set; }
        public string? SerialNumberProduct { get; set; }
        public string? FFF { get; set; }
        public string? YY { get; set; }
        public string? PartIdent { get; set; }
        public string? PlanCode { get; set; }
        public string? CodeQuality { get; set; }
        public DateTime? DateTime { get; set; }
        public required int PartId { get; set; }
    }
}
