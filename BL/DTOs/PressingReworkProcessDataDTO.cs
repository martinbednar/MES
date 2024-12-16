namespace BL.DTOs
{
    public class PressingReworkProcessDataDTO
    {
        public required int Id { get; set; }
        public required string SerialNumber { get; set; }
        public string? Message { get; set; }
        public bool? In1 { get; set; }
        public bool? In2 { get; set; }
        public bool? In3 { get; set; }
        public bool? Rework1 { get; set; }
        public bool? Rework2 { get; set; }
        public bool? Rework3 { get; set; }
        public DateTime? DateTime { get; set; }
        public required int PartId { get; set; }
    }
}
