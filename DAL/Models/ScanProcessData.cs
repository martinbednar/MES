namespace DAL.Models
{
    public class ScanProcessData
    {
        public int Id { get; set; }
        public required string SerialNumber { get; set; }
        public string? SerialNumberProduct { get; set; }
        public string? FFF { get; set; }
        public string? YY { get; set; }
        public string? PartIdent { get; set; }
        public string? PlantCode { get; set; }
        public string? CodeQuality { get; set; }
        public DateTime? DateTime { get; set; }
        public required int PartId { get; set; }
        public PartAllProcessData? Part { get; set; }
    }
}
