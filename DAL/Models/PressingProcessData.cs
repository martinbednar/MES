namespace DAL.Models
{
    public class PressingProcessData
    {
        public int Id { get; set; }
        public required string SerialNumber { get; set; }
        public int? HoleNumber { get; set; }
        public DateTime? DateTimeStarted { get; set; }
        public float? Force { get; set; }
        public float? Position { get; set; }
        public bool? OK { get; set; }
        public bool? NOK { get; set; }
        public StatusEnum? Status { get; set; }
        public DateTime? DateTimeFinished { get; set; }
        public required int PartId { get; set; }
        public PartAllProcessData? Part { get; set; }
    }
}
