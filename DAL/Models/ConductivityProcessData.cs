namespace DAL.Models
{
    public class ConductivityProcessData
    {
        public int Id { get; set; }
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
        public PartAllProcessData? Part { get; set; }
    }
}
