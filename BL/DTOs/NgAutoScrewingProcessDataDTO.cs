namespace BL.DTOs
{
    public class NgAutoScrewingProcessDataDTO
    {
        public required int Id { get; set; }
        public required string SerialNumber { get; set; }
        public DateTime? DateTime { get; set; }
        public string? Message { get; set; }
        public required int PartId { get; set; }
    }
}
