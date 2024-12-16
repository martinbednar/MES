namespace DAL.Models
{
    public class FitAndFunctionProcessData
    {
        public int Id { get; set; }
        public required string SerialNumber { get; set; }
        public DateTime? DateTimeStarted { get; set; }
        public bool? OK { get; set; }
        public bool? NOK { get; set; }
        public StatusEnum? OverallStatus { get; set; }
        public bool? LeftOK { get; set; }
        public bool? LeftNOK { get; set; }
        public StatusEnum? LeftStatus { get; set; }
        public bool? RightOK { get; set; }
        public bool? RightNOK { get; set; }
        public StatusEnum? RightStatus { get; set; }
        public DateTime? DateTimeFinished { get; set; }
        public required int PartId { get; set; }
        public PartAllProcessData? Part { get; set; }
        public required ICollection<FitAndFunctionMeasurement> Measurements { get; set; }
    }
}
