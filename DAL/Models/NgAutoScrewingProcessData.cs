namespace DAL.Models
{
    public class NgAutoScrewingProcessData
    {
        public int Id { get; set; }
        public required string SerialNumber { get; set; }
        public DateTime? DateTime { get; set; }
        public string? Message { get; set; }
        public required int PartId { get; set; }
        public PartAllProcessData? Part { get; set; }
    }
}
