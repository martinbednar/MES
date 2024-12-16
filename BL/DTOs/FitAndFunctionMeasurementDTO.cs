using DAL.Models;

namespace BL.DTOs
{
    public class FitAndFunctionMeasurementDTO
    {
        public required int Id { get; set; }
        public float? Min { get; set; }
        public float? Value { get; set; }
        public float? Max { get; set; }
        public bool? OK { get; set; }
        public bool? NOK { get; set; }
        public StatusEnum? Status { get; set; }
        public required int FitAndFunctionId { get; set; }
    }
}
