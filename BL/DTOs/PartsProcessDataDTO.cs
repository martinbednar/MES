namespace BL.DTOs
{
    public class PartsProcessDataDTO
    {
        public required int PartsCount { get; set; }
        public required List<PartAllProcessDataDTO> PartsProcessData { get; set; }

    }
}
