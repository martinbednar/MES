using DAL.Models;

namespace BL.DTOs
{
    public class ConductivityProcessDataDTO
    {
        public required int Id { get; set; }
        public required string SerialNumber { get; set; }
        public DateTime? DateTimeStarted { get; set; }
        public float? Min { get; set; }
        public float? Value { get; set; }
        public float? Max { get; set; }
        public bool? OK { get; set; }
        public bool? NOK { get; set; }
        public StatusEnum? Status { get; set; }
        public DateTime? DateTimeFinished { get; set; }
        public required int PartId { get; set; }
    }
}
