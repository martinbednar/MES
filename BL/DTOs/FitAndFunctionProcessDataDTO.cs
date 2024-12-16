using DAL.Models;

namespace BL.DTOs
{
    public class FitAndFunctionProcessDataDTO
    {
        public required int Id { get; set; }
        public required string SerialNumber { get; set; }
        public DateTime? DateTimeStarted { get; set; }
        public bool? OK { get; set; }
        public bool? NOK { get; set; }
        public StatusEnum? OverallStatus { get; set; }
        public bool? leftOK { get; set; }
        public bool? leftNOK { get; set; }
        public StatusEnum? leftStatus { get; set; }
        public bool? rightOK { get; set; }
        public bool? rightNOK { get; set; }
        public StatusEnum? rightStatus { get; set; }
        public DateTime? DateTimeFinished { get; set; }
        public required int PartId { get; set; }
        public required List<FitAndFunctionMeasurementDTO> Measurements { get; set; }
    }
}
